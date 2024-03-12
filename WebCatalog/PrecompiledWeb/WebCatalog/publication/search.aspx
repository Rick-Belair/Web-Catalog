<%@ page title="" language="C#" masterpagefile="~/master/webcatalog.master" autoeventwireup="true" inherits="publication_search, App_Web_rbb1ftvn" %>
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
    <h2 id="lblTitle" class="background-accent" runat="server" ></h2>
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

    <p id="lblInfo" runat="server"></p>
</div>
<div class="clear"></div>
<div class="span-2 row-start">
    <asp:Label ID="lblSearchText" AssociatedControlID="txtSearchText" CssClass="margin-left-medium " runat="server"  Text="Search">Test</asp:Label>
</div>
<div class="span-4 row-end">    
    <asp:TextBox ID="txtSearchText" runat="server" CssClass="width-80"></asp:TextBox>
</div>

<div class="clear"></div>
<div class="span-2 row-start">
    <asp:Label ID="lblCategory" runat="server" AssociatedControlID="ddlCategory" CssClass="margin-left-medium " Text="Category"></asp:Label>
</div>
<div class="span-4 margin-bottom-none row-end">    
    <asp:DropDownList ID="ddlCategory" runat="server" Width="300px"> </asp:DropDownList>
</div>

<div class="clear"></div>
<div class="span-2 row-start">
    <asp:Label ID="lblDisplay" runat="server" AssociatedControlID="ddlDisplay" CssClass="margin-left-medium" Text="Display"></asp:Label>
</div>
<div class="span-4 margin-bottom-none row-end">    
    <asp:DropDownList ID="ddlDisplay" runat="server"> </asp:DropDownList>
</div>

<div class="clear"></div>
<div class="span-2 row-start">
    <asp:Label ID="lblSort" runat="server" AssociatedControlID="ddlSort" CssClass="margin-left-medium" Text="Sort"></asp:Label>
</div>
<div class="span-4 margin-bottom-none row-end">    
    <asp:DropDownList ID="ddlSort" runat="server"></asp:DropDownList>
</div>

<div class="clear"></div>
<div class="span-2 row-start"></div>
<div class="span-4 margin-bottom-none row-end">    
    <asp:Button ID="btnSumbit" runat="server" Text="Submit"  CssClass="button span-2"
        onclick="btnSumbit_Click" />
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
            AllowPaging="true" PageSize="100" onpageindexchanging="grdvData_PageIndexChanging">
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

