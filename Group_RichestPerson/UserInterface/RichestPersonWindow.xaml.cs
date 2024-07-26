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
    /// Interaction logic for RichestPersonWindow.xaml
    /// </summary>
    public partial class RichestPersonWindow : Window
    {
        RichestPersonService _richestPersonService = new RichestPersonService();
        public RichestPersonWindow()
        {
            InitializeComponent();
        }

        private void QuitButton_Click(object sender, RoutedEventArgs e)
        {
            var rs = MessageBox.Show("Do you want to quit?", "Quit?", MessageBoxButton.OKCancel, MessageBoxImage.Question);
            if(rs == MessageBoxResult.OK)
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

        private void LoadDataRichestPeople()
        {
            RichestPeopleDataGrid.ItemsSource = null;
            RichestPeopleDataGrid.ItemsSource = _richestPersonService.GetAll();
        }

        private void CreateButton_Click(object sender, RoutedEventArgs e)
        {
            DetailRichestPersonWindow detailRichestPersonWindow = new DetailRichestPersonWindow();
            detailRichestPersonWindow.ShowDialog();
            if (detailRichestPersonWindow.DialogResult == true)
            {
                LoadDataRichestPeople();
            }
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            LoadDataRichestPeople();

            ChinaRiadio.Tag = "China";
            UnitedStatesRadio.Tag = "United States";
            TechnologyRiadio.Tag = "Technology";
            FashionAndRetailRadio.Tag = "Fashion & Retail";
        }

        private void DeleteButton_Click(object sender, RoutedEventArgs e)
        {
            var selectedRichestPerson = RichestPeopleDataGrid.SelectedItem as RichestPerson;
            if (selectedRichestPerson == null)
            {
                MessageBox.Show("Please select Richest Person to delete", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }
            var confirm = MessageBox.Show("Do you want to delete?","Delete",MessageBoxButton.OKCancel, MessageBoxImage.Question);
            if(confirm == MessageBoxResult.OK)
            {
                _richestPersonService.Delete(selectedRichestPerson);
                LoadDataRichestPeople();
            }
           
        }

        private void UpdateButton_Click(object sender, RoutedEventArgs e)
        {
            var selectedRichestPerson = RichestPeopleDataGrid.SelectedItem as RichestPerson;
            if (selectedRichestPerson == null)
            {
                MessageBox.Show("Please select Richest Person to update", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }
            DetailRichestPersonWindow detailRichestPersonWindow = new DetailRichestPersonWindow();
            detailRichestPersonWindow.selectedRichest = selectedRichestPerson;
            detailRichestPersonWindow.ShowDialog();
            if (detailRichestPersonWindow.DialogResult == true)
            {
                LoadDataRichestPeople();
            }
        }

        private void SearchButton_Click(object sender, RoutedEventArgs e)
        {
            string tag = null;
            if (ChinaRiadio.IsChecked.GetValueOrDefault())
            {
                tag = ChinaRiadio.Tag.ToString();
            }
            if (UnitedStatesRadio.IsChecked.GetValueOrDefault())
            {
                tag = UnitedStatesRadio.Tag.ToString();
            }
            if (TechnologyRiadio.IsChecked.GetValueOrDefault())
            {
                tag = TechnologyRiadio.Tag.ToString();
            }
            if (FashionAndRetailRadio.IsChecked.GetValueOrDefault())
            {
                tag = FashionAndRetailRadio.Tag.ToString();
            }


            if (string.IsNullOrWhiteSpace(NameTextBox.Text.Trim()) && string.IsNullOrWhiteSpace(RankTextBox.Text.Trim()) && string.IsNullOrEmpty(tag))
            {
                MessageBox.Show("Please input value to search", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }
            int rank = -1;

            if (!string.IsNullOrWhiteSpace(RankTextBox.Text.Trim()))
            {
                if (!int.TryParse(RankTextBox.Text, out rank))
                {
                    MessageBox.Show("Rank must be a number", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                    return;
                }
            }
            var result = _richestPersonService.Search(NameTextBox.Text, rank, tag);
            RichestPeopleDataGrid.ItemsSource = null;
            RichestPeopleDataGrid.ItemsSource = result;
        }

        private void ResetButton_Click(object sender, RoutedEventArgs e)
        {
            LoadDataRichestPeople();
            RankTextBox.Text = "";
            NameTextBox.Text = "";
            ChinaRiadio.IsChecked = false;
            UnitedStatesRadio.IsChecked = false ;
            TechnologyRiadio.IsChecked = false;
            FashionAndRetailRadio.IsChecked = false;
        }
    }
}
