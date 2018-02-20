<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="AdminPage.aspx.cs" Inherits="ite264project.Admin.AdminPage" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="body" runat="server">
    <div class="panel col-lg-4 col-md-6 col-sm-12 menuBlock">
        <h1 class="panel-heading">View Information</h1>
        <a class="panel-body" href="/Admin/CustomerInfo.aspx">View Customers</a>
        <a class="panel-body"href="/Admin/EmployeeInfo.aspx">View Employees</a>
        <a class="panel-body"href="/Admin/ProductInfo.aspx">View Products</a>
        <a class="panel-body"href="/Admin/OrderInfo.aspx">View Orders</a>
    </div>

    <div class="panel col-lg-4 col-md-6 col-sm-12 menuBlock">
        <h1 class="panel-heading">Insert Information</h1>
        <a class="panel-body" href="/Registration.aspx">Insert Customers</a>
        <a class="panel-body"href="/Admin/EmployeeRegistration.aspx">Insert Employees</a>
        <a class="panel-body"href="/Admin/InsertProduct.aspx">Insert Products</a>
        <a class="panel-body"href="/Admin/InsertOrder.aspx">Insert Orders</a>
    </div>
</asp:Content>
