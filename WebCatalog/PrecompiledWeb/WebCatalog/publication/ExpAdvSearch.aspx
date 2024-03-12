<%@ page title="" language="C#" masterpagefile="~/master/webcatalog.master" autoeventwireup="true" inherits="publication_ExpAdvSearch, App_Web_rbb1ftvn" %>
<%@ MasterType TypeName="master_WebCatalog" %>
<%@ Register TagPrefix="bc" TagName="BreadCrumb" Src="~/BreadCrumb/BreadCrumb.ascx" %>

<asp:Content ID="Content2" ContentPlaceHolderID="breadcrumbs" runat="server">
    <bc:BreadCrumb id="BreadCrumb1" Level="3" TailName="Name" runat="server"></bc:BreadCrumb>
</asp:Content>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
<div class="clear"></div>
<asp:ValidationSummary ID="vldSummary" runat="server" CssClass="color-attention" />

<div class="clear"></div>
<div class="span-6 margin-top-medium margin-bottom-none">
    <h2 id="lblAdvSearch" class="background-accent" runat="server">Adv Search</h2>
</div>

<div class="clear"></div>
<div class="span-6 module margin-top-none">

<div class="clear"></div>
<div class="span-6">

<div id="dViewCart" runat="server" class="module-summary  float-right margin-bottom-none margin-top-none">
    <p ID="lblItemInCart" runat="server"></p>
    <p class="align-center">
        <asp:LinkButton ID="hplViewCart" CssClass="button" Text="viewCart" runat="server" onclick="hplViewCart_Click" ></asp:LinkButton>
    </p>
</div>
    <p id="lblAdvMsg" runat="server"></p>
</div>



    <div class="clear"></div>

    <div class="span-6 module-inprogress  module-simplify">
    <div class="span-6 font-large margin-top-medium">
    <asp:Label ID="lblFind" runat="server" Text="FindResults" CssClass="margin-left-medium"></asp:Label>
   </div>
    <div class="span-2 row-start margin-bottom-none">
        <asp:Label ID="lblAll" runat="server" AssociatedControlID="txtAll" Text="AllWords" CssClass="margin-left-medium"></asp:Label>
    </div>
    <div class="span-4 row-end margin-bottom-none">
        <asp:TextBox id="txtAll" runat="server" ></asp:TextBox>
    </div>

    <div class="span-2 row-start margin-bottom-none">
        <asp:Label ID="lblExact" runat="server" AssociatedControlID="txtExact" Text="ExactPhrase" CssClass="margin-left-medium"></asp:Label>
    </div>
    <div class="span-4 row-end margin-bottom-none">
        <asp:TextBox id="txtExact" runat="server" ></asp:TextBox>
    </div>

    <div class="span-2 row-start margin-bottom-none">
        <asp:Label ID="lblAny" runat="server" AssociatedControlID="txtAny" Text="AnyWords" CssClass="margin-left-medium"></asp:Label>
    </div>
    <div class="span-4 row-end margin-bottom-none">
        <asp:TextBox id="txtAny" runat="server" ></asp:TextBox>
    </div>
    <div class="clear margin-bottom-none"></div>

    <div class="span-2 row-start margin-bottom-none">
        <asp:Label ID="lblWithout" runat="server" AssociatedControlID="txtWithout" Text="WithoutWords" CssClass="margin-left-medium"></asp:Label>
    </div>
    <div class="span-4 row-end margin-bottom-none">
        <asp:TextBox id="txtWithout" runat="server" ></asp:TextBox>
    </div>
</div>

<div class="clear"></div>
<div class="span-2  margin-bottom-none row-start">
    <asp:Label ID="lblCategory" AssociatedControlID="ddlCategory" runat="server" CssClass="margin-left-medium" Text="Category"></asp:Label>
</div>
<div class="span-4  margin-bottom-none row-end">
    <asp:DropDownList ID="ddlCategory" runat="server"></asp:DropDownList>
</div>

<div class="clear"></div>
<div class="span-2  margin-bottom-none row-start">
    <asp:Label ID="lblPubDate" AssociatedControlID="ddlFromDate" runat="server" CssClass="margin-left-medium" Text="PubDateRange"></asp:Label>
</div>
<div class="span-4 form-inline margin-bottom-none row-end">
    <asp:Label ID="lblFrom" AssociatedControlID="ddlFromDate" runat="server" Text="From"></asp:Label>
    <asp:DropDownList ID="ddlFromDate" runat="server"></asp:DropDownList>
    <asp:Label ID="lblTo" AssociatedControlID="ddlToDate" runat="server" Text="To"></asp:Label>
    <asp:DropDownList ID="ddlToDate" runat="server"></asp:DropDownList>
</div>

<div class="clear"></div>
<div class="span-2  margin-bottom-none row-start">
    <asp:Label ID="lblLang" AssociatedControlID="ddlLang" runat="server" CssClass="margin-left-medium" Text="Language"></asp:Label>
</div>
<div class="span-4 margin-bottom-none row-end">
    <asp:DropDownList ID="ddlLang" runat="server"></asp:DropDownList>
</div>


<div class="clear"></div>
<div class="span-2  margin-bottom-none row-start">
    <asp:Label ID="lblIsbn" AssociatedControlID="txtIsbn" runat="server" CssClass="margin-left-medium" Text="IsbnNumber"></asp:Label>
</div>
<div class="span-4 margin-bottom-none row-end">
    <asp:TextBox ID="txtIsbn" runat="server"></asp:TextBox>
</div>

<div class="clear"></div>
<div class="span-2  margin-bottom-none row-start">
    <asp:Label ID="lblCatNumber" AssociatedControlID="txtCatNumber" runat="server" CssClass="margin-left-medium" Text="CatNumber"></asp:Label>
</div>
<div class="span-4 margin-bottom-none row-end">
    <asp:TextBox ID="txtCatNumber" runat="server"></asp:TextBox>
</div>

<div class="clear"></div>
<div class="span-2  margin-bottom-none row-start">
    <asp:Label ID="lblAutor" AssociatedControlID="txtAuthor" runat="server" CssClass="margin-left-medium" Text="Author"></asp:Label>
</div>
<div class="span-4 margin-bottom-none row-end">
    <asp:TextBox ID="txtAuthor" runat="server"></asp:TextBox>
</div>

<div class="clear"></div>
<div class="span-2  margin-bottom-none row-start">
    <asp:Label ID="lblSort" AssociatedControlID="ddlSort" runat="server" CssClass="margin-left-medium" Text="SortBy"></asp:Label>
</div>
<div class="span-4 margin-bottom-none row-end">
    <asp:DropDownList ID="ddlSort" runat="server"></asp:DropDownList>
</div>

<div class="clear"></div>
<div class="span-2 row-start"></div>
<div class="span-4 row-end">
    <asp:Button ID="btnSubmit" Text="Submit" runat="server" CssClass="button span-2" onclick="btnSubmit_Click" />
</div>

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
        <asp:GridView ID="grdvData" runat="server" AutoGenerateColumns="False" Visible="true" CssClass="margin-left-medium wet-boew-zebra table-accent"
            CellPadding="3" EnableViewState="true"  OnRowDataBound="grdvData_RowDataBound" OnRowCommand="grdvData_RowCommand"
            AllowPaging="true" PageSize="100" onpageindexchanging="grdvData_PageIndexChanging" >

            <Columns>
                 <asp:TemplateField HeaderText="Code">
                    <ItemTemplate>
                    <asp:HiddenField ID="hidItem" runat="server" />
                    <asp:HyperLink ID="hplCode" runat="server" CssClass="wb-icon-info" NavigateUrl="http:\\www.msn.com" ></asp:HyperLink>
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
                    <asp:HyperLink ID="hplPDF" runat="server" Target="_blank"></asp:HyperLink>
                    </ItemTemplate>
                    <ItemStyle HorizontalAlign="Center"/>
                </asp:TemplateField>

                <asp:TemplateField HeaderText="Add">
                    <ItemTemplate>
                    <asp:Button ID="btnAdd" CssClass="button"  runat="server" CommandName="AddToCart"  />
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


