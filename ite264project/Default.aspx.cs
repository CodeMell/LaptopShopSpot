using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ite264project.DBClasses;
using ite264project.DataModel;

namespace ite264project
{
    public partial class Default : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Table mainTable = new Table();
            mainTable.CssClass = "table-striped";
            mainTable.Style.Add("margin", "10px auto 10px auto");
            mainTable.Style.Add("width", "auto");
            ProductTier productTier = new ProductTier();
            TableRow mainTr;
            TableCell mainTd;

            int counter = 0;

            List<Product> productList = productTier.getAllProducts();

            mainTr = new TableRow();

            foreach(Product item in productList)
            {
                if(counter % 4 == 0)
                {
                    mainTable.Rows.Add(mainTr);
                    mainTr = new TableRow();
                }
                mainTd = new TableCell();
                Table theProductTable = productTable(item);
                mainTd.Controls.Add(theProductTable);
                mainTd.Style.Add("padding", "0px 20px 0px 20px");
                mainTr.Cells.Add(mainTd);
                

                counter++;
            }

            if(counter % 1 == 0  || counter % 2 == 0 || counter % 3 == 0) 
            {
                mainTable.Rows.Add(mainTr);
            }
          
            pnlProducts.Controls.Add(mainTable);
        }

        private Table productTable(Product theProduct)
        {
            Table theTable = new Table();
            TableRow tr = new TableRow();
            TableCell td = new TableCell();
            Label theLabel = new Label();
            Button addToCart;

            Image theImage = new Image();
            theImage.ImageUrl = "/Handlers/imgHandler.ashx?ID=" + theProduct.prodID.ToString();
            theImage.CssClass = "img-thumbnail prodImg";
            td.Controls.Add(theImage);
            td.Style.Add("height", "200px");
            tr.Cells.Add(td);
            theTable.Rows.Add(tr);

            tr = new TableRow();
            td = new TableCell();
            theLabel = new Label();
            theLabel.Text = theProduct.prodName.ToString();
            td.Controls.Add(theLabel);
            tr.Cells.Add(td);
            theTable.Rows.Add(tr);

            tr = new TableRow();
            td = new TableCell();
            theLabel = new Label();
            theLabel.Text = theProduct.prodDesc.ToString();
            td.Controls.Add(theLabel);
            tr.Cells.Add(td);
            theTable.Rows.Add(tr);

            tr = new TableRow();
            td = new TableCell();
            theLabel.Text = "$" + Math.Round(theProduct.price, 2).ToString("N2");
            td.Controls.Add(theLabel);
            tr.Cells.Add(td);
            theTable.Rows.Add(tr);

            tr = new TableRow();
            td = new TableCell();
            addToCart = new Button();
            addToCart.ID = theProduct.prodID.ToString();
            addToCart.Text = "Add To Cart";
            addToCart.CssClass = "btn btn-success";
            addToCart.Click += addToCartClick;
            td.Controls.Add(addToCart);
            tr.Cells.Add(td);
            theTable.Rows.Add(tr);


            return theTable;
        }

        protected void addToCartClick(object sender, EventArgs e)
        {
            Button theButton = (Button)sender;
            ProductTier productTier = new ProductTier();
            Product theProduct = productTier.getProductById(int.Parse(theButton.ID));

            Cart theCart;

            if(Session["theCart"] != null)
            {
                theCart = (Cart)Session["theCart"];
                theCart.addProduct(theProduct, 1);
            }
            else
            {
                theCart = new Cart();
                theCart.addProduct(theProduct, 1);
            }

            Session["theCart"] = theCart;
            
        }
    }
}