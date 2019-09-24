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
    public class ClientsDA
    {
        private static string filePath = Application.StartupPath + @"\Clients.dat";
        private static string fileTemp = Application.StartupPath + @"\Temp.dat";

        public static void Save(Client Clien)

        {
            StreamWriter sWriter = new StreamWriter(filePath, true);
            sWriter.WriteLine(Clien.ClientID + "," + Clien.Name + "," + Clien.Street + "," + Clien.City + "," + Clien.PostalCode + "," + Clien.PhoneNumber + "," +  Clien.FaxNumber + "," +  Clien.CreditLimit);
            sWriter.Close();
            MessageBox.Show("Client Data has been saved");
        }

        public static void ListClient(ListView ListViewClient)
        {
            StreamReader sReader = new StreamReader(filePath);
            ListViewClient.Items.Clear();

            string line = sReader.ReadLine();
            while (line != null)
            {
                string[] fields = line.Split(',');
                ListViewItem item = new ListViewItem(fields[0]);
                item.SubItems.Add(fields[1]); //int
                item.SubItems.Add(fields[2]);
                item.SubItems.Add(fields[3]);
                item.SubItems.Add(fields[4]);
                item.SubItems.Add(fields[5]);
                item.SubItems.Add(fields[6]);
                item.SubItems.Add(fields[7]); //int
                ListViewClient.Items.Add(item);
                line = sReader.ReadLine();
            }
            sReader.Close();
        }
        public static Client SearchNM(string Clientname)
        {
            Client Clien = new Client();

            StreamReader sReader = new StreamReader(filePath);
            string line = sReader.ReadLine();

            while (line != null)
            {
                string[] fields = line.Split(',');
                if (Clientname == fields[1])
                {
                    Clien.ClientID = Convert.ToInt32(fields[0]);
                    Clien.Name = fields[1];
                    Clien.Street = fields[2];
                    Clien.City = fields[3];
                    Clien.PostalCode = fields[4];
                    Clien.PhoneNumber = fields[5];
                    Clien.FaxNumber = fields[6];
                    Clien.CreditLimit = Convert.ToInt32(fields[7]);
                    sReader.Close();
                    return Clien;
                }
                line = sReader.ReadLine();
            }
            sReader.Close();
            return null;
        }

        public static Client SearchID(int ClientID)
        {
            Client Clien = new Client();

            StreamReader sReader = new StreamReader(filePath);
            string line = sReader.ReadLine();

            while (line != null)
            {
                string[] fields = line.Split(',');
                if (ClientID == Convert.ToInt32(fields[0]))
                {
                    Clien.ClientID = Convert.ToInt32(fields[0]);
                    Clien.Name = fields[1];
                    Clien.Street = fields[2];
                    Clien.City = fields[3];
                    Clien.PostalCode = fields[4];
                    Clien.PhoneNumber = fields[5];
                    Clien.FaxNumber = fields[6];
                    Clien.CreditLimit = Convert.ToInt32(fields[7]);
                    sReader.Close();
                    return Clien;
                }
                line = sReader.ReadLine();
            }
            sReader.Close();
            return null;
        }


        public static void Delete(int ClientID)
        {
            StreamReader sReader = new StreamReader(filePath);
            string line = sReader.ReadLine();
            StreamWriter sWriter = new StreamWriter(fileTemp, true);
            while (line != null)
            {
                string[] fields = line.Split(',');
                if ((ClientID) != (Convert.ToInt32(fields[0])))
                {
                    sWriter.WriteLine(fields[0] + "," + fields[1] + "," + fields[2] + "," + fields[3] + "," + fields[4] + "," + fields[5] + "," + fields[6] + "," + fields[7]);
                }
                line = sReader.ReadLine();
            }
            sReader.Close();
            sWriter.Close();

            File.Delete(filePath);
            File.Move(fileTemp, filePath);
        }

        public static void Update(Client Clien)
        {
            StreamReader sReader = new StreamReader(filePath);
            StreamWriter sWriter = new StreamWriter(fileTemp, true);
            string line = sReader.ReadLine();

            while (line != null)
            {
                string[] fields = line.Split(',');
                if ((Convert.ToInt32(fields[0]) != (Clien.ClientID)))
                {
                    sWriter.WriteLine(fields[0] + "," + fields[1] + "," + fields[2] + "," + fields[3] + "," + fields[4] + "," + fields[5] + "," + fields[6] + "," + fields[7]);
                }

                line = sReader.ReadLine();// Attention : read the next line        
            }
            sWriter.WriteLine(Clien.ClientID + "," + Clien.Name + "," + Clien.Street + "," + Clien.City + "," + Clien.PostalCode + "," + Clien.PhoneNumber + "," + Clien.FaxNumber + "," + Clien.CreditLimit);
            sReader.Close();
            sWriter.Close();
            File.Delete(filePath);
            File.Move(fileTemp, filePath);
        }

        
    }
}
