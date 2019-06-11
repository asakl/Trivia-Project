using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClientSide
{
    public class Room
    {
        private string name;
        private uint room_id;
        private uint num_of_question;
        private uint time_per_question;
        private uint num_of_users;

        public uint Room_id { get => room_id; set => room_id = value; }
        public string Name { get => name; set => name = value; }
        public uint Num_of_question { get => num_of_question; set => num_of_question = value; }
        public uint Time_per_question { get => time_per_question; set => time_per_question = value; }
        public uint Num_of_users { get => num_of_users; set => num_of_users = value; }
    }

    public static class User
    {
        private static string username = "";
        private static bool is_admin = false;
        private static Room userRoom = new Room();

        public static bool Is_admin { get => is_admin; set => is_admin = value; }
        public static string Username { get => username; set => username = value; }
        public static Room UserRoom { get => userRoom; set => userRoom = value; }

        public static void initRoom(string rname, uint id, uint unum, uint qnum, uint time)
        {
            userRoom.Name = rname;
            userRoom.Num_of_question = qnum;
            userRoom.Num_of_users = unum;
            userRoom.Room_id = id;
            userRoom.Time_per_question = time;
        }
    }
}
