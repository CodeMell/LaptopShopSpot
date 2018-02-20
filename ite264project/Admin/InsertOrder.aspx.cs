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
    public partial class InsertOrder : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            OrderTier theTier = new OrderTier();
            Order theOrder = new Order();
            theOrder.custID = int.Parse(txtCustID.Text);
            theOrder.cartID = Guid.Parse(txtCartID.Text);
            theOrder.total = double.Parse(txtTotal.Text);
            if(calDateOfSale.SelectedDate != null)
            {
                theOrder.dateOfSale = calDateOfSale.SelectedDate;
            }
            theOrder.taxRate = double.Parse(txtTaxRate.Text);
            theOrder.discount = double.Parse(txtDiscount.Text);

            Session["theOrder"] = theOrder;

            Response.Redirect("/Admin/OrderConfirmation.aspx");
        }

        protected void btnCancel_Click(object sender, EventArgs e)
        {
            Response.Redirect("/Admin/AdminPage.aspx");
        }

        protected void btnDate1_Click(object sender, EventArgs e)
        {
            if (!calDateOfSale.Visible)
            {
                calDateOfSale.Visible = true;
            }
            else
            {
                calDateOfSale.Visible = false;
            }
        }

        protected void calDateOfSale_SelectionChanged(object sender, EventArgs e)
        {
            lblDateOfSale.Text = calDateOfSale.SelectedDate.ToShortDateString();
            calDateOfSale.Visible = false;
        }
    }
}