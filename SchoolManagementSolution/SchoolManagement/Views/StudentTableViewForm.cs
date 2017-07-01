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
    public partial class StudentTableViewForm : Form
    {
        public StudentTableViewForm()
        {
            InitializeComponent();
        }

        private void StudentTableViewForm_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'schoolDatabaseDataSet.StudentTable' table. You can move, or remove it, as needed.
            this.studentTableTableAdapter.Fill(this.schoolDatabaseDataSet.StudentTable);

        }

        private void backBtn_Click(object sender, EventArgs e)
        {
            HomePage hp = new HomePage();
            hp.Show();
        }
    }
}
