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
        private uint id;
        private uint num_of_question;
        private uint timePerQuestion;
        private uint msxPlayers;

        public uint Id { get => id; set => id = value; }
        public string Name { get => name; set => name = value; }
        public uint Num_of_question { get => num_of_question; set => num_of_question = value; }
        public uint TimePerQuestion { get => timePerQuestion; set => timePerQuestion = value; }
        public uint MsxPlayers { get => msxPlayers; set => msxPlayers = value; }
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
            userRoom.MsxPlayers = unum;
            userRoom.Id = id;
            userRoom.TimePerQuestion = time;
        }
    }
}
