<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Navbar.Master" AutoEventWireup="true" CodeBehind="HandleTransaction.aspx.cs" Inherits="ProjectPSD.Views.HandleTransaction" %>
<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <div>
    <asp:GridView ID="TransactionGV" runat="server" AutoGenerateColumns="False" OnRowEditing="TransactionGV_RowEditing">
    <Columns>
        <asp:BoundField DataField="TransactionID" HeaderText="Transaction ID" SortExpression="TransactionID" />
        <asp:BoundField DataField="TransactionDate" HeaderText="Transaction Date" SortExpression="TransactionDate" />
        <asp:BoundField DataField="CustomerID" HeaderText="Customer ID" SortExpression="CustomerID" />
        <asp:BoundField DataField="Status" HeaderText="Status" SortExpression="Status" />
        <asp:TemplateField HeaderText="Update Status">
            <ItemTemplate>
                <asp:Button ID="UpdateBtn" runat="server" Text="Update" CommandName="Edit"/>
            </ItemTemplate>
        </asp:TemplateField>
    </Columns>
</asp:GridView>
        </div>
</asp:Content>
