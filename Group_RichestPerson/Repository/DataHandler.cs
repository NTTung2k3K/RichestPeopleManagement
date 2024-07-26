using Microsoft.VisualBasic.FileIO;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository
{
    public static class DataHandler
    {

        public static void LoadMainData()
        {
            string filePath = "Top 200 Richest Person in the World.csv"; // Update this to your CSV file path
            var csvData = ReadCSV(filePath);

            // Define your SQL connection string
            string connectionString = "Server=LAPTOP-5TIM7V26\\THANGLAM2710;uid=sa;pwd=1234567890;database= BTN_TopWordRichest;TrustServerCertificate=True;"; // Update this to your SQL connection string

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();

                foreach (var row in csvData)
                {
                    try
                    {
                        // Debugging output to verify row structure
                        Console.WriteLine($"Processing row: {string.Join(",", row)}");

                        // Assuming CSV columns: S. No., Rank, Name, Age, Country, Networth, Industry
                        int rank = int.Parse(row[1]);  // index 1
                        string name = row[2];          // index 2
                        int age = int.Parse(row[3]);   // index 3
                        string countryName = row[4];   // index 4
                        string networth = row[5];      // index 5
                        string industryName = row[6];  // index 6

                        // Check if the person already exists
                        if (PersonExists(rank, name, conn))
                        {
                            Console.WriteLine($"Skipping existing person: {name}");
                            continue;
                        }

                        // Get or insert Country
                        int countryId = GetOrInsertCountry(countryName, conn);

                        // Get or insert Industry
                        int industryId = GetOrInsertIndustry(industryName, conn);

                        // Insert into RichestPerson table
                        string insertPersonQuery = "INSERT INTO RichestPerson (Rank, Name, Age, Networth, CountryID, IndustryID) VALUES (@Rank, @Name, @Age, @Networth, @CountryID, @IndustryID)";
                        using (SqlCommand cmd = new SqlCommand(insertPersonQuery, conn))
                        {
                            cmd.Parameters.AddWithValue("@Rank", rank);
                            cmd.Parameters.AddWithValue("@Name", name);
                            cmd.Parameters.AddWithValue("@Age", age);
                            cmd.Parameters.AddWithValue("@Networth", ParseNetworth(networth));
                            cmd.Parameters.AddWithValue("@CountryID", countryId);
                            cmd.Parameters.AddWithValue("@IndustryID", industryId);
                            cmd.ExecuteNonQuery();
                        }
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine($"Error processing row: {string.Join(",", row)}");
                        Console.WriteLine($"Error: {ex.Message}");
                    }
                }
            }
        }

        public static List<string[]> ReadCSV(string filePath)
        {
            var rows = new List<string[]>();

            using (TextFieldParser parser = new TextFieldParser(filePath))
            {
                parser.TextFieldType = FieldType.Delimited;
                parser.SetDelimiters(",");

                // Skip the header row
                if (!parser.EndOfData)
                {
                    parser.ReadLine();
                }

                // Read through the file
                while (!parser.EndOfData)
                {
                    // Processing row
                    string[] fields = parser.ReadFields();
                    rows.Add(fields);
                }
            }

            return rows;
        }

        public static int GetOrInsertCountry(string countryName, SqlConnection conn)
        {
            string selectQuery = "SELECT CountryID FROM Country WHERE CountryName = @CountryName";
            using (SqlCommand cmd = new SqlCommand(selectQuery, conn))
            {
                cmd.Parameters.AddWithValue("@CountryName", countryName);
                object result = cmd.ExecuteScalar();
                if (result != null)
                {
                    return (int)result;
                }
            }

            string insertQuery = "INSERT INTO Country (CountryName) OUTPUT INSERTED.CountryID VALUES (@CountryName)";
            using (SqlCommand cmd = new SqlCommand(insertQuery, conn))
            {
                cmd.Parameters.AddWithValue("@CountryName", countryName);
                return (int)cmd.ExecuteScalar();
            }
        }

        public static int GetOrInsertIndustry(string industryName, SqlConnection conn)
        {
            string selectQuery = "SELECT IndustryID FROM Industry WHERE IndustryName = @IndustryName";
            using (SqlCommand cmd = new SqlCommand(selectQuery, conn))
            {
                cmd.Parameters.AddWithValue("@IndustryName", industryName);
                object result = cmd.ExecuteScalar();
                if (result != null)
                {
                    return (int)result;
                }
            }

            string insertQuery = "INSERT INTO Industry (IndustryName) OUTPUT INSERTED.IndustryID VALUES (@IndustryName)";
            using (SqlCommand cmd = new SqlCommand(insertQuery, conn))
            {
                cmd.Parameters.AddWithValue("@IndustryName", industryName);
                return (int)cmd.ExecuteScalar();
            }
        }

        public static bool PersonExists(int rank, string name, SqlConnection conn)
        {
            string selectQuery = "SELECT COUNT(1) FROM RichestPerson WHERE Name = @Name";
            using (SqlCommand cmd = new SqlCommand(selectQuery, conn))
            {
                cmd.Parameters.AddWithValue("@Name", name);
                int count = (int)cmd.ExecuteScalar();
                return count > 0;
            }
        }

        public static decimal ParseNetworth(string networth)
        {
            if (networth.StartsWith("$") && networth.EndsWith("B"))
            {
                // Remove '$' and 'B', then parse to decimal
                string numericValue = networth.Replace("$", "").Replace("B", "");
                if (decimal.TryParse(numericValue, out decimal result))
                {
                    return result;
                }
            }
            throw new FormatException("Invalid net worth format.");
        }

    }
}
