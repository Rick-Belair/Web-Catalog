<%@ Page Language="C#" AutoEventWireup="true" CodeFile="shiptest.aspx.cs" Inherits="davec_utl_shiptest" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    Language&nbsp;
    <asp:DropDownList ID="ddlLanguage" runat="server" AutoPostBack="true">
        <asp:ListItem Value="E">English</asp:ListItem>
        <asp:ListItem Value="F">French</asp:ListItem>
    </asp:DropDownList><br />
    
    Province&nbsp;<asp:DropDownList ID="ddlProvince" runat="server"></asp:DropDownList><br />

    Affiliation&nbsp;<asp:DropDownList ID="ddlAffiliation" runat="server"></asp:DropDownList>
    </div>
    </form>
</body>
</html>
