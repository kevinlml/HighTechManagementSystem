/*
 * 
 Kevin Murillo
 */
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibraryHiTech.Bussines
{
    public class Books : Product
    {
        
        public string BookAuthor { get; set; }
        public string BookYearPublished { get; set; }
        public int BookQOH { get; set; }
        public float BookUnitePrice { get; set; }

        public Books()
        {
            BookAuthor = "ellacra";
            BookYearPublished = "123";
            BookQOH = 11;
            BookUnitePrice = 12;


        }

        public Books(string bookauthor, string bookyearpublished, int bookqoh, float bookuniteprice, int isbn, string title) : base(isbn, title)
        {
            this.BookAuthor = bookauthor;
            this.BookYearPublished = bookyearpublished;
            this.BookQOH = bookqoh;
            this.BookUnitePrice = bookuniteprice;


        }



    }
}
