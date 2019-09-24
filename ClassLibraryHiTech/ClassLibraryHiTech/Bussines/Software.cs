using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibraryHiTech.Bussines
{
    public class Software : Product
    {
        public int SoftwareQOH { get; set; }
        public float SoftwareUnitePrice { get; set; }
        public string SoftwareAuthor { get; set; }

        public Software()
        {
            SoftwareQOH = 11111;
            SoftwareUnitePrice = 123456789;
            SoftwareAuthor = "Edgar";



        }

        public Software(int softwareqoh, float softwareuniteprice, string softwareauthor, int isbn, string title) : base(isbn, title)
        {
            this.SoftwareQOH = softwareqoh;
            this.SoftwareUnitePrice = softwareuniteprice;
            this.SoftwareAuthor = softwareauthor;



        }
    }
}
