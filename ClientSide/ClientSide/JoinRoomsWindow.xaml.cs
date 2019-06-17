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
using Newtonsoft.Json;
using System.ComponentModel;

namespace ClientSide
{
    /// <summary>
    /// Interaction logic for JoinRoomsWindow.xaml
    /// </summary>
    public partial class JoinRoomsWindow : Window
    {
        private Dictionary<string, Room> allRooms = new Dictionary<string, Room>();

        // C'tor
        public JoinRoomsWindow()
        {
            InitializeComponent();
            Refresh();
        }
        
        /// <summary>
        /// the func refresh the rooms data
        /// </summary>
        private void Refresh()
        {
            // define vars
            //RoomsList.SelectedIndex = -1;
            RoomsList.Items.Clear();
            allRooms.Clear();

            User_Label.Visibility = Visibility.Hidden;
            PlayerList.Visibility = Visibility.Hidden;

            string jsonString = "{\"status\": 7}";
            byte[] arr = Helper.SerializeMsg(jsonString,7);

            // send msg
            Communicator.SendMsg(arr, arr.Length);
            KeyValuePair<int, string> msg = Communicator.GetMsg();

            var mainResJson = JsonConvert.DeserializeObject<Dictionary<string, object>>(msg.Value);
            var v = mainResJson["rooms"].ToString();            
            var roomResJson = JsonConvert.DeserializeObject<Dictionary<string, object>>(v);
            Room room = new Room();

            if (roomResJson == null)
            {
                this.ErrorLabel.Visibility = Visibility.Visible;
                Storyboard sb = Resources["sbHideAnimation"] as Storyboard;
                sb.Begin(ErrorLabel);
            }
            else
            {
                int j = 0;
                foreach (var i in roomResJson.Keys)
                {
                    var res = JsonConvert.DeserializeObject<Dictionary<string, string>>(roomResJson[i].ToString());
                    room.Id =  Convert.ToUInt32(res["ID"]);
                    room.Name =res["name"];
                    room.TimePerQuestion = Convert.ToUInt32(res["timePerQuestion"]);
                    room.Num_of_question = Convert.ToUInt32(res["numOfQustion"]);
                    room.MsxPlayers = Convert.ToUInt32(res["maxPlayers"]);


                    allRooms.Add(room.Name, room);
                    this.RoomsList.Items.Add(room.Name);
                    j++;
                }
            }

        }

        /// <summary>
        /// the user click on the refresh button
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Refresh_Button_Click(object sender, RoutedEventArgs e)
        {
            Refresh();
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

        /// <summary>
        /// the user click on one room in the list
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void RoomsList_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            // show the players in the room
            if (RoomsList.Items.Count > 0)
            {
                User_Label.Visibility = Visibility.Visible;
                PlayerList.Visibility = Visibility.Visible;

                // get the players
                Dictionary<string, int> json = new Dictionary<string, int>();
                json.Add("roomId", (int)allRooms[RoomsList.SelectedItem.ToString()].Id);
                string jsonString = JsonConvert.SerializeObject(json);
                byte[] arr = Helper.SerializeMsg(jsonString, 3);
                Communicator.SendMsg(arr, arr.Length);
                KeyValuePair<int, string> msg = Communicator.GetMsg();

                var v = JsonConvert.DeserializeObject<Dictionary<string, string[]>>(msg.Value);

                foreach (var i in v["players"])
                {
                    PlayerList.Items.Add(i);
                }
            }
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

        private void Join_Button_Click(object sender, RoutedEventArgs e)
        {
            Dictionary<string, int> json = new Dictionary<string, int>();
            json.Add("roomId", (int)allRooms[RoomsList.SelectedItem.ToString()].Id);
            string jsonString = JsonConvert.SerializeObject(json);
            byte[] arr = Helper.SerializeMsg(jsonString, 3);
            Communicator.SendMsg(arr, arr.Length);
            KeyValuePair<int, string> msg = Communicator.GetMsg();
            User.UserRoom = allRooms[RoomsList.SelectedItem.ToString()];
            var v = JsonConvert.DeserializeObject<Dictionary<string, string[]>>(msg.Value);
            User.UserRoom.Players = new List<string>();
            foreach (var i in v["players"])
            {
                User.UserRoom.Players.Add(i);
            }
            RoomDataWinow dataWinow = new RoomDataWinow();
            Communicator.EndCommunicate = false;
            Close();
            dataWinow.Show();
        }
    }
}
