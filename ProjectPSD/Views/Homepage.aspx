<%@ Page Title="Home" Language="C#" MasterPageFile="~/Views/Navbar.master" AutoEventWireup="true" CodeBehind="Homepage.aspx.cs" Inherits="ProjectPSD.Views.Homepage" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
    Home
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <asp:Label ID="WelcomeLbl" runat="server" Font-Size="Large" />
</asp:Content>
