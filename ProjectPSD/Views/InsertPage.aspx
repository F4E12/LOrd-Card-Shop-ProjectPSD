<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="InsertPage.aspx.cs" Inherits="ProjectPSD.Views.InsertPage" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <h1>Insert Page</h1>
            <asp:Label ID="NameLbl" runat="server" Text="Name"></asp:Label>
            <asp:TextBox ID="NameTb" runat="server"></asp:TextBox> <br />
            <br />

            <asp:Label ID="PriceLbl" runat="server" Text="Price"></asp:Label>
            <asp:TextBox ID="PriceTb" runat="server"></asp:TextBox> <br />
            <br />

            <asp:Label ID="DescLbl" runat="server" Text="Description"></asp:Label>
            <asp:TextBox ID="DescTb" runat="server"></asp:TextBox> <br />
            <br />

            <asp:Label ID="TypeLbl" runat="server" Text="Type"></asp:Label>
            <asp:DropDownList ID="TypeDd" runat="server">
                <asp:ListItem Text="Spell" Value="Spell"></asp:ListItem>
                <asp:ListItem Text="Monster" Value="Monster"></asp:ListItem>
            </asp:DropDownList>
            <br />

            <asp:Label ID="FoilLbl" runat="server" Text="Foil"></asp:Label>
            <asp:DropDownList ID="FoilDd" runat="server">
                <asp:ListItem Text="Yes" Value="Yes"></asp:ListItem>
                <asp:ListItem Text="No" Value="No"></asp:ListItem>
            </asp:DropDownList>

            <br />

            <asp:Label ID="ErrorLbl" runat="server" Text="" ForeColor="Red"></asp:Label> <br />
            
            <br />
            <asp:Button ID="InsertBtn" runat="server" Text="Insert" OnClick="InsertBtn_Click"/>
        </div>
    </form>
</body>
</html>
