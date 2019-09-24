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
    public class BooksDA
    {
        private static string filePath = Application.StartupPath + @"\Books.dat";
        private static string fileTemp = Application.StartupPath + @"\Temp.dat";

        public static void Save(Books book)

        {
            StreamWriter sWriter = new StreamWriter(filePath, true);
            sWriter.WriteLine(book.ISBN + "," + book.Title + "," 
                + book.BookAuthor + "," + book.BookYearPublished + "," + book.BookQOH + "," + book.BookUnitePrice);
            sWriter.Close();
            MessageBox.Show("Book Data has been saved");
        }

        public static void ListBook(ListView ListViewBook)
        {
            StreamReader sReader = new StreamReader(filePath);
            ListViewBook.Items.Clear();

            string line = sReader.ReadLine();
            while (line != null)
            {
                string[] fields = line.Split(',');
                ListViewItem item = new ListViewItem(fields[0]);
                item.SubItems.Add(fields[1]);
                item.SubItems.Add(fields[2]);
                item.SubItems.Add(fields[3]);
                item.SubItems.Add(fields[4]);
                item.SubItems.Add(fields[5]);
                ListViewBook.Items.Add(item);
                line = sReader.ReadLine(); 
            }
            sReader.Close();
        }

        public static Books Search(int BookID)
        {
            Books book = new Books();

            StreamReader sReader = new StreamReader(filePath);
            string line = sReader.ReadLine();

            while (line != null)
            {
                string[] fields = line.Split(',');
                if (BookID == Convert.ToInt32(fields[0]))
                {
                    book.ISBN = Convert.ToInt32(fields[0]);
                    book.Title = fields[1];
                    book.BookAuthor = fields[2];
                    book.BookYearPublished = fields[3];
                    book.BookQOH = Convert.ToInt32(fields[4]);
                    book.BookUnitePrice = Convert.ToInt32(fields[5]);
                    sReader.Close();
                    return book;
                }
                line = sReader.ReadLine();
            }
            sReader.Close();
            return null;
        }

        public static Books SearchTitle(string BookID)
        {
            Books book = new Books();

            StreamReader sReader = new StreamReader(filePath);
            string line = sReader.ReadLine();

            while (line != null)
            {
                string[] fields = line.Split(',');
                if (BookID == fields[1])
                {
                    book.ISBN = Convert.ToInt32(fields[0]);
                    book.Title = fields[1];
                    book.BookAuthor = fields[2];
                    book.BookYearPublished = fields[3];
                    book.BookQOH = Convert.ToInt32(fields[4]);
                    book.BookUnitePrice = Convert.ToInt32(fields[5]);
                    sReader.Close();
                    return book;
                }
                line = sReader.ReadLine();
            }
            sReader.Close();
            return null;
        }
        public static void Delete(int BookID)
        {
            StreamReader sReader = new StreamReader(filePath);
            string line = sReader.ReadLine();
            StreamWriter sWriter = new StreamWriter(fileTemp, true);
            while (line != null)
            {
                string[] fields = line.Split(',');
                if ((BookID) != (Convert.ToInt32(fields[0])))
                {
                    sWriter.WriteLine(fields[0] + "," + fields[1] + "," + fields[2] + "," + fields[3] + "," + fields[4] + "," + fields[5]);
                }
                line = sReader.ReadLine();
            }
            sReader.Close();
            sWriter.Close();

            File.Delete(filePath);
            File.Move(fileTemp, filePath);
        }

        public static void Update(Books book)
        {
            StreamReader sReader = new StreamReader(filePath);
            StreamWriter sWriter = new StreamWriter(fileTemp, true);
            string line = sReader.ReadLine();

            while (line != null)
            {
                string[] fields = line.Split(',');
                if ((Convert.ToInt32(fields[0]) != (book.ISBN)))
                {
                    sWriter.WriteLine(fields[0] + "," + fields[1] + "," + fields[2] + "," + fields[3] + "," + fields[4] + "," + fields[5] );
                }

                line = sReader.ReadLine();        
            }
            sWriter.WriteLine(book.ISBN + "," + book.Title + "," + book.BookAuthor + "," + book.BookYearPublished + "," + book.BookQOH + "," + book.BookUnitePrice);
            sReader.Close();
            sWriter.Close();
            File.Delete(filePath);
            File.Move(fileTemp, filePath);
        }
    }
}

