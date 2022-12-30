using System.Windows;

namespace Resident
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
                
        public MainWindow()
        {
            InitializeComponent();
            
        }

        private void yesButton_Click(object sender, RoutedEventArgs e) 
        {
            MessageBox.Show("Thank you. Your trash butler has been notified you have a pick up today.");
        }


        private void NoButton_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Thank you. Your trash butler has been notified you do not need their services today");
        }
    }
}
