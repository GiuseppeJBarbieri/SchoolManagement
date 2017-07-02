using SchoolServer2.controller;
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
                Console.WriteLine(b.Length);

                LoginObject info = ByteArrayToLoginObject(b);                         
                    
                s.Send(StringToByteArray(ValidateLogin.ValidateCredentials(info)));
                Console.WriteLine("\nSent Acknowledgement");
                Console.ReadLine();

                s.Close();
                myList.Stop();
            }
            catch (Exception e)
            {
                Console.WriteLine("Error..... " + e.StackTrace);
                Console.ReadLine();
            }

        }

        public static LoginObject ByteArrayToLoginObject(byte[] buffer)
        {
            LoginObject retVal = new LoginObject();

            using (MemoryStream ms = new MemoryStream(buffer))
            {
                BinaryReader br = new BinaryReader(ms);
                retVal.Username = br.ReadString();
                retVal.Password = br.ReadString();

            }
            return retVal;
        }

        public static byte[] StringToByteArray(bool valid)
        {
            using (MemoryStream ms = new MemoryStream())
            {
                BinaryWriter bw = new BinaryWriter(ms);
                if(valid == true)
                {
                    bw.Write("true");
                }
                else
                {
                    bw.Write("false");
                }                
                return ms.ToArray();
            }
        }
    }
}
