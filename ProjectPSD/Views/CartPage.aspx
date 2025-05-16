<%@ Page Title="Cart Page" Language="C#" MasterPageFile="~/Views/Navbar.master" AutoEventWireup="true" CodeBehind="CartPage.aspx.cs" Inherits="ProjectPSD.Views.Cart" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
    Your Shopping Cart
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <h1>Your Shopping Cart!</h1>

    <asp:GridView ID="CartGv" runat="server" AutoGenerateColumns="False">
        <Columns>
            <asp:BoundField DataField="CardName" HeaderText="Card Name" SortExpression="CardName" />
            <asp:BoundField DataField="CardPrice" HeaderText="Card Price" SortExpression="CardPrice" />
            <asp:BoundField DataField="CardType" HeaderText="Card Type" SortExpression="CardType" />
            <asp:BoundField DataField="CardDesc" HeaderText="Card Description" SortExpression="CardDesc" />
            <asp:BoundField DataField="Quantity" HeaderText="Quantity" SortExpression="Quantity" />
        </Columns>
    </asp:GridView>

    <br />
    <asp:Button ID="CheckOutBtn" runat="server" Text="Check Out" OnClick="CheckOutBtn_Click1" />
</asp:Content>
