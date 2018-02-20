<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="InsertProduct.aspx.cs" Inherits="ite264project.Admin.InsertProduct" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="body" runat="server">
    <div class="panel panel-success">
        <div class="panel-header text-center">
            <h1>Insert Product</h1>
        </div>
        <div class="panel-body">
            <div class="form-group">
                <label>Product Name</label>
                <asp:TextBox ID="txtProdName" runat="server" CssClass="form-control"></asp:TextBox>
                <label>Description</label>
                <asp:TextBox ID="txtDesc" runat="server" CssClass="form-control"></asp:TextBox>
                <label>Price</label>
                <asp:TextBox ID="txtPrice" runat="server" CssClass="form-control"></asp:TextBox>
                <label>Inventory</label>
                <asp:TextBox ID="txtInv" runat="server" CssClass="form-control"></asp:TextBox>
                <label>Image</label>
                <asp:FileUpload ID="flUpload" runat="server" CssClass="form-control"/>
            </div>
            <div class="form-group text-center">
                <asp:Button ID="btnSubmit" runat="server" Text="Submit" CssClass="btn btn-success" OnClick="btnSubmit_Click" />
            </div>
        </div>
    </div>
</asp:Content>
