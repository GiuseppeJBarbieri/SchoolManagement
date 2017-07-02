using SchoolServer2.Mangement;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace SchoolServer2.controller
{
    class ObjectManager
    {
        Socket socket;

        public ObjectManager(Socket s)
        {
            this.socket = s;
        }

        public void ObjectInstruction(byte[] buffer)
        {
            using (MemoryStream ms = new MemoryStream(buffer))
            {
                BinaryReader br = new BinaryReader(ms);
                string instruct = br.ReadString();

                if (instruct == "Login")
                {
                    LoginObject info = new LoginObject();
                    info.Username = br.ReadString();
                    info.Password = br.ReadString();
                    socket.Send(StringToByteArrayForLogin(ValidateLogin.ValidateCredentials(info)));
                    Console.WriteLine("\nSent Acknowledgement");

                }

            }

        }

        public static byte[] StringToByteArrayForLogin(bool valid)
        {
            using (MemoryStream ms = new MemoryStream())
            {
                BinaryWriter bw = new BinaryWriter(ms);
                if (valid == true)
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
