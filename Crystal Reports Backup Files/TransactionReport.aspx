<%@ Page Title="Transaction Report" Language="C#" MasterPageFile="~/Views/Navbar.Master" AutoEventWireup="true" CodeBehind="TransactionReport.aspx.cs" Inherits="ProjectPSD.Views.TransactionReport" %>

<%@ Register Assembly="CrystalDecisions.Web, Version=13.0.4000.0, Culture=neutral, PublicKeyToken=692fbea5521e1304" Namespace="CrystalDecisions.Web" TagPrefix="CR" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <div>
        <h1>Transaction Report</h1>
        <CR:CrystalReportViewer ID="ReportViewer" runat="server" AutoDataBind="true" />
    </div>
</asp:Content>
