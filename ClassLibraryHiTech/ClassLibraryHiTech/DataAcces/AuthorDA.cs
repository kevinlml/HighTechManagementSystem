/*
 * 
 Kevin Murillo
 */
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ClassLibraryHiTech.Bussines;
using System.Windows.Forms;
using System.IO;

namespace ClassLibraryHiTech.DataAcces
{
    public class AuthorDA
    {
        private static string filePath = Application.StartupPath + @"\Authors.Dat";
        private static string fileTemp = Application.StartupPath + @"\Temp.Dat";

        public static void Save(Author Autho)
        {
            StreamWriter sWriter = new StreamWriter(filePath, true);
            sWriter.WriteLine(Autho.AuthorID + "," + Autho.FName + "," + Autho.LName + "," + Autho.Email);
            sWriter.Close();
            MessageBox.Show("Author Data Has been saved");
        }

        public static void ListAuthor(ListView ListViewAuthor)
        {
            StreamReader sReader = new StreamReader(filePath);
            ListViewAuthor.Items.Clear();
            string line = sReader.ReadLine();
            while (line != null)
            {
                string[] fields = line.Split(',');
                ListViewItem item = new ListViewItem(fields[0]);
                item.SubItems.Add(fields[1]);
                item.SubItems.Add(fields[2]);
                item.SubItems.Add(fields[3]);
                ListViewAuthor.Items.Add(item);
                line = sReader.ReadLine();
            }
            sReader.Close();
        }

        public static Author Search(int Authorid)
        {
            Author Autho = new Author();

            StreamReader sReader = new StreamReader(filePath);
            string line = sReader.ReadLine();

            while (line != null)
            {
                string[] field = line.Split(',');
                if (Authorid == Convert.ToInt32(field[0]))
                {
                    Autho.AuthorID = Convert.ToInt32(field[0]);
                    Autho.FName = field[1];
                    Autho.LName = field[2];
                    Autho.Email = field[3];
                    sReader.Close();
                    return Autho;

                }
                line = sReader.ReadLine();
            }
            sReader.Close();
            return null;
        }
        public static Author Searchemail(string Authoremail)
        {
            Author Autho = new Author();

            StreamReader sReader = new StreamReader(filePath);
            string line = sReader.ReadLine();

            while (line != null)
            {
                string[] field = line.Split(',');
                if (Authoremail == field[3])
                {
                    Autho.AuthorID = Convert.ToInt32(field[0]);
                    Autho.FName = field[1];
                    Autho.LName = field[2];
                    Autho.Email = field[3];
                    sReader.Close();
                    return Autho;

                }
                line = sReader.ReadLine();
            }
            sReader.Close();
            return null;
        }


        public static void Delete(int Authorid)
        {
            StreamReader sReader = new StreamReader(filePath);
            string line = sReader.ReadLine();
            StreamWriter sWriter = new StreamWriter(fileTemp, true);
            while (line != null)
            {
                string[] fields = line.Split(',');
                if ((Authorid) != (Convert.ToInt32(fields[0])))
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

        public static void Update(Author Autho)
        {
            StreamReader sReader = new StreamReader(filePath);
            StreamWriter sWriter = new StreamWriter(fileTemp, true);
            string line = sReader.ReadLine();

            while (line != null)
            {
                string[] fields = line.Split(',');
                if ((Convert.ToInt32(fields[0]) != (Autho.AuthorID)))
                {
                    sWriter.WriteLine(fields[0] + "," + fields[1] + "," + fields[2] + "," + fields[3]);
                }
                line = sReader.ReadLine();
            }
            sWriter.WriteLine(Autho.AuthorID + "," + Autho.FName + "," + Autho.LName + "," + Autho.Email);
            sReader.Close();
            sWriter.Close();

            File.Delete(filePath);
            File.Move(fileTemp, filePath);
        }
    }
}
