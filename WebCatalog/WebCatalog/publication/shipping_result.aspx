<%@ Page Title="" Language="C#" MasterPageFile="~/master/webcatalog.master" AutoEventWireup="true" CodeFile="shipping_result.aspx.cs" Inherits="publication_shipping_result" %>
<%@ MasterType TypeName="master_WebCatalog" %>
<%@ Register TagPrefix="bc" TagName="BreadCrumb" Src="~/BreadCrumb/BreadCrumb.ascx" %>

<asp:Content ID="Content2" ContentPlaceHolderID="breadcrumbs" runat="server">
    <bc:BreadCrumb id="BreadCrumb1" Level="2" TailName="Name" runat="server"></bc:BreadCrumb>
</asp:Content>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
<div class="clear"></div>
<div class="span-6 margin-top-medium margin-bottom-none">
    <h2 id="H1WebCat" class="background-accent" runat="server">Publication Catalog</h2>
</div>

<div class="clear"></div>
<div class="span-6 module margin-top-none">

<div class="clear"></div>
<div class="span-6">
    <p id="pConfirmation" runat="server">ConfirmationMessageEmail</p>
</div>

<div class="clear"></div>
<div class="span-6">
    <p id="pDetails" runat="server">DetailsOfOrder</p>
</div>

<div class="clear"></div>
<div  class="span-6" id="divGrid" runat="server" >
<div style="height: auto;">
        <asp:GridView ID="grdvData" runat="server" AutoGenerateColumns="False" Visible="true" CssClass="tablepad"            
            CellPadding="3" EnableViewState="true"  OnRowDataBound="grdvData_RowDataBound">
            <Columns>
                 <asp:TemplateField >
                    <ItemTemplate>
                    <asp:Label ID="lblCnt" runat="server"></asp:Label>
                    </ItemTemplate>
                    <ItemStyle HorizontalAlign="Center" />
                </asp:TemplateField>

                 <asp:TemplateField HeaderText="Title">
                    <ItemTemplate>
                    <asp:Label ID="lblTitle" runat="server"></asp:Label>
                    </ItemTemplate>
                    <HeaderStyle HorizontalAlign="Left" CssClass="align-left" />
                </asp:TemplateField>

                 <asp:TemplateField HeaderText="Qty">
                    <ItemTemplate>
                    <asp:Label ID="lblQty" runat="server"></asp:Label>
                    </ItemTemplate>
                    <ItemStyle HorizontalAlign="Center" />
                </asp:TemplateField>
            </Columns>
        </asp:GridView>
</div>



<div class="clear"></div>
<div class="span-6">
    <p id="pOrderShip" runat="server">InStockOrderShipMsg</p>
</div>


<div class="clear"></div>
<div class="span-6 margin-bottom-medium">
    <p id="pShipTo" runat="server"></p>
</div>

<div class="clear"></div>
<div class="span-1 row-start margin-bottom-none">
    <asp:Label ID="lblName" runat="server" CssClass="margin-left-medium" Text=""></asp:Label>
</div>
<div class="span-5 row-end margin-bottom-none">
    <asp:Label ID="txtName" runat="server" Text=""></asp:Label>
</div>

<div class="clear"></div>
<div class="span-1 row-start margin-bottom-none">
    <asp:Label ID="lblAddress" runat="server" CssClass="margin-left-medium" Text=""></asp:Label>
</div>
<div class="span-5 row-end margin-bottom-none">
    <asp:Label ID="txtAddress" runat="server" Text=""></asp:Label>
</div>

<div class="clear"></div>
<div class="span-1 row-start margin-bottom-none">
    <asp:Label ID="lblCity" runat="server" CssClass="margin-left-medium" Text=""></asp:Label>
</div>
<div class="span-5 row-end margin-bottom-none">
    <asp:Label ID="txtCity" runat="server" Text=""></asp:Label>
</div>

<div class="clear"></div>
<div class="span-1 row-start margin-bottom-none">
    <asp:Label ID="lblCountry" runat="server" CssClass="margin-left-medium" Text=""></asp:Label>
</div>
<div class="span-5 row-end margin-bottom-none">
    <asp:Label ID="txtCountry" runat="server" Text=""></asp:Label>
</div>

<div class="clear"></div>
<div class="span-1 row-start margin-bottom-none">
    <asp:Label ID="lblProvince" runat="server" CssClass="margin-left-medium" Text=""></asp:Label>
</div>
<div class="span-5 row-end margin-bottom-none">
    <asp:Label ID="txtProvince" runat="server" Text=""></asp:Label>
</div>

<div class="clear"></div>
<div class="span-1 row-start margin-bottom-none">
    <asp:Label ID="lblPostal" runat="server" CssClass="margin-left-medium" Text=""></asp:Label>
</div>
<div class="span-5 row-end margin-bottom-none">
    <asp:Label ID="txtPostal" runat="server" Text=""></asp:Label>
</div>

<div class="clear"></div>
<div class="span-1 row-start margin-bottom-none">
    <asp:Label ID="lblPhone" runat="server" CssClass="margin-left-medium" Text=""></asp:Label>
</div>
<div class="span-5 row-end margin-bottom-none">
    <asp:Label ID="txtPhone" runat="server" Text=""></asp:Label>
</div>



</div>
</div>
</asp:Content>



