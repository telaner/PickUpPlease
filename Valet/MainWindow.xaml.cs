using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
using System.Windows.Navigation;
using System.Windows.Shapes;
using DataAccess;
using DataAccess.Data;

namespace Valet
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        
        public ResidentData _residentData = new ResidentData();
        public ValetData _valetData = new ValetData();
        public ObservableCollection<string> Building { get;private set; }
        public ObservableCollection<string> Number { get; private set; }
        public ObservableCollection<string> Message { get; private set; }
        string resident;
        string message;
        string building;
        string number;
     

        public MainWindow()
        {
            InitializeComponent();


            Binding();

        }

        private void Binding()
        {
            var building = _residentData.GetBuilding();
            Building = new ObservableCollection<string>(building);
            buildingComboBox.ItemsSource = Building;

            var number = _residentData.GetHouseNumber();
            Number = new ObservableCollection<string>(number);
            numberComboBox.ItemsSource = Number;

            var message = _valetData.GetMessage();
            Message = new ObservableCollection<string>(message);
            noPickUpBox.ItemsSource= Message;
        }


        private void buildingComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            building = buildingComboBox.SelectedItem as string;
            if (buildingComboBox.SelectedItem != null)
            {
                resident = building + number;
            }
            residentBox.Text = resident;

        }

        private void numberComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            number = numberComboBox.SelectedItem as string;
            if (numberComboBox.SelectedItem != null)
            {
                resident = building + number;
            }
            residentBox.Text = resident;
            if (buildingComboBox.SelectedItem != null && number != null) 
            {
                yesButton.IsEnabled = true;
                NoButton.IsEnabled = true;
            }
        }

        private void yesButton_Click(object sender, RoutedEventArgs e)
        {
            var id = _residentData.GetId(number, building);
            var pickupid = _valetData.GetId(int.Parse(id.ToString()));
            
            submitButton.IsEnabled = true;
        }

        private void NoButton_Click(object sender, RoutedEventArgs e)
        {
            noPickUpBox.IsEnabled = true;
        }
        private void noPickUpBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            message = noPickUpBox.SelectedItem as string;
            if (noPickUpBox.SelectedItem != null) 
            {
                submitButton.IsEnabled=true;
            }

        }

        private void submitButton_Click(object sender, RoutedEventArgs e)
        {
            if (noPickUpBox == null) 
            {
               
            }
            if (noPickUpBox != null)
            {
               
            }
            
        }

    }
}
