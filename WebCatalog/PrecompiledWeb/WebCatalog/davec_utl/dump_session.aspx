<%@ page language="C#" autoeventwireup="true" inherits="davec_utl_dump_session, App_Web_lokrfrvp" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
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
