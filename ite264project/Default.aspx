<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="ite264project.Default" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style type="text/css">
        .prodImg{
            max-width: 200px;
            max-height: 200px;

        }

        body{
            text-align: center;    
        }

        .prodPanel{
            padding: 10px 20px 10px 20px; 
        }

        .prodHeader{
            background-color: black;
            color: white;
        }

        tr{
            margin-top: 15px;
            margin-bottom: 15px;
            padding-top: 15px;
            padding-top: 15px;
        }

        


    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="body" runat="server">
    <div class="panel panel-heading container-fluid">
        <h1 style="font-size: 5em">Laptop Shop Spot</h1>
    </div>
    <div class="panel prodPanel container-fluid">
        <div class="panel panel-heading prodHeader" >
            <h2>All Products</h2>
        </div>
        <div class="col-md-12 col-sm-12 col-lg-12">
            <asp:Panel ID="pnlProducts" runat="server"></asp:Panel>
        </div>
    </div>
</asp:Content>
