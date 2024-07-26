using Repository.Models;
using Services;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace UserInterface
{
    /// <summary>
    /// Interaction logic for DetailRichestPersonWindow.xaml
    /// </summary>
    public partial class DetailRichestPersonWindow : Window
    {

        private IndustryService _industryService = new IndustryService();
        private CountryService _countryService = new CountryService();
        private RichestPersonService _richestPersonService = new RichestPersonService();

        public RichestPerson selectedRichest { get; set; } = null;
        public DetailRichestPersonWindow()
        {
            InitializeComponent();
        }


        public bool Validation()
        {

            if (string.IsNullOrWhiteSpace(NameTextBox.Text))
            {
                MessageBox.Show("You must input Name", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                return false;
            }
            if (!(NameTextBox.Text.Length >= 4 && NameTextBox.Text.Length <= 20))
            {
                MessageBox.Show("Name has valid length from 4 to 20 chars", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                return false;
            }
            if (selectedRichest == null)
            {
                var checkName = _richestPersonService.GetAll().Where(x => x.Name.ToLower() == NameTextBox.Text.ToLower()).FirstOrDefault();
                if (checkName != null)
                {
                    MessageBox.Show("Name is Existed", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                    return false;
                }
            }
            else
            {
                var id = int.Parse(IdValueLabel.Content.ToString());

                var riches = _richestPersonService.GetById(id);
                if(NameTextBox.Text != riches.Name)
                {
                    var checkNameUpdate = _richestPersonService.GetAll().Where(x => x.Name.ToLower() == NameTextBox.Text.ToLower()).FirstOrDefault();
                    if (checkNameUpdate != null)
                    {
                        MessageBox.Show("Name is Existed", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                        return false;
                    }
                }
            }

            var tokenName = NameTextBox.Text.Split(" ");
            foreach (var item in tokenName)
            {
                if (char.IsLower(item[0]))
                {
                    MessageBox.Show("The starting letter of each word must be uppercase", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                    return false;
                }
            }
            string pattern = @"^[\p{L}\p{M} ]+$"; 

            if (!Regex.IsMatch(NameTextBox.Text, pattern))
            {
                MessageBox.Show("Name is not allow for specific character or number", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                return false;
            }

                if (string.IsNullOrWhiteSpace(AgeTextBox.Text))
            {
                MessageBox.Show("You must input Age", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                return false;
            }
            int age = -1;
            if (!int.TryParse(AgeTextBox.Text, out age))
            {
                MessageBox.Show("Age must be a number", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                return false;
            }
            if (!(age >= 18 && age <= 130))
            {
                MessageBox.Show("Age must be in range 18-130", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                return false;
            }
            if (string.IsNullOrWhiteSpace(NetWorthTextBox.Text))
            {
                MessageBox.Show("You must input NetWorth", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                return false;
            }
            double networth = -1;
            if (NetWorthTextBox.Text.Contains(","))
            {
                MessageBox.Show("NetWorth must be a number with a dot (.) as the decimal separator.", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                return false;
            }
            if (!double.TryParse(NetWorthTextBox.Text, NumberStyles.Any, CultureInfo.InvariantCulture, out networth))
            {
                MessageBox.Show("NetWorth must be a number with a dot (.) as the decimal separator.", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                return false;
            }
            if (!(networth >= 0))
            {
                MessageBox.Show("NetWorth must be greater than 0", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                return false;
            }


            if (CountryCombobox.SelectedItem == null)
            {
                MessageBox.Show("You must select Country", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                return false;
            }
            if (IndustryCombobox.SelectedItem == null)
            {
                MessageBox.Show("You must select Industry", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                return false;
            }
            return true;
        }

        private void CloseButton_Click(object sender, RoutedEventArgs e)
        {
            DialogResult = true;
            this.Close();
        }

        private void SaveButton_Click(object sender, RoutedEventArgs e)
        {
            if (Validation())
            {
                var richestPerson = new RichestPerson()
                {
                    Age = int.Parse(AgeTextBox.Text),
                    Name = NameTextBox.Text,
                    NetWorth = decimal.Parse(NetWorthTextBox.Text),
                    CountryId = int.Parse(CountryCombobox.SelectedValue.ToString()),
                    IndustryId = int.Parse(IndustryCombobox.SelectedValue.ToString()),
                };
                if (selectedRichest == null)
                {
                    _richestPersonService.Add(richestPerson);
                }
                else
                {
                    richestPerson.RichestPersonId = int.Parse(IdValueLabel.Content.ToString());
                    richestPerson.Rank = int.Parse(RankValueLabel.Content.ToString());
                    _richestPersonService.Update(richestPerson);
                }
                DialogResult = true;
                this.Close();
            }
        }
        public static decimal ExtractNumericValue(string text)
        {
            string numericString = Regex.Replace(text, @"[^\d.]", "");

            if (decimal.TryParse(numericString, NumberStyles.Any, CultureInfo.InvariantCulture, out decimal result))
            {
                return result;
            }

            throw new FormatException("The input string does not contain a valid numeric value.");
        }
        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            CountryCombobox.ItemsSource = _countryService.GetAll();
            CountryCombobox.DisplayMemberPath = "CountryName";
            CountryCombobox.SelectedValuePath = "CountryId";

            IndustryCombobox.ItemsSource = _industryService.GetAll();
            IndustryCombobox.DisplayMemberPath = "IndustryName";
            IndustryCombobox.SelectedValuePath = "IndustryId";

            IdLabel.Visibility = Visibility.Collapsed;
            IdValueLabel.Visibility = Visibility.Collapsed;
            RankLabel.Visibility = Visibility.Collapsed;
            RankValueLabel.Visibility = Visibility.Collapsed;
            if (selectedRichest != null)
            {
                IdLabel.Visibility = Visibility.Visible;
                IdValueLabel.Visibility = Visibility.Visible;
                RankLabel.Visibility = Visibility.Visible;
                RankValueLabel.Visibility = Visibility.Visible;
                RankValueLabel.Content = selectedRichest.Rank;
                TitileLabel.Content = "Update Richest Person";
                IdValueLabel.Content = selectedRichest.RichestPersonId;
                NameTextBox.Text = selectedRichest.Name.ToString();
                AgeTextBox.Text = selectedRichest.Age.ToString();
                NetWorthTextBox.Text = ExtractNumericValue(selectedRichest.NetWorth.ToString()).ToString();
                CountryCombobox.SelectedValue = selectedRichest.CountryId;
                IndustryCombobox.SelectedValue = selectedRichest.IndustryId;
            }

        }
    }
}
