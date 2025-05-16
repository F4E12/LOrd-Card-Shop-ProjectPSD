<%@ Page Title="Profile" Language="C#" MasterPageFile="~/Views/Navbar.master" AutoEventWireup="true" CodeBehind="Profile.aspx.cs" Inherits="ProjectPSD.Views.Profile" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
    Profile
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <asp:Label ID="lblMessage" runat="server" ForeColor="Red"></asp:Label><br />

    <asp:TextBox ID="txtUsername" runat="server" Placeholder="Username"></asp:TextBox><br />
    <asp:TextBox ID="txtEmail" runat="server" Placeholder="Email"></asp:TextBox><br />
    <asp:TextBox ID="txtPassword" runat="server" TextMode="Password" Placeholder="Password"></asp:TextBox><br />

    <asp:DropDownList ID="ddlGender" runat="server">
        <asp:ListItem Text="Male" Value="Male" />
        <asp:ListItem Text="Female" Value="Female" />
    </asp:DropDownList><br />

    <asp:Label ID="DobLbl" runat="server" Text="Date of Birth"></asp:Label><br />
    <asp:DropDownList ID="ddlDay" runat="server" Width="60px" />
    <asp:DropDownList ID="ddlMonth" runat="server" Width="100px" AutoPostBack="true" OnSelectedIndexChanged="MonthOrYearChanged" />
    <asp:DropDownList ID="ddlYear" runat="server" Width="80px" AutoPostBack="true" OnSelectedIndexChanged="MonthOrYearChanged" /><br />
    <br />

    <h4>Change Password</h4>
    <asp:TextBox ID="txtOldPassword" runat="server" TextMode="Password" Placeholder="Old Password"></asp:TextBox><br />
    <asp:TextBox ID="txtNewPassword" runat="server" TextMode="Password" Placeholder="New Password"></asp:TextBox><br />
    <asp:TextBox ID="txtConfirmPassword" runat="server" TextMode="Password" Placeholder="Confirm Password"></asp:TextBox><br />

    <asp:Button ID="btnUpdate" runat="server" Text="Update" OnClick="btnUpdate_Click" />
</asp:Content>
