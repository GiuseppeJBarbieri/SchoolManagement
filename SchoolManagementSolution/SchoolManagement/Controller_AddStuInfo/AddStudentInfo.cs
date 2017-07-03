using SchoolManagement.Model_StudentInformation;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SchoolManagement.Controller_AddStuInfo
{
    class AddStudentInfo
    {
        public static void AddStudentInfoToDB(StudentObject student)
        {
            try
            {
                TcpClient tcpclnt = new TcpClient();
                MessageBox.Show("Connecting.....");
                tcpclnt.Connect("192.168.1.114", 8000);
                MessageBox.Show("Connected");

                Stream stm = tcpclnt.GetStream();

                byte[] ba = ObjectToByteArray(student);

                stm.Write(ba, 0, ba.Length);

                byte[] bb = new byte[100];
                int k = stm.Read(bb, 0, 100);
                                
                tcpclnt.Close();
            }
            catch (Exception e)
            {
                MessageBox.Show("Error..... " + e.StackTrace);
            }
        }

        public static byte[] ObjectToByteArray(StudentObject student)
        {
            using (MemoryStream ms = new MemoryStream())
            {
                BinaryWriter bw = new BinaryWriter(ms);

                bw.Write("Add To Student Database");
                bw.Write(student.Firstname);
                bw.Write(student.Lastname);
                bw.Write(student.Grade);
                bw.Write(student.Age);
                bw.Write(student.Gender);
                bw.Write(student.Gpa);

                return ms.ToArray();
            }
        }
        public static string ByteArrayToObject(byte[] buffer)
        {
            string retVal = null;

            using (MemoryStream ms = new MemoryStream(buffer))
            {
                BinaryReader br = new BinaryReader(ms);
                retVal = br.ReadString();

            }
            return retVal;
        }
    }
}
