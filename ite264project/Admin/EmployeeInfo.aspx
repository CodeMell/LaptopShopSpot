<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="EmployeeInfo.aspx.cs" Inherits="ite264project.Admin.EmployeeInfo" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style type="text/css">
        td{
            padding: 10px;
        }
        th{
            padding: 10px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="body" runat="server">
    <div class="panel panel-success">
        <h1 class="panel-heading">Employee Information</h1>
        
        <asp:Panel cssClass="panel-body" ID="pnlOut" runat="server"></asp:Panel>
    </div>
</asp:Content>
