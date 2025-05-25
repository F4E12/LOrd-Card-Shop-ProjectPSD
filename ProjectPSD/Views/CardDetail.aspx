<%@ Page Title="Card Detail" Language="C#" MasterPageFile="~/Views/Navbar.Master" AutoEventWireup="true" CodeBehind="CardDetail.aspx.cs" Inherits="ProjectPSD.Views.CardDetail" %>

<asp:Content ID="HeadContent" ContentPlaceHolderID="TitleContent" runat="server">
    Card Detail
</asp:Content>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <h1>Card Detail Page</h1>
    <div style="margin-top:20px">
        <asp:Label ID="NameDisplay" runat="server" Text="Name: " Font-Bold="true" />
        <asp:Label ID="nameLbl" runat="server" /><br /><br />

        <asp:Label ID="PriceDisplay" runat="server" Text="Price: " Font-Bold="true" />
        <asp:Label ID="priceLbl" runat="server" /><br /><br />

        <asp:Label ID="TypeDisplay" runat="server" Text="Type: " Font-Bold="true" />
        <asp:Label ID="cardTypeLbl" runat="server" /><br /><br />

        <asp:Label ID="DescDisplay" runat="server" Text="Description: " Font-Bold="true" />
        <asp:Label ID="cardDescLbl" runat="server" /><br /><br />

        <asp:Button ID="backBtn" runat="server" Text="Back" OnClick="backBtn_Click" CssClass="btn btn-primary" />
    </div>
</asp:Content>
