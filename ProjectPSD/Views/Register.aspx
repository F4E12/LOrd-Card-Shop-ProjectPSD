<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Register.aspx.cs" Inherits="ProjectPSD.Views.Register" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <h1>Register</h1>
            <%-- Username --%>
            <asp:Label ID="UsernameLbl" runat="server" Text="Username"></asp:Label> <br />
            <asp:TextBox ID="UsernameTb" runat="server"></asp:TextBox> <br />

            <%-- Email --%>
            <asp:Label ID="EmailLbl" runat="server" Text="Email"></asp:Label><br />
            <asp:TextBox ID="EmailTb" runat="server"></asp:TextBox> <br />

            <%-- Password --%>
            <asp:Label ID="PasswordLbl" runat="server" Text="Password"></asp:Label><br />
            <asp:TextBox ID="PasswordTb" runat="server" TextMode="Password"></asp:TextBox> <br />

            <%-- Gender --%>
            <asp:Label ID="GenderLbl" runat="server" Text="Gender"></asp:Label>
            <asp:RadioButtonList ID="GenderRbl" runat="server">
                <asp:ListItem Value="Male" Selected="True">Male</asp:ListItem>
                <asp:ListItem Value="Female">Female</asp:ListItem>
            </asp:RadioButtonList> 

            <%-- Confirmation Password --%>
            <asp:Label ID="ConfirmPasswordLbl" runat="server" Text="Confirm Password"></asp:Label><br />
            <asp:TextBox ID="ConfirmPasswordTb" runat="server" TextMode="Password"></asp:TextBox> <br />

            <%-- Role --%>
           <%-- <asp:Label ID="RoleLbl" runat="server" Text="Role"></asp:Label> <br />
            <asp:DropDownList ID="RoleDDL" runat="server">
                <asp:ListItem Value="Customer">Customer</asp:ListItem>
                <asp:ListItem Value="Admin">Admin</asp:ListItem>
            </asp:DropDownList>--%>
             <asp:Label ID="RoleLbl" runat="server" Text="Role: Customer"></asp:Label>

            <%-- Error Message --%>
            <asp:Label ID="ErrorMsg" runat="server" Text="" ForeColor="Red"></asp:Label> <br />

            <%-- Register Button --%>
            <asp:Button ID="RegisterBtn" runat="server" Text="Register" OnClick="RegisterBtn_Click" /> <br /><br />
            <asp:Label runat="server" Text="Already have an account? "></asp:Label>
            <asp:HyperLink ID="LoginLink" runat="server" NavigateUrl="~/Views/Login.aspx">Login here</asp:HyperLink>
        </div>
    </form>
</body>
</html>
