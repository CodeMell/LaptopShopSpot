<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Confirmation.aspx.cs" Inherits="ite264project.Confirmation" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="body" runat="server">
    <div class="panel panel-danger">
        <div class="panel-heading text-center">
            <h1>Registration Confirmation</h1>
            <p>Please review this information before submitting</p>
        </div>
        <div class="panel-body">
            <div class="row">
                <div class="col-md-2 col-lg-2">
                    <label>First Name</label>
                </div>
                <div class="col-md-10 col-lg-10">
                    <asp:Label runat ="server" ID="lblFirstName" Text=""></asp:Label>
                </div>
            </div>

            <div class="row">
                <div class="col-md-2 col-lg-2">
                    <label>Last Name</label>
                </div>
                <div class="col-md-10 col-lg-10">
                    <asp:Label runat ="server" ID="lblLastName" Text=""></asp:Label>
                </div>
            </div>

            <div class="row">
                <div class="col-md-2 col-lg-2">
                    <label>Email</label>
                </div>
                <div class="col-md-10 col-lg-10">
                    <asp:Label runat ="server" ID="lblEmail" Text=""></asp:Label>
                </div>
            </div>

            <div class="row">
                <div class="col-md-2 col-lg-2">
                    <label>Address</label>
                </div>
                <div class="col-md-10 col-lg-10">
                    <asp:Label runat ="server" ID="lblAddress" Text=""></asp:Label>
                </div>
            </div>

            <div class="row">
                <div class="col-md-2 col-lg-2">
                    <label>Address2</label>
                </div>
                <div class="col-md-10 col-lg-10">
                    <asp:Label runat ="server" ID="lblAddress2" Text=""></asp:Label>
                </div>
            </div>

            <div class="row">
                <div class="col-md-2 col-lg-2">
                    <label>City</label>
                </div>
                <div class="col-md-10 col-lg-10">
                    <asp:Label runat ="server" ID="lblCity" Text=""></asp:Label>
                </div>
            </div>

            <div class="row">
                <div class="col-md-2 col-lg-2">
                    <label>State</label>
                </div>
                <div class="col-md-10 col-lg-10">
                    <asp:Label runat ="server" ID="lblState" Text=""></asp:Label>
                </div>
            </div>

            <div class="row">
                <div class="col-md-2 col-lg-2">
                    <label>Zip</label>
                </div>
                <div class="col-md-10 col-lg-10">
                    <asp:Label runat ="server" ID="lblZip" Text=""></asp:Label>
                </div>
            </div>

            <div class="row text-center">
                <asp:Button ID="btnCancel" runat="server" Text="Cancel" CssClass="btn btn-danger" OnClick="btnCancel_Click" />
                <asp:Button ID="btnOkay" runat="server" Text="Okay" CssClass="btn btn-success" OnClick="btnOkay_Click"/>
            </div>

        </div>
    </div>
</asp:Content>
