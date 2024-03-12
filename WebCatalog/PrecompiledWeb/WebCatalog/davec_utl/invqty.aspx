<%@ page language="C#" autoeventwireup="true" inherits="davec_utl_invqty, App_Web_lokrfrvp" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    <asp:TextBox ID="txtItem" runat="server"></asp:TextBox>
    <asp:Button ID="btnSubmit" runat="server" Text="Go" onclick="btnSubmit_Click" /><br />
    Available:&nbsp;<asp:Label ID="lblAvailable" runat="server">???</asp:Label>&nbsp(
    <asp:Label ID="lblAvailable2" runat="server">???</asp:Label>
    )
    </div>
    </form>
</body>
</html>
