<%@ Page Title="" Language="C#" MasterPageFile="~/master/webcatalog.master" AutoEventWireup="true" CodeFile="cart.aspx.cs" Inherits="cart" %>
<%@ MasterType TypeName="master_WebCatalog" %>
<%@ Register TagPrefix="bc" TagName="BreadCrumb" Src="~/BreadCrumb/BreadCrumb.ascx" %>

<asp:Content ID="Content2" ContentPlaceHolderID="breadcrumbs" runat="server">
    <bc:BreadCrumb id="BreadCrumb1" Level="3" TailName="Name" runat="server"></bc:BreadCrumb>
</asp:Content>


<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
<div class="clear"></div>
<div class="span-6 margin-top-medium margin-bottom-none">
    <h2 id="lblTitle" class="background-accent" runat="server">Cart</h2>
</div>


<div class="clear"></div>
<div class="span-6 module margin-top-none">

<div class="clear"></div>
<div class="span-6">
    <asp:Label id="lblMsg" runat="server">
    </asp:Label>
    <asp:Label ID="lblPubMsg" runat="server"></asp:Label>

</div>

<div class="clear"></div>
<div  class="span-6" id="divGrid" runat="server" >
    <p id="lblInstructions" runat="server"></p>
<div style="height: auto;">
        <asp:GridView ID="grdvData" runat="server" AutoGenerateColumns="False" Visible="true" CssClass="tablepad"
            CellPadding="3" EnableViewState="true"  OnRowDataBound="grdvData_RowDataBound" OnRowCommand="grdvData_RowCommand">
            <Columns>
                 <asp:TemplateField HeaderText="Title">
                    <ItemTemplate>
                    <asp:Label ID="lblTitle" runat="server"></asp:Label>
                    <asp:HiddenField ID="hidSeq" runat="server" />
                    <asp:HiddenField ID="hidItem" runat="server" />
                    </ItemTemplate>
                </asp:TemplateField>

                 <asp:TemplateField HeaderText="Qty">
                    <ItemTemplate>
                    <div class="form-inline wrap-none">
                        <asp:DropDownList ID="ddlQty" runat="server"></asp:DropDownList>
                        <asp:Label ID="lblStatus" CssClass="color-attention" runat="server"></asp:Label>
                    </div>
                    </ItemTemplate>
                    <ItemStyle HorizontalAlign="Center" />
                </asp:TemplateField>

                <asp:TemplateField HeaderText="Delete">
                    <ItemTemplate>
                    <asp:Button ID="btnDeleteItem" CssClass="wb-icon-x" style="height:20px; width:20px" runat="server" CommandName="DeleteItem"  />
                    </ItemTemplate>
                    <ItemStyle HorizontalAlign="Center" />
                </asp:TemplateField>

            </Columns>
        </asp:GridView>
</div>
    
    <div class="clear"></div>
    <div class="span-1 row-start"></div>
    <div class="span-4 module-alert" id="modMsg" runat="server">
        <p id="pMsg" runat="server"></p>
    </div>
    <div class="span-1 row-end"></div>

    <div class="clear"></div>
    <br />
    <div class="span-2 row-start">
        <asp:Button ID="btnEmpty" runat="server" Text="Empty"  CssClass="btn btn-primary"
            onclick="btnEmpty_Click" />
            <asp:Button ID="btnUpdate" runat="server" Text="UpdateCart"  CssClass="btn btn-primary"
            onclick="btnUpdate_Click" />
            <asp:Button ID="btnContinue" runat="server" Text="Continue"  CssClass="btn btn-primary"
            onclick="btnContinue_Click" />
    </div>
    <div class="span-2">
       
    </div>
    <div class="span-2 row-end">

    </div>
</div>
</div>
</asp:Content>

