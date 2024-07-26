using Repository.Models;
using Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
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
    /// Interaction logic for CountryWindow.xaml
    /// </summary>
    public partial class CountryWindow : Window
    {
        CountryService _countryService = new CountryService();

        public CountryWindow()
        {
            InitializeComponent();
        }

        private void QuitButton_Click(object sender, RoutedEventArgs e)
        {
            var rs = MessageBox.Show("Do you want to quit?", "Quit?", MessageBoxButton.OKCancel, MessageBoxImage.Question);
            if (rs == MessageBoxResult.OK)
            {
                Application.Current.Shutdown();
            }
        }

        private void BackButton_Click(object sender, RoutedEventArgs e)
        {
            this.Hide();
            MainWindow mainWindow = new MainWindow();
            mainWindow.Show();
        }

        private void LoadDataCountry()
        {
            CountryDataGrid.ItemsSource = null;
            CountryDataGrid.ItemsSource = _countryService.GetAll();
        }

        private void CreateButton_Click(object sender, RoutedEventArgs e)
        {
            DetailCountryWindow detailCountryWindow = new DetailCountryWindow();
            detailCountryWindow.ShowDialog();
            if (detailCountryWindow.DialogResult == true)
            {
                LoadDataCountry();
            }
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            LoadDataCountry();
        }

        private void DeleteButton_Click(object sender, RoutedEventArgs e)
        {
            var selectedCountry = CountryDataGrid.SelectedItem as Country;
            if (selectedCountry == null)
            {
                MessageBox.Show("Please select Country to delete", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }
            var confirm = MessageBox.Show("Do you want to delete?", "Delete", MessageBoxButton.OKCancel, MessageBoxImage.Question);
            if (confirm == MessageBoxResult.OK)
            {
                _countryService.Delete(selectedCountry);
                LoadDataCountry();
            }
        }

        private void UpdateButton_Click(object sender, RoutedEventArgs e)
        {
            var selectedCountry = CountryDataGrid.SelectedItem as Country;
            if (selectedCountry == null)
            {
                MessageBox.Show("Please select Country to update", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }
            DetailCountryWindow detailCountryWindow = new DetailCountryWindow();
            detailCountryWindow.selectedCountry = selectedCountry;
            detailCountryWindow.ShowDialog();
            if (detailCountryWindow.DialogResult == true)
            {
                LoadDataCountry();
            }
        }

        private void SearchButton_Click(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(CountryNameTextBox.Text.Trim()))
            {
                MessageBox.Show("Please input value to search", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }
            var result = _countryService.Search(CountryNameTextBox.Text);
            CountryDataGrid.ItemsSource = null;
            CountryDataGrid.ItemsSource = result;
        }

        private void ResetButton_Click(object sender, RoutedEventArgs e)
        {
            CountryNameTextBox.Text = "";
            LoadDataCountry();
        }
    }
}
