<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="WebForm1.aspx.cs" Inherits="CrystalReport.WebForm1" %>
<%@ Register Assembly="CrystalDecisions.Web, Version=13.0.3500.0, Culture=neutral, PublicKeyToken=692fbea5521e1304" Namespace="CrystalDecisions.Web" TagPrefix="CR" %>
<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <asp:Button ID="btnExport" OnClick="btnExport_Click" Text="Export" CssClass="btn btn-primary" runat="server" />
        <CR:CrystalReportViewer OnLoad="CRV_Load" ToolPanelView="None" Width="500" Height="500" ID="CRV" runat="server" AutoDataBind="true" />
    </form>
</body>
</html>
