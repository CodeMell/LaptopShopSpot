using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Collections;
using ite264project.DataModel;
using ite264project.DBClasses;
using System.Threading;

namespace ite264project.DataModel
{
    public class Cart
    {
        public ArrayList products { get; set; }
        public ArrayList quantities { get; set; }
        public Guid cartID { get; set; }

        public Cart()
        {
            cartID = Guid.NewGuid();
            products = new ArrayList();
            quantities = new ArrayList();
        }

        public void addProduct(Product prod, int quan)
        {
            int counter = 0;
            int initQuan;
            foreach(Product item in products)
            {
                if(item.prodID == prod.prodID)
                {
                    initQuan = (int)quantities[counter];
                    quantities[counter] = initQuan + quan;
                    return;
                }
                counter++;
            }
            products.Add(prod);
            quantities.Add(quan);
        }
        
        public void deleteProduct(int prodID)
        {
            foreach(Product item in products)
            {
                if(item.prodID == prodID)
                {
                    quantities.RemoveAt(products.IndexOf(item));
                    products.Remove(item);
                    break;
                }
            }
        }
    }
}