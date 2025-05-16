<%@ Page Title="Order Card" Language="C#" MasterPageFile="~/Views/Navbar.master" AutoEventWireup="true" CodeBehind="OrderCard.aspx.cs" Inherits="ProjectPSD.Views.OrderCard" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
    Order Card
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <asp:GridView ID="gvOrderCard" runat="server" AutoGenerateColumns="False" OnRowCommand="gvOrderCard_RowCommand">
        <Columns>
            <asp:BoundField DataField="CardID" HeaderText="Card ID" SortExpression="CardID" />
            <asp:BoundField DataField="CardName" HeaderText="Card Name" SortExpression="CardName" />
            <asp:BoundField DataField="CardPrice" HeaderText="Card Price" SortExpression="CardPrice" />
            <asp:TemplateField HeaderText="Actions">
                <ItemTemplate>
                    <asp:Button ID="btnDetail" runat="server" Text="Detail" CommandName="ViewDetail" CommandArgument='<%# Eval("CardID") %>' />
                    <asp:Button ID="btnAddToCart" runat="server" Text="Add to Cart" CommandName="AddToCart" CommandArgument='<%# Eval("CardID") %>' />
                </ItemTemplate>
            </asp:TemplateField>
        </Columns>
    </asp:GridView>
</asp:Content>
