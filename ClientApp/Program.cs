using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ClientApp
{
    class Program
    {
        private static int defaultPort = 3535;
        static void Main(string[] args)
        {
        IPEndPoint endPoint = new IPEndPoint(IPAddress.Parse("127.0.0.1"), defaultPort);
        Socket socket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            try
            {
               
                Console.WriteLine("Client запущен ");
                Console.WriteLine("отправка сообщения");
                socket.Connect(endPoint);

                ChatData chatData = new ChatData(); 
                var jsonConvert = JsonConvert.DeserializeObject<ChatData>(chatData.Sender);
                socket.Send(Encoding.Default.GetBytes(jsonConvert.Sender));
                
                StringBuilder stringBuilder = new StringBuilder();
                string text = Console.ReadLine();
            }
            catch (SocketException ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally
            {
                socket.Close();
            }
            Console.ReadLine();

        }
    }
}
