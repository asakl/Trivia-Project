using System;
using System.Collections.Generic;
using System.ComponentModel;
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
using Newtonsoft.Json;

namespace ClientSide
{
    /// <summary>
    /// Interaction logic for HighscoresWindow.xaml
    /// </summary>
    public partial class HighscoresWindow : Window
    {
        // C'tor
        public HighscoresWindow()
        {
            InitializeComponent();
            string s = "";
            byte[] arr = Helper.SerializeMsg(s, 8);
            Communicator.SendMsg(arr, arr.Length);
            KeyValuePair<int, string> msg = Communicator.GetMsg();

            if (msg.Key == 0)
            {
                var json = JsonConvert.DeserializeObject<Dictionary<string, object>>(msg.Value);
                var top = json["highscores"];
                string[] str = ((System.Collections.IEnumerable)top).Cast<object>().Select(x => x.ToString()).ToArray();

                ThirdPlace.Content = ThirdPlace.Content + "\t\t" + str[0];
                SecondPlace.Content = SecondPlace.Content + "\t\t" + str[1];
                FirstPlace.Content = FirstPlace.Content + "\t\t" + str[2];
            }
        }

        /// <summary>
        /// the user click on the back button
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BackButton_Click(object sender, RoutedEventArgs e)
        {
            //the func close the curr window and open the main window
            MainWindow mainWindow = new MainWindow();
            Communicator.EndCommunicate = false;
            this.Close();
            mainWindow.Show();
        }

        //the user click 'close'
        private void Window_Closing(object sender, CancelEventArgs e)
        {
            //stop the default closing
            e.Cancel = true;

            //return to main window
            Communicator.Finish();

            //close curr window
            e.Cancel = false;
        }
    }
}
