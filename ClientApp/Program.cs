using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
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

                var jsonConvert1 = JsonConvert.DeserializeObject<ChatData>(chatData.Text);
                byte[] byts = Encoding.Default.GetBytes(jsonConvert1.Text);
                socket.Send(byts);
                

                Console.WriteLine("Отправка Файла");
                string filePath = Console.ReadLine();
                chatData.FilePath = filePath;
                socket.Send(byts);
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
        public byte[] ToDo()
        {
            using (var openFileDialog = new OpenFileDialog())
            {
                openFileDialog.Filter = "Comma Separated Value(*.*) | *.*";
                FileStream fs;

                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    fs = new FileStream(openFileDialog.FileName, FileMode.Open, FileAccess.Read);
                    byte[] readBuf = new byte[fs.Length]; 
                    return readBuf;
                }
               
            }
            
        }
    }
}
