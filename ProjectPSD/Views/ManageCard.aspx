<%@ Page Title="Manage Card" Language="C#" MasterPageFile="~/Views/Navbar.Master" AutoEventWireup="true" CodeBehind="ManageCard.aspx.cs" Inherits="ProjectPSD.Views.ManageCard" %>

<asp:Content ID="HeadContent" ContentPlaceHolderID="TitleContent" runat="server">
    Manage Card
</asp:Content>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <div>
        <h2>Manage Card</h2>
        <asp:GridView ID="ManageCardGV" runat="server" AutoGenerateColumns="False" 
                      OnRowDeleting="ManageCardGV_RowDeleting" 
                      OnRowEditing="ManageCardGV_RowEditing"
                      CssClass="table table-bordered table-striped">
            <Columns>
                <asp:BoundField DataField="CardID" HeaderText="Card ID" SortExpression="CardID" />
                <asp:BoundField DataField="CardName" HeaderText="Card Name" SortExpression="CardName" />
                <asp:BoundField DataField="CardPrice" HeaderText="Card Price" SortExpression="CardPrice" />
                <asp:BoundField DataField="CardDesc" HeaderText="Card Description" SortExpression="CardDesc" />
                <asp:TemplateField HeaderText="Action">
                    <ItemTemplate>
                        <asp:Button ID="DeleteBtn" runat="server" Text="Delete" CommandName="Delete" CssClass="btn btn-danger btn-sm" />
                        <asp:Button ID="UpdateBtn" runat="server" Text="Update" CommandName="Edit" CssClass="btn btn-warning btn-sm" />
                    </ItemTemplate>
                </asp:TemplateField>
            </Columns>
        </asp:GridView>

        <asp:Label ID="MessageLbl" runat="server" Text="" ForeColor="Red" Font-Bold="true"></asp:Label>
        <br />
        <asp:Button ID="InsertBtn" runat="server" Text="Insert New Card" CssClass="btn btn-primary" OnClick="InsertBtn_Click" />
    </div>
</asp:Content>
