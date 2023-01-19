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
using DataAccess.Models;

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
        public List<int> Orders { get; private set; }
        string resident;
        string message;
        string building;
        string number;
     

        public MainWindow()
        {
            InitializeComponent();


            Binding();

            updateBinding();

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
        private void updateBinding() 
        {
            var orders = _valetData.GetOrders();
            Orders = new List<int>(orders);
            if (orders.Contains(1)) 
            {
                a1Box.Background = new SolidColorBrush(Colors.Green);
            }

            if (orders.Contains(2)) 
            {
                a2Box.Background = new SolidColorBrush(Colors.Green);
            }
            if (orders.Contains(3)) 
            {
                a3Box.Background = new SolidColorBrush(Colors.Green);
            }
            if (orders.Contains(4))
            {
                a4Box.Background = new SolidColorBrush(Colors.Green);
            }
            if (orders.Contains(5))
            {
                a5Box.Background = new SolidColorBrush(Colors.Green);
            }
            if (orders.Contains(6))
            {
                a6Box.Background = new SolidColorBrush(Colors.Green);
            }
            if (orders.Contains(7))
            {
                b1Box.Background = new SolidColorBrush(Colors.Green);
            }
            if (orders.Contains(8))
            {
                b2Box.Background = new SolidColorBrush(Colors.Green);
            }
            if (orders.Contains(9))
            {
                b3Box.Background = new SolidColorBrush(Colors.Green);
            }
            if (orders.Contains(10))
            {
                b4Box.Background = new SolidColorBrush(Colors.Green);
            }
            if (orders.Contains(11))
            {
                b5Box.Background = new SolidColorBrush(Colors.Green);
            }
            if (orders.Contains(12))
            {
                b6Box.Background = new SolidColorBrush(Colors.Green);
            }
            if (orders.Contains(13))
            {
                c1Box.Background = new SolidColorBrush(Colors.Green);
            }
            if (orders.Contains(14))
            {
                c2Box.Background = new SolidColorBrush(Colors.Green);
            }
            if (orders.Contains(15))
            {
                c3Box.Background = new SolidColorBrush(Colors.Green);
            }
            if (orders.Contains(16))
            {
                c4Box.Background = new SolidColorBrush(Colors.Green);
            }
            if (orders.Contains(17))
            {
                c5Box.Background = new SolidColorBrush(Colors.Green);
            }
            if (orders.Contains(18))
            {
                c6Box.Background = new SolidColorBrush(Colors.Green);
            }
            if (orders.Contains(19))
            {
                d1Box.Background = new SolidColorBrush(Colors.Green);
            }
            if (orders.Contains(20))
            {
                d2Box.Background = new SolidColorBrush(Colors.Green);
            }
            if (orders.Contains(21))
            {
                d3Box.Background = new SolidColorBrush(Colors.Green);
            }
            if (orders.Contains(22))
            {
                d4Box.Background = new SolidColorBrush(Colors.Green);
            }
            if (orders.Contains(23))
            {
                d5Box.Background = new SolidColorBrush(Colors.Green);
            }
            if (!orders.Contains(24))
            {
                d6Box.Background = new SolidColorBrush(Colors.Green);
            }
            if (!orders.Contains(1))
            {
                a1Box.Background = default;
            }

            if (!orders.Contains(2))
            {
                a2Box.Background = default;
            }
            if (!orders.Contains(3))
            {
                a3Box.Background = default;
            }
            if (!orders.Contains(4))
            {
                a4Box.Background = default;
            }
            if (!orders.Contains(5))
            {
                a5Box.Background = default;
            }
            if (!orders.Contains(6))
            {
                a6Box.Background = default;
            }
            if (orders.Contains(7))
            {
                b1Box.Background = default;
            }
            if (!orders.Contains(8))
            {
                b2Box.Background = default;
            }
            if (!orders.Contains(9))
            {
                b3Box.Background = default;
            }
            if (!orders.Contains(10))
            {
                b4Box.Background = default;
            }
            if (!orders.Contains(11))
            {
                b5Box.Background = default;
            }
            if (!orders.Contains(12))
            {
                b6Box.Background = default;
            }
            if (!orders.Contains(13))
            {
                c1Box.Background = default;
            }
            if (!orders.Contains(14))
            {
                c2Box.Background = default;
            }
            if (!orders.Contains(15))
            {
                c3Box.Background = default;
            }
            if (!orders.Contains(16))
            {
                c4Box.Background = default;
            }
            if (!orders.Contains(17))
            {
                c5Box.Background = default;
            }
            if (!orders.Contains(18))
            {
                c6Box.Background = default;
            }
            if (!orders.Contains(19))
            {
                d1Box.Background = default;
            }
            if (!orders.Contains(20))
            {
                d2Box.Background = default;
            }
            if (!orders.Contains(21))
            {
                d3Box.Background = default;
            }
            if (!orders.Contains(22))
            {
                d4Box.Background = default;
            }
            if (!orders.Contains(23))
            {
                d5Box.Background = default;
            }
            if (!orders.Contains(24))
            {
                d6Box.Background = default;
            }


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
                int id = _valetData.GetId(_residentData.GetId(number, building));
                var completed = new Completed { pickupID = id };
                _valetData.CompletePickUp(completed);
                _valetData.DeletePendingOrder(id);
                updateBinding();
               
            }
            if (noPickUpBox != null)
            {
                int resid = _residentData.GetId(number, building);
                int id = _valetData.GetId(resid);
                int mesid = _valetData.GetMessageId(message);
                var incomplete = new Incomplete { pickupID = id, messageID = mesid };
                _valetData.DeletePendingOrder(id);
                _valetData.SendMessage(incomplete);
                _valetData.SendMessageResident(mesid, resid, message);

                updateBinding();
               
            }

            submitButton.IsEnabled=false;
            yesButton.IsEnabled=false;
            NoButton.IsEnabled=false;
            noPickUpBox.SelectedItem = default;
            numberComboBox.SelectedItem = default;
            buildingComboBox.SelectedItem = default;
            
        }

    }
}
