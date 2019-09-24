using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibraryHiTech.Bussines
{
    public class Product
    {

        public int ISBN { get; set; }
        public string Title { get; set; }

        public Product()

        {
            ISBN = 123;
            Title = "hola";
        }
        public Product(int isbn, string title)
        {
            this.ISBN = isbn;
            this.Title = title;
        }



    }
}
