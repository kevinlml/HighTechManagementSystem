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
    public class Order
    {
        public int OrdernUmber { get; set; }
        public string OrderDate { get; set; }
        public string ShippingDate { get; set; }
        public string ClientNumber { get; set; }
        public string BookName { get; set; }
        public int Quantity { get; set; } 
        public double unit { get; set; }
        public double Subtotal { get; set; }
        public double Gst { get; set; }
        public double Pst { get; set; }
        public double total { get; set; }
    }
}
