using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using ClassLibraryHiTech.Bussines;
using System.Data.OleDb;
using System.Data;

namespace ClassLibraryHiTech.DataAcces
{
    public class UserDA
    {
        private static string filePath = Application.StartupPath + @"\Users.Dat";
        private static string fileTemp = Application.StartupPath + @"\Temp.Dat";
        OleDbConnection mycon = new OleDbConnection(@"Provider = Microsoft.Jet.OLEDB.4.0; Data Source =C:\Users\Kevin\Documents\Visual Studio 2015\Projects\Administration’sApplicationForRemax\Administration’sApplicationForRemax\bin\Debug\Remax.mdb");

        public static void Save(User User)
        {
            StreamWriter sWriter = new StreamWriter(filePath, true);
            sWriter.WriteLine(User.UserID + "," + User.Password + "," + User.JobTitle + "," + User.YearBorn);
            sWriter.Close();
            MessageBox.Show("User Data Has been saved");
        }

        public static void ListUsers(ListView ListviewUser)
        {
            StreamReader sReader = new StreamReader(filePath);
            ListviewUser.Items.Clear();
            string line = sReader.ReadLine();
            while (line != null)
            {
                string[] fields = line.Split(',');
                ListViewItem item = new ListViewItem(fields[0]);
                item.SubItems.Add(fields[1]);
                item.SubItems.Add(fields[2]);
                item.SubItems.Add(fields[3]);
                ListviewUser.Items.Add(item);
                line = sReader.ReadLine();
            }
            sReader.Close();
        }

        public static User Search(string UserID)
        {
            User Use = new User();

            StreamReader sReader = new StreamReader(filePath);
            string line = sReader.ReadLine();
            OleDbCommand mycmd2 = new OleDbCommand("SELECT * FROM Students", mycon);
            OleDbDataReader myReader = mycmd2.ExecuteReader();

            DataTable tmp = new DataTable();

            tmp.Load(myReader);
           while (myReader.Read())
            {
                

            }
            
            while (line != null)
            {
                string[] field = line.Split(',');
                if (UserID == field[0])
                {
                    Use.UserID = field[0];
                    Use.Password = field[1];
                    Use.JobTitle = field[2];
                    Use.YearBorn = field[3];
                    sReader.Close();
                    return Use;

                }
                line = sReader.ReadLine();
            }
            sReader.Close();
            return null;
        }

        public static void Delete(string UserID)
        {
            StreamReader sReader = new StreamReader(filePath);
            string line = sReader.ReadLine();
            StreamWriter sWriter = new StreamWriter(fileTemp, true);
            while (line != null)
            {
                string[] fields = line.Split(',');
                if ((UserID) != fields[0])
                {
                    sWriter.WriteLine(fields[0] + "," + fields[1] + "," + fields[2] + "," + fields[3]);
                }
                line = sReader.ReadLine();
            }
            sReader.Close();
            sWriter.Close();

            File.Delete(filePath);
            File.Move(fileTemp, filePath);
        }

        public static void Update(User US)
        {
            StreamReader sReader = new StreamReader(filePath);
            StreamWriter sWriter = new StreamWriter(fileTemp, true);
            string line = sReader.ReadLine();

            while (line != null)
            {
                string[] fields = line.Split(',');
                if (fields[0] != (US.UserID))
                {
                    sWriter.WriteLine(fields[0] + "," + fields[1] + "," + fields[2] + "," + fields[3]);
                }
                line = sReader.ReadLine();
            }
            sWriter.WriteLine(US.UserID + "," + US.Password + "," + US.JobTitle + "," + US.YearBorn);
            sReader.Close();
            sWriter.Close();

            File.Delete(filePath);
            File.Move(fileTemp, filePath);
        }
    }
}
