<%@ page language="C#" autoeventwireup="true" inherits="davec_utl_lang, App_Web_lokrfrvp" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Language Database Adder</title>
<script type="text/javascript" src="../includes/jquery.js"></script>
<script type="text/javascript">
function clearFields()
{
    $('#<%=txtPageName.ClientID%>').val("");
    $('#<%=txtCode.ClientID%>').val("");
    $('#<%=txtEnglish.ClientID%>').val("");
    $('#<%=txtFrench.ClientID%>').val("");
    $('#<%=txtSearch.ClientID%>').val("");
}
</script>
</head>
<body>
    <form id="form1" runat="server">
    <div id="divMessage" runat="server" enableviewstate="false" style="text-align: center; display: none"></div>
    <asp:ValidationSummary ID="vldSummary" runat="server" ForeColor="Red" style="text-align: center" />
    <div>
<table align="center">
<tr>
<td colspan="2">Page:&nbsp;
    <asp:TextBox ID="txtPageName" runat="server" MaxLength="50"></asp:TextBox><asp:RequiredFieldValidator ID="vldPageName" runat="server" ForeColor="Red" ControlToValidate="txtPageName" ErrorMessage="Enter a page">*</asp:RequiredFieldValidator>&nbsp;&nbsp;
Code:&nbsp;<asp:TextBox ID="txtCode" runat="server" MaxLength="50"></asp:TextBox><asp:RequiredFieldValidator ID="vldCode" runat="server" ForeColor="Red" ControlToValidate="txtCode" ErrorMessage="Enter a code name">*</asp:RequiredFieldValidator></td>
</tr>
<tr>
<td>English:</td>
<td>French:</td>
</tr>
<tr>
<td><asp:TextBox ID="txtEnglish" runat="server" TextMode="MultiLine" Columns="30" Rows="5"></asp:TextBox></td>
<td><asp:TextBox ID="txtFrench" runat="server" TextMode="MultiLine" Columns="30" Rows="5"></asp:TextBox></td>
</tr>
<tr>
<td colspan="2" align="center"><asp:Button ID="btnAdd" runat="server" Text="Add" 
        onclick="btnAdd_Click" />&nbsp;&nbsp;
<input type="button" name="btnClear" value="Clear Fields" onclick="clearFields()" /></td>
</tr>
<tr><td colspan="2">&nbsp;</td></tr>
<tr>
<td colspan="2">Search For: <asp:TextBox ID="txtSearch" runat="server"></asp:TextBox>
    <asp:Button ID="btnSearch" runat="server" Text="Search" 
        onclick="btnSearch_Click" CausesValidation="false" /></td>
</tr>
<tr>
<td colspan="2">
    <asp:GridView ID="grdvwSearch" runat="server" AutoGenerateColumns="False" 
        CellPadding="3" EnableViewState="true">
    <Columns>
    <asp:BoundField HeaderText="Code" DataField="Lang_Code" />
    <asp:BoundField HeaderText="E" DataField="Lang_EN" />
    <asp:BoundField HeaderText="F" DataField="Lang_FR" />
    </Columns>
    </asp:GridView>
</td>
</tr>
</table>
    
    </div>
    </form>
</body>
</html>
