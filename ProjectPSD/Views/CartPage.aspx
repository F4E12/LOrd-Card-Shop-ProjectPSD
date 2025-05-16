<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="CartPage.aspx.cs" Inherits="ProjectPSD.Views.Cart" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <asp:PlaceHolder ID="NavbarPH" runat="server"></asp:PlaceHolder>
            <h1>Your Shopping Cart!</h1>

            <asp:GridView ID="CartGv" runat="server" AutoGenerateColumns="False">
                <Columns>
                    <asp:BoundField DataField="CardName" HeaderText="Card Name" SortExpression="CardName"></asp:BoundField>
                    <asp:BoundField DataField="CardPrice" HeaderText="Card Price" SortExpression="CardPrice"></asp:BoundField>
                    <asp:BoundField DataField="CardType" HeaderText="Card Type" SortExpression="CardType"></asp:BoundField>
                    <asp:BoundField DataField="CardDesc" HeaderText="Card Description" SortExpression="CardDesc"></asp:BoundField>
                    <asp:BoundField DataField="Quantity" HeaderText="Quantity" SortExpression="Quantity"></asp:BoundField>
                </Columns>
            </asp:GridView>

            <br />
            <asp:Button ID="CheckOutBtn" runat="server" Text="Check Out" OnClick="CheckOutBtn_Click1"/>
        </div>
    </form>
</body>
</html>