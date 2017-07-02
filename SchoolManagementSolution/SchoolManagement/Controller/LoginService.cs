using SchoolManagement.Views;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SchoolManagement.Model
{
    class LoginService
    {
        public static bool CheckValid(LoginObject accInfo)
        {
            try
            {
                TcpClient tcpclnt = new TcpClient();
                MessageBox.Show("Connecting.....");
                tcpclnt.Connect("192.168.1.114", 8000);
                MessageBox.Show("Connected");

                Stream stm = tcpclnt.GetStream();

                byte[] ba = ObjectToByteArray(accInfo.username, accInfo.password);
                              
                stm.Write(ba, 0, ba.Length);

                byte[] bb = new byte[100];
                int k = stm.Read(bb, 0, 100);
                
                LoginVerify(ByteArrayToObject(bb));
                tcpclnt.Close();
            }
            catch (Exception e)
            {
                MessageBox.Show("Error..... " + e.StackTrace);
            }
            return false;            
        }

        public static void LoginVerify(string valid)
        {
            if(valid == "true")
            {
                MessageBox.Show("Login sucess Welcome to Homepage ");
                HomePage hp = new HomePage();
                LoginForm.ActiveForm.Hide();
                hp.Show();
            }
            else
            {
                MessageBox.Show("Login unsuccessful");

            }

        }

        public static byte[] ObjectToByteArray(string username, string password)
        {
            using (MemoryStream ms = new MemoryStream())
            {
                BinaryWriter bw = new BinaryWriter(ms);

                bw.Write("Login");
                bw.Write(username);
                bw.Write(password);                
                
                return ms.ToArray();
            }
        }

        public static string ByteArrayToObject(byte[] buffer)
        {
            string retVal = null;

            using (MemoryStream ms = new MemoryStream(buffer))
            {
                BinaryReader br = new BinaryReader(ms);
                retVal = br.ReadString();              

            }
            return retVal;
        }

        public void OnLoginHandled(object source, Object acc)
        {
            CheckValid((LoginObject)acc);           
        }
        
    }
}
