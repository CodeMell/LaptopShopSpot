<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="OrderConfirmation.aspx.cs" Inherits="ite264project.Admin.OrderConfirmation" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="body" runat="server">
    <div class="panel panel-sucess">
        <div class="panel-header text-center">
            <h1>Confirm Order Information</h1>
        </div>
        <div class="panel-body">
            <div class="row">
                <div class="col-md-2 col-lg-2">
                    <label>Customer ID</label>
                </div>
                <div class="col-md-10 col-lg-10">
                    <asp:Label runat="server" ID="lblCustID" Text=""></asp:Label>
                </div>
            </div>
            <div class="row">
                <div class="col-md-2 col-lg-2">
                    <label>Cart ID</label>
                </div>
                <div class="col-md-10 col-lg-10">
                    <asp:Label runat="server" ID="lblCartID" Text=""></asp:Label>
                </div>
            </div>

            <div class="row">
                <div class="col-md-2 col-lg-2">
                    <label>Total</label>
                </div>
                <div class="col-md-10 col-lg-10">
                    <asp:Label runat="server" ID="lblTotal" Text=""></asp:Label>
                </div>
            </div>

            <div class="row">
                <div class="col-md-2 col-lg-2">
                    <label>Date of Sale</label>
                </div>
                <div class="col-md-10 col-lg-10">
                    <asp:Label runat="server" ID="lblDateOfSale" Text=""></asp:Label>
                </div>
            </div>

            <div class="row">
                <div class="col-md-2 col-lg-2">
                    <label>Tax Rate</label>
                </div>
                <div class="col-md-10 col-lg-10">
                    <asp:Label runat="server" ID="lblTaxRate" Text=""></asp:Label>
                </div>
            </div>

            <div class="row">
                <div class="col-md-2 col-lg-2">
                    <label>Discount</label>
                </div>
                <div class="col-md-10 col-lg-10">
                    <asp:Label runat="server" ID="lblDiscount" Text=""></asp:Label>
                </div>
            </div>
            
            <div class="row text-center">
                <asp:Button ID="btnSubmit" runat="server" Text="Submit" CssClass="btn btn-success" OnClick="btnSubmit_Click" />
                <asp:Button ID="btnCancel" runat="server" Text="Cancel" CssClass="btn btn-danger" OnClick="btnCancel_Click" />
            </div>
        </div>
    </div>
</asp:Content>
