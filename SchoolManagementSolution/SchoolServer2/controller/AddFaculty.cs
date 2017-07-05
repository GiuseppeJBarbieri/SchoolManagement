using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SchoolServer2.Model;
using System.Data.SqlClient;

namespace SchoolServer2.controller
{
    class AddFaculty
    {
        public static bool AddFacTODB(FacultyObject faculty)
        {
            Console.WriteLine("Faculty: " + faculty.Firstname);
            try
            {
                string connetionString = null;
                string sql = null;
                connetionString = "Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=C:\\Users\\Giuseppe\\Documents\\SchoolManagement\\SchoolManagementSolution\\SchoolServer2\\DatabaseForSchool.mdf;Integrated Security=True";
                using (SqlConnection cnn = new SqlConnection(connetionString))
                {
                    sql = "insert into Faculty ([FirstName], [LastName], [Age], [Gender], [Class]) values(@first,@last,@age,@gender,@class)";
                    cnn.Open();
                    using (SqlCommand cmd = new SqlCommand(sql, cnn))
                    {
                        cmd.Parameters.AddWithValue("@first", faculty.Firstname);
                        cmd.Parameters.AddWithValue("@last", faculty.Lastname);
                        cmd.Parameters.AddWithValue("@age", faculty.Age);
                        cmd.Parameters.AddWithValue("@gender", faculty.Gender);
                        cmd.Parameters.AddWithValue("@class", faculty.Class);
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
