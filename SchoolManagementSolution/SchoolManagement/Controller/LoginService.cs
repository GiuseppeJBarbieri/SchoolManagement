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

                MessageBox.Show("Transmitting.....");
                stm.Write(ba, 0, ba.Length);

                byte[] bb = new byte[100];
                int k = stm.Read(bb, 0, 100);
                String s = null;
                StringBuilder sb = new StringBuilder(s);

                for (int i = 0; i < k; i++)
                   sb.Append(Convert.ToString(bb[i]));

                MessageBox.Show(s);

                tcpclnt.Close();
            }
            catch (Exception e)
            {
                MessageBox.Show("Error..... " + e.StackTrace);
            }
            return false;            
        }

        public static byte[] ObjectToByteArray(string username, string password)
        {
            using (MemoryStream ms = new MemoryStream())
            {
                BinaryWriter bw = new BinaryWriter(ms);
                bw.Write("login");
                bw.Write(username);
                bw.Write(password);

                return ms.ToArray();
            }
        }

        public void OnLoginHandled(object source, Object acc)
        {
            CheckValid((LoginObject)acc);

            /*
            LoginObject account = (LoginObject)acc;

            SqlConnection con = new SqlConnection();
            con.ConnectionString = "Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=C:\\Users\\Giuseppe\\Documents\\SchoolManagement\\SchoolManagementSolution\\SchoolManagement\\SchoolDatabase.mdf;Integrated Security=True";
            con.Open();

            SqlCommand cmd = new SqlCommand("select UserName,Password from LoginInformation where UserName='" + account.username + "'and Password='" + account.password + "'", con);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            if (dt.Rows.Count > 0)
            {
                MessageBox.Show("Login sucess Welcome to Homepage ");
                HomePage hp = new HomePage();
                LoginForm.ActiveForm.Hide();
                hp.Show();

            }
            else
            {
                MessageBox.Show("Invalid Login please check username and password");
            }

            con.Close();
            */
        }
        
    }
}
