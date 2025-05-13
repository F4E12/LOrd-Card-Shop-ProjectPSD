<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Homepage.aspx.cs" Inherits="ProjectPSD.Views.Homepage" %>

<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Homepage</title>
</head>
<body>
    <form id="form1" runat="server">
        <asp:PlaceHolder ID="NavbarPH" runat="server"></asp:PlaceHolder> <br />

        <div>
            <asp:Label ID="WelcomeLbl" runat="server" Text=""></asp:Label>
        </div>
    </form>
</body>
</html>
