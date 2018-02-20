<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="InsertOrder.aspx.cs" Inherits="ite264project.Admin.InsertOrder" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="body" runat="server">
    <div class="panel">
        <div class="panel-header text-center">
            <h1>Insert Order Information</h1>
        </div>
        <div class="panel-body">
            <div class="form-group">
                <div><label id ="idLabel" runat ="server"></label></div>
                <label>Customer ID</label>
                <asp:TextBox ID="txtCustID" runat="server" CssClass="form-control"></asp:TextBox>
                <label>Cart ID</label>
                <asp:TextBox ID="txtCartID" runat="server" CssClass="form-control"></asp:TextBox>
                <label>Total</label>
                <asp:TextBox ID="txtTotal" runat="server" CssClass="form-control"></asp:TextBox>
                <label>Date Of Sale</label>
                <asp:Label ID="lblDateOfSale" runat="server"></asp:Label>
                <div><asp:Button ID="btnDate1" runat="server" Text="Enter Date" OnClick="btnDate1_Click" /></div>
                <asp:Calendar ID="calDateOfSale" runat="server" OnSelectionChanged="calDateOfSale_SelectionChanged" Visible="false"></asp:Calendar>
                <label>Tax Rate</label>
                <asp:TextBox ID="txtTaxRate" runat="server" CssClass="form-control"></asp:TextBox>
                <label>Discount</label>
                <asp:TextBox ID="txtDiscount" runat="server" CssClass="form-control"></asp:TextBox>
                
            </div>
            <div class="form-group text-center">
                <asp:Button ID="btnSubmit" runat="server" Text="Submit" CssClass="btn btn-success" OnClick="btnSubmit_Click" />
                <asp:Button ID="btnCancel" runat="server" Text="Cancel" CssClass="btn btn-danger" OnClick="btnCancel_Click" />
            </div>
        </div>
    </div>
</asp:Content>
