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
    public partial class OrderConfirmation : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["theOrder"] != null)
            {
                Order theOrder = (Order)Session["theOrder"];
                lblCustID.Text = theOrder.custID.ToString();
                lblCartID.Text = theOrder.cartID.ToString();
                lblTotal.Text = "$" + Math.Round(theOrder.total, 2).ToString();
                lblDateOfSale.Text = theOrder.dateOfSale.ToShortDateString();
                lblTaxRate.Text = Math.Round(theOrder.taxRate, 3).ToString() + "%";
                lblDiscount.Text = Math.Round(theOrder.discount, 2).ToString() + "%";
            }else
            {
                Response.Redirect("/Admin/InsertOrder.aspx");
            }
        }
        
        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            OrderTier theTier = new OrderTier();
            Order theOrder = (Order)Session["theOrder"];

            if (theTier.insertOrder(theOrder))
            {
                Response.Redirect("/SuccessfulSubmission.aspx");
            }
            else
            {
                Response.Redirect("/FailedSubmission.aspx");
            }
        }

        protected void btnCancel_Click(object sender, EventArgs e)
        {
            Response.Redirect("/Admin/InsertOrder.aspx");
        }
    }
}