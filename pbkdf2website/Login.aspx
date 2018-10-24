<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="Login.aspx.cs" Inherits="Login" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
        <div class="jumbotron d-inline-flex flex-column col-lg-4 offset-4">
            <!-- Robert Sean McDonald 10/23/18 -->
            <strong>Login</strong><br />
            <strong class="text-center text-info">Welcome!</strong>
            <asp:TextBox ID="txtUsername" runat="server" placeholder="Username" CssClass=" p-1 m-2"></asp:TextBox>
            <asp:TextBox ID="txtPassword" runat="server" TextMode="Password" placeholder="Password" CssClass="p-1 m-2"></asp:TextBox>
            <br />
            <asp:Button ID="btnLogin" runat="server" OnClick="btnLogin_Click" Text="Login" CssClass="btn-success" />
            <br />
            <asp:Label ID="lblStatus" runat="server" CssClass="text-info"></asp:Label>
        </div>
</asp:Content>

