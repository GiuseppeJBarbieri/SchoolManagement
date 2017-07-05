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
    public partial class AddFacultyForm : Form
    {
        public AddFacultyForm()
        {
            InitializeComponent();
            LoadFacultyInfo();
        }

        private void AddFacultyForm_Load(object sender, EventArgs e)
        {

        }

        private void LoadFacultyInfo()
        {
            string connectionString = "Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=" +
                "C:\\Users\\Giuseppe\\Documents\\SchoolManagement\\SchoolManagementSolution\\SchoolServer2\\DatabaseForSchool.mdf;Integrated Security=True";
            string sql = "SELECT * FROM Faculty";
            SqlConnection connection = new SqlConnection(connectionString);
            SqlDataAdapter dataadapter = new SqlDataAdapter(sql, connection);
            DataSet ds = new DataSet();
            connection.Open();
            dataadapter.Fill(ds, "Faculty_table");
            connection.Close();
            facultyGridView.DataSource = ds;
            facultyGridView.DataMember = "Faculty_table";
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void addFacBtn_Click(object sender, EventArgs e)
        {
            FacultyObject faculty = new FacultyObject(firstNameTxt.Text, lastNameTxt.Text, ageTxt.Text, genderTxt.Text, classTxt.Text);
            AddFacultyInfo.AddFacultyInfoToDB(faculty);

            LoadFacultyInfo();
        }
    }
}
