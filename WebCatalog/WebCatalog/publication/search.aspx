<%@ Page Title="" Language="C#" MasterPageFile="~/master/webcatalog.master" AutoEventWireup="true" CodeFile="search.aspx.cs" Inherits="publication_search" %>
<%@ MasterType TypeName="master_WebCatalog" %>
<%@ Register TagPrefix="bc" TagName="BreadCrumb" Src="~/BreadCrumb/BreadCrumb.ascx" %>

<asp:Content ID="Content2" ContentPlaceHolderID="breadcrumbs" runat="server">
    <bc:BreadCrumb id="BreadCrumb1" Level="3" TailName="Name" runat="server"></bc:BreadCrumb>
</asp:Content>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
<div class="clear"></div>
<asp:ValidationSummary ID="vldSummary" runat="server" CssClass="color-attention" />

<div style="width: 100%; display: table">
<div style="display: table-row">

<div style="display: table-cell; vertical-align: top">

    <h2 id="lblTitle" class="background-accent" runat="server" ></h2>
    <p id="lblInfo" runat="server"></p>


</div>

<div style="display: table-cell; vertical-align: middle;">

  <div id="dViewCart" runat="server" class="module-summary  float-right margin-bottom-none margin-top-none">
    <p ID="lblItemInCart" runat="server"></p>
    <p class="align-center">
        <asp:LinkButton ID="hplViewCart" CssClass="btn btn-primary" Text="viewCart" runat="server" onclick="hplViewCart_Click" ></asp:LinkButton>
    </p>
  </div>
</div>

</div>  <!-- end table row -->
</div>  <!-- end table span -->


<div class="clear"></div>
<div class="span-6 module margin-top-none">


<table>
<tr>
<td style="width: 40%">

    <asp:Label ID="lblSearchText" AssociatedControlID="txtSearchText" CssClass="margin-left-medium " runat="server"  Text="Search">Test</asp:Label>
</td>
<td style="vertical-align: top">
    <asp:TextBox ID="txtSearchText" runat="server" CssClass="width-80"></asp:TextBox>
</td>
</tr>
<tr>
<td>
    <asp:Label ID="lblCategory" runat="server" AssociatedControlID="ddlCategory" CssClass="margin-left-medium " Text="Category"></asp:Label>
</td>
<td>
    <asp:DropDownList ID="ddlCategory" runat="server" Width="300px"> </asp:DropDownList>
</td>
</tr>
<tr>
<td>
    <asp:Label ID="lblDisplay" runat="server" AssociatedControlID="ddlDisplay" CssClass="margin-left-medium" Text="Display"></asp:Label>
</td>
<td>
    <asp:DropDownList ID="ddlDisplay" runat="server"> </asp:DropDownList>
</td>
</tr>

<tr>
<td>
    <asp:Label ID="lblSort" runat="server" AssociatedControlID="ddlSort" CssClass="margin-left-medium" Text="Sort"></asp:Label>
</td>
<td>
    <asp:DropDownList ID="ddlSort" runat="server"></asp:DropDownList>
</td>
</tr>
<tr>
<td>
  &nbsp;
  </td>
  <td>
    <asp:Button ID="btnSumbit" runat="server" Text="Submit"  CssClass="btn btn-primary"
        onclick="btnSumbit_Click" />
</td>
</tr>
</table>


<div id="dGridArea" runat="server">
    <div class="clear"></div>
    <div class="span-6">
        <p id="lblToOrder" runat="server"></p>
    </div>

    <div class="clear"></div>
    <div class="span-6 margin-bottom-none row-start">
        <p id="lblFound" runat="server"></p>
    </div>

    <div class="clear"></div>
    <div id="divGrid" runat="server" class="span-6" 
        style="overflow:auto; max-height: 600px;">
        <asp:GridView ID="grdvData" runat="server" AutoGenerateColumns="False" Visible="true" cellspacing="5" CssClass="tablepad"
            CellPadding="10" EnableViewState="true"  OnRowDataBound="grdvData_RowDataBound" OnRowCommand="grdvData_RowCommand"
            AllowPaging="true" PageSize="100" onpageindexchanging="grdvData_PageIndexChanging">
            <Columns>
                 <asp:TemplateField HeaderText="Code">
                    <ItemTemplate>
                    <asp:HiddenField ID="hidItem" runat="server" />
                    <asp:HyperLink ID="hplCode" runat="server" CssClass="wb-icon-info" NavigateUrl="http:\\www.msn.com" ></asp:HyperLink>
                    </ItemTemplate>
                    <ItemStyle HorizontalAlign="Center"  />
                </asp:TemplateField>

                <asp:TemplateField HeaderText="Title">
                    <ItemTemplate>
                    <asp:Label ID="lblText" runat="server" style="width:auto; padding: 2px"></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>

                <asp:BoundField DataField="Language" HeaderText="Language" ItemStyle-HorizontalAlign="Center"  />

                <asp:TemplateField HeaderText="HTML">
                    <ItemTemplate>
                    <asp:HyperLink ID="hplHTML" runat="server" Target="_blank"></asp:HyperLink>
                    </ItemTemplate>
                    <ItemStyle HorizontalAlign="Center" />
                </asp:TemplateField>

                <asp:TemplateField HeaderText="PDF">
                    <ItemTemplate>
                    <asp:HyperLink ID="hplPDF" runat="server" Target="_blank"></asp:HyperLink>
                    </ItemTemplate>
                    <ItemStyle HorizontalAlign="Center" />
                </asp:TemplateField>

                <asp:TemplateField HeaderText="Add">
                    <ItemTemplate>
                    <asp:Button ID="btnAdd" CssClass="btn btn-primary"  runat="server" CommandName="AddToCart" style="padding: 2px"  />
                    <asp:Label ID="lblAdd" runat="server" Visible="false"  style="padding: 2px"></asp:Label>
                    </ItemTemplate>
                    <ItemStyle HorizontalAlign="Center" />
                </asp:TemplateField>
            </Columns>
        </asp:GridView>
    </div>
</div>
</div>
</asp:Content>

