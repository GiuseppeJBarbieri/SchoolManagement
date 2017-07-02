using SchoolManagement.Controller;
using SchoolManagement.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SchoolManagement
{
    
    public partial class LoginForm : Form
    {
        private SchoolServerController server;
        private LoginService loginService;

        public LoginForm()
        {
            InitializeComponent();
        }

        private void LoginForm_Load(object sender, EventArgs e)
        {           
            server = new SchoolServerController();
            loginService = new LoginService();

            server.LoginHandled += loginService.OnLoginHandled;
            
        }

        private void loginBtn_Click(object sender, EventArgs e)
        {
            server.VerifyLogin(new LoginObject(usernameTxt.Text, passwordTxt.Text));
        }

       
    }
}
