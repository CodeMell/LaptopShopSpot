<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="OrderConfirmation.aspx.cs" Inherits="ite264project.OrderConfirmation" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="body" runat="server">
    <div class="panel panel-success">
        <h1 class="panel-heading">Confirm Order</h1>
        <div class="form-group">
            <label>Enter Your Customer ID</label>
            <asp:TextBox ID="txtCustID" runat="server" CssClass="form-control"></asp:TextBox>
            <label>Enter Your Discount</label>
            <asp:TextBox ID="txtDiscount" runat="server" CssClass="form-control"></asp:TextBox>
        </div>
        <asp:Panel cssClass="panel-body" ID="pnlOut" runat="server"></asp:Panel>
    </div>
</asp:Content>
