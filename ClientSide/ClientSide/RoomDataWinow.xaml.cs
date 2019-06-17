using System.Collections.Generic;
using System.ComponentModel;
using System.Threading;
using System.Windows;
using Newtonsoft.Json;

namespace ClientSide
{
    /// <summary>
    /// Interaction logic for RoomDataWinow.xaml
    /// </summary>
    public partial class RoomDataWinow : Window
    {
        private Thread timer;

        public RoomDataWinow()
        {
            InitializeComponent();
            if (User.Is_admin)
            {
                StartButton.Visibility = Visibility.Visible;
            }
            else
            {
                StartButton.Visibility = Visibility.Hidden;
            }

            NameLabel.Content = "the room is - " + User.UserRoom.Name.Replace("_", "__");
            InfoList.Items.Add("num of question: " + User.UserRoom.Num_of_question);
            InfoList.Items.Add("max num of users: " + User.UserRoom.MsxPlayers);
            InfoList.Items.Add("time per question: " + User.UserRoom.TimePerQuestion);
            UsersList.Items.Add(User.Username);
            foreach (var i in User.UserRoom.Players)
            {
                UsersList.Items.Add(i);
            }
            timer = new Thread(Tick);
            timer.Start();
        }

        private void BackButton_Click(object sender, RoutedEventArgs e)
        {

            Dictionary<string, int> json = new Dictionary<string, int>();
            json.Add("roomId", (int)User.UserRoom.Id);
            string jsonString = JsonConvert.SerializeObject(json);
            byte[] arr = Helper.SerializeMsg(jsonString, 13);
            Communicator.SendMsg(arr, arr.Length);
            KeyValuePair<int, string> msg = Communicator.GetMsg();


            MainWindow main = new MainWindow();
            Communicator.EndCommunicate = false;
            Close();
            main.Show();
        }

        private void Tick()
        {
            while (true)
            {
                Thread.Sleep(5000);
                Dictionary<string, int> json = new Dictionary<string, int>();
                json.Add("roomId", (int)User.UserRoom.Id);
                string jsonString = JsonConvert.SerializeObject(json);
                byte[] arr = Helper.SerializeMsg(jsonString, 3);
                Communicator.SendMsg(arr, arr.Length);
                KeyValuePair<int, string> msg = Communicator.GetMsg();

                var v = JsonConvert.DeserializeObject<Dictionary<string, string[]>>(msg.Value);

                foreach (var i in v["players"])
                {
                    if (!User.UserRoom.Players.Contains(i))
                    {
                        User.UserRoom.Players.Add(i);
                        Application.Current.Dispatcher.Invoke(delegate () { UsersList.Items.Add(i); });
                    }
                }
            }
        }

        private void StartButton_Click(object sender, RoutedEventArgs e)
        {
            GameWindow game = new GameWindow();
            Communicator.EndCommunicate = false;
            Close();
            game.Show();
        }

        //the user click 'close'
        private void Window_Closing(object sender, CancelEventArgs e)
        {
            //stop the default closing
            e.Cancel = true;

            //return to main window
            if (timer.IsAlive)
            {
                timer.Abort();
            }
            Communicator.Finish();

            //close curr window
            e.Cancel = false;
        }
    }
}
