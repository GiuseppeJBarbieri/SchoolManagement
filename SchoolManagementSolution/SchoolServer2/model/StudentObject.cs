using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolServer2.Model
{
    class StudentObject
    {
        public string Firstname { get; set; }
        public string Lastname { get; set; }
        public string Grade { get; set; }
        public string Age { get; set; }
        public string Gender { get; set; }
        public string Gpa { get; set; }
       

        public StudentObject(string firstname, string lastname, string grade, string age,
            string gender, string gpa)
        {
            this.Firstname = firstname;
            this.Lastname = lastname;
            this.Grade = grade;
            this.Age = age;
            this.Gender = gender;
            this.Gpa = gpa;
           
        }

        public StudentObject()
        {

        }
    }
}
