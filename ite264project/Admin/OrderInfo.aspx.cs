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
    public partial class OrderInfo : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            OrderTier theTier = new OrderTier();
            List<Order> theList = theTier.getAllOrders();
            Table theTable = new Table();
            theTable.CssClass = "table-striped";
            theTable.Style.Add("margin", "10px auto 10px auto");
            theTable.Style.Add("width", "auto");
            TableHeaderCell th;
            TableRow tr = new TableRow();
            TableCell td;
            Button delete;
            Button edit;
            Button details;

            th = new TableHeaderCell();
            Label theLabel = new Label();
            theLabel.Text = "Order ID";
            th.Controls.Add(theLabel);
            tr.Cells.Add(th);

            th = new TableHeaderCell();
            theLabel = new Label();
            theLabel.Text = "Customer ID";
            th.Controls.Add(theLabel);
            tr.Cells.Add(th);

            th = new TableHeaderCell();
            theLabel = new Label();
            theLabel.Text = "Cart ID";
            th.Controls.Add(theLabel);
            tr.Cells.Add(th);

            th = new TableHeaderCell();
            theLabel = new Label();
            theLabel.Text = "Total";
            th.Controls.Add(theLabel);
            tr.Cells.Add(th);

            th = new TableHeaderCell();
            theLabel = new Label();
            theLabel.Text = "Date of Sale";
            th.Controls.Add(theLabel);
            tr.Cells.Add(th);

            th = new TableHeaderCell();
            theLabel = new Label();
            theLabel.Text = "Tax Rate";
            th.Controls.Add(theLabel);
            tr.Cells.Add(th);

            th = new TableHeaderCell();
            theLabel = new Label();
            theLabel.Text = "Discount";
            th.Controls.Add(theLabel);
            tr.Cells.Add(th);

            theTable.Rows.Add(tr);

            if (theList != null)
            {
                foreach (Order item in theList)
                {
                    tr = new TableRow();

                    td = new TableCell();
                    theLabel = new Label();
                    theLabel.Text = item.orderID.ToString();
                    td.Controls.Add(theLabel);
                    tr.Cells.Add(td);

                    td = new TableCell();
                    theLabel = new Label();
                    theLabel.Text = item.custID.ToString();
                    td.Controls.Add(theLabel);
                    tr.Cells.Add(td);

                    td = new TableCell();
                    theLabel = new Label();
                    theLabel.Text = item.cartID.ToString();
                    td.Controls.Add(theLabel);
                    tr.Cells.Add(td);

                    td = new TableCell();
                    theLabel = new Label();
                    theLabel.Text = "$" + Math.Round(item.total, 2).ToString("N2");
                    td.Controls.Add(theLabel);
                    tr.Cells.Add(td);

                    td = new TableCell();
                    theLabel = new Label();
                    theLabel.Text = item.dateOfSale.ToShortDateString();
                    td.Controls.Add(theLabel);
                    tr.Cells.Add(td);

                    td = new TableCell();
                    theLabel = new Label();
                    theLabel.Text = Math.Round(item.taxRate, 3).ToString() + "%";
                    td.Controls.Add(theLabel);
                    tr.Cells.Add(td);

                    td = new TableCell();
                    theLabel = new Label();
                    theLabel.Text = Math.Round(item.discount, 2).ToString() + "%";
                    td.Controls.Add(theLabel);
                    tr.Cells.Add(td);

                    td = new TableCell();
                    delete = new Button();
                    delete.Text = "Delete";
                    delete.ID = item.orderID.ToString();
                    delete.Click += deleteClick;
                    td.Controls.Add(delete);
                    edit = new Button();
                    edit.Text = "Edit";
                    edit.ID = item.orderID.ToString() + "a";
                    edit.Click += editClick;
                    td.Controls.Add(edit);
                    tr.Cells.Add(td);
                    td = new TableCell();
                    details = new Button();
                    details.Text = "Details";
                    details.ID = item.orderID.ToString() + "b";
                    details.Click += detailsClick;
                    td.Controls.Add(details);
                    tr.Cells.Add(td);

                    theTable.Rows.Add(tr);

                }
            }

            pnlOut.Controls.Add(theTable);
        }

        protected void deleteClick(object sender, EventArgs e)
        {
            Button theButton = (Button)sender;
            OrderTier theTier = new OrderTier();
            OrderDetailTier theDetailTier = new OrderDetailTier();
            int orderID = int.Parse(theButton.ID);

            theTier.deleteOrder(orderID);
            theDetailTier.deleteFullOrder(orderID);

            Response.Redirect("/Admin/OrderInfo.aspx");
        }

        protected void editClick(object sender, EventArgs e)
        {
            Button theButton = (Button)sender;
            OrderTier theTier = new OrderTier();
            string id = theButton.ID.Remove(theButton.ID.IndexOf('a'), 1);
            int orderID = int.Parse(id);

            Session["OrderID"] = orderID;

            Response.Redirect("/Admin/ModifyOrder.aspx");
        }

        protected void detailsClick(object sender, EventArgs e)
        {
            Button theButton = (Button)sender;
            OrderTier theTier = new OrderTier();
            string id = theButton.ID.Remove(theButton.ID.IndexOf('b'), 1);
            int orderID = int.Parse(id);

            Session["OrderID"] = orderID;

            Response.Redirect("/Admin/OrderDetails.aspx");
        }
    }
}