using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ite264project.DataModel
{
    public class Product
    {
        public int prodID { get; set; }
        public string prodName { get; set; }
        public string prodDesc { get; set; }
        public Byte[] prodImg { get; set; }
        public double price { get; set; }
        public int inventory { get; set; }
       
    }
}