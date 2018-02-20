using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ite264project.DataModel;
using ite264project.DBClasses;

namespace ite264project.Admin
{
    public partial class OrderDetails : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["OrderID"] != null)
            {
                int orderID = (int)Session["OrderID"];
                OrderDetailTier theDetailTier = new OrderDetailTier();
                ProductTier theProductTier = new ProductTier();
                Product theProduct;
                List<OrderDetail> theDetailList = theDetailTier.getFullOrder(orderID);
                Table theTable = new Table();
                theTable.CssClass = "table-striped";
                theTable.Style.Add("margin", "10px auto 10px auto");
                theTable.Style.Add("width", "auto");
                TableRow tr = new TableRow();
                TableCell td = new TableCell();
                TableHeaderRow th = new TableHeaderRow();
                Image theImage;
                Button delete;

                Label theLabel = new Label();
                theLabel.Text = "Order ID: " + orderID.ToString();
                td.Controls.Add(theLabel);
                th.Cells.Add(td);
                theTable.Rows.Add(th);

                tr = new TableRow();
                td = new TableCell();
                theLabel = new Label();
                theLabel.Text = "Product ID";
                td.Controls.Add(theLabel);
                tr.Cells.Add(td);

                theLabel = new Label();
                td = new TableCell();
                theLabel.Text = "Product Name";
                td.Controls.Add(theLabel);
                tr.Cells.Add(td);

                theLabel = new Label();
                td = new TableCell();
                theLabel.Text = "Product Description";
                td.Controls.Add(theLabel);
                tr.Cells.Add(td);

                theLabel = new Label();
                td = new TableCell();
                theLabel.Text = "Product Image";
                td.Controls.Add(theLabel);
                tr.Cells.Add(td);

                theLabel = new Label();
                td = new TableCell();
                theLabel.Text = "Qauntity";
                td.Controls.Add(theLabel);
                tr.Cells.Add(td);

                theLabel = new Label();
                td = new TableCell();
                theLabel.Text = "Price";
                td.Controls.Add(theLabel);
                tr.Cells.Add(td);

                theTable.Rows.Add(tr);

                if (theDetailList != null)
                {
                    foreach (OrderDetail item in theDetailList)
                    {
                        theProduct = new Product();
                        theProduct = theProductTier.getProductById(item.prodID);

                        tr = new TableRow();

                        theLabel = new Label();
                        td = new TableCell();
                        theLabel.Text = theProduct.prodID.ToString();
                        td.Controls.Add(theLabel);
                        tr.Cells.Add(td);

                        theLabel = new Label();
                        td = new TableCell();
                        theLabel.Text = theProduct.prodName.ToString();
                        td.Controls.Add(theLabel);
                        tr.Cells.Add(td);

                        theLabel = new Label();
                        td = new TableCell();
                        theLabel.Text = theProduct.prodDesc.ToString();
                        td.Controls.Add(theLabel);
                        tr.Cells.Add(td);

                        theImage = new Image();
                        td = new TableCell();
                        theImage.ImageUrl = "/Handlers/imgHandler.ashx?ID=" + theProduct.prodID;
                        theImage.CssClass = "img-thumbnail prodImg";
                        td.Controls.Add(theImage);
                        tr.Cells.Add(td);

                        theLabel = new Label();
                        td = new TableCell();
                        theLabel.Text = item.quantitySold.ToString();
                        td.Controls.Add(theLabel);
                        tr.Cells.Add(td);

                        theLabel = new Label();
                        td = new TableCell();
                        theLabel.Text = "$" + Math.Round(theProduct.price, 2).ToString("N2");
                        td.Controls.Add(theLabel);
                        tr.Cells.Add(td);

                        delete = new Button();
                        td = new TableCell();
                        delete.Text = "Delete";
                        delete.CssClass = "btn btn-danger";
                        delete.ID = item.orderID + " " + item.prodID;
                        delete.Click += deleteClick;
                        td.Controls.Add(delete);
                        tr.Cells.Add(td);

                        theTable.Rows.Add(tr);
                    }
                    pnlDetails.Controls.Add(theTable);
                }

            }
            else
            {
                Response.Redirect("/Admin/OrderInfo.aspx");
            }
        }

        protected void deleteClick(object sender, EventArgs e)
        {
            Button btn = (Button)sender;
            OrderDetailTier theTier = new OrderDetailTier();
            string id = btn.ID;
            string[] ids = id.Split(' ');
            theTier.deleteOrderDetail(int.Parse(ids[0]), int.Parse(ids[1]));
        }
    }
}