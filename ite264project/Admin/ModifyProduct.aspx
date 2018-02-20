<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="ModifyProduct.aspx.cs" Inherits="ite264project.Admin.ModifyProduct" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style type="text/css">
        .prodImg{
            max-width: 200px;
            max-height: 200px;

        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="body" runat="server">
    <div class="panel panel-success">
        <div class="panel-header text-center">
            <h1>Edit Product Information</h1>
        </div>
        <div class="panel-body">
            <div class="form-group">
                <div><label id ="idLabel" runat ="server"></label></div>
                <label>Product Name</label>
                <asp:TextBox ID="txtProdName" runat="server" CssClass="form-control"></asp:TextBox>
                <label>Description</label>
                <asp:TextBox ID="txtProdDesc" runat="server" CssClass="form-control"></asp:TextBox>
                <label>Image</label>
                <asp:Image ID="prodImg" runat="server" CssClass="img-thumbnail prodImg"/>
                <asp:FileUpload ID="newImg" runat="server" CssClass="form-control"/>
                <label>Price</label>
                <asp:TextBox ID="txtPrice" runat="server" CssClass="form-control"></asp:TextBox>
                <label>Inventory</label>
                <asp:TextBox ID="txtInventory" runat="server" CssClass="form-control"></asp:TextBox>
            </div>
            <div class="form-group text-center">
                <asp:Button ID="btnSubmit" runat="server" Text="Submit" CssClass="btn btn-success" OnClick="btnSubmit_Click" />
                <asp:Button ID="btnCancel" runat="server" Text="Cancel" CssClass="btn btn-danger" OnClick="btnCancel_Click" />
            </div>
        </div>
    </div>
</asp:Content>
