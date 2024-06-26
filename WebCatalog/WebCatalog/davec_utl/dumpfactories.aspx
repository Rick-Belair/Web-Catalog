﻿<%@ Page Language="C#" AutoEventWireup="true" CodeFile="dumpfactories.aspx.cs" Inherits="davec_utl_dumpfactories" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "https://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="https://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    <asp:GridView ID="grdvwFactories" runat="server" AutoGenerateColumns="false" CellPadding="3">
    <Columns>
    <asp:TemplateField>
    <ItemTemplate>
    <asp:Label ID="lblName" runat="server" Text='<%# Eval("Name") %>'></asp:Label><br /><br />
    <asp:HyperLink ID="hyplMoreInfo" runat="server" Target="_blank" NavigateUrl="https://drudgereport.com">MORE INFO</asp:HyperLink><br /><br />
    </ItemTemplate>
    </asp:TemplateField>
    <asp:BoundField DataField="Description" HeaderText="Description" />
    <asp:BoundField DataField="InvariantName" HeaderText="InvariantName" />
    <asp:BoundField DataField="AssemblyQualifiedName" HeaderText="AssemblyQualifiedName" />
    </Columns>
    </asp:GridView>
    </div>
    </form>
</body>
</html>
