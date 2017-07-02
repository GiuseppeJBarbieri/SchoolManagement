using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolServer2.Mangement
{
    class LoginObject
    {
        public string Username { get; set; }
        public string Password { get; set; }

        public LoginObject(string username, string password)
        {
            this.Username = username;
            this.Password = password;
        }

        public LoginObject()
        {
        }
    }
}
