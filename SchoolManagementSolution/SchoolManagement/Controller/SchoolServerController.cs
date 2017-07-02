using SchoolManagement.Model;
using SchoolManagement.Views;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SchoolManagement.Controller
{
    class SchoolServerController
    {
        //1-define delegate
        //2-define an event based on that delegate
        //3 raise the event

        public delegate void VerifyLoginHandler(object source, Object acc);

        public event VerifyLoginHandler LoginHandled;

        public void VerifyLogin(Object acc)
        {            
            OnLoginHandled(acc);
        }

        protected virtual void OnLoginHandled(Object acc)
        {
            if(LoginHandled != null)
            {
                LoginHandled(this, acc);
            }
        }
    }
}
