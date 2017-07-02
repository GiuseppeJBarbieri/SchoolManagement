using SchoolServer2.controller;
using SchoolServer2.Mangement;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;

namespace SchoolServer2
{
    class ServerStart
    {
        static void Main(string[] args)
        {
            while (true)
            {
                try
                {
                    IPAddress ipAd = IPAddress.Parse("192.168.1.114");
                    TcpListener myList = new TcpListener(ipAd, 8000);

                    myList.Start();

                    Console.WriteLine("The server is running at port 8000...");
                    Console.WriteLine("The local End point is  :" +
                                      myList.LocalEndpoint);

                    Console.WriteLine("Waiting for a connection.....");
                    Socket s = myList.AcceptSocket();
                    Console.WriteLine("Connection accepted from " + s.RemoteEndPoint);

                    byte[] b = new byte[1000];
                    int k = s.Receive(b);

                    Console.WriteLine("Recieved...");

                    ObjectManager objectManager = new ObjectManager(s);
                    objectManager.ObjectInstruction(b);
                    
                    s.Close();
                    myList.Stop();
                }
                catch (Exception e)
                {
                    Console.WriteLine("Error..... " + e.StackTrace);                    
                }
            }
        }                  
    }
}
