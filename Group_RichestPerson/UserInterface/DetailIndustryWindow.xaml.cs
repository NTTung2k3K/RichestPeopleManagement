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
using WinForms = System.Windows.Forms;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace UserInterface
{
	/// <summary>
	/// Interaction logic for DetailIndustryWindow.xaml
	/// </summary>
	public partial class DetailIndustryWindow : Window
	{
		private IndustryService _industryService = new IndustryService();

		public Industry selectedIndustry { get; set; } = null;
		public DetailIndustryWindow()
		{
			InitializeComponent();
		}

		public bool Validation()
		{
			if (string.IsNullOrWhiteSpace(IndustryNameTextBox.Text))
			{
				System.Windows.MessageBox.Show("You must input Name", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
				return false;
			}
			if (selectedIndustry == null)
			{
				var checkName = _industryService.GetAll().Where(x => x.IndustryName.ToLower() == IndustryNameTextBox.Text.ToLower()).FirstOrDefault();
				if (checkName != null)
				{
					System.Windows.MessageBox.Show("Industry Name is Existed", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
					return false;
				}
			}
            else
            {
                var id = int.Parse(IdValueLabel.Content.ToString());

                var industry = _industryService.GetById(id);
                if (IndustryNameTextBox.Text != industry.IndustryName)
                {
                    var checkNameUpdate = _industryService.GetAll().Where(x => x.IndustryName.ToLower() == IndustryNameTextBox.Text.ToLower()).FirstOrDefault();
                    if (checkNameUpdate != null)
                    {
                        MessageBox.Show("Industry Name is Existed", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                        return false;
                    }
                }
            }

            var tokenName = IndustryNameTextBox.Text.Split(" ");
            foreach (var item in tokenName)
            {
                if (char.IsLower(item[0]))
                {
                    MessageBox.Show("The starting letter of each word must be uppercase", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                    return false;
                }
            }
            string pattern = @"^[\p{L}\p{M} ]+$";

            if (!Regex.IsMatch(IndustryNameTextBox.Text, pattern))
            {
                MessageBox.Show("Industry Name is not allow for specific character or number", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
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
				var industry = new Industry()
				{
					IndustryName = IndustryNameTextBox.Text,
				};
				if (selectedIndustry == null)
				{
					 _industryService.Add(industry);
				}
				else
				{
					industry.IndustryId = int.Parse(IdValueLabel.Content.ToString());
					 _industryService.Update(industry);
				}
				DialogResult = true;
				this.Close();
			}
		}

		

		private void Window_Loaded(object sender, RoutedEventArgs e)
		{
			IdLabel.Visibility = Visibility.Collapsed;
			IdValueLabel.Visibility = Visibility.Collapsed;
			if (selectedIndustry != null)
			{
				IdLabel.Visibility = Visibility.Visible;
				IdValueLabel.Visibility = Visibility.Visible;
				TitileLabel.Content = "Update Industry";
				IdValueLabel.Content = selectedIndustry.IndustryId;
				IndustryNameTextBox.Text = selectedIndustry.IndustryName.ToString();
			}
		}
	}
}
