<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="OrderDetails.aspx.cs" Inherits="ite264project.Admin.OrderDetails" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style type="text/css">
        td{
            padding: 10px;
        }
        th{
            padding: 10px;
        }
        .prodImg{
            max-width: 200px;
            max-height: 200px;

        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="body" runat="server">
    <div class="panel panel-success">
        <h1 class="panel-heading">Order Details</h1>
        <asp:Panel cssClass="panel-body" ID="pnlDetails" runat="server"></asp:Panel>
    </div>
</asp:Content>
