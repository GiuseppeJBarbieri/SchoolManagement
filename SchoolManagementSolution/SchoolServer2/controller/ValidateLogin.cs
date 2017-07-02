using SchoolServer2.Mangement;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolServer2.controller
{
    class ValidateLogin
    {
        public ValidateLogin()
        {
        }               

        public static bool ValidateCredentials(LoginObject acc)
        {            
            SqlConnection con = new SqlConnection();
            con.ConnectionString = "Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=" +
                "C:\\Users\\Giuseppe\\Documents\\SchoolManagement\\SchoolManagementSolution\\SchoolServer2\\DatabaseForSchool.mdf;Integrated Security=True";

            con.Open();
            SqlCommand cmd = new SqlCommand("select username,password from loginInfo where username='" + acc.Username + "'and password='" + acc.Password + "'", con);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            
            if (dt.Rows.Count > 0)
            {                
                Console.WriteLine("Accepted in validate login class");
                con.Close();
                return true;
            }
            else
            {
                Console.WriteLine("RETURNING FALSE");
                con.Close();
                return false;
            }           

        }
    }
}
