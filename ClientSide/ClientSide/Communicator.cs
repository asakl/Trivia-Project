using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;


namespace ClientSide
{
    /// <summary>
    /// the class do all the communication stuff
    /// </summary>
    class Communicator
    {
        // define vars
        static private int port;
        static private string ip;
        static private TcpClient client = new TcpClient();
        static private IPEndPoint serverEndPoint;
        static private NetworkStream clientStream;

        static public void Connect()
        {
            // becuase all the reopen main window
            // check if there is connection
            if (!client.Connected)
            {
                // connect
                client = new TcpClient();
                serverEndPoint = new IPEndPoint(IPAddress.Parse(ip), port);
                client.Connect(serverEndPoint);
                clientStream = client.GetStream();
            }
        }

        /// <summary>
        /// the func send a msg
        /// </summary>
        /// <param name="arr"> the msg to send encoded </param>
        /// <param name="arr_size"> the msg len </param>
        static public void SendMsg(byte[] arr, int arr_size)
        {
            clientStream.Write(arr, 0, arr_size);
            clientStream.Flush();
        }

        /// <summary>
        /// the func get msg from server
        /// </summary>
        /// <returns> pair: the key is the msg code and the val is string of json </returns>
        static public KeyValuePair<int, string> GetMsg()
        {
            // read
            byte[] buffer = new byte[100];
            int bytesRead = clientStream.Read(buffer, 0, 100);

            // get size
            IEnumerable<byte> a = buffer.Take(5).Reverse().Take(4);
            byte[] arr = a.ToArray();
            uint size = BitConverter.ToUInt32(arr, 0);

            // decode
            string str = Encoding.UTF8.GetString(buffer, 0, 100);

            // get json
            return new KeyValuePair<int, string>(buffer[0], str.Substring(5, (int)size));
        }

        /// <summary>
        /// the func close the communication
        /// and send the logout msg
        /// </summary>
        static public void Finish()
        {
            // define var
            string jsonString = "{\"msg\": \"goodbey\"}";

            // make the json string into byte list
            byte[] arr = Helper.SerializeMsg(jsonString, 6);
            Communicator.SendMsg(arr, arr.Length);
            client.Close();
        }

        static public void Init(string path)
        {
            // Read the file as one string.
            string[] text = System.IO.File.ReadAllLines(path);

            ip = text[0].Split('=')[1];
            port = Convert.ToInt32(text[1].Split('=')[1]);
        }
    }

}
