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
    /// Interaction logic for CreateRoomWindow.xaml
    /// </summary>
    public partial class CreateRoomWindow : Window
    {
        // C'tor
        public CreateRoomWindow()
        {
            InitializeComponent();

            this.RoomsInput.Text = "room_name";
            this.TimeInput.Text = "5";
            this.NumPlayersInput.Text = "2";
            this.NumQuestionsInput.Text = "5";
        }

        /// <summary>
        /// the user click on the back button
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            // the func close the curr window and open the main window
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

        /// <summary>
        /// the func add key and val to dict and check if the val is valid
        /// </summary>
        /// <param name="dict"></param>
        /// <param name="key"></param>
        /// <param name="val"></param>
        /// <param name="b"> will be false if the val is str that not a num </param>
        /// <returns> if the val is empty </returns>
        private bool AddToJson(Dictionary<string, int> dict, string key, string val, ref bool b)
        {
            // define var
            bool good = true;

            // val is empty? b is num?
            if (val == "" || !( b &= int.TryParse(val, out int n)))
            {
                good = false;
            }
            // val is ok
            else
            {
                dict.Add(key, int.Parse(val));
            }

            return good;
        }

        /// <summary>
        /// the user click on the create room button
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void CreateButton_Click(object sender, RoutedEventArgs e)
        {
            // define vars
            Dictionary<string, string> json1 = new Dictionary<string, string>();
            Dictionary<string, int> json2 = new Dictionary<string, int>();
            bool validInput = true;
            bool num = true;

            // make two dicts of msg
            validInput &= Helper.AddToJson(json1, "roomName", this.RoomsInput.GetLineText(0));
            validInput &= AddToJson(json2, "questionCount", this.NumPlayersInput.GetLineText(0), ref num);
            validInput &= AddToJson(json2, "maxUsers", this.NumQuestionsInput.GetLineText(0), ref num);
            validInput &= AddToJson(json2, "answerTimeout", this.TimeInput.GetLineText(0), ref num);

            // all input is valid?
            if (validInput)
            {
                // hide error label
                this.ErrorLabel.Visibility = Visibility.Hidden;

                // create msg
                string jsonString1 = JsonConvert.SerializeObject(json1);
                string jsonString2 = JsonConvert.SerializeObject(json2);
                string jsonString = Helper.AddTwoJson(jsonString1, jsonString2);
                byte[] arr = Helper.SerializeMsg(jsonString, 5);

                // send and get res
                Communicator.SendMsg(arr, arr.Length);
                KeyValuePair<int, string> msg = Communicator.GetMsg();

                Dictionary<string, uint> resJson = JsonConvert.DeserializeObject<Dictionary<string, uint>>(msg.Value);
                int i = 0;

                User.Is_admin = true;
                User.initRoom(json1["roomName"], resJson["roomId"], (uint)json2["maxUsers"], (uint)json2["questionCount"], (uint)json2["answerTimeout"]);

                RoomDataWinow roomDataWinow = new RoomDataWinow();
                Close();
                roomDataWinow.Show();
            }
            // invalid input
            else
            {
                // input of string and not int?
                if (!num)
                {
                    // show error label with this msg
                    this.ErrorLabel.Content = "pls make sure all is in the good type";
                    this.ErrorLabel.Visibility = Visibility.Visible;
                }
                else
                {
                    // show error label with this msg
                    this.ErrorLabel.Content = "pls fill all the filds";
                    this.ErrorLabel.Visibility = Visibility.Visible;
                }
            }
        }
    }
}
