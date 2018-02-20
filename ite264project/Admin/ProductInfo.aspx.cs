using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ite264project.DBClasses;
using ite264project.DataModel;

namespace ite264project.Admin
{
    public partial class ProductInfo : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            ProductTier theTier = new ProductTier();
            List<Product> theList = theTier.getAllProducts();
            Table theTable = new Table();
            theTable.CssClass = "table-striped";
            theTable.Style.Add("margin", "10px auto 10px auto");
            theTable.Style.Add("width", "auto");
            TableRow tr = new TableRow();
            TableCell td;
            Button delete;
            Button edit;

            TableHeaderCell th = new TableHeaderCell();
            Label theLabel = new Label();
            theLabel.Text = "Product ID";
            th.Controls.Add(theLabel);
            tr.Cells.Add(th);

            th = new TableHeaderCell();
            theLabel = new Label();
            theLabel.Text = "Name";
            th.Controls.Add(theLabel);
            tr.Cells.Add(th);

            th = new TableHeaderCell();
            theLabel = new Label();
            theLabel.Text = "Description";
            th.Controls.Add(theLabel);
            tr.Cells.Add(th);

            th = new TableHeaderCell();
            theLabel = new Label();
            theLabel.Text = "Image";
            th.Controls.Add(theLabel);
            tr.Cells.Add(th);

            th = new TableHeaderCell();
            theLabel = new Label();
            theLabel.Text = "Price";
            th.Controls.Add(theLabel);
            tr.Cells.Add(th);

            th = new TableHeaderCell();
            theLabel = new Label();
            theLabel.Text = "Inventory";
            th.Controls.Add(theLabel);
            tr.Cells.Add(th);

            theTable.Rows.Add(tr);
            if (theList != null)
            {
                foreach (Product prod in theList)
                {
                    Session["theImage"] = prod.prodImg;
                    tr = new TableRow();

                    td = new TableCell();
                    theLabel = new Label();
                    theLabel.Text = prod.prodID.ToString();
                    td.Controls.Add(theLabel);
                    tr.Cells.Add(td);

                    td = new TableCell();
                    theLabel = new Label();
                    theLabel.Text = prod.prodName.ToString();
                    td.Controls.Add(theLabel);
                    tr.Cells.Add(td);

                    td = new TableCell();
                    theLabel = new Label();
                    theLabel.Text = prod.prodDesc.ToString();
                    td.Controls.Add(theLabel);
                    tr.Cells.Add(td);

                    td = new TableCell();
                    Image theImage = new Image();
                    theImage.ImageUrl = "/Handlers/imgHandler.ashx?ID=" + prod.prodID;
                    theImage.CssClass = "img-thumbnail prodImg";
                    td.Controls.Add(theImage);
                    tr.Cells.Add(td);

                    td = new TableCell();
                    theLabel = new Label();
                    theLabel.Text = "$" + Math.Round(prod.price, 2).ToString("N2");
                    td.Controls.Add(theLabel);
                    tr.Cells.Add(td);

                    td = new TableCell();
                    theLabel = new Label();
                    theLabel.Text = prod.inventory.ToString();
                    td.Controls.Add(theLabel);
                    tr.Cells.Add(td);

                    td = new TableCell();
                    delete = new Button();
                    delete.Text = "Delete";
                    delete.ID = prod.prodID.ToString();
                    delete.Click += deleteClick;
                    td.Controls.Add(delete);
                    edit = new Button();
                    edit.Text = "Edit";
                    edit.ID = prod.prodID.ToString() + "a";
                    edit.Click += editClick;
                    td.Controls.Add(edit);

                    tr.Cells.Add(td);

                    theTable.Rows.Add(tr);
                }
            }

            pnlOut.Controls.Add(theTable);

        }

        protected void deleteClick(object sender, EventArgs e)
        {
            Button theButton = (Button)sender;
            ProductTier theTier = new ProductTier();
            int prodID = int.Parse(theButton.ID);
            theTier.deleteProduct(prodID);

            Response.Redirect("/Admin/ProductInfo.aspx");
        }

        protected void editClick(object sender, EventArgs e)
        {
            Button theButton = (Button)sender;
            ProductTier theTier = new ProductTier();
            Session["ProductID"] = int.Parse(theButton.ID.Remove(theButton.ID.IndexOf("a"), 1));

            Response.Redirect("/Admin/ModifyProduct.aspx");
        }
    }
}