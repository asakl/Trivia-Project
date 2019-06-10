using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Media.Animation;
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
    /// Interaction logic for ConnectionErrorWindow.xaml
    /// </summary>
    public partial class ConnectionErrorWindow : Window
    {
        // C'tor
        public ConnectionErrorWindow()
        {
            InitializeComponent();
        }

        /// <summary>
        /// if user click on retry button, then retry to connect to server
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void RetryButton_Click(object sender, RoutedEventArgs e)
        {
            // define var
            bool connect = true;

            // try to connect
            try
            {
                Communicator.Connect();
            }
            // can't
            catch (Exception)
            {
                // show error label to the user
                // and then she (the label) fade 
                ErrorLabel.Visibility = Visibility.Visible;
                Storyboard sb = Resources["sbHideAnimation"] as Storyboard;
                sb.Begin(ErrorLabel);
                connect = false;
            }
            // the client connect?
            if (connect)
            {
                // open main window and close this
                MainWindow main = new MainWindow();
                Close();
                main.Show();
            }
        }

        /// <summary>
        /// close the prog
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void CancelButton_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }
    }
}
