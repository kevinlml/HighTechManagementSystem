/*
 * 
 Kevin Murillo
 */
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using ClassLibraryHiTech.Bussines;

namespace ClassLibraryHiTech.DataAcces
{
    public class PublisherDA
    {
        private static string filePath = Application.StartupPath + @"\Publisher.dat";
        private static string fileTemp = Application.StartupPath + @"\Temp.dat";

        public static void Save(Publisher publi)
        {
            StreamWriter sWriter = new StreamWriter(filePath, true);
            sWriter.WriteLine(publi.PUBname + "," + publi.PUbAddress + "," + publi.PUBphone );
            sWriter.Close();
            MessageBox.Show("Publisher Data Has been saved");
        }

        public static void ListPublisher(ListView ListviewPublisher)
        {
            StreamReader sReader = new StreamReader(filePath);
            ListviewPublisher.Items.Clear();

            string line = sReader.ReadLine();
            while (line != null)
            {
                string[] fields = line.Split(',');
                ListViewItem item = new ListViewItem(fields[0]);
                item.SubItems.Add(fields[1]);
                item.SubItems.Add(fields[2]);
                ListviewPublisher.Items.Add(item);
                line = sReader.ReadLine(); // Attention : read the next line
            }
            sReader.Close();
        }

        public static Publisher Search(string Publisher)
        {
            Publisher Publi = new Publisher();
            StreamReader sReader = new StreamReader(filePath);
            string line = sReader.ReadLine();
            while (line != null)
            {
                string[] fields = line.Split(',');
                if (Publisher == fields[0])
                {
                    Publi.PUBname = fields[0];
                    Publi.PUbAddress = fields[1];
                    Publi.PUBphone = fields[2];
                    sReader.Close();
                    return Publi;
                }
                line = sReader.ReadLine(); 
            }
            sReader.Close();
            return null;
        }

        public static Publisher Searchbyphonenumber(string Publisher)
        {
            Publisher Publi = new Publisher();
            StreamReader sReader = new StreamReader(filePath);
            string line = sReader.ReadLine();
            while (line != null)
            {
                string[] fields = line.Split(',');
                if (Publisher == fields[2])
                {
                    Publi.PUBname = fields[0];
                    Publi.PUbAddress = fields[1];
                    Publi.PUBphone = fields[2];
                    sReader.Close();
                    return Publi;
                }
                line = sReader.ReadLine();
            }
            sReader.Close();
            return null;
        }

        public static void Delete(string PubliName)
        {
            StreamReader sReader = new StreamReader(filePath);
            string line = sReader.ReadLine();
            StreamWriter sWriter = new StreamWriter(fileTemp, true);
            while (line != null)
            {
                string[] fields = line.Split(',');
                if ((PubliName) != fields[0])
                {
                    sWriter.WriteLine(fields[0] + "," + fields[1] + "," + fields[2] );
                }
                line = sReader.ReadLine();  
            }
            sReader.Close();
            sWriter.Close();

            File.Delete(filePath);
            File.Move(fileTemp, filePath);
        }

        public static void Update(Publisher Publi)
        {
            StreamReader sReader = new StreamReader(filePath);
            StreamWriter sWriter = new StreamWriter(fileTemp, true);
            string line = sReader.ReadLine();

            while (line != null)
            {
                string[] fields = line.Split(',');
                if (fields[0] != (Publi.PUBname))
                {
                    sWriter.WriteLine(fields[0] + "," + fields[1] + "," + fields[2]);
                }
                line = sReader.ReadLine();  
            }
            sWriter.WriteLine(Publi.PUBname + "," + Publi.PUbAddress + "," + Publi.PUBphone);
            sReader.Close();
            sWriter.Close();
            
            File.Delete(filePath); 
            File.Move(fileTemp, filePath);
        }
    }
}
