﻿<%@ Page Title="" Language="C#" MasterPageFile="~/master/webcatalog.master" AutoEventWireup="true" CodeFile="shipping2.aspx.cs" Inherits="shipping2" %>
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



<div style="width: 100%; display: table">
<div style="display: table-row">

<div style="display: table-cell; vertical-align: top">
    <h2 id="lblTitle" class="background-accent" runat="server">Shipping</h2>
    <p id="lblShipMsg" runat="server"></p>
    <p ID="lblMgs" runat="server" class="margin-left-medium"></p>
    
</div>
<div style="display: table-cell; vertical-align: middle;">
<div id="dViewCart" runat="server"  class="module-summary  float-right margin-bottom-none margin-top-none">
    <p ID="lblItemInCart" runat="server"></p>
    <p class="align-center">
        <asp:LinkButton ID="hplViewCart" CausesValidation="false" CssClass="btn btn-primary" Text="viewCart" runat="server" onclick="hplViewCart_Click" ></asp:LinkButton>

    </p>
</div>
</div>

</div>  <!-- end table row -->
</div>  <!-- end table span -->

<asp:ValidationSummary ID="vldSummary" runat="server" CssClass="color-attention" style="font: itallic" />

<div class="span-6 module margin-top-none">
    <div class="span-6" id="divEmpty" runat="server" visible="false">
      <p id="pEmpty" runat="server" class="color-attention"></p>

    </div>
    <div id="divShow" runat="server">
    <div class="span-6">

        
    </div>

    <div class="span-2 row-start margin-bottom-none">
        <asp:Label ID="lblRequired" runat="server" CssClass="margin-left-medium"></asp:Label>
        <strong class="color-accent">*</strong>
    </div>

    <table class="tablepad">
    <tr>
    <td style="width:40%">
        <asp:Label ID="lblSalutation" runat="server" AssociatedControlID="ddlSalutation" CssClass="margin-left-medium"></asp:Label>
    </td>
    <td>
        <asp:DropDownList ID="ddlSalutation" runat="server"></asp:DropDownList>
    </td>
    </tr>

    <tr>
    <td>
        <asp:Label ID="lblFirst" runat="server" AssociatedControlID="txtFirst" CssClass="margin-left-medium"></asp:Label>
        <strong class="color-accent">*</strong>        
    </td>
    <td>
        <asp:TextBox ID="txtFirst" runat="server" MaxLength="20"></asp:TextBox>
        <asp:RequiredFieldValidator ID="vldFirst" runat="server" ControlToValidate="txtFirst" SetFocusOnError="true" Display="Static" CssClass="color-attention"><strong>*</strong></asp:RequiredFieldValidator> 
    </td>
    </tr>

    <tr>
    <td>
        <asp:Label ID="lblLast" runat="server" AssociatedControlID="txtLast" CssClass="margin-left-medium"></asp:Label>
        <strong class="color-accent">*</strong>
    </td>
    <td>
        <asp:TextBox ID="txtLast" runat="server" MaxLength="30"></asp:TextBox>
        <asp:RequiredFieldValidator ID="vldLast" runat="server" ControlToValidate="txtLast" SetFocusOnError="true" CssClass="color-attention"><strong>*</strong></asp:RequiredFieldValidator> 
    </td>
    </tr>

    <tr>
    <td>
        <asp:Label ID="lblJob" runat="server" AssociatedControlID="txtPosition" CssClass="margin-left-medium"></asp:Label>
    </td>
    <td>
        <asp:TextBox ID="txtPosition" runat="server" MaxLength="200"></asp:TextBox>
    </td>
    </tr>

    <tr>
    <td>
        <asp:Label ID="lblCompany" runat="server" AssociatedControlID="txtOrganization" CssClass="margin-left-medium"></asp:Label>
    </td>
    <td>
        <asp:TextBox ID="txtOrganization" runat="server" MaxLength="100"></asp:TextBox>
    </td>
    </tr>

    <tr>
    <td style="vertical-align:top">
        <asp:Label ID="lblAddress" runat="server" AssociatedControlID="txtAddress" CssClass="margin-left-medium"></asp:Label>
        <strong class="color-accent">*</strong>
    </td>
    <td>
        <asp:TextBox ID="txtAddress" runat="server" MaxLength="100"></asp:TextBox>
        <asp:RequiredFieldValidator ID="vldAddress" runat="server" ControlToValidate="txtAddress" SetFocusOnError="true" CssClass="color-attention"><strong>*</strong></asp:RequiredFieldValidator> 
        <br />
        <asp:TextBox ID="txtAddress2" runat="server" MaxLength="50"></asp:TextBox>
    </td>
    </tr>

    <tr>
    <td>
        <asp:Label ID="lblCity" runat="server" AssociatedControlID="txtCity" CssClass="margin-left-medium"></asp:Label>
        <strong class="color-accent">*</strong>
    </td>
    <td>
        <asp:TextBox ID="txtCity" runat="server" MaxLength="30"></asp:TextBox>
        <asp:RequiredFieldValidator ID="vldCity" runat="server" ControlToValidate="txtCity" SetFocusOnError="true" CssClass="color-attention"><strong>*</strong></asp:RequiredFieldValidator> 
     </td>
    </tr>

    <tr>
    <td>
        <asp:Label ID="lblProv" runat="server" AssociatedControlID="ddlProv" CssClass="margin-left-medium"></asp:Label>
        <strong class="color-accent">*</strong>
    </td>
    <td>
        <asp:DropDownList ID="ddlProv" runat="server"></asp:DropDownList>
        <asp:RequiredFieldValidator ID="vldProv" runat="server" ControlToValidate="ddlProv" SetFocusOnError="true" CssClass="color-attention"><strong>*</strong></asp:RequiredFieldValidator> 
    </td>
    </tr>

    <tr>
    <td>
        <asp:Label ID="lblPostal" runat="server" AssociatedControlID="txtPostal" CssClass="margin-left-medium"></asp:Label>
        <strong class="color-accent">*</strong>
    </td>
    <td>
        <asp:TextBox ID="txtPostal" runat="server" MaxLength="10"></asp:TextBox>
        <asp:RequiredFieldValidator ID="vldPostal" runat="server" ControlToValidate="txtPostal" SetFocusOnError="true" CssClass="color-attention"><strong>*</strong></asp:RequiredFieldValidator> 
    </td>
    </tr>

    <tr>
    <td>
        <asp:Label ID="lblCountry" runat="server" AssociatedControlID="txtCountry" CssClass="margin-left-medium"></asp:Label>
    </td>
    <td>
        <asp:Label ID="txtCountry" runat="server" Text="Canada" MaxLength="50"></asp:Label>
    </td>
    </tr>

    <tr>
    <td colspan="2">
        <p><asp:Label ID="lblCndMsg" runat="server" CssClass="color-attention" Text="NonCdnOrdersMsg"></asp:Label></p>
    </td>
    </tr>

    <tr>
    <td colspan="2">
    <hr class="opacity-50" />
    </td>
    </tr>

    <tr>
    <td colspan="2">
        <p><asp:Label ID="lblTelEmailMsg" runat="server" Text="RequestTelAndEmail"></asp:Label></p>
    </td>
    </tr>

    <tr>
    <td>
    <asp:Label ID="lblPhone" AssociatedControlID="txtPhone" runat="server" Text="Phone" CssClass="margin-left-medium"></asp:Label>
        <strong class="color-accent">*</strong>
    </td>
    <td>
        <asp:TextBox ID="txtPhone" runat="server" ValidationGroup="vldEmailPhone" MaxLength="25"></asp:TextBox>
        <asp:CustomValidator id="vldPhone" runat="server" SetFocusOnError="true"  ClientValidationFunction="validatePhoneEmail" CssClass="color-attention"><strong>*</strong></asp:CustomValidator>
    </td>
    </tr>

    <tr>
    <td>
        <asp:Label ID="lblEmail" AssociatedControlID="txtEmail" runat="server" Text="Email" CssClass="margin-left-medium"></asp:Label>
        <strong class="color-accent">*</strong>
    </td>
    <td>
        <asp:TextBox ID="txtEmail" runat="server" CssClass="span-3"  ValidationGroup="vldEmailPhone" MaxLength="100"></asp:TextBox>
        <asp:CustomValidator id="vldEmail" runat="server" SetFocusOnError="true" ClientValidationFunction="validateEmail"  CssClass="color-attention"><strong>*</strong></asp:CustomValidator>
    </td>
    </tr>

    <tr>
    <td colspan="2">
    <hr class="opacity-50" />
    </td>
    </tr>
    <tr>

    <td>
        <asp:Label ID="lblAboriginalMsg" runat="server" Text="AboriginalInfoMsg"></asp:Label>
        <strong class="color-accent">*</strong>
    </td>
    <td>
        <asp:DropDownList ID="ddlAboriginal" runat="server"></asp:DropDownList>
        <asp:RequiredFieldValidator ID="vldAboriginal" runat="server" ControlToValidate="ddlAboriginal" SetFocusOnError="true" CssClass="color-attention">
        <strong>*</strong></asp:RequiredFieldValidator> 
    </td>
    </tr>
    
    <tr>
    <td>
        <asp:Label ID="lblDescribe" runat="server" Text="DescribeYourself"></asp:Label>
        <strong class="color-accent">*</strong>
    </td>
    <td>        
        <asp:DropDownList ID="ddlCtype" runat="server"></asp:DropDownList>
        <asp:RequiredFieldValidator ID="vldCtype" runat="server" ControlToValidate="ddlCtype" SetFocusOnError="true" CssClass="color-attention">
        <strong>*</strong></asp:RequiredFieldValidator> 
    </td>
    </tr>
    <tr>
    <td colspan="2">
    <hr class="opacity-50" />
    </td>
    </tr>

    <tr>
    <td colspan="2">
    <asp:Label ID="lblInfoMsg" runat="server" Text="PersonalInfoMsg"></asp:Label>
    </td>
    </tr>
    <tr>
    <td>
      &nbsp;
    </td>
    <td>
        <asp:Button ID="btnReset" runat="server" CssClass="btn btn-primary" CausesValidation="false" onclick="btnReset_Click" />
        &nbsp;&nbsp;
        <asp:Button ID="btnSubmit" runat="server" CssClass="btn btn-primary"  Text="Submit" onclick="btnSubmit_Click" />
    </td>
    </tr>

    </table>
    
    <div class="span-4 module-attention ">
        <h3 id="lblNotes" runat="server"></h3>
        <p ID="lblShipNote" runat="server"></p>
    </div>


</div>
</div>
</asp:Content>

