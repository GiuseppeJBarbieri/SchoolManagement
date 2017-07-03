using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolManagement.Model_StudentInformation
{
    class ClassListObject
    {
        public int ClassId { get; set; }
        public string Class1 { get; set; }
        public string Class2 { get; set; }
        public string Class3 { get; set; }

        public ClassListObject(int classId, string class1, string class2, string class3)
        {
            this.ClassId = classId;
            this.Class1 = class1;
            this.Class2 = class2;
            this.Class3 = class3;
        }

        public ClassListObject()
        {

        }
    }
}
