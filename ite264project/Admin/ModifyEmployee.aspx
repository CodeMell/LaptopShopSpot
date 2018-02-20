<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="ModifyEmployee.aspx.cs" Inherits="ite264project.Admin.ModifyEmployee" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="body" runat="server">
    <div class="panel panel-success">
        <div class="panel-header text-center">
            <h1>Edit Employee Information</h1>
        </div>
        <div class="panel-body">
            <div class="form-group">
                <div><label id ="idLabel" runat ="server"></label></div>
                <label>First Name</label>
                <asp:TextBox ID="txtFirstName" runat="server" CssClass="form-control"></asp:TextBox>
                <label>Last Name</label>
                <asp:TextBox ID="txtLastName" runat="server" CssClass="form-control"></asp:TextBox>
                <label>Email</label>
                <asp:TextBox ID="txtEmail" runat="server" CssClass="form-control"></asp:TextBox>
                <label>Address</label>
                <asp:TextBox ID="txtAddress" runat="server" CssClass="form-control"></asp:TextBox>
                <label>Address2</label>
                <asp:TextBox ID="txtAddress2" runat="server" CssClass="form-control"></asp:TextBox>
                <label>City</label>
                <asp:TextBox ID="txtCity" runat="server" CssClass="form-control"></asp:TextBox>
                <label>State</label>
                <asp:TextBox ID="txtState" runat="server" CssClass="form-control"></asp:TextBox>
                <label>Zip</label>
                <asp:TextBox ID="txtZip" runat="server" CssClass="form-control"></asp:TextBox>
                <label>Hire Date</label>
                <asp:Label ID="lblHireDate" runat="server" Text=""></asp:Label>
                <div><asp:Button ID="btnDate1" runat="server" Text="Enter Date" OnClick="btnDate1_Click" /></div>
                <div><asp:Calendar ID="calHireDate" runat="server" OnSelectionChanged="calHireDate_SelectionChanged" Visible="false"></asp:Calendar></div>
                <label>Termination Date</label>
                <asp:Label ID="lblTermDate" runat="server" Text="" Width="200px"></asp:Label>
                <div><asp:Button ID="btnDate2" runat="server" Text="Enter Date" OnClick="btnDate2_Click" /></div>
                <div><asp:Calendar ID="calTermDate" runat="server" onSelectionChanged="calTermDate_SelectionChanged" Visible="false"></asp:Calendar></div>

            </div>
            <div class="form-group text-center">
                <asp:Button ID="btnSubmit" runat="server" Text="Submit" CssClass="btn btn-success" OnClick="btnSubmit_Click" />
                <asp:Button ID="btnCancel" runat="server" Text="Cancel" CssClass="btn btn-danger" OnClick="btnCancel_Click" />
            </div>
        </div>
    </div>
</asp:Content>
