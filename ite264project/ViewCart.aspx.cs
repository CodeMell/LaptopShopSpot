using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ite264project.DataModel;
using ite264project.DBClasses;
using System.Collections;

namespace ite264project
{
    public partial class ViewCart : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if(Session["theCart"] != null)
            {
                Cart theCart = (Cart)Session["theCart"];
                ProductTier theTier = new ProductTier();
                Table theTable = new Table();
                theTable.CssClass = "table-striped";
                theTable.Style.Add("margin", "10px auto 10px auto");
                theTable.Style.Add("width", "auto");
                TableRow tr;
                TableCell td = new TableCell();
                TableHeaderRow th = new TableHeaderRow();
                Image theImage;
                Button delete;

                Label theLabel = new Label();
                td = new TableCell();
                theLabel.Text = "Product Name";
                td.Controls.Add(theLabel);
                th.Cells.Add(td);

                theLabel = new Label();
                td = new TableCell();
                theLabel.Text = "Image";
                td.Controls.Add(theLabel);
                th.Cells.Add(td);

                theLabel = new Label();
                td = new TableCell();
                theLabel.Text = "Quantity";
                td.Controls.Add(theLabel);
                th.Cells.Add(td);

                theLabel = new Label();
                td = new TableCell();
                theLabel.Text = "Price";
                td.Controls.Add(theLabel);
                th.Cells.Add(td);

                theTable.Rows.Add(th);

                foreach(Product item in theCart.products){

                    tr = new TableRow();

                    theLabel = new Label();
                    td = new TableCell();
                    theLabel.Text = item.prodName;
                    td.Controls.Add(theLabel);
                    tr.Cells.Add(td);

                    theLabel = new Label();
                    td = new TableCell();
                    theImage = new Image();
                    theImage.ImageUrl = "/Handlers/imgHandler.ashx?ID=" + item.prodID;
                    theImage.CssClass = "img-thumbnail prodImg";
                    td.Controls.Add(theImage);
                    tr.Cells.Add(td);

                    theLabel = new Label();
                    td = new TableCell();
                    theLabel.Text = theCart.quantities[theCart.products.IndexOf(item)].ToString();
                    td.Controls.Add(theLabel);
                    tr.Cells.Add(td);


                    theLabel = new Label();
                    td = new TableCell();
                    theLabel.Text = "$" + Math.Round(item.price, 2).ToString("N2");
                    td.Controls.Add(theLabel);
                    tr.Cells.Add(td);

                    td = new TableCell();
                    delete = new Button();
                    
                    delete.Click += deleteClick;
                    delete.Text = "Delete";
                    delete.CssClass = item.prodID.ToString() + " btn btn-danger";
                    td.Controls.Add(delete);
                    tr.Cells.Add(td);

                    theTable.Rows.Add(tr);
                }

                Button submit = new Button();
                td = new TableCell();
                tr = new TableRow();
                submit.Text = "Submit Order";
                submit.CssClass = "btn btn-success";
                submit.Click += submitClick;
                td.Controls.Add(submit);
                tr.Cells.Add(td);

                theTable.Rows.Add(tr);

                pnlOut.Controls.Add(theTable);
            }
            else
            {
                Label theLabel = new Label();
                theLabel.Text = "There are no items in your cart!";
                pnlOut.Controls.Add(theLabel);
            }

        }

        protected void deleteClick(object sender, EventArgs e)
        {
            Cart theCart = (Cart)Session["theCart"];
            Button delete = (Button)sender;
            int id = int.Parse(delete.CssClass.Remove(delete.CssClass.IndexOf(" "), 15));
            ArrayList theList = theCart.products;

            foreach(Product item in theList)
            {
                if(item.prodID == id)
                {
                    theCart.deleteProduct(item.prodID);
                    break;
                }
            }
            if (theCart.products.Count != 0)
            {
                Session["theCart"] = theCart;
            }
            else
            {
                Session["theCart"] = null;
            }
            Response.Redirect("/ViewCart.aspx");
        }

        protected void submitClick(object sender, EventArgs e)
        {
            if(Session["theCart"] != null)
            {
                Response.Redirect("/OrderConfirmation.aspx");
            }
            else
            {
                Response.Redirect("/Default.aspx");
            }
        }
    }
}