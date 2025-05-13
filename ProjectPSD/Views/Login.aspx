    <%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="ProjectPSD.Views.Login" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <h1>Login</h1>

            <%-- Username --%>
            <asp:Label ID="UsernameLbl" runat="server" Text="Username"></asp:Label> <br />
            <asp:TextBox ID="UsernameTb" runat="server"></asp:TextBox> <br />

            <%-- Password --%>
            <asp:Label ID="PasswordLbl" runat="server" Text="Password"></asp:Label><br />
            <asp:TextBox ID="PasswordTb" runat="server" TextMode="Password"></asp:TextBox> <br />

            <%-- Remember Me --%>
            <asp:CheckBox ID="RememberMeCb" runat="server" Text="Remember Me" /> <br /><br />

            <%-- Error Message --%>
            <asp:Label ID="ErrorMsg" runat="server" ForeColor="Red"></asp:Label><br />

            <%-- Login Button --%>
            <asp:Button ID="LoginBtn" runat="server" Text="Login" OnClick="LoginBtn_Click" /> <br /><br />
            <asp:Label runat="server" Text="Don't have an account? "></asp:Label>
            <asp:HyperLink ID="RegisterLink" runat="server" NavigateUrl="~/Views/Register.aspx">Register here</asp:HyperLink>



        </div>
    </form>
</body>
</html>
