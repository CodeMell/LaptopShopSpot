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
    public partial class CustomerInfo : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            CustomerTier theTier = new CustomerTier();
            List<Customer> theList;
            Table theTable = new Table();
            theTable.CssClass = "table-striped";
            theTable.Style.Add("margin", "10px auto 10px auto");
            theTable.Style.Add("width", "auto");
            TableRow tr = new TableRow();
            TableCell td;
            theList = theTier.getAllCustomers();
            Button delete;
            Button edit;

            TableHeaderCell th = new TableHeaderCell();
            Label theLabel = new Label();
            theLabel.Text = "Cust ID";
            th.Controls.Add(theLabel);
            tr.Cells.Add(th);

            th = new TableHeaderCell();
            theLabel = new Label();
            theLabel.Text = "First Name";
            th.Controls.Add(theLabel);
            tr.Cells.Add(th);

            th = new TableHeaderCell();
            theLabel = new Label();
            theLabel.Text = "Last Name";
            th.Controls.Add(theLabel);
            tr.Cells.Add(th);

            th = new TableHeaderCell();
            theLabel = new Label();
            theLabel.Text = "Email";
            th.Controls.Add(theLabel);
            tr.Cells.Add(th);

            th = new TableHeaderCell();
            theLabel = new Label();
            theLabel.Text = "Address";
            th.Controls.Add(theLabel);
            tr.Cells.Add(th);

            th = new TableHeaderCell();
            theLabel = new Label();
            theLabel.Text = "Address 2";
            th.Controls.Add(theLabel);
            tr.Cells.Add(th);

            th = new TableHeaderCell();
            theLabel = new Label();
            theLabel.Text = "City";
            th.Controls.Add(theLabel);
            tr.Cells.Add(th);

            th = new TableHeaderCell();
            theLabel = new Label();
            theLabel.Text = "State";
            th.Controls.Add(theLabel);
            tr.Cells.Add(th);

            th = new TableHeaderCell();
            theLabel = new Label();
            theLabel.Text = "Zip";
            th.Controls.Add(theLabel);
            tr.Cells.Add(th);

            theTable.Rows.Add(tr);

            foreach(Customer cust in theList)
            {
                tr = new TableRow();

                td = new TableCell();
                theLabel = new Label();
                theLabel.Text = cust.custID.ToString();
                td.Controls.Add(theLabel);
                tr.Cells.Add(td);

                td = new TableCell();
                theLabel = new Label();
                theLabel.Text = cust.firstName;
                td.Controls.Add(theLabel);
                tr.Cells.Add(td);

                td = new TableCell();
                theLabel = new Label();
                theLabel.Text = cust.lastName;
                td.Controls.Add(theLabel);
                tr.Cells.Add(td);

                td = new TableCell();
                theLabel = new Label();
                theLabel.Text = cust.email;
                td.Controls.Add(theLabel);
                tr.Cells.Add(td);

                td = new TableCell();
                theLabel = new Label();
                theLabel.Text = cust.address;
                td.Controls.Add(theLabel);
                tr.Cells.Add(td);

                td = new TableCell();
                theLabel = new Label();
                theLabel.Text = cust.address2;
                td.Controls.Add(theLabel);
                tr.Cells.Add(td);

                td = new TableCell();
                theLabel = new Label();
                theLabel.Text = cust.city;
                td.Controls.Add(theLabel);
                tr.Cells.Add(td);

                td = new TableCell();
                theLabel = new Label();
                theLabel.Text = cust.state;
                td.Controls.Add(theLabel);
                tr.Cells.Add(td);

                td = new TableCell();
                theLabel = new Label();
                theLabel.Text = cust.zip.ToString();
                td.Controls.Add(theLabel);
                tr.Cells.Add(td);

                td = new TableCell();
                delete = new Button();
                delete.Text = "Delete";
                delete.ID = cust.custID.ToString();
                delete.Click += deleteClick;
                td.Controls.Add(delete);
                edit = new Button();
                edit.Text = "Edit";
                edit.ID = cust.custID.ToString() + "a";
                edit.Click += editClick;
                td.Controls.Add(edit);
                tr.Cells.Add(td);

                theTable.Rows.Add(tr);

            }
            pnlOut.Controls.Add(theTable);
        }

        protected void deleteClick(object sender, EventArgs e)
        {
            Button theButton = (Button)sender;
            CustomerTier theTier = new CustomerTier();
            int custID = int.Parse(theButton.ID);

            theTier.deleteCustomer(custID);

            Response.Redirect("/Admin/CustomerInfo.aspx");
        }

        protected void editClick(object sender, EventArgs e)
        {
            Button theButton = (Button)sender;
            CustomerTier theTier = new CustomerTier();
            string id = theButton.ID.Remove(theButton.ID.IndexOf('a'), 1);
            int custID = int.Parse(id);

            Session["CustomerID"] = custID;

            Response.Redirect("/Admin/ModifyCustomer.aspx");
        }
    }
}