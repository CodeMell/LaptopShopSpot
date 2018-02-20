<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="ProductConfirmation.aspx.cs" Inherits="ite264project.Admin.ProductConfirmation" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="body" runat="server">
    <div class="panel panel-danger">
        <div class="panel-heading text-center">
            <h1>Insert Product Confirmation</h1>
            <p>Please review this information before submitting</p>
        </div>
        <div class="panel-body">

            <div class="row">
                <div class="col-md-2 col-lg-2">
                    <label>Product Name</label>
                </div>
                <div class="col-md-10 col-lg-10">
                    <asp:Label runat ="server" ID="lblProdName" Text=""></asp:Label>
                </div>
            </div>

            <div class="row">
                <div class="col-md-2 col-lg-2">
                    <label>Description</label>
                </div>
                <div class="col-md-10 col-lg-10">
                    <asp:Label runat ="server" ID="lblDesc" Text=""></asp:Label>
                </div>
            </div>

            <div class="row">
                <div class="col-md-2 col-lg-2">
                    <label>Price</label>
                </div>
                <div class="col-md-10 col-lg-10">
                    <asp:Label runat ="server" ID="lblPrice" Text=""></asp:Label>
                </div>
            </div>

            <div class="row">
                <div class="col-md-2 col-lg-2">
                    <label>Inventory</label>
                </div>
                <div class="col-md-10 col-lg-10">
                    <asp:Label runat ="server" ID="lblInventory" Text=""></asp:Label>
                </div>
            </div>

            <div class="row">
                <div class="col-md-2 col-lg-2">
                    <label>Image</label>
                </div>
                <div class="col-md-10 col-lg-10">
                    <asp:Image ID="prodImg" runat="server" Visible="false" />
                </div>
            </div>

            <div class="row text-center">
                <asp:Button ID="btnCancel" runat="server" Text="Cancel" CssClass="btn btn-danger" OnClick="btnCancel_Click" />
                <asp:Button ID="btnOkay" runat="server" Text="Okay" CssClass="btn btn-success" OnClick="btnOkay_Click"/>
            </div>

        </div>
    </div>
</asp:Content>
