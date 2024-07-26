using Repository;
using Services;
using System;
using System.Linq;
using System.Windows;
using ClosedXML.Excel;
using PdfSharp.Drawing;
using PdfSharp.Pdf;

namespace UserInterface
{
	/// <summary>
	/// Interaction logic for MainWindow.xaml
	/// </summary>
	public partial class MainWindow : Window
	{
		RichestPersonService _richestPersonService = new RichestPersonService();
		IndustryService _industryService = new IndustryService();
		CountryService _countryService = new CountryService();

		public MainWindow()
		{
			InitializeComponent();
		}

		private void RichestPeopleButton_Click(object sender, RoutedEventArgs e)
		{
			RichestPersonWindow richestPersonWindow = new RichestPersonWindow();
			this.Hide();
			richestPersonWindow.Show();
		}

		private void Window_Loaded(object sender, RoutedEventArgs e)
		{
			var richestData = _richestPersonService.GetAll();
			var countryData = _countryService.GetAll();	
			var industryData = _industryService.GetAll();
			if (richestData.Count == 0 && countryData.Count == 0 && industryData.Count == 0)
			{
				DataHandler.LoadMainData();
			}
		}

		private void QuitButton_Click(object sender, RoutedEventArgs e)
		{
			var rs = MessageBox.Show("Do you want to quit?", "Quit?", MessageBoxButton.OKCancel, MessageBoxImage.Question);
			if (rs == MessageBoxResult.OK)
			{
				Application.Current.Shutdown();
			}
		}

		private void IndustryButton_Click(object sender, RoutedEventArgs e)
		{
			IndustryWindow industryWindow = new IndustryWindow();
			this.Hide();
			industryWindow.Show();
		}

		private void CountryButton_Click(object sender, RoutedEventArgs e)
		{
			CountryWindow countryWindow = new CountryWindow();
			this.Hide();
			countryWindow.Show();
		}

		private void Export_Click(object sender, RoutedEventArgs e)
		{
			ExportToExcel();
		}

		private void ExportToExcel()
		{
			try
			{
				using (var workbook = new XLWorkbook())
				{

					var richestPeopleSheet = workbook.Worksheets.Add("RichestPeople");
					var richestPeople = _richestPersonService.GetAll();
					richestPeopleSheet.Cell(1, 1).Value = "S. No.";
					richestPeopleSheet.Cell(1, 2).Value = "Rank";
					richestPeopleSheet.Cell(1, 3).Value = "Name";
					richestPeopleSheet.Cell(1, 4).Value = "Age";
					richestPeopleSheet.Cell(1, 5).Value = "Country";
					richestPeopleSheet.Cell(1, 6).Value = "Networth";
					richestPeopleSheet.Cell(1, 7).Value = "Industry";

					for (int i = 0; i < richestPeople.Count; i++)
					{
						richestPeopleSheet.Cell(i + 2, 1).Value = richestPeople[i].RichestPersonId;
						richestPeopleSheet.Cell(i + 2, 2).Value = richestPeople[i].Rank;
						richestPeopleSheet.Cell(i + 2, 3).Value = richestPeople[i].Name;
						richestPeopleSheet.Cell(i + 2, 4).Value = richestPeople[i].Age;
						richestPeopleSheet.Cell(i + 2, 5).Value = richestPeople[i].Country?.CountryName?.ToString() ?? "";
						var netWorth = richestPeople[i].NetWorth ?? 0;
						richestPeopleSheet.Cell(i + 2, 6).Value = $"${decimal.ToInt32(netWorth)}B";
						richestPeopleSheet.Cell(i + 2, 7).Value = richestPeople[i].Industry?.IndustryName?.ToString() ?? "";
					}

					var saveFileDialog = new Microsoft.Win32.SaveFileDialog
					{
						Filter = "Excel Workbook|*.xlsx",
						Title = "Save an Excel File",
						FileName = "Top_200_Richest_In_The_World"
					};

					if (saveFileDialog.ShowDialog() == true)
					{
						var filePath = saveFileDialog.FileName;
						workbook.SaveAs(filePath);
						MessageBox.Show($"Export successful! File saved at:\n{filePath}", "Success", MessageBoxButton.OK, MessageBoxImage.Information);
					}
				}
			}
			catch (Exception ex)
			{
				MessageBox.Show("An error occurred: " + ex.Message, "Error", MessageBoxButton.OK, MessageBoxImage.Error);
			}
		}

        private void Export1_Click(object sender, RoutedEventArgs e)
        {
            ExportToPdf();
        }

        private void ExportToPdf()
        {
            try
            {
                var richestPeople = _richestPersonService.GetAll();
                var document = new PdfDocument();
                var font = new XFont("Verdana", 12, XFontStyle.Regular);
                var headerFont = new XFont("Verdana", 14, XFontStyle.Bold);

                int itemsPerPage = 39;
                int pageCount = (richestPeople.Count + itemsPerPage - 1) / itemsPerPage;

                for (int page = 0; page < pageCount; page++)
                {
                    var pdfPage = document.AddPage();
                    var gfx = XGraphics.FromPdfPage(pdfPage);

                    gfx.DrawString("Top 200 Richest People in the World", headerFont, XBrushes.Black,
                        new XRect(0, 0, pdfPage.Width, pdfPage.Height),
                        XStringFormats.TopCenter);

                    int yPoint = 40;
                    gfx.DrawString(" S. No. | Rank | Name | Age | Country | Networth | Industry", font, XBrushes.Black,
                        new XRect(0, yPoint, pdfPage.Width, pdfPage.Height),
                        XStringFormats.TopLeft);
                    yPoint += 20;

                    for (int i = 0; i < itemsPerPage; i++)
                    {
                        int index = page * itemsPerPage + i;
                        if (index >= richestPeople.Count)
                            break;

                        gfx.DrawString($" {index + 1} | {richestPeople[index].Rank} | {richestPeople[index].Name} | {richestPeople[index].Age} | {richestPeople[index].Country?.CountryName ?? ""} | ${decimal.ToInt32(richestPeople[index].NetWorth ?? 0)}B | {richestPeople[index].Industry?.IndustryName ?? ""}",
                            font, XBrushes.Black,
                            new XRect(0, yPoint, pdfPage.Width, pdfPage.Height),
                            XStringFormats.TopLeft);
                        yPoint += 20;
                    }
                }

                var saveFileDialog = new Microsoft.Win32.SaveFileDialog
                {
                    Filter = "PDF Document|*.pdf",
                    Title = "Save a PDF File",
                    FileName = "Top_200_Richest_In_The_World"
                };

                if (saveFileDialog.ShowDialog() == true)
                {
                    var filePath = saveFileDialog.FileName;
                    document.Save(filePath);
                    MessageBox.Show($"Export successful! File saved at:\n{filePath}", "Success", MessageBoxButton.OK, MessageBoxImage.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("An error occurred: " + ex.Message, "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

    }
}
