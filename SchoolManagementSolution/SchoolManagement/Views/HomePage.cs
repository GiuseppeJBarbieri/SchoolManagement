using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SchoolManagement.Views
{
    public partial class HomePage : Form
    {
        public HomePage()
        {
            InitializeComponent();
        }

        private void studentTableToolStripMenuItem_Click(object sender, EventArgs e)
        {
            StudentTableViewForm stvf = new StudentTableViewForm();
            stvf.Show();

        }

        private void logoutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
            LoginForm lf = new LoginForm();
            lf.Show();
        }

        private void facultyTableToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FacultyTableViewForm ftvf = new FacultyTableViewForm();
            ftvf.Show();
        }

        private void studentToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AddStudentForm asf = new AddStudentForm();
            asf.Show();
        }

        private void facultyMemberToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AddFacultyForm aff = new AddFacultyForm();
            aff.Show();
        }
    }
}
