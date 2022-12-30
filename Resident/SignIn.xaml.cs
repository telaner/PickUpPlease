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

namespace Resident
{
    /// <summary>
    /// Interaction logic for Window1.xaml
    /// </summary>
    public partial class Window1 : Window
    {
        public List<string> Builiding = new List<string> { "A", "B", "C", "D" };
        public List<string> Number = new List<string> {"1", "2", "3", "4", "5", "6"};
        public string resident;
        public Window1()
        {
            InitializeComponent();
            buldingCombobox.ItemsSource = Builiding;
            numberCombobox.ItemsSource = Number;
        }



        private void buldingCombobox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            string building = buldingCombobox.SelectedItem as string;
            if (buldingCombobox.SelectedItem != null) 
            {
                buildingText.Text = building;
            } 

        }

        private void numberCombobox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            string number = numberCombobox.SelectedItem as string;
            if (buldingCombobox.SelectedItem != null)
            {
                numberText.Text = number;
            }
            resident = buildingText.Text + number;
            
            if (buldingCombobox.SelectedItem != null || buldingCombobox.SelectedItem != null)
            {
                    signInButton.IsEnabled = true;
            }


        }
        

        

        private void signInButton_Click(object sender, RoutedEventArgs e)
        {
            
            MainWindow mainWindow = new MainWindow();
            mainWindow.Show();
            mainWindow.residentBox.Text = resident;
            this.Close();
        }

        
    }
}
