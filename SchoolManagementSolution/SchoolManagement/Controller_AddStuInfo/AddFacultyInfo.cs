using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SchoolManagement.Model_StudentInformation;
using System.Windows.Forms;
using System.IO;
using System.Net.Sockets;

namespace SchoolManagement.Controller_AddStuInfo
{
    class AddFacultyInfo
    {
        public static void AddFacultyInfoToDB(FacultyObject faculty)
        {
            try
            {
                TcpClient tcpclnt = new TcpClient();
                MessageBox.Show("Connecting.....");
                tcpclnt.Connect("192.168.1.114", 8000);
                MessageBox.Show("Connected");

                Stream stm = tcpclnt.GetStream();

                byte[] ba = ObjectToByteArray(faculty);

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

        private static byte[] ObjectToByteArray(FacultyObject faculty)
        {
            using (MemoryStream ms = new MemoryStream())
            {
                BinaryWriter bw = new BinaryWriter(ms);

                bw.Write("Add To Faculty Database");
                bw.Write(faculty.Firstname);
                bw.Write(faculty.Lastname);
                bw.Write(faculty.Age);
                bw.Write(faculty.Gender);
                bw.Write(faculty.Class);

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
