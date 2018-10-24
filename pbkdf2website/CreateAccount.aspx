<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="CreateAccount.aspx.cs" Inherits="UserCreate" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <!-- Robert Sean McDonald 10/23/18 -->
        <div class="jumbotron d-inline-flex flex-column col-lg-4 offset-4">
            <strong>Create Account</strong><br />
            <asp:TextBox ID="txtFirstName" runat="server" placeholder="First Name" CssClass=" p-1 m-2"></asp:TextBox>
            <asp:TextBox ID="txtLastName" runat="server" placeholder="Last Name" CssClass=" p-1 m-2"></asp:TextBox>
            <asp:TextBox ID="txtUsername" runat="server" placeholder ="Username" CssClass=" p-1 m-2 "></asp:TextBox>
            <asp:TextBox ID="txtPassword" runat="server" TextMode="Password" placeholder="Password" CssClass="p-1 m-2"></asp:TextBox>
            <br />
            <asp:Button ID="btnSubmit" runat="server" OnClick="btnSubmit_Click" Text="Submit" CssClass="btn-success" />
            <br />
            <asp:Label ID="lblStatus" runat="server" CssClass="text-info"></asp:Label>
            <br />
            <asp:LinkButton ID="lnkAnother" runat="server" OnClick="lnkAnother_Click" Visible="False">Create Another</asp:LinkButton>
        </div>
</asp:Content>

