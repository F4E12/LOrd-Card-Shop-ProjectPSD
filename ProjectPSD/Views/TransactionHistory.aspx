<%@ Page Title="Transaction History" Language="C#" MasterPageFile="~/Views/Navbar.Master" AutoEventWireup="true" CodeBehind="TransactionHistory.aspx.cs" Inherits="ProjectPSD.Views.TransactionHistory" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
    Transaction History
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <div>
        <h1>Transaction History Page</h1>

        <asp:GridView ID="TransactionHistoryGV" runat="server" AutoGenerateColumns="false"
            OnRowCommand="TransactionHistoryGV_RowCommand">
            <Columns>
                <asp:BoundField DataField="TransactionID" HeaderText="Transaction ID" SortExpression="TransactionID" />
                <asp:BoundField DataField="TransactionDate" HeaderText="Transaction Date" SortExpression="TransactionDate" />
                <asp:BoundField DataField="CustomerID" HeaderText="Customer ID" SortExpression="CustomerID" />
                <asp:BoundField DataField="Status" HeaderText="Status" SortExpression="Status" />
                <asp:TemplateField>
                    <ItemTemplate>
                        <asp:Button ID="ViewDetailBtn" runat="server" Text="View Detail" CommandName="ViewDetail"
                            CommandArgument='<%# Eval("TransactionID") %>' />
                    </ItemTemplate>
                </asp:TemplateField>
            </Columns>
        </asp:GridView>
    </div>
</asp:Content>