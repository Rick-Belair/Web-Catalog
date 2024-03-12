<%@ Page Title="" Language="C#" MasterPageFile="~/master/webcatalog.master" AutoEventWireup="true" CodeFile="catalog.aspx.cs" Inherits="catalog_catalog" %>
<%@ MasterType TypeName="master_WebCatalog" %>
<%@ Register TagPrefix="bc" TagName="BreadCrumb" Src="~/BreadCrumb/BreadCrumb.ascx" %>

<asp:Content ID="Content2" ContentPlaceHolderID="breadcrumbs" runat="server">
    <bc:BreadCrumb id="BreadCrumb1" Level="2" TailName="Name" runat="server"></bc:BreadCrumb>
</asp:Content>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <div class="clear"></div>
<asp:ValidationSummary ID="vldSummary" runat="server" CssClass="color-attention" />

  
<div class="clear"></div>

<div class="span-6 module margin-top-none">


<div style="width: 100%; display: table">
<div style="display: table-row">

<div style="display: table-cell;">
<table>
<tr>
<td>
   <asp:Image runat="server" ID="imgProdCat" AlternateText="Publication Image" ImageUrl="../images/publications.jpg" style="height:80px; width:80px; "   />
</td>
<td>
  &nbsp;&nbsp;
</td>
<td>
   <p ID="lblWelcome" runat="server">Welcome to our publication ordering portal.</p>
</td>
</tr>
<tr>
<td>
  &nbsp;&nbsp;
</td>
</tr>
</table>
</div>

<div style="display: table-cell; vertical-align: top">
  <div id="dViewCart" runat="server" class="module-summary  float-right margin-bottom-none margin-top-none">
    <p ID="lblItemInCart" runat="server"></p>
    <p class="align-center">
        <asp:LinkButton ID="hplViewCart" CssClass="btn btn-primary" Text="viewCart" runat="server" onclick="hplViewCart_Click" ></asp:LinkButton>
    </p>
  </div>
</div>

</div>  <!-- end table row -->
</div>  <!-- end table span -->

<table>
<tr>
<td>
  &nbsp;&nbsp;
</td>
<td>
   <asp:Label ID="lblCategory" AssociatedControlID="ddlCategory" runat="server" CssClass="margin-left-medium"  Text="Category"></asp:Label>
</td>
</tr>
<tr>
<td>
   <asp:Label ID="lblSelect" runat="server" Text="SelectCategoryAndClickGo"></asp:Label>
   &nbsp;
</td>
<td>
<asp:DropDownList ID="ddlCategory" runat="server" CssClass="categoryDDL"></asp:DropDownList>
            <asp:Button ID="btnGo" runat="server" Text="GO"  CssClass="btn btn-primary" OnClick="btnGo_Click" />
</td>
</tr>
</table>


<div id="dGridArea" runat="server">

    <div class="clear"></div>
    <div class="span-6 margin-bottom-none">
        <p id="lblToOrder" runat="server"></p>
    </div>

    <div class="clear"></div>
    <div class="span-6 margin-bottom-none row-start">
        <p id="lblFound" runat="server"></p>
    </div>


    <div class="clear"></div>
    <div id="divGrid" runat="server" class="span-6" 
        style="overflow:auto; max-height: 600px;">
        <asp:GridView ID="grdvData" runat="server" AutoGenerateColumns="False" Visible="true" CssClass="tablepad"
            CellPadding="3" EnableViewState="true"  OnRowDataBound="grdvData_RowDataBound" OnRowCommand="grdvData_RowCommand"
            AllowPaging="true" PageSize="100" onpageindexchanging="grdvData_PageIndexChanging">
            <Columns>
                 <asp:TemplateField HeaderText="Code">
                    <ItemTemplate>
                    <asp:HiddenField ID="hidItem" runat="server" />
                    <asp:HyperLink ID="hplCode" runat="server" CssClass="wb-icon-info" NavigateUrl="http://www.msn.com" ></asp:HyperLink>
                    </ItemTemplate>
                    <ItemStyle HorizontalAlign="Center" />
                </asp:TemplateField>

                <asp:TemplateField HeaderText="Title">
                    <ItemTemplate>
                    <asp:Label ID="lblText" runat="server" style="width:auto"></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>

                <asp:BoundField DataField="Language" HeaderText="Language" ItemStyle-HorizontalAlign="Center"  />

                <asp:TemplateField HeaderText="HTML">
                    <ItemTemplate>
                    <asp:HyperLink ID="hplHTML" runat="server" Target="_blank"></asp:HyperLink>
                    </ItemTemplate>
                    <ItemStyle HorizontalAlign="Center"/>
                </asp:TemplateField>

                <asp:TemplateField HeaderText="PDF">
                    <ItemTemplate>
                    <asp:HyperLink ID="hplPDF" runat="server" Target="_blank" ></asp:HyperLink>
                    </ItemTemplate>
                    <ItemStyle HorizontalAlign="Center"/>
                </asp:TemplateField>

                <asp:TemplateField HeaderText="Add">
                    <ItemTemplate>
                    <asp:Button ID="btnAdd" runat="server" CommandName="AddToCart" CssClass="btn btn-primary" />
                    <asp:Label ID="lblAdd" runat="server" Visible="false"></asp:Label>
                    </ItemTemplate>
                    <ItemStyle HorizontalAlign="Center" />
                </asp:TemplateField>
            </Columns>
        </asp:GridView>
    </div>
</div>

</div>
</asp:Content>


