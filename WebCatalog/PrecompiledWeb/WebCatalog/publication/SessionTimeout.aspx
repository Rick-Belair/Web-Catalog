<%@ page title="" language="C#" masterpagefile="~/master/webcatalog.master" autoeventwireup="true" inherits="publication_SessionTimeout, App_Web_rbb1ftvn" %>
<%@ MasterType TypeName="master_WebCatalog" %>
<%@ Register TagPrefix="bc" TagName="BreadCrumb" Src="~/BreadCrumb/BreadCrumb.ascx" %>

<asp:Content ID="Content2" ContentPlaceHolderID="breadcrumbs" runat="server">
    <bc:BreadCrumb id="BreadCrumb1" Level="3" TailName="Session" runat="server"></bc:BreadCrumb>
</asp:Content>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
<div class="clear"></div>
<div class="span-6 margin-top-medium margin-bottom-none">
    <h2 id="H1WebCat" class="background-accent" runat="server"> </h2>
</div>

<div class="clear"></div>
<div class="span-6 module margin-top-none">

<div class="clear"></div>
<div class="span-6">
    <p id="pConfirmation" runat="server">
    <asp:Label ID="txtMsg" runat="server" Text=""></asp:Label>
    </p>
</div>


</div>
</asp:Content>

