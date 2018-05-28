using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.Net.Sockets;

namespace ServerApp
{
    public class Program
    {
        private static int defaultPort = 3535;
        private static int defaultConectionCount = 5;
        static void Main(string[] args)
        {
            //127.0.0.1 - локальный адресс пк 
            //локал хост
            IPEndPoint endPoint = new IPEndPoint(IPAddress.Parse("127.0.0.1"),defaultPort);
            //по Tcp
            Socket socket = new Socket(AddressFamily.InterNetwork,SocketType.Stream,ProtocolType.Tcp);
            socket.Bind(endPoint);
            try
            {
                socket.Listen(defaultConectionCount);
                Console.WriteLine("Сервер запущен и ждет подключеннй...");
                while (true)
                {
                   Socket incomeConnection= socket.Accept();
                    Console.WriteLine("Вход");
                    int bytes;
                    //Размер буферра 
                    byte[] data = new byte[1024];
                    StringBuilder builder = new StringBuilder();

                    do
                    {
                      bytes=incomeConnection.Receive(data);
                        builder.Append(Encoding.Default.GetString(data));
                    }
                    while (incomeConnection.Available>0);

                    Console.WriteLine(builder);
                    incomeConnection.Shutdown(SocketShutdown.Receive);
                }
            }
            catch(SocketException ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally
            {
                socket.Close();
            }

        }
    }
}
