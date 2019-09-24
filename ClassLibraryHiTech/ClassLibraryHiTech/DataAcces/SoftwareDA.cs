using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using ClassLibraryHiTech.Bussines;
using System.Windows.Forms;

namespace ClassLibraryHiTech.DataAcces
{
    public class SoftwareDA
    {
        private static string filePath = Application.StartupPath + @"\Softwares.dat";
        private static string fileTemp = Application.StartupPath + @"\Temp.dat";

        public static void Save(Software software)

        {
            StreamWriter sWriter = new StreamWriter(filePath, true);
            sWriter.WriteLine(software.ISBN + "," + software.Title + ","
                + software.SoftwareAuthor + "," + software.SoftwareQOH + "," + software.SoftwareUnitePrice);
            sWriter.Close();
            MessageBox.Show("software Data has been saved");
        }

        public static void ListSoftware(ListView ListViewSoftware)
        {
            StreamReader sReader = new StreamReader(filePath);
            ListViewSoftware.Items.Clear();

            string line = sReader.ReadLine();
            while (line != null)
            {
                string[] fields = line.Split(',');
                ListViewItem item = new ListViewItem(fields[0]);
                item.SubItems.Add(fields[1]);
                item.SubItems.Add(fields[2]);
                item.SubItems.Add(fields[3]);
                item.SubItems.Add(fields[4]);
                ListViewSoftware.Items.Add(item);
                line = sReader.ReadLine();
            }
            sReader.Close();
        }

        public static Software Search(int SoftwareID)
        {
            Software software = new Software();

            StreamReader sReader = new StreamReader(filePath);
            string line = sReader.ReadLine();

            while (line != null)
            {
                string[] fields = line.Split(',');
                if (SoftwareID == Convert.ToInt32(fields[0]))
                {
                    software.ISBN = Convert.ToInt32(fields[0]);
                    software.Title = fields[1];
                    software.SoftwareAuthor = fields[2];
                    software.SoftwareQOH = Convert.ToInt32(fields[3]);
                    software.SoftwareUnitePrice = Convert.ToInt32(fields[4]);
                    sReader.Close();
                    return software;
                }
                line = sReader.ReadLine();
            }
            sReader.Close();
            return null;
        }

        public static Software SearchTitle(string SoftwareID)
        {
            Software software = new Software();

            StreamReader sReader = new StreamReader(filePath);
            string line = sReader.ReadLine();

            while (line != null)
            {
                string[] fields = line.Split(',');
                if (SoftwareID == fields[1])
                {
                    software.ISBN = Convert.ToInt32(fields[0]);
                    software.Title = fields[1];
                    software.SoftwareAuthor = fields[2];
                    software.SoftwareQOH = Convert.ToInt32(fields[3]);
                    software.SoftwareUnitePrice = Convert.ToInt32(fields[4]);
                    sReader.Close();
                    return software;
                }
                line = sReader.ReadLine();
            }
            sReader.Close();
            return null;
        }
        public static void Delete(int SoftwareID)
        {
            StreamReader sReader = new StreamReader(filePath);
            string line = sReader.ReadLine();
            StreamWriter sWriter = new StreamWriter(fileTemp, true);
            while (line != null)
            {
                string[] fields = line.Split(',');
                if ((SoftwareID) != (Convert.ToInt32(fields[0])))
                {
                    sWriter.WriteLine(fields[0] + "," + fields[1] + "," + fields[2] + "," + fields[3] + "," + fields[4]);
                }
                line = sReader.ReadLine();
            }
            sReader.Close();
            sWriter.Close();

            File.Delete(filePath);
            File.Move(fileTemp, filePath);
        }

        public static void Update(Software software)
        {
            StreamReader sReader = new StreamReader(filePath);
            StreamWriter sWriter = new StreamWriter(fileTemp, true);
            string line = sReader.ReadLine();

            while (line != null)
            {
                string[] fields = line.Split(',');
                if ((Convert.ToInt32(fields[0]) != (software.ISBN)))
                {
                    sWriter.WriteLine(fields[0] + "," + fields[1] + "," + fields[2] + "," + fields[3] + "," + fields[4]);
                }

                line = sReader.ReadLine();
            }
            sWriter.WriteLine(software.ISBN + "," + software.Title + "," + software.SoftwareAuthor + "," + software.SoftwareQOH + "," + software.SoftwareUnitePrice);
            sReader.Close();
            sWriter.Close();
            File.Delete(filePath);
            File.Move(fileTemp, filePath);
        }
    }
}
