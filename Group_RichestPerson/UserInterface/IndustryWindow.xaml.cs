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
    /// Interaction logic for IndustryWindow.xaml
    /// </summary>
    public partial class IndustryWindow : Window
    {
        IndustryService _industryService = new IndustryService();

        public IndustryWindow()
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

		private void LoadDataIndustry()
		{
			IndustryDataGrid.ItemsSource = null;
			IndustryDataGrid.ItemsSource = _industryService.GetAll();
		}

		private void CreateButton_Click(object sender, RoutedEventArgs e)
		{
			DetailIndustryWindow detailIndustryWindow = new DetailIndustryWindow();
			detailIndustryWindow.ShowDialog();
			if (detailIndustryWindow.DialogResult == true)
			{
				LoadDataIndustry();
			}
		}

		private void Window_Loaded(object sender, RoutedEventArgs e)
		{
			LoadDataIndustry();
		}

		private void DeleteButton_Click(object sender, RoutedEventArgs e)
		{
			var selectedIndustry = IndustryDataGrid.SelectedItem as Industry;
			if (selectedIndustry == null)
			{
				MessageBox.Show("Please select Industry to delete", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
				return;
			}
            var confirm = MessageBox.Show("Do you want to delete?", "Delete", MessageBoxButton.OKCancel, MessageBoxImage.Question);
            if (confirm == MessageBoxResult.OK)
            {
                _industryService.Delete(selectedIndustry);
                LoadDataIndustry();
            }
		}

		private void UpdateButton_Click(object sender, RoutedEventArgs e)
		{
			var selectedIndustry = IndustryDataGrid.SelectedItem as Industry;
			if (selectedIndustry == null)
			{
				MessageBox.Show("Please select Industry to update", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
				return;
			}
			DetailIndustryWindow detailIndustryWindow = new DetailIndustryWindow();
			detailIndustryWindow.selectedIndustry = selectedIndustry;
			detailIndustryWindow.ShowDialog();
			if (detailIndustryWindow.DialogResult == true)
			{
				LoadDataIndustry();
			}
		}

		private void SearchButton_Click(object sender, RoutedEventArgs e)
		{
			if (string.IsNullOrWhiteSpace(IndustryNameTextBox.Text.Trim()))
			{
				MessageBox.Show("Please input value to search", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
				return;
			}
			var result = _industryService.Search(IndustryNameTextBox.Text);
			IndustryDataGrid.ItemsSource = null;
			IndustryDataGrid.ItemsSource = result;
		}

		private void ResetButton_Click(object sender, RoutedEventArgs e)
		{
			IndustryNameTextBox.Text = "";
			LoadDataIndustry();
		}
	}
}
