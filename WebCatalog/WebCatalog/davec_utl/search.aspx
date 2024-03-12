<%@ Page Language="C#" AutoEventWireup="true" CodeFile="search.aspx.cs" Inherits="search" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <div style="display: table; border: 1px solid red; border-spacing: 3px">
            <div style="display: table-row">
                <div style="display: table-cell">
                with <strong>all</strong> of the words
                </div>
                <div style="display: table-cell">
                <asp:TextBox ID="txtAllWords" runat="server"></asp:TextBox>
                </div>
            </div>
            <div style="display: table-row">
                <div style="display: table-cell">
                with the <strong>exact phrase</strong>
                </div>
                <div style="display: table-cell">
                <asp:TextBox ID="txtExactPhrase" runat="server"></asp:TextBox>
                </div>
            </div>
            <div style="display: table-row">
                <div style="display: table-cell">
                with <strong>at least one</strong> of the words
                </div>
                <div style="display: table-cell">
                <asp:TextBox ID="txtAnyWord" runat="server"></asp:TextBox>
                </div>
            </div>
            <div style="display: table-row">
                <div style="display: table-cell">
                <strong>without</strong> the words
                </div>
                <div style="display: table-cell">
                <asp:TextBox ID="txtWithout" runat="server"></asp:TextBox>
                </div>
            </div>
        </div>
        <br />

        <div style="display: table">
            <div style="display: table-row">
                <div style="display: table-cell">
                Language
                </div>
                <div style="display: table-cell">
                <asp:DropDownList ID="ddlLang" runat="server">
                    <asp:ListItem Value="E">English</asp:ListItem>
                    <asp:ListItem Value="F">French</asp:ListItem>
                </asp:DropDownList>
                </div>
            </div>
            <div style="display: table-row">
                <div style="display: table-cell">
                Publication Language
                </div>
                <div style="display: table-cell">
                <asp:DropDownList ID="ddlPubLang" runat="server">
                    <asp:ListItem Value="E">English</asp:ListItem>
                    <asp:ListItem Value="F">French</asp:ListItem>
                    <asp:ListItem Value="B">Both</asp:ListItem>
                </asp:DropDownList>
                </div>
            </div>
            <div style="display: table-row">
                <div style="display: table-cell">
                Search Titles
                </div>
                <div style="display: table-cell">
                <asp:TextBox ID="txtSearch" runat="server"></asp:TextBox>
                </div>
            </div>
            <div style="display: table-row">
                <div style="display: table-cell">
                Category
                </div>
                <div style="display: table-cell">
                <asp:DropdownList ID="ddlCategory" runat="server" Width="300px"></asp:DropdownList>
                </div>
            </div>
            <div style="display: table-row">
                <div style="display: table-cell">
                Publication year
                </div>
                <div style="display: table-cell">
                From&nbsp;<asp:DropDownList ID="ddlYearFrom" runat="server"></asp:DropDownList>&nbsp;To&nbsp;<asp:DropDownList ID="ddlYearTo" runat="server"></asp:DropDownList>
                </div>
            </div>
            <div style="display: table-row">
                <div style="display: table-cell">
                ISBN
                </div>
                <div style="display: table-cell">
                <asp:TextBox ID="txtISBN" runat="server"></asp:TextBox>
                </div>
            </div>
            <div style="display: table-row">
                <div style="display: table-cell">
                Catalogue Number
                </div>
                <div style="display: table-cell">
                <asp:TextBox ID="txtCatNumber" runat="server"></asp:TextBox>
                </div>
            </div>
            <div style="display: table-row">
                <div style="display: table-cell">
                Author
                </div>
                <div style="display: table-cell">
                <asp:TextBox ID="txtAuthor" runat="server"></asp:TextBox>
                </div>
            </div>
            <div style="display: table-row">
                <div style="display: table-cell">
                Sort By
                </div>
                <div style="display: table-cell">
                <asp:DropdownList ID="ddlSortBy" runat="server">
                    <asp:ListItem Value=""></asp:ListItem>
                    <asp:ListItem Value="T">Title</asp:ListItem>
                    <asp:ListItem Value="D">Date Printed</asp:ListItem>
                    <asp:ListItem Value="A">Author</asp:ListItem>
                </asp:DropdownList>
                </div>
            </div>
        </div>

        <asp:Button ID="btnGenerateList" runat="server" Text="Generate List" 
            onclick="btnGenerateList_Click" /><br />

        <asp:Label ID="lblItemsFound" runat="server">0</asp:Label> item(s) found.

        <asp:GridView ID="grdvwList" runat="server" AutoGenerateColumns="true">
        </asp:GridView>
    </div>
    </form>
</body>
</html>
