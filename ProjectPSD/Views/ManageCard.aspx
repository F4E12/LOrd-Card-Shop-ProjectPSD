<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ManageCard.aspx.cs" Inherits="ProjectPSD.Views.ManageCard" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <asp:GridView ID="ManageCardGV" runat="server" AutoGenerateColumns="False" OnRowDeleting="ManageCardGV_RowDeleting" OnRowEditing="ManageCardGV_RowEditing">
                <Columns>
                    <asp:BoundField DataField="CardID" HeaderText="Card ID" SortExpression="CardID" />
                    <asp:BoundField DataField="CardName" HeaderText="Card Name" SortExpression="CardName" />
                    <asp:BoundField DataField="CardPrice" HeaderText="Card Price" SortExpression="CardPrice" />
                    <asp:TemplateField HeaderText="Action">
                        <ItemTemplate>
                            <asp:Button ID="DeleteBtn" runat="server" Text="Delete" CommandName="Delete"/>
                            <asp:Button ID="UpdateBtn" runat="server" Text="Update" CommandName="Edit"/>
                        </ItemTemplate>
                    </asp:TemplateField>
                </Columns>
            </asp:GridView>
            <asp:Button ID="InsertBtn" runat="server" Text="Insert New Card" />
        </div>
    </form>
</body>
</html>
