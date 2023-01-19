using System.Collections.ObjectModel;
using System.Windows;
using DataAccess;
using DataAccess.Data;
using DataAccess.Models;

namespace Resident
{
    
    public partial class MainWindow : Window
    {
        
        public ResidentData _residentData = new ResidentData();
        public ObservableCollection<string> Message { get; private set; }
                
        public MainWindow()
        {

            InitializeComponent();
                       
            
        }
        

        private void yesButton_Click(object sender, RoutedEventArgs e) 
        {
            string building = buildingBox.Text;
            string number = numberBox.Text;
            var id = _residentData.GetId(number, building);
            var pickup = new PendingPickUp { ResidentId = id };
            _residentData.SendPickUp(pickup);
            MessageBox.Show("Thank you. Your trash butler has been notified you have a pick up today.");
            
        }


        private void NoButton_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Thank you. Your trash butler has been notified you do not need their services today");
        }

        private void viewMessageButton_Click(object sender, RoutedEventArgs e)
        {
            string building = buildingBox.Text;
            string number = numberBox.Text;
            var id = _residentData.GetId(number, building);
            var message = _residentData.GetMessage(id);
            
            
            if (message != null) 
            {
                MessageTextBox.Text = "Your Trash was not picked up because it " + message;
            }

            if (message == null) 
            {
                MessageTextBox.Text = "You have no messages";
            }

        }

        private void clearMessageButton_Click(object sender, RoutedEventArgs e)
        {
            string building = buildingBox.Text;
            string number = numberBox.Text;
            var id = _residentData.GetId(number, building);
            MessageTextBox.Clear();
            _residentData.DeleteMessage(id);


        }
    }
}
