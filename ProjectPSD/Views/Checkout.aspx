<%@ Page Title="Checkout" Language="C#" MasterPageFile="~/Views/Navbar.master" AutoEventWireup="true" CodeBehind="Checkout.aspx.cs" Inherits="ProjectPSD.Views.Checkout" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
    Checkout
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <h1>Check Out Page</h1>

    <asp:GridView ID="CheckOutGv" runat="server" AutoGenerateColumns="False">
        <Columns>
            <asp:BoundField DataField="CardName" HeaderText="Card Name" SortExpression="CardName" />
            <asp:BoundField DataField="CardPrice" HeaderText="Card Price" SortExpression="CardPrice" />
            <asp:BoundField DataField="CardType" HeaderText="Card Type" SortExpression="CardType" />
            <asp:BoundField DataField="CardDesc" HeaderText="Card Description" SortExpression="CardDesc" />
            <asp:BoundField DataField="Quantity" HeaderText="Quantity" SortExpression="Quantity" />
            <asp:BoundField DataField="TotalItemPrice" HeaderText="Total" DataFormatString="{0:C}" />
        </Columns>
    </asp:GridView>

    <asp:Label ID="totalLbl" runat="server" Font-Bold="true" Font-Size="Large" />
    <br />
    <br />

    <asp:Button ID="btnConfirmCheckout" runat="server" Text="Confirm Checkout" OnClick="btnConfirmCheckout_Click" />
</asp:Content>
