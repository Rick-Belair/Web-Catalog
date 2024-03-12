<%@ Page Language="C#" AutoEventWireup="true" CodeFile="qty.aspx.cs" Inherits="davec_utl_qty" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    <asp:DropDownList ID="ddlCategory" runat="server" Width="300px"></asp:DropDownList>&nbsp;
    <asp:Button ID="btnGo" runat="server" Text="Go" onclick="btnGo_Click" /><br /><br />
    <asp:Label ID="lblNrows" runat="server">0</asp:Label> row(s) returned
    <asp:GridView ID="grdvData" runat="server" onrowdatabound="grdvData_RowDataBound" AutoGenerateColumns="false">
    <Columns>
        <asp:BoundField HeaderText="Title" DataField="Title" ItemStyle-Wrap="true" />
        <asp:BoundField HeaderText="Item Code" DataField="Item" ItemStyle-Wrap="false" />
        <asp:BoundField HeaderText="Status" DataField="Status" ItemStyle-HorizontalAlign="Center" />
        <asp:BoundField HeaderText="Quota" DataField="INV_QUOTA" ItemStyle-HorizontalAlign="Right" />
        <asp:TemplateField HeaderText="# Available" ItemStyle-HorizontalAlign="Right">
        <ItemTemplate>
        <asp:Label ID="lblQtyAvailable" runat="server"></asp:Label>
        </ItemTemplate>
        </asp:TemplateField>
        <asp:BoundField HeaderText="Category" DataField="Pt_Code" ItemStyle-HorizontalAlign="Center" />
    </Columns>
    </asp:GridView>
    </div>
    </form>
</body>
</html>
