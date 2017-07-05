using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolServer2.Model
{
    class FacultyObject
    {
        public string Firstname { get; set; }
        public string Lastname { get; set; }
        public string Age { get; set; }
        public string Gender { get; set; }
        public string Class { get; set; }

        public FacultyObject(string firstname, string lastname, string age, string gender, string classSub)
        {
            this.Firstname = firstname;
            this.Lastname = lastname;
            this.Age = age;
            this.Gender = gender;
            this.Class = classSub;
        }

        public FacultyObject()
        {

        }
    }
}
