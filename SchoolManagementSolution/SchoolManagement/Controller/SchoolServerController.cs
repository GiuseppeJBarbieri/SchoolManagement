using SchoolManagement.Model;
using SchoolManagement.Views;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SchoolManagement.Controller
{
    class SchoolServerController
    {
        public void LoginVerification(object loginobj)
        {
            LoginObject acc = (LoginObject)loginobj;

            SqlConnection con = new SqlConnection();
            con.ConnectionString = "Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=C:\\Users\\Giuseppe\\Documents\\SchoolManagement\\SchoolManagementSolution\\SchoolManagement\\SchoolDatabase.mdf;Integrated Security=True";
            con.Open();

            SqlCommand cmd = new SqlCommand("select UserName,Password from LoginInformation where UserName='" + acc.username + "'and Password='" + acc.password + "'", con);
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
           
        }
    }
}
