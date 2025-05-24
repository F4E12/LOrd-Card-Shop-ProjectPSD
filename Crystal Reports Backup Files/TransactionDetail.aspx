<%@ Page Title="Transaction Detail" Language="C#" MasterPageFile="~/Views/Navbar.Master" AutoEventWireup="true" CodeBehind="TransactionDetail.aspx.cs" Inherits="ProjectPSD.Views.TransactionDetail" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
    Transaction Detail
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <h2>Transaction Detail</h2>

    <asp:GridView ID="TransactionDetailGV" runat="server" AutoGenerateColumns="False">
        <Columns>
            <asp:BoundField DataField="TransactionID" HeaderText="Transaction ID" />
            <asp:BoundField DataField="CardID" HeaderText="Card ID" />
            <asp:BoundField DataField="CardName" HeaderText="Card Name" />
            <asp:BoundField DataField="CardPrice" HeaderText="Card Price" DataFormatString="{0:C}" />
            <asp:BoundField DataField="Quantity" HeaderText="Quantity" />
        </Columns>
    </asp:GridView>

    <br />
    <asp:Button ID="backBtn" runat="server" Text="Back to History" OnClick="backBtn_Click" />
</asp:Content>
