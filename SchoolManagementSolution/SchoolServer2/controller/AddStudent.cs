using SchoolServer2.Model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolServer2.controller
{
    class AddStudent
    {

        public static bool AddStuTODB(StudentObject student)
        {
            Console.WriteLine("Student: " + student.Firstname);
            try
            {
                string connetionString = null;
                string sql = null;
                connetionString = "Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=C:\\Users\\Giuseppe\\Documents\\SchoolManagement\\SchoolManagementSolution\\SchoolServer2\\DatabaseForSchool.mdf;Integrated Security=True";
                using (SqlConnection cnn = new SqlConnection(connetionString))
                {
                    sql = "insert into Students ([FirstName], [LastName], [Grade], [Age], [Gender], [GPA]) values(@first,@last,@grade,@age,@gender,@gpa)";
                    cnn.Open();
                    using (SqlCommand cmd = new SqlCommand(sql, cnn))
                    {
                        cmd.Parameters.AddWithValue("@first", student.Firstname);
                        cmd.Parameters.AddWithValue("@last", student.Lastname);
                        cmd.Parameters.AddWithValue("@grade", student.Grade);
                        cmd.Parameters.AddWithValue("@age", student.Age);
                        cmd.Parameters.AddWithValue("@gender", student.Gender);
                        cmd.Parameters.AddWithValue("@gpa", student.Gpa);
                        cmd.ExecuteNonQuery();
                        Console.WriteLine("Row inserted !! ");
                        return true;
                    }
                }

            }
            catch
            {
                Console.WriteLine("FAILED");
                return false;
            }

            

        }
    }
}
