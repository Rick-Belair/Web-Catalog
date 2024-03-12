<%@ Page Title="" Language="C#" MasterPageFile="~/master/webcatalog.master" AutoEventWireup="true" CodeFile="moreinfo.aspx.cs" Inherits="publication_moreinfo" %>
<%@ MasterType TypeName="master_WebCatalog" %>
<%@ Register TagPrefix="bc" TagName="BreadCrumb" Src="~/BreadCrumb/BreadCrumb.ascx" %>

<asp:Content ID="Content2" ContentPlaceHolderID="breadcrumbs" runat="server">
    <bc:BreadCrumb id="BreadCrumb1" Level="3" TailName="Name" runat="server"></bc:BreadCrumb>
</asp:Content>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
<div class="clear"></div>
<div class="span-6 margin-top-small module">
    <h2 class="background-accent" id="lblMoreInfo" runat="server">More Info</h2>

    <h5><asp:Label ID="lblTitle" runat="server" Text="Title" CssClass="margin-left-medium"></asp:Label>  </h5>
    <p runat="server" id="lblDesc">There is some text in this paragraph.</p>
    <p><asp:Label ID="lblAuthor" runat="server" Text="Author"></asp:Label></p>
    <p><asp:Label ID="lblPrinted" runat="server" Text="Printed"></asp:Label></p>
    <p><asp:Label ID="lblLang" runat="server" Text="Language"></asp:Label></p>
    <p><asp:Label ID="lblPub" runat="server" Text="PubNum"></asp:Label></p>


<div class="clear"></div>
<div class="span-6"> 
        &nbsp;&nbsp;<asp:button id="bntReturn" runat="server" text="Back" CssClass="btn btn-primary"
OnClientClick="JavaScript: window.history.back(1); return false;"></asp:button>
</div>

<asp:HiddenField ID="hidRefPage" runat="server" />

</div>


</asp:Content>


