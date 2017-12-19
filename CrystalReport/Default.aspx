<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="CrystalReport._Default" %>

<%@ Register Assembly="CrystalDecisions.Web, Version=13.0.3500.0, Culture=neutral, PublicKeyToken=692fbea5521e1304" Namespace="CrystalDecisions.Web" TagPrefix="CR" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <asp:Button ID="btnExport" OnClick="btnExport_Click" Text="Export" CssClass="btn btn-primary" runat="server" />
    <CR:CrystalReportViewer OnLoad="CRV_Load" ToolPanelView="None" Width="500" Height="500" ID="CRV" runat="server" AutoDataBind="true" />
</asp:Content>
