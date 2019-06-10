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

namespace ClientSide
{
    /// <summary>
    /// Interaction logic for MyStatusWindow.xaml
    /// </summary>
    public partial class MyStatusWindow : Window
    {
        // C'tor
        public MyStatusWindow(string name)
        {
            InitializeComponent();
            this.UsernameLabel.Content = name;
        }

        /// <summary>
        /// the user click in the back button
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BackButton_Click(object sender, RoutedEventArgs e)
        {
            //the func close the curr window and open the main window
            MainWindow mainWindow = new MainWindow();
            this.Close();
            mainWindow.Show();
        }

        private void GetStatus()
        {
        }
    }
}
