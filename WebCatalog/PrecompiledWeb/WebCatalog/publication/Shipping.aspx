
<%@ page title="" language="C#" masterpagefile="~/master/webcatalog.master" autoeventwireup="true" inherits="publication_Shipping, App_Web_rbb1ftvn" %>
<%@ MasterType TypeName="master_WebCatalog" %>
<%@ Register TagPrefix="bc" TagName="BreadCrumb" Src="~/BreadCrumb/BreadCrumb.ascx" %>

<asp:Content ID="Content2" ContentPlaceHolderID="breadcrumbs" runat="server">
    <bc:BreadCrumb id="BreadCrumb1" Level="4" TailName="Name" runat="server"></bc:BreadCrumb>
</asp:Content>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">

<script type="text/javascript">


    function validatePhoneEmail(source, args) {

        var email = $('input:text[id*=txtEmail]').val();
        var phone = $('input:text[id*=txtPhone]').val();
        var c;

        email = email.split(' ').join('');
        phone = phone.split(' ').join('');

        if (email == "" && phone == "") {
            args.IsValid = false;
        }
        else {
            args.IsValid = true;
        }
    }

    function validateEmail(source, args) {

        var email = $('input:text[id*=txtEmail]').val();
        var res;
        res = true;
        email = email.split(' ').join('');
        if (email == "") {
            // do nothing
        }
        else {
            if (email.indexOf("@") < 1) {
                res = false;
            }
            if (email.indexOf(".") < 1) {
                res = false;
            }
            if (email.indexOf("'") > 1) {
                res = false;
            }
        }
        args.IsValid = res;
    }
</script>

<div class="clear"></div>
<asp:ValidationSummary ID="vldSummary" runat="server" CssClass="color-attention" />


<div class="clear"></div>
<div class="span-6 margin-top-medium margin-bottom-none">
    <h2 id="lblTitle" class="background-accent" runat="server">Adv Search</h2>
</div>

<div class="span-6 module margin-top-none">
    <div class="span-6" id="divEmpty" runat="server" visible="false">
        <p id="pEmpty" runat="server" class="color-attention"></p>
    </div>

    <div id="divShow" runat="server">
    <div class="span-6">
<div id="dViewCart" runat="server"  class="module-summary  float-right margin-bottom-none margin-top-none">
    <p ID="lblItemInCart" runat="server"></p>
    <p class="align-center">
        <asp:LinkButton ID="hplViewCart" CausesValidation="false" CssClass="button" Text="viewCart" runat="server" onclick="hplViewCart_Click" ></asp:LinkButton>
    </p>
</div>
        <p ID="lblMgs" runat="server" class="margin-left-medium"></p>
    </div>
    <div class="clear"></div>
    <div class="span-6">
        <p id="lblShipMsg" runat="server"></p>
    </div>

    <div class="clear"></div>
    <div class="span-2 row-start margin-bottom-none">
        <asp:Label ID="lblRequired" runat="server" CssClass="margin-left-medium"></asp:Label>
    </div>
    <div class="span-4 row-end margin-bottom-none">
        
    </div>

    <div class="clear"></div>
    <div class="span-2 row-start margin-bottom-none">
        <asp:Label ID="lblSalutation" runat="server" AssociatedControlID="ddlSalutation" CssClass="margin-left-medium"></asp:Label>
    </div>
    <div class="span-4 row-end margin-bottom-none">
        <asp:DropDownList ID="ddlSalutation" runat="server"></asp:DropDownList>
    </div>

    <div class="clear"></div>
    <div class="span-2 row-start margin-bottom-none form-inline">
        <asp:Label ID="lblFirst" runat="server" AssociatedControlID="txtFirst" CssClass="margin-left-medium"></asp:Label>
        <strong class="color-accent">*</strong>        
    </div>
    <div class="span-4 row-end margin-bottom-none">
        <asp:TextBox ID="txtFirst" runat="server" MaxLength="20"></asp:TextBox>
        <asp:RequiredFieldValidator ID="vldFirst" runat="server" ControlToValidate="txtFirst" SetFocusOnError="true" Display="Static" CssClass="color-attention"><strong>*</strong></asp:RequiredFieldValidator> 
    </div>

    <div class="clear"></div>
    <div class="span-2 row-start margin-bottom-none form-inline">
        <asp:Label ID="lblLast" runat="server" AssociatedControlID="txtLast" CssClass="margin-left-medium"></asp:Label>
        <strong class="color-accent">*</strong>
    </div>
    <div class="span-4 row-end margin-bottom-none">
        <asp:TextBox ID="txtLast" runat="server" MaxLength="30"></asp:TextBox>
        <asp:RequiredFieldValidator ID="vldLast" runat="server" ControlToValidate="txtLast" SetFocusOnError="true" CssClass="color-attention"><strong>*</strong></asp:RequiredFieldValidator> 
    </div>

    <div class="clear"></div>
    <div class="span-2 row-start margin-bottom-none">
        <asp:Label ID="lblJob" runat="server" AssociatedControlID="txtPosition" CssClass="margin-left-medium"></asp:Label>
    </div>
    <div class="span-4 row-end margin-bottom-none">
        <asp:TextBox ID="txtPosition" runat="server" MaxLength="200"></asp:TextBox>
    </div>

    <div class="clear"></div>
    <div class="span-2 row-start margin-bottom-none">
        <asp:Label ID="lblCompany" runat="server" AssociatedControlID="txtOrganization" CssClass="margin-left-medium"></asp:Label>
    </div>
    <div class="span-4 row-end margin-bottom-none">
        <asp:TextBox ID="txtOrganization" runat="server" MaxLength="100"></asp:TextBox>
    </div>

    <div class="clear"></div>
    <div class="span-2 row-start margin-bottom-none form-inline">
        <asp:Label ID="lblAddress" runat="server" AssociatedControlID="txtAddress" CssClass="margin-left-medium"></asp:Label>
        <strong class="color-accent">*</strong>
    </div>
    <div class="span-4 row-end margin-bottom-none">
        <asp:TextBox ID="txtAddress" runat="server" MaxLength="100"></asp:TextBox>
        <asp:RequiredFieldValidator ID="vldAddress" runat="server" ControlToValidate="txtAddress" SetFocusOnError="true" CssClass="color-attention"><strong>*</strong></asp:RequiredFieldValidator> 
    </div>

    <div class="clear"></div>
    <div class="span-2 row-start margin-bottom-none"></div>
    <div class="span-4 row-end margin-bottom-none">
        <asp:TextBox ID="txtAddress2" runat="server" MaxLength="50"></asp:TextBox>
    </div>

    <div class="clear"></div>
    <div class="span-2 row-start margin-bottom-none form-inline">
        <asp:Label ID="lblCity" runat="server" AssociatedControlID="txtCity" CssClass="margin-left-medium"></asp:Label>
        <strong class="color-accent">*</strong>
    </div>
    <div class="span-4 row-end margin-bottom-none">
        <asp:TextBox ID="txtCity" runat="server" MaxLength="30"></asp:TextBox>
        <asp:RequiredFieldValidator ID="vldCity" runat="server" ControlToValidate="txtCity" SetFocusOnError="true" CssClass="color-attention"><strong>*</strong></asp:RequiredFieldValidator> 
    </div>

    <div class="clear"></div>
    <div class="span-2 row-start margin-bottom-none form-inline">
        <asp:Label ID="lblProv" runat="server" AssociatedControlID="ddlProv" CssClass="margin-left-medium"></asp:Label>
        <strong class="color-accent">*</strong>
    </div>
    <div class="span-4 row-end margin-bottom-none">
        <asp:DropDownList ID="ddlProv" runat="server"></asp:DropDownList>
        <asp:RequiredFieldValidator ID="vldProv" runat="server" ControlToValidate="ddlProv" SetFocusOnError="true" CssClass="color-attention"><strong>*</strong></asp:RequiredFieldValidator> 
    </div>

    <div class="clear"></div>
    <div class="span-2 row-start margin-bottom-none form-inline">
        <asp:Label ID="lblPostal" runat="server" AssociatedControlID="txtPostal" CssClass="margin-left-medium"></asp:Label>
        <strong class="color-accent">*</strong>
    </div>
    <div class="span-4 row-end margin-bottom-none">
        <asp:TextBox ID="txtPostal" runat="server" MaxLength="10"></asp:TextBox>
        <asp:RequiredFieldValidator ID="vldPostal" runat="server" ControlToValidate="txtPostal" SetFocusOnError="true" CssClass="color-attention"><strong>*</strong></asp:RequiredFieldValidator> 
    </div>

    <div class="clear"></div>
    <div class="span-2 row-start margin-bottom-none">
        <asp:Label ID="lblCountry" runat="server" AssociatedControlID="txtCountry" CssClass="margin-left-medium"></asp:Label>
    </div>
    <div class="span-4 margin-bottom-none row-end">
        <asp:Label ID="txtCountry" runat="server" Text="Canada" MaxLength="50"></asp:Label>
    </div>

    <div class="clear"></div>
    <div class="span-6 margin-bottom-none">
        <p><asp:Label ID="lblCndMsg" runat="server" CssClass="color-attention" Text="NonCdnOrdersMsg"></asp:Label></p>
    </div>

    <div class="clear"></div>
    <hr class="opacity-50" />
    <div class="span-6 ">
        <p><asp:Label ID="lblTelEmailMsg" runat="server" Text="RequestTelAndEmail"></asp:Label></p>
    </div>

    <div class="clear"></div>
    <div class="span-2 row-start form-inline">
    <asp:Label ID="lblPhone" AssociatedControlID="txtPhone" runat="server" Text="Phone" CssClass="margin-left-medium"></asp:Label>
        <strong class="color-accent">*</strong>
    </div>
    <div class="span-4 row-end">
        <asp:TextBox ID="txtPhone" runat="server" ValidationGroup="vldEmailPhone" MaxLength="25"></asp:TextBox>
        <asp:CustomValidator id="vldPhone" runat="server" SetFocusOnError="true"  ClientValidationFunction="validatePhoneEmail" CssClass="color-attention"><strong>*</strong></asp:CustomValidator>
    </div>


    <div class="clear"></div>
    <div class="span-2 row-start form-inline">
        <asp:Label ID="lblEmail" AssociatedControlID="txtEmail" runat="server" Text="Email" CssClass="margin-left-medium"></asp:Label>
        <strong class="color-accent">*</strong>
    </div>
    <div class="span-4 row-end">
        <asp:TextBox ID="txtEmail" runat="server" CssClass="span-3"  ValidationGroup="vldEmailPhone" MaxLength="100"></asp:TextBox>
        <asp:CustomValidator id="vldEmail" runat="server" SetFocusOnError="true" ClientValidationFunction="validateEmail"  CssClass="color-attention"><strong>*</strong></asp:CustomValidator>
    </div>

    <hr class="opacity-50" />
    <div class="clear"></div>
    <div class="span-3 row-start">
        <p><asp:Label ID="lblAboriginalMsg" runat="server" Text="AboriginalInfoMsg"></asp:Label>
        <strong class="color-accent">*</strong></p>
    </div>
    <div class="span-3 row-end">
        <asp:DropDownList ID="ddlAboriginal" runat="server"></asp:DropDownList>
        <asp:RequiredFieldValidator ID="vldAboriginal" runat="server" ControlToValidate="ddlAboriginal" SetFocusOnError="true" CssClass="color-attention"><strong>*</strong></asp:RequiredFieldValidator> 
    </div>
            
    <div class="clear"></div>
    <div class="span-3 row-start form-inline">
        <asp:Label ID="lblDescribe" runat="server" AssociatedControlID="ddlCtype" Text="DescribeYourself" CssClass="margin-left-medium"></asp:Label>
        <strong class="color-accent">*</strong>
    </div>
    <div class="span-3 row-end">        
        <asp:DropDownList ID="ddlCtype" runat="server"></asp:DropDownList>
        <asp:RequiredFieldValidator ID="vldCtype" runat="server" ControlToValidate="ddlCtype" SetFocusOnError="true" CssClass="color-attention"><strong>*</strong></asp:RequiredFieldValidator> 
    </div>
    
    <div class="clear"></div>
    <hr class="opacity-50" />
    <div class="span-6">
        <p><asp:Label ID="lblInfoMsg" runat="server" Text="PersonalInfoMsg"></asp:Label></p>
    </div>

    <div class="clear"></div>
    <div class="span-1 row-start"></div>
    <div class="span-3 center row-start">
        <asp:Button ID="btnReset" runat="server" CssClass="button span-1" CausesValidation="false" onclick="btnReset_Click" />
    </div>
    <div class="span-2 row-end center">
        <asp:Button ID="btnSubmit" runat="server" CssClass="button span-1"  Text="Submit" onclick="btnSubmit_Click" />
    </div>

    <div class="clear"></div>
    <div class="span-1">
    </div>
    
    <div class="span-4 module-attention ">
        <h3 id="lblNotes" runat="server"></h3>
        <p ID="lblShipNote" runat="server"></p>
    </div>
    

</div>
</div>
</asp:Content>

