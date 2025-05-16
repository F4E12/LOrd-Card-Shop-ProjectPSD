<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Checkout.aspx.cs" Inherits="ProjectPSD.Views.Checkout" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <asp:PlaceHolder ID="NavbarPH" runat="server"></asp:PlaceHolder>
            <h1>Check Out Page</h1>

            <asp:GridView ID="CheckOutGv" runat="server" AutoGenerateColumns="False">
                <Columns>
                    <asp:BoundField DataField="CardName" HeaderText="Card Name" SortExpression="CardName"></asp:BoundField>
                    <asp:BoundField DataField="CardPrice" HeaderText="Card Price" SortExpression="CardPrice"></asp:BoundField>
                    <asp:BoundField DataField="CardType" HeaderText="Card Type" SortExpression="CardType"></asp:BoundField>
                    <asp:BoundField DataField="CardDesc" HeaderText="Card Description" SortExpression="CardDesc"></asp:BoundField>
                    <asp:BoundField DataField="Quantity" HeaderText="Quantity" SortExpression="Quantity"></asp:BoundField>
                    <asp:BoundField DataField="TotalItemPrice" HeaderText="Total" DataFormatString="{0:C}" />
                </Columns>
            </asp:GridView>
            <asp:Label ID="totalLbl" runat="server" Font-Bold="true" Font-Size="Large" />
            <br /><br />

            <asp:Button ID="btnConfirmCheckout" runat="server" Text="Confirm Checkout" OnClick="btnConfirmCheckout_Click" />
        </div>
    </form>
</body>
</html>
