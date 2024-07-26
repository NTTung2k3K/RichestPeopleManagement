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
    /// Interaction logic for DetailCountryWindow.xaml
    /// </summary>
    public partial class DetailCountryWindow : Window
    {
        private CountryService _countryService = new CountryService();

        public Country selectedCountry { get; set; } = null;
        public DetailCountryWindow()
        {
            InitializeComponent();
        }

        public bool Validation()
        {
            if (string.IsNullOrWhiteSpace(CountryNameTextBox.Text))
            {
                System.Windows.MessageBox.Show("You must input Name", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                return false;
            }
            if (selectedCountry == null)
            {
                var checkName = _countryService.GetAll().Where(x => x.CountryName.ToLower() == CountryNameTextBox.Text.ToLower()).FirstOrDefault();
                if (checkName != null)
                {
                    System.Windows.MessageBox.Show("Country Name is Existed", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                    return false;
                }
            }
            else
            {
                var id = int.Parse(IdValueLabel.Content.ToString());

                var industry = _countryService.GetById(id);
                if (CountryNameTextBox.Text != industry.CountryName)
                {
                    var checkNameUpdate = _countryService.GetAll().Where(x => x.CountryName.ToLower() == CountryNameTextBox.Text.ToLower()).FirstOrDefault();
                    if (checkNameUpdate != null)
                    {
                        MessageBox.Show("Country Name is Existed", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                        return false;
                    }
                }
            }

            var tokenName = CountryNameTextBox.Text.Split(" ");
            foreach (var item in tokenName)
            {
                if (char.IsLower(item[0]))
                {
                    MessageBox.Show("The starting letter of each word must be uppercase", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                    return false;
                }
            }
            string pattern = @"^[\p{L}\p{M} ]+$";

            if (!Regex.IsMatch(CountryNameTextBox.Text, pattern))
            {
                MessageBox.Show("Country Name is not allow for specific character or number", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
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
                var country = new Country()
                {
                    CountryName = CountryNameTextBox.Text,
                };
                if (selectedCountry == null)
                {
                    _countryService.Add(country);
                }
                else
                {
                    country.CountryId = int.Parse(IdValueLabel.Content.ToString());
                    _countryService.Update(country);
                }
                DialogResult = true;
                this.Close();
            }
        }

       
        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            IdLabel.Visibility = Visibility.Collapsed;
            IdValueLabel.Visibility = Visibility.Collapsed;
            if (selectedCountry != null)
            {
                IdLabel.Visibility = Visibility.Visible;
                IdValueLabel.Visibility = Visibility.Visible;
                TitileLabel.Content = "Update Country";
                IdValueLabel.Content = selectedCountry.CountryId;
                CountryNameTextBox.Text = selectedCountry.CountryName.ToString();
            }
        }
    }
}
