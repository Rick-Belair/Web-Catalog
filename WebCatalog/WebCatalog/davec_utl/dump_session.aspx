<%@ Page Language="C#" AutoEventWireup="true" CodeFile="dump_session.aspx.cs" Inherits="davec_utl_dump_session" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "https://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="https://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>Session Variables</title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <table border="1" id="tblSessionVars" runat="server"></table>
    </div>
    </form>
    <br />
    Timeout:&nbsp:<asp:Label ID="lblTimeOut" runat="server"></asp:Label>
</body>
</html>
