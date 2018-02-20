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
    public partial class ModifyOrder : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if(Session["OrderID"] != null)
            {
                int id = (int)Session["OrderID"];
                OrderTier theTier = new OrderTier();
                Order theOrder = theTier.getOrderByID(id);
                idLabel.InnerText = "Order ID: " + theOrder.orderID;
                if (!IsPostBack)
                {
                    txtCartID.Text = theOrder.cartID.ToString();
                    txtCustID.Text = theOrder.custID.ToString();
                    txtTotal.Text = Math.Round(theOrder.total).ToString();
                    lblDateOfSale.Text = theOrder.dateOfSale.ToShortDateString();
                    txtTaxRate.Text = Math.Round(theOrder.taxRate, 3).ToString();
                    txtDiscount.Text = Math.Round(theOrder.discount, 2).ToString();
                }
            }
            else
            {
                Response.Redirect("/Admin/OrderInfo.aspx");
            }

        }

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            OrderTier theTier = new OrderTier();
            Order theOrder = new Order();
            theOrder.orderID = (int)Session["OrderID"];
            theOrder.custID = int.Parse(txtCustID.Text);
            theOrder.cartID = Guid.Parse(txtCartID.Text);
            if (txtTotal.Text.StartsWith("$"))
            {
                txtTotal.Text.Remove(0, 1);
            }
            theOrder.total = Convert.ToDouble(txtTotal.Text);
            if(calDateOfSale.SelectedDate != null)
            {
                theOrder.dateOfSale = calDateOfSale.SelectedDate;
            }
            //This is here because I was initially concatenating $ and % onto some of the fields but it kept giving me invalid format
            //exceptions even when I removed them before parsing.
            if (txtTaxRate.Text.EndsWith("%"))
            {
                txtTaxRate.Text.Remove(txtTaxRate.Text.IndexOf("%"), 1);
            }
            theOrder.taxRate = Convert.ToDouble(txtTaxRate.Text);
            if (txtDiscount.Text.EndsWith("%"))
            {
                txtDiscount.Text.Remove(txtDiscount.Text.IndexOf("%"), 1);
            }
            theOrder.discount = Convert.ToDouble(txtDiscount.Text);
            

            if (theTier.modifyOrder(theOrder))
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