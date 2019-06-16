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
using System.Threading;
using System.Windows.Threading;
using System.Windows.Media.Animation;
using System.ComponentModel;

namespace ClientSide
{
    /// <summary>
    /// Interaction logic for GameWindow.xaml
    /// </summary>
    public partial class GameWindow : Window
    {
        public GameWindow()
        {
            InitializeComponent();
            RoomName.Content = User.UserRoom.Name;
            QuestNum.Content = "0/" + User.UserRoom.Num_of_question;
            Score.Content = "0/0";
            Username.Content = User.Username;
            StartGame();
        }

        private void Exit_Click(object sender, RoutedEventArgs e)
        {
            MainWindow main = new MainWindow();
            Close();
            main.Show();
        }

        private void CounterFunc()
        {
            var count = User.UserRoom.TimePerQuestion;
            var dt = new DispatcherTimer();
            dt.Interval = TimeSpan.FromSeconds(1);
            dt.Tick += (_, a) =>
            {
                if (count-- == 0)
                {
                    dt.Stop();
                    Counter.Content = "done";
                }
                else
                    Counter.Content = count;
            };

            dt.Start();

        }

        private void GetQuestion()
        {

        }

        private void StartGame()
        {
            for (int i = 0; i < User.UserRoom.Num_of_question; i++)
            {
                Thread t = new Thread(CounterFunc);
                t.Start();
                GetQuestion();
                QuestNum.Content = (i + 1) + "/" + User.UserRoom.Num_of_question;
                Score.Content = "0/" + (i + 1);
                t.Join();
            }
        }

        //the user click 'close'
        private void Window_Closing(object sender, CancelEventArgs e)
        {
            //stop the default closing
            e.Cancel = true;

            //return to main window
            Communicator.Finish();
            Close();

            //close curr window
            e.Cancel = false;
        }
    }
}
