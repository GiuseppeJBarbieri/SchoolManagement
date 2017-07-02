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
                    Console.WriteLine(b.Length);
                  

                    LoginObject info = (LoginObject)ByteArrayToLoginObject(b);

                    s.Send(StringToByteArray(ValidateLogin.ValidateCredentials(info)));
                    Console.WriteLine("\nSent Acknowledgement");
                    
                    s.Close();
                    myList.Stop();
                }
                catch (Exception e)
                {
                    Console.WriteLine("Error..... " + e.StackTrace);                    
                }
            }

        }

        public static object ByteArrayToLoginObject(byte[] buffer)
        {
            LoginObject retVal = new LoginObject();

            using (MemoryStream ms = new MemoryStream(buffer))
            {
                BinaryReader br = new BinaryReader(ms);
                string instruct = br.ReadString();                

                if (instruct == "Login")
                {                   
                    retVal.Username = br.ReadString();
                    retVal.Password = br.ReadString();
                } 

            }
            return retVal;
        }

        public static string FindNameOfClass(byte[] buffer)
        {
            
           

            using (MemoryStream ms = new MemoryStream(buffer))
            {
                BinaryFormatter bf = new BinaryFormatter();
                object obj = bf.Deserialize(ms);
                return obj.GetType().Name;
            }

            
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
