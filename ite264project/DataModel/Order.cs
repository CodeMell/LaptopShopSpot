using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ite264project.DataModel
{
    public class Order
    {
        public int orderID { get; set; }
        public int custID { get; set; }
        public Guid cartID { get; set; }
        public double total { get; set; }
        public DateTime dateOfSale { get; set; }
        public double taxRate { get; set; }
        public double discount { get; set; }
    }
}