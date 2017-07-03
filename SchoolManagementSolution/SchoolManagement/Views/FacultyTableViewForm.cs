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
    public partial class FacultyTableViewForm : Form
    {
        public FacultyTableViewForm()
        {
            InitializeComponent();
            LoadFacultyTable();
        }

        private void FacultyTableViewForm_Load(object sender, EventArgs e)
        {

        }

        private void LoadFacultyTable()
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
            facultyDataGridView.DataSource = ds;
            facultyDataGridView.DataMember = "Faculty_table";
        }

        private void backBtn_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
