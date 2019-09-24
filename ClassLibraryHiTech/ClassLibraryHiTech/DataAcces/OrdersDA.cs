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
    public class OrdersDA
    {
        private static string filepath2 = Application.StartupPath + @"\Orders.dat";
        private static string fileTemp = Application.StartupPath + @"\Temp.dat";

        public static void Save(Order Or)
        {
            StreamWriter sWriter = new StreamWriter(filepath2, true);
            sWriter.WriteLine(Or.OrdernUmber + "|" + Or.OrderDate + "|" + Or.ShippingDate + "|"+ Or.ClientNumber + "|" + Or.BookName + "|" + Or.Quantity + "|" + Or.unit + "|" + Or.Subtotal + "|" + Or.Gst + "|" + Or.Pst + "|" + Or.total);
            sWriter.Close();
            MessageBox.Show("Order Data Has been saved");
        }

        public static void ListOrder(ListView ListViewOrders)
        {
            StreamReader sReader = new StreamReader(filepath2);
            ListViewOrders.Items.Clear();

            string line = sReader.ReadLine();
            while (line != null)
            {
                string[] fields = line.Split('|');
                ListViewItem item = new ListViewItem(fields[0]);
                item.SubItems.Add(fields[1]);
                item.SubItems.Add(fields[2]);
                item.SubItems.Add(fields[3]);
                item.SubItems.Add(fields[4]);
                item.SubItems.Add(fields[5]);
                item.SubItems.Add(fields[6]);
                item.SubItems.Add(fields[7]);
                item.SubItems.Add(fields[8]);
                item.SubItems.Add(fields[9]);
                item.SubItems.Add(fields[10]);
                ListViewOrders.Items.Add(item);
                line = sReader.ReadLine(); 
            }
            sReader.Close();
        }

        public static Order Search(string Order)
        {
            Order Or = new Order();
            StreamReader sReader = new StreamReader(filepath2);
            string line = sReader.ReadLine();
            while (line != null)
            {
                string[] fields = line.Split('|');
                if (Order == fields[0])
                {
                    Or.OrdernUmber = Convert.ToInt32(fields[0]);
                    Or.OrderDate = fields[1];
                    Or.ShippingDate = fields[2];
                    Or.ClientNumber =(fields[3]);
                    Or.BookName = fields[4];
                    Or.Quantity = Convert.ToInt32(fields[5]);
                    Or.unit = Convert.ToInt32(fields[6]);
                    Or.Subtotal = Convert.ToInt32(fields[7]);
                    Or.Gst = Convert.ToInt32(fields[8]);
                    Or.Pst = Convert.ToInt32(fields[9]);
                    Or.total = Convert.ToInt32(fields[10]);
                    
                    sReader.Close();
                    return Or;
                }
                line = sReader.ReadLine(); 
            }
            sReader.Close();
            return null;
        }

        public static Order SearchN(int Order)
        {
            Order Or = new Order();
            StreamReader sReader = new StreamReader(filepath2);
            string line = sReader.ReadLine();
            while (line != null)
            {
                string[] fields = line.Split('|');
                if (Order == Convert.ToInt32(fields[0]))
                {
                    Or.OrdernUmber = Convert.ToInt32(fields[0]);
                    Or.OrderDate = fields[1];
                    Or.ShippingDate = fields[2];
                    Or.ClientNumber = (fields[3]);
                    Or.BookName = fields[4];
                    Or.Quantity = Convert.ToInt32(fields[5]);
                    Or.unit = Convert.ToInt32(fields[6]);
                    Or.Subtotal = Convert.ToInt32(fields[7]);
                    Or.Gst = Convert.ToInt32(fields[8]);
                    Or.Pst = Convert.ToInt32(fields[9]);
                    Or.total = Convert.ToInt32(fields[10]);

                    sReader.Close();
                    return Or;
                }
                line = sReader.ReadLine(); 
            }
            sReader.Close();
            return null;
        }

        public static void Delete(string Order)
        {
            StreamReader sReader = new StreamReader(filepath2);
            string line = sReader.ReadLine();
            StreamWriter sWriter = new StreamWriter(fileTemp, true);
            while (line != null)
            {
                string[] fields = line.Split('|');
                if ((Order) != fields[0])
                {
                    sWriter.WriteLine(fields[0] + "|" + fields[1] + "|" + fields[2] + "|" + fields[3] + "|" + fields[4] + "|" + fields[5] + "|" + fields[6] + "|" + fields[7] + "|" + fields[8] + "|" + fields[9] + "|" + fields[10]);
                }
                line = sReader.ReadLine(); 
            }
            sReader.Close();
            sWriter.Close();
            
            File.Delete(filepath2);
            File.Move(fileTemp, filepath2);
        }

        public static void Update(Order Or)
        {
            StreamReader sReader = new StreamReader(filepath2);
            StreamWriter sWriter = new StreamWriter(fileTemp, true);
            string line = sReader.ReadLine();

            while (line != null)
            {
                string[] fields = line.Split('|');
                if ((Convert.ToInt32(fields[0]) != (Or.OrdernUmber)))
                {
                    sWriter.WriteLine(fields[0] + "|" + fields[1] + "|" + fields[2] + "|" + fields[3] + "|" + fields[4] + "|" + fields[5] + "|" + fields[6] + "|" + fields[7] + "|" + fields[8] + "|" + fields[9] + "|" + fields[10]);
                }
                line = sReader.ReadLine();  
            }
            sWriter.WriteLine(Or.OrdernUmber + "|" + Or.OrderDate + "|" + Or.ShippingDate + "|" + Or.ClientNumber + "|" + Or.BookName + "|" + Or.Quantity + "|" + Or.unit + "|" + Or.Subtotal + "|" + Or.Gst + "|" + Or.Pst + "|" + Or.total);
            sReader.Close();
            sWriter.Close();
            
            File.Delete(filepath2); 
            File.Move(fileTemp, filepath2);
        }
    }
}
