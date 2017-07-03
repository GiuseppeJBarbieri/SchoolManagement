using SchoolManagement.Controller_AddStuInfo;
using SchoolManagement.Model_StudentInformation;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SchoolManagement.Views
{
    public partial class AddStudentForm : Form
    {
        public AddStudentForm()
        {
            InitializeComponent();
            LoadStudentInfo();
        }

        private void backBtn_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void LoadStudentInfo()
        {
            string connectionString = "Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=" +
                "C:\\Users\\Giuseppe\\Documents\\SchoolManagement\\SchoolManagementSolution\\SchoolServer2\\DatabaseForSchool.mdf;Integrated Security=True";
            string sql = "SELECT * FROM Students";
            SqlConnection connection = new SqlConnection(connectionString);
            SqlDataAdapter dataadapter = new SqlDataAdapter(sql, connection);
            DataSet ds = new DataSet();
            connection.Open();
            dataadapter.Fill(ds, "Student_table");
            connection.Close();
            studentGridView.DataSource = ds;
            studentGridView.DataMember = "Student_table";
        }

        private void addStuBtn_Click(object sender, EventArgs e)
        {
            StudentObject student = new StudentObject(firstNameTxt.Text, lastNameTxt.Text, gradeTxt.Text, ageTxt.Text, genderTxt.Text, gpaTxt.Text);
            AddStudentInfo.AddStudentInfoToDB(student);
            
            LoadStudentInfo();
        }
    }
}
