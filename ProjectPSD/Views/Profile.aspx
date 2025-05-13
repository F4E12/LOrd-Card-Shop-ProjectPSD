<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Profile.aspx.cs" Inherits="ProjectPSD.Views.Profile" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Profile</title>
</head>
<body>
    <form id="form1" runat="server">
            <asp:PlaceHolder ID="NavbarPH" runat="server"></asp:PlaceHolder> <br />

        <div>
            <asp:Label ID="lblMessage" runat="server" ForeColor="Red"></asp:Label><br />

            <asp:TextBox ID="txtUsername" runat="server" Placeholder="Username"></asp:TextBox><br />
            <asp:TextBox ID="txtEmail" runat="server" Placeholder="Email"></asp:TextBox><br />
            <asp:TextBox ID="txtPassword" runat="server" TextMode="Password" Placeholder="Password"></asp:TextBox><br />
            <asp:DropDownList ID="ddlGender" runat="server">
                <asp:ListItem Text="Male" Value="Male" />
                <asp:ListItem Text="Female" Value="Female" />
            </asp:DropDownList><br />

            <h4>Change Password</h4>
            <asp:TextBox ID="txtOldPassword" runat="server" TextMode="Password" Placeholder="Old Password"></asp:TextBox><br />
            <asp:TextBox ID="txtNewPassword" runat="server" TextMode="Password" Placeholder="New Password"></asp:TextBox><br />
            <asp:TextBox ID="txtConfirmPassword" runat="server" TextMode="Password" Placeholder="Confirm Password"></asp:TextBox><br />

            <asp:Button ID="btnUpdate" runat="server" Text="Update" OnClick="btnUpdate_Click" />
        </div>
    </form>
</body>
</html>