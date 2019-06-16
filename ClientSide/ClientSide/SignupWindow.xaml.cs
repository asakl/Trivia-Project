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
using System.Windows.Navigation;
using System.Windows.Shapes;
using Newtonsoft.Json;

namespace ClientSide
{
    /// <summary>
    /// the class is a window that registe user
    /// it get username, password, and email
    /// and send them to server
    /// </summary>
    public partial class SignupWindow : Window
    {
        // C'tor
        public SignupWindow()
        {
            InitializeComponent();
        }

        //the func close the curr window and open the main window
        private void ReturnFunc()
        {
            MainWindow mainWindow = new MainWindow();
            Communicator.EndCommunicate = false;
            this.Close();
            mainWindow.Show();
        }

        //if user click the 'ok' button
        private void Ok_Button_Click(object sender, RoutedEventArgs e)
        {
            //define vars
            Dictionary<string, string> json = new Dictionary<string, string>(2);
            bool valid = true;

            //there is username?
            valid &= Helper.AddToJson(json, "username", this.UsernameText.GetLineText(0));
            valid &= Helper.AddToJson(json, "email", this.EmailText.GetLineText(0));
            valid &= Helper.AddToJson(json, "password", this.PasswordText.Password);

            //there is all three args?
            if (valid)
            {
                //hide the error label
                this.ErrorLabel.Visibility = Visibility.Hidden;

                //make a json string 
                string jsonString = JsonConvert.SerializeObject(json);

                byte[] arr = Helper.SerializeMsg(jsonString, 2);
               
                Communicator.SendMsg(arr, arr.Length);
                KeyValuePair<int, string> pair = Communicator.GetMsg();

                //valid request
                if (pair.Key == 0)
                {
                    ReturnFunc();
                }
            }
            //something invalid
            else
            {
                this.ErrorLabel.Visibility = Visibility.Visible;
            }

        }

        //the user click 'back' button
        private void BackButton_Click(object sender, RoutedEventArgs e)
        {
            //return to main window
            ReturnFunc();
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
