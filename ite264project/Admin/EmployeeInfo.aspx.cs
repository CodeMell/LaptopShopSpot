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
    public partial class EmployeeInfo : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            EmployeeTier theTier = new EmployeeTier();
            List<Employee> theList;
            Table theTable = new Table();
            theTable.CssClass = "table-striped";
            theTable.Style.Add("margin", "10px auto 10px auto");
            theTable.Style.Add("width", "auto");
            TableRow tr = new TableRow();
            TableCell td;
            theList = theTier.getAllEmployees();
            Button delete;
            Button edit;

            TableHeaderCell th = new TableHeaderCell();
            Label theLabel = new Label();
            theLabel.Text = "Employee ID";
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

            th = new TableHeaderCell();
            theLabel = new Label();
            theLabel.Text = "Hire Date";
            th.Controls.Add(theLabel);
            tr.Cells.Add(th);

            th = new TableHeaderCell();
            theLabel = new Label();
            theLabel.Text = "Termination Date";
            th.Controls.Add(theLabel);
            tr.Cells.Add(th);

            theTable.Rows.Add(tr);

            foreach (Employee emp in theList)
            {
                tr = new TableRow();

                td = new TableCell();
                theLabel = new Label();
                theLabel.Text = emp.empID.ToString();
                td.Controls.Add(theLabel);
                tr.Cells.Add(td);

                td = new TableCell();
                theLabel = new Label();
                theLabel.Text = emp.firstName.ToString();
                td.Controls.Add(theLabel);
                tr.Cells.Add(td);

                td = new TableCell();
                theLabel = new Label();
                theLabel.Text = emp.lastName.ToString();
                td.Controls.Add(theLabel);
                tr.Cells.Add(td);

                td = new TableCell();
                theLabel = new Label();
                theLabel.Text = emp.email.ToString();
                td.Controls.Add(theLabel);
                tr.Cells.Add(td);

                td = new TableCell();
                theLabel = new Label();
                theLabel.Text = emp.address.ToString();
                td.Controls.Add(theLabel);
                tr.Cells.Add(td);

                td = new TableCell();
                theLabel = new Label();
                theLabel.Text = emp.address2.ToString();
                td.Controls.Add(theLabel);
                tr.Cells.Add(td);

                td = new TableCell();
                theLabel = new Label();
                theLabel.Text = emp.city.ToString();
                td.Controls.Add(theLabel);
                tr.Cells.Add(td);

                td = new TableCell();
                theLabel = new Label();
                theLabel.Text = emp.state.ToString();
                td.Controls.Add(theLabel);
                tr.Cells.Add(td);

                td = new TableCell();
                theLabel = new Label();
                theLabel.Text = emp.zip.ToString();
                td.Controls.Add(theLabel);
                tr.Cells.Add(td);

                td = new TableCell();
                theLabel = new Label();
                theLabel.Text = emp.hireDate.ToShortDateString();
                td.Controls.Add(theLabel);
                tr.Cells.Add(td);

                td = new TableCell();
                theLabel = new Label();
                theLabel.Text = emp.termDate.ToShortDateString();
                td.Controls.Add(theLabel);
                tr.Cells.Add(td);

                td = new TableCell();
                delete = new Button();
                delete.Text = "Delete";
                delete.ID = emp.empID.ToString();
                delete.Click += deleteClick;
                td.Controls.Add(delete);
                edit = new Button();
                edit.Text = "Edit";
                edit.ID = emp.empID.ToString() + "a";
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
            EmployeeTier theTier = new EmployeeTier();
            int empID = int.Parse(theButton.ID);

            theTier.deleteEmployee(empID);

            Response.Redirect("/Admin/EmployeeInfo.aspx");

        }

        protected void editClick(object sender, EventArgs e)
        {
            Button theButton = (Button)sender;
            EmployeeTier theTier = new EmployeeTier();
            string id = theButton.ID.Remove(theButton.ID.IndexOf("a"), 1);
            Session["EmployeeID"] = int.Parse(id);

            Response.Redirect("/Admin/ModifyEmployee.aspx");
        }
    }
}