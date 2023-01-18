using System.Collections.ObjectModel;
using System.Windows;
using DataAccess;
using DataAccess.Data;
using DataAccess.Models;

namespace Resident
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        
        public ResidentData _residentData = new ResidentData();
        public ObservableCollection<string> Message { get; private set; }
        public string building;
        public string number;
        public int id;
        public MainWindow()
        {
            InitializeComponent();
            Binding();
            
        }
        private void Binding() 
        {
            id = _residentData.GetId(number, building);

            var message = _residentData.GetMessage(int.Parse(id.ToString()));

            Message = new ObservableCollection<string>(message);
            MessageTextBox.Text = Message.ToString();
        }

        private void yesButton_Click(object sender, RoutedEventArgs e) 
        {
            id = _residentData.GetId(number, building);
            var pickup = new PendingPickUp { ResidentId = id };
            _residentData.SendPickUp(pickup);
            MessageBox.Show("Thank you. Your trash butler has been notified you have a pick up today.");
            
        }


        private void NoButton_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Thank you. Your trash butler has been notified you do not need their services today");
        }
    }
}
