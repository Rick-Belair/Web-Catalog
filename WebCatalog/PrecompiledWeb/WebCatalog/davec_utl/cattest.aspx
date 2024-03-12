<%@ page language="C#" autoeventwireup="true" inherits="davec_utl_cattest, App_Web_lokrfrvp" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    Page Language:&nbsp;
    <asp:RadioButtonList ID="rblLanguage" runat="server" AutoPostBack="true" 
            RepeatDirection="Horizontal" 
            onselectedindexchanged="rblLanguage_SelectedIndexChanged" >
        <asp:ListItem Selected="True" Value="E">English</asp:ListItem>
        <asp:ListItem Value="F">French</asp:ListItem>
    </asp:RadioButtonList><br />

    Publication Language:&nbsp;
    <asp:RadioButtonList ID="rblPublicationLanguage" runat="server" RepeatDirection="Horizontal" >
        <asp:ListItem Selected="True" Value="E">English</asp:ListItem>
        <asp:ListItem Value="F">French</asp:ListItem>
        <asp:ListItem Value="B">Both</asp:ListItem>
    </asp:RadioButtonList><br />

    Categories:&nbsp;
    <asp:DropDownList ID="ddlCategory" runat="server" Width="300px"></asp:DropDownList><br /><br />

    <asp:Button ID="btnLoadData" runat="server" Text="Load Data" 
            onclick="btnLoadData_Click" />&nbsp;
    <asp:Label ID="lblRecordCount" runat="server">0</asp:Label> records(s) retrieved. 

    <asp:GridView ID="grdvwPublications" runat="server" AutoGenerateColumns="true" 
            onrowdatabound="grdvwPublications_RowDataBound" AllowPaging="true" CellPadding="3"
            PageSize="10" onpageindexchanging="grdvwPublications_PageIndexChanging"></asp:GridView>
    </div>
    </form>
</body>
</html>
