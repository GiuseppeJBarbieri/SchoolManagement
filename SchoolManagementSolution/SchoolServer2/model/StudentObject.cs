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
        public int Grade { get; set; }
        public int Age { get; set; }
        public string Gender { get; set; }
        public int Gpa { get; set; }
        public int ClassId { get; set; }

        public StudentObject(string firstname, string lastname, int grade, int age,
            string gender, int gpa, int classId)
        {
            this.Firstname = firstname;
            this.Lastname = lastname;
            this.Grade = grade;
            this.Age = age;
            this.Gender = gender;
            this.Gpa = gpa;
            this.ClassId = classId;
        }

        public StudentObject()
        {

        }
    }
}
