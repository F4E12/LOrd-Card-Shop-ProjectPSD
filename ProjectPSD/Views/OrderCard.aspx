<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="OrderCard.aspx.cs" Inherits="ProjectPSD.Views.OrderCard" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <asp:PlaceHolder ID="NavbarPH" runat="server"></asp:PlaceHolder> <br />
        <div>
            <asp:GridView ID="gvOrderCard" runat="server" AutoGenerateColumns="False">
                <Columns>
                    <asp:BoundField DataField="CardID" HeaderText="Card ID" SortExpression="CardID"></asp:BoundField>
                    <asp:BoundField DataField="CardName" HeaderText="Card Name" SortExpression="CardName"></asp:BoundField>
                    <asp:BoundField DataField="CardPrice" HeaderText="Card Price" SortExpression="CardPrice"></asp:BoundField>
                    <asp:BoundField DataField="CardDesc" HeaderText="Card Desc" SortExpression="CardDesc"></asp:BoundField>
                    <asp:BoundField DataField="CardType" HeaderText="Card Type" SortExpression="CardType"></asp:BoundField>
                    <asp:BoundField DataField="isFoil" HeaderText="is Foil" SortExpression="isFoil"></asp:BoundField>

                    <asp:TemplateField HeaderText="Actions">
                        <ItemTemplate>
                            <asp:Button ID="btnDetail" runat="server" Text="Detail" CommandName="ViewDetail" CommandArgument='<%# Eval("CardID") %>' />
                            <asp:Button ID="btnAddToCart" runat="server" Text="Add to Cart" CommandName="AddToCart" CommandArgument='<%# Eval("CardID") %>' />
                        </ItemTemplate>
                    </asp:TemplateField>

                    
                </Columns>
            </asp:GridView>
        </div>
    </form>
</body>
</html>
