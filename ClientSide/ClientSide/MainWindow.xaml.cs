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
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        // C'tor
        public MainWindow()
        {
            InitializeComponent();

            Communicator.Init(@"C:\Users\user\Documents\magshimim\year 2\cpp class\c16 trivia\ClientSide\config.txt");

            // try to connect
            try
            {
                Communicator.Connect();
            }
            // open the error connection window
            catch(Exception)
            {
                // open error window and close this
                ConnectionErrorWindow errorWindow = new ConnectionErrorWindow();
                this.Close();
                errorWindow.Show();
            }

            this.UsernameText.Text = "asa";
            this.PasswordText.Password = "asa1";

            // there is logged user?
            if (Helper.Username != "")
            {
                LoggedUser();
            }
        }
        
        /// <summary>
        /// the func log a user into sys
        /// </summary>
        private void LoggedUser()
        {
            // change all the UI
            LoginGrid.Visibility = Visibility.Hidden;
            Logout_Button.Visibility = Visibility.Visible;
            User_Label.Content = "Welcome " + Helper.Username + "!";
            User_Label.Visibility = Visibility.Visible;
            Join_Button.IsEnabled = true;
            Create_Button.IsEnabled = true;
            Status_Button.IsEnabled = true;
            Best_Button.IsEnabled = true;
        }

        /// <summary>
        /// the user click on the signup button
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Signup_Button_Click(object sender, RoutedEventArgs e)
        {
            // open signup window and close this
            SignupWindow signupWindow = new SignupWindow();
            this.Close();
            signupWindow.Show();
        }
        
        /// <summary>
        /// the user click on the login button
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Ok_Button_Click(object sender, RoutedEventArgs e)
        {
            // define vars
            Dictionary<string, string> json = new Dictionary<string, string>(2);
            bool valid = true;
             
            // create msg dict
            valid &= Helper.AddToJson(json, "username", this.UsernameText.GetLineText(0));
            valid &= Helper.AddToJson(json, "password", this.PasswordText.Password);

            // valid msg?
            if (valid)
            {
                // encode msg
                this.ErrorLabel.Visibility = Visibility.Hidden;
                string jsonString = JsonConvert.SerializeObject(json);
                byte[] arr = Helper.SerializeMsg(jsonString, 1);

                // send msg and get res
                Communicator.SendMsg(arr, arr.Length);
                KeyValuePair<int, string> msg = Communicator.GetMsg();
                
                // the user is valid
                if ((msg.Key) == 0)
                {
                    // log user
                    Helper.Username = json["username"];
                    LoggedUser();
                }
                else
                {
                    // show erre label
                    ErrorLabel.Content = "username or password incorrect";
                    ErrorLabel.Visibility = Visibility.Visible;
                }
            }
            else
            {
                ErrorLabel.Visibility = Visibility.Visible;
            }

        }

        /// <summary>
        /// the user exit the app
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Quit_Button_Click(object sender, RoutedEventArgs e)
        {
            Communicator.Finish();
            Close();
        }

        /// <summary>
        /// the user click on the join button
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Join_Button_Click(object sender, RoutedEventArgs e)
        {
            // open join room window and close this
            JoinRoomsWindow joinRoomsWindow = new JoinRoomsWindow();
            Close();
            joinRoomsWindow.Show();
        }

        /// <summary>
        /// the user click on the logout button
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Logout_Button_Click(object sender, RoutedEventArgs e)
        {
            // close communication
            Communicator.Finish();

            // change th UI
            LoginGrid.Visibility = Visibility.Visible;
            Logout_Button.Visibility = Visibility.Hidden;
            User_Label.Visibility = Visibility.Hidden;
            PasswordText.Clear();
            Join_Button.IsEnabled = false;
            Create_Button.IsEnabled = false;
            Status_Button.IsEnabled = false;
            Best_Button.IsEnabled = false;
            Helper.Username = "";

            // reconnect server
            Communicator.Connect();
        }

        /// <summary>
        /// the user click on the create button
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Create_Button_Click(object sender, RoutedEventArgs e)
        {
            // open create room window and close this
            CreateRoomWindow createRoomWindow = new CreateRoomWindow();
            Close();
            createRoomWindow.Show();
        }

        /// <summary>
        /// the user click on the status button
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Status_Button_Click(object sender, RoutedEventArgs e)
        {
            // open status window and close this
            MyStatusWindow myStatusWindow = new MyStatusWindow(Helper.Username);
            Close();
            myStatusWindow.Show();
        }

        /// <summary>
        /// the user click on the highscore button
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Best_Button_Click(object sender, RoutedEventArgs e)
        {
            // open highscores window and close this
            HighscoresWindow highscores = new HighscoresWindow();
            Close();
            highscores.Show();
        }
    }
}
