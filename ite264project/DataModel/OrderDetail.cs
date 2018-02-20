using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ite264project.DataModel
{
    public class OrderDetail
    {
        public int orderID { get; set; }
        public int prodID { get; set; }
        public int quantitySold { get; set; }
    }
}