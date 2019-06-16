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

namespace ClientSide
{
    /// <summary>
    /// Interaction logic for RoomDataWinow.xaml
    /// </summary>
    public partial class RoomDataWinow : Window
    {
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
        }

        public void addName()
        {

        }

        private void BackButton_Click(object sender, RoutedEventArgs e)
        {
            MainWindow main = new MainWindow();
            Communicator.EndCommunicate = false;
            Close();
            main.Show();
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
            Communicator.Finish();

            //close curr window
            e.Cancel = false;
        }
    }
}
