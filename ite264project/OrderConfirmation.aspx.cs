using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ite264project.DataModel;
using ite264project.DBClasses;

namespace ite264project
{
    public partial class OrderConfirmation : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["theCart"] != null)
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
                TextBox txtCustID;
                TextBox txtDiscount;
                

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

                foreach (Product item in theCart.products)
                {

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

                    theTable.Rows.Add(tr);
                }

                tr = new TableRow();
                td = new TableCell();
                tr.Cells.Add(td);
                td = new TableCell();
                tr.Cells.Add(td);
                td = new TableCell();
                tr.Cells.Add(td);
                td = new TableCell();
                theLabel = new Label();
                double total = 0;
                int quan = 1;
                foreach(Product item in theCart.products)
                {
                    if(int.Parse(theCart.quantities[theCart.products.IndexOf(item)].ToString()) > 1)
                    {
                        quan = int.Parse(theCart.quantities[theCart.products.IndexOf(item)].ToString());
                    }
                    total += (item.price * quan);
                    quan = 1;
                }
                Session["total"] = total;
                theLabel.Text = "Total: $" + Math.Round(total, 2).ToString("N2");
                td.Controls.Add(theLabel);
                tr.Cells.Add(td);
                theTable.Rows.Add(tr);


                Button submit = new Button();
                td = new TableCell();
                tr = new TableRow();
                submit.Text = "Confirm Order";
                submit.CssClass = "btn btn-success";
                submit.Click += submitClick;
                td.Controls.Add(submit);
                tr.Cells.Add(td);

                theTable.Rows.Add(tr);

                pnlOut.Controls.Add(theTable);
            }
            else
            {
                Response.Redirect("ViewCart.aspx");
            }
        }

        protected void submitClick(object sender, EventArgs e)
        {

            if (txtCustID.Text != null)
            {
                Cart theCart = (Cart)Session["theCart"];
                OrderTier theOrderTier = new OrderTier();
                OrderDetailTier theDetailTier = new OrderDetailTier();
                OrderDetail theDetail;
                Order theOrder = new Order();
                if (txtCustID.Text != null) {
                    theOrder.custID = int.Parse(txtCustID.Text);
                }
                theOrder.cartID = theCart.cartID;
                theOrder.total = (double)Session["total"];
                theOrder.dateOfSale = DateTime.Now;
                theOrder.taxRate = 8.625;
                if (txtDiscount.Text != null)
                {
                    theOrder.discount = double.Parse(txtDiscount.Text);
                }
                bool success = false;
                if (theOrderTier.insertOrder(theOrder))
                {
                    theOrder = theOrderTier.getLastOrder();
                    foreach (Product item in theCart.products)
                    {
                        theDetail = new OrderDetail();
                        theDetail.orderID = theOrder.orderID;
                        theDetail.prodID = item.prodID;
                        theDetail.quantitySold = int.Parse(theCart.quantities[theCart.products.IndexOf(item)].ToString());
                        if (theDetailTier.insertOrderDetail(theDetail))
                        {
                            success = true;
                        }

                    }
                }
                else
                {
                    success = false;
                }

                if (success)
                {
                    Response.Redirect("/SuccessfulSubmission.aspx");
                    Session["theCart"] = null;
                }
                else
                {
                    Response.Redirect("/FailedSubmission.aspx");
                }




            }
        }
    }
}