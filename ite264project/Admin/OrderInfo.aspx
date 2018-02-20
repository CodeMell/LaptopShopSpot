<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="OrderInfo.aspx.cs" Inherits="ite264project.Admin.OrderInfo" %>
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
        <h1 class="panel-heading">All Order Information</h1>
        
        <asp:Panel cssClass="panel-body" ID="pnlOut" runat="server"></asp:Panel>
    </div>
</asp:Content>
