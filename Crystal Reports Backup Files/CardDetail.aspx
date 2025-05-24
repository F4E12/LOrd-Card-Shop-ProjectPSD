<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="CardDetail.aspx.cs" Inherits="ProjectPSD.Views.CardDetail" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <asp:PlaceHolder ID="NavbarPH" runat="server"></asp:PlaceHolder>
            <h1>Card Detail Page</h1>
            <asp:Label ID="NameDisplay" runat="server" Text="Name: "></asp:Label>
            <asp:Label ID="nameLbl" runat="server"></asp:Label><br />

            <asp:Label ID="PriceDisplay" runat="server" Text="Price: "></asp:Label>
            <asp:Label ID="priceLbl" runat="server"></asp:Label><br />

            <asp:Label ID="TypeDisplay" runat="server" Text="Type: "></asp:Label>
            <asp:Label ID="cardTypeLbl" runat="server"></asp:Label><br />

            <asp:Label ID="DescDisplay" runat="server" Text="Description: "></asp:Label>
            <asp:Label ID="cardDescLbl" runat="server"></asp:Label><br />

            <asp:Button ID="backBtn" runat="server" Text="Back" OnClick="Button1_Click"/>
        </div>
    </form>
</body>
</html>
