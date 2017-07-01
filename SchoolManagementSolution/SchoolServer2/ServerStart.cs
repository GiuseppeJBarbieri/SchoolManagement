using SchoolServer2.Mangement;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace SchoolServer2
{
    class ServerStart
    {
        static void Main(string[] args)
        {
            try
            {
                IPAddress ipAd = IPAddress.Parse("192.168.1.114");
                // use local m/c IP address, and 
                // use the same in the client

                /* Initializes the Listener */
                TcpListener myList = new TcpListener(ipAd, 8000);

                /* Start Listeneting at the specified port */
                myList.Start();

                Console.WriteLine("The server is running at port 8000...");
                Console.WriteLine("The local End point is  :" +
                                  myList.LocalEndpoint);
                Console.WriteLine("Waiting for a connection.....");

                while (true)
                {
                    Socket s = myList.AcceptSocket();
                    Console.WriteLine("Connection accepted from " + s.RemoteEndPoint);

                    byte[] b = new byte[1000];
                    int k = s.Receive(b);

                    Console.WriteLine("Recieved...");
                    Console.WriteLine(b.Length);

                    LoginObject info = ByteArrayToObject(b);
                    Console.WriteLine("UN :" + info.username);
                    

                    ASCIIEncoding asen = new ASCIIEncoding();
                    s.Send(asen.GetBytes("The string was recieved by the server."));
                    Console.WriteLine("\nSent Acknowledgement");
                    /* clean up */
                    Console.ReadLine();
                    s.Close();
                    myList.Stop();
                }

            }
            catch (Exception e)
            {
                Console.WriteLine("Error..... " + e.StackTrace);
                Console.ReadLine();
            }

        }

        public static LoginObject ByteArrayToObject(byte[] buffer)
        {
            LoginObject retVal = new LoginObject();

            using (MemoryStream ms = new MemoryStream(buffer))
            {
                BinaryReader br = new BinaryReader(ms);

                retVal.username = br.ReadString();
                retVal.password = br.ReadString();

            }
            return retVal;
        }
    }
}
