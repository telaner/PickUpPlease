using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data;
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
using DataAccess;
using DataAccess.Data;

namespace Resident
{
    /// <summary>
    /// Interaction logic for Window1.xaml
    /// </summary>
    public partial class Window1 : Window
    {
        
        public ResidentData _residentData = new ResidentData();
        public ObservableCollection<string> Building { get; private set; }
        public ObservableCollection<string> Number { get; private set; }
        public string resident;
        public string building;
        public string number;
        public Window1()
        {
            InitializeComponent();

            Binding();
        }

        private void Binding() 
        {
            var building = _residentData.GetBuilding();
            Building = new ObservableCollection<string>(building);
            buildingCombobox.ItemsSource=Building;

            var number = _residentData.GetHouseNumber();
            Number = new ObservableCollection<string>(number);
            numberCombobox.ItemsSource = Number;
        }



        private void buldingCombobox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            building = buildingCombobox.SelectedItem as string;
            if (buildingCombobox.SelectedItem != null) 
            {
                buildingText.Text = building;
            } 

        }

        private void numberCombobox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            number = numberCombobox.SelectedItem as string;
            if (buildingCombobox.SelectedItem != null)
            {
                numberText.Text = number;
            }
            resident = building + number;
            
            if (buildingCombobox.SelectedItem != null || numberCombobox.SelectedItem != null)
            {
                    signInButton.IsEnabled = true;
            }

        }
        
        

        

        private void signInButton_Click(object sender, RoutedEventArgs e)
        {
            
            MainWindow mainWindow = new MainWindow();
            mainWindow.Show();
            mainWindow.buildingBox.Text = building;
            mainWindow.numberBox.Text = number;
            this.Close();
        }

        
    }
}
