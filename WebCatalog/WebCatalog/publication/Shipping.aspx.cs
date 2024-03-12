using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.Common;
using System.Diagnostics;
using CallBaseCRM.WebLang;
using CallBaseCRM.Business.Entities;
using CallBaseCRM.Business.Workflows;

public partial class publication_Shipping : WebCatBasePage
{
    protected Language oLang;
    protected WebCatalogManager catMan;
    protected Collection<BasketItem> basket;
    protected Dictionary<string, string> shippingInfo;
    protected void Page_Load(object sender, EventArgs e)
    {
        string strUrlLang;

        Session["thispage"] = "shipping.aspx";

        strUrlLang = Request.QueryString["l"];

        if (strUrlLang == null)
        {
            strUrlLang = "";
        }

        if (strUrlLang.ToUpper() == "F")
        {
            Session["Language"] = "F";
        }
        else if (strUrlLang.ToUpper() == "E")
        {
            Session["Language"] = "E";
        }
        else
        {
            if (Session["Language"] == null)
            {
                Session["Language"] = "E";
            }
        }

        oLang = new Language(Session);
        oLang.SetLabel("Shipping");

        Master.PageTitle = oLang.GetLabel("ShippingDetails");

        BreadCrumb1.TailName = oLang.GetLabel("ShippingDetails");

        shippingInfo = new Dictionary<string, string>();
        if (Session["shippingInfo"] != null)
            shippingInfo = (Dictionary<string, string>)Session["shippingInfo"];

        catMan = new WebCatalogManager(Request.ServerVariables["REMOTE_ADDR"], Session.SessionID);

        basket = new Collection<BasketItem>();
        if (Session["basket"] != null)
        {
            
            basket = (Collection<BasketItem>)Session["basket"];
            if (basket.Count == 0)
            {
                divShow.Visible = false;
                divEmpty.Visible = true;            
            }
        }
        else
        {
            divShow.Visible = false;
            divEmpty.Visible = true;            
        }

        if (!IsPostBack)
        {
            catMan.LogActivity("CRMweb.Shipping",
                Request.ServerVariables["URL"],
                "Open",
                "Viewing Page",
                "INV",
                null,
                oLang.CurrentLanguage);

            PopulateFields();
        }       
    }

    private void PopulateFields()
    {


        Master.PageTitle = oLang.GetLabel("ShippingDetails");
        lblTitle.InnerText = oLang.GetLabel("ShippingDetails");
        pEmpty.InnerText = oLang.GetLabel("ShoppingCartEmpty");
        lblMgs.InnerText = oLang.GetLabel("FreePubsMsg");
        lblShipMsg.InnerText = oLang.GetLabel("ShippingMessage");

        lblRequired.Text = oLang.GetLabel("RequiredFields");
        lblSalutation.Text = oLang.GetLabel("Salutation");
        lblFirst.Text = oLang.GetLabel("FirstName");
        lblLast.Text = oLang.GetLabel("LastName");
        lblJob.Text = oLang.GetLabel("JobTitle");
        lblCompany.Text = oLang.GetLabel("Company");
        lblAddress.Text = oLang.GetLabel("Address");
        lblCity.Text = oLang.GetLabel("City");
        lblProv.Text = oLang.GetLabel("Province");
        lblPostal.Text = oLang.GetLabel("PostalCode");
        lblCountry.Text = oLang.GetLabel("Country");
        lblCndMsg.Text = oLang.GetLabel("NonCdnOrdersMsg");
        lblAboriginalMsg.Text = oLang.GetLabel("AboriginalInfoMsg");
        lblDescribe.Text = oLang.GetLabel("DescribeYourself");
        lblTelEmailMsg.Text = oLang.GetLabel("RequestTelAndEmail");
        lblPhone.Text = oLang.GetLabel("Phone");
        lblEmail.Text = oLang.GetLabel("Email");
        lblInfoMsg.Text = oLang.GetLabel("PersonalInfoMsg");
        lblNotes.InnerText = oLang.GetLabel("Note");
        lblShipNote.InnerText = oLang.GetLabel("ShippingNote");
        btnReset.Text = oLang.GetLabel("Reset");
        btnSubmit.Text = oLang.GetLabel("Submit");

        vldFirst.ErrorMessage = oLang.GetLabel("AlertFirstName");
        vldAboriginal.ErrorMessage = oLang.GetLabel("AlertAboriginal");
        vldAddress.ErrorMessage = oLang.GetLabel("AlertAddress");
        vldCity.ErrorMessage = oLang.GetLabel("AlertCity");
        vldLast.ErrorMessage = oLang.GetLabel("AlertLastName");        
        vldPostal.ErrorMessage = oLang.GetLabel("AlertZipCode");
        vldProv.ErrorMessage = oLang.GetLabel("AlertProvince");
        vldCtype.ErrorMessage = oLang.GetLabel("AlertPublicCustType");
        vldPhone.ErrorMessage = oLang.GetLabel("AlertTeleEmail") ;
        vldEmail.ErrorMessage = oLang.GetLabel("AlertProperEmail");

        DataSet dsCat = catMan.GetProvinceList(oLang.CurrentLanguage);
        ddlProv.DataSource = dsCat;
        ddlProv.DataTextField = "Definition";
        ddlProv.DataValueField = "Code";
        ddlProv.DataBind();
        ddlProv.Items.Insert(0, new ListItem("", ""));
        ddlProv.SelectedIndex = 0;

        dsCat = catMan.GetAffiliationList(oLang.CurrentLanguage);
        ddlCtype.DataSource = dsCat;
        ddlCtype.DataTextField = "Gen_Def";
        ddlCtype.DataValueField = "Aff_Code";
        ddlCtype.DataBind();
        ddlCtype.Items.Insert(0, new ListItem("", ""));
        ddlCtype.SelectedIndex = 0;

        ddlSalutation.Items.Insert(0, new ListItem("", ""));
        ddlSalutation.Items.Insert(1, new ListItem(oLang.GetLabel("Mr"), oLang.GetLabel("Mr")));
        ddlSalutation.Items.Insert(2, new ListItem(oLang.GetLabel("Miss"), oLang.GetLabel("Miss")));
        ddlSalutation.Items.Insert(3, new ListItem(oLang.GetLabel("Mrs"), oLang.GetLabel("Mrs")));
        ddlSalutation.SelectedIndex = 0;

        ddlAboriginal.Items.Insert(0, new ListItem("", ""));
        ddlAboriginal.Items.Insert(1, new ListItem(oLang.GetLabel("Aboriginal"), "1"));
        ddlAboriginal.Items.Insert(2, new ListItem(oLang.GetLabel("NonAboriginal"), "2"));
        ddlAboriginal.Items.Insert(3, new ListItem(oLang.GetLabel("NoReply"), "3"));
        ddlCtype.SelectedIndex = 0;

        ViewCartBtn();
       
        if (Session["shippingInfo"] != null)
        {
            ddlSalutation.SelectedValue = shippingInfo["salutation"];
            txtFirst.Text = shippingInfo["firstName"];
            txtLast.Text = shippingInfo["lastName"];
            txtPosition.Text = shippingInfo["position"];
            txtOrganization.Text = shippingInfo["organization"];
            txtAddress.Text = shippingInfo["address"];
            txtAddress2.Text = shippingInfo["address2"];
            txtCity.Text = shippingInfo["city"];
            ddlProv.SelectedValue = shippingInfo["province"];
            txtPostal.Text = shippingInfo["postalCode"];
            txtCountry.Text = shippingInfo["country"];
            ddlAboriginal.SelectedValue = shippingInfo["aboriginal"];
            ddlCtype.SelectedValue = shippingInfo["cType"];
            txtPhone.Text = shippingInfo["phone"];
            txtEmail.Text = shippingInfo["email"];
        }

    }

    private void ViewCartBtn()
    {
        if (basket.Count > 0)
        {
            dViewCart.Visible = true;
            lblItemInCart.InnerText = oLang.GetLabel("ItemIsInCart") + " - " + basket.Count.ToString();
            hplViewCart.Text = oLang.GetLabel("View") + " " + oLang.GetLabel("Cart");
        }
        else
            dViewCart.Visible = false;
    }

    protected void hplViewCart_Click(object sender, EventArgs e)
    {
        Response.Redirect("~/publication/cart.aspx");
    }

    protected void btnReset_Click(object sender, EventArgs e)
    {

        this.ddlSalutation.SelectedIndex = -1;
        this.txtFirst.Text = "";
        this.txtLast.Text = "";
        this.txtOrganization.Text = "";
        this.txtPosition.Text = "";
        this.txtAddress.Text = "";
        this.txtAddress2.Text = "";
        this.txtCity.Text = "";
        this.ddlProv.SelectedIndex = -1;
        this.txtPhone.Text = "";
        this.txtPostal.Text = "";
        this.txtEmail.Text = "";
        this.ddlAboriginal.SelectedIndex = -1;
        this.ddlCtype.SelectedIndex = -1;
        //shippingInfo.Clear();
        //Session["shippingInfo"] = null;
    }

    protected void btnSubmit_Click(object sender, EventArgs e)
    {
        // Check to see if the session has 'timed out'. If so, don't try to save anything.

        if (Session["basket"] == null)
        {
            string strURL;
            string lang;
            lang = Request.QueryString["l"];
            if (lang == null)
            {
                lang = "E";
            }
            strURL = "SessionTimeout.aspx?l=" + lang;
            Response.Redirect(strURL);
        }

        if (IsValid)
        {
            catMan.LogActivity("CRMweb.Shipping",
                Request.ServerVariables["URL"],
                "Submit",
                "Shipping data saved",
                "INV",
                null,
                oLang.CurrentLanguage);
                
            shippingInfo.Clear();
            shippingInfo.Add("salutation", ddlSalutation.SelectedValue);
            shippingInfo.Add("firstName", txtFirst.Text);
            shippingInfo.Add("lastName", txtLast.Text);
            shippingInfo.Add("position", txtPosition.Text);
            shippingInfo.Add("organization", txtOrganization.Text);
            shippingInfo.Add("address", txtAddress.Text);
            shippingInfo.Add("address2", txtAddress2.Text);
            shippingInfo.Add("city", txtCity.Text);
            shippingInfo.Add("province", ddlProv.SelectedValue);
            shippingInfo.Add("provinceLong", ddlProv.SelectedItem.ToString());
            shippingInfo.Add("postalCode", txtPostal.Text);
            shippingInfo.Add("country", txtCountry.Text);
            shippingInfo.Add("cType", ddlCtype.SelectedValue);
            shippingInfo.Add("phone", txtPhone.Text);
            //shippingInfo.Add("phoneExt",);
            shippingInfo.Add("email", txtEmail.Text);
            shippingInfo.Add("language", oLang.CurrentLanguage);
            shippingInfo.Add("sessionID", Session.SessionID);
            shippingInfo.Add("aboriginal", ddlAboriginal.SelectedValue);
            Session["shippingInfo"] = shippingInfo;

            if (basket.Count > 0)
            {
                Session["orderNumber"] = catMan.SaveData(shippingInfo, basket, oLang);
                //basket.Clear();
                //Session["shippingInfo"] = "";
                Response.Redirect("shipping_result.aspx");

            }
            else
            {
                Response.Redirect("shipping_result.aspx");
            }

        }


    }

    protected void vldEmail_ServerValidate(object source, ServerValidateEventArgs args)
    {

        if (string.IsNullOrEmpty(txtPhone.Text) && string.IsNullOrEmpty(txtEmail.Text))
            args.IsValid = false;
        else
            args.IsValid = true;
    }

    protected void vldPhone_ServerValidate(object source, ServerValidateEventArgs args)
    {

        if (string.IsNullOrEmpty(txtPhone.Text) && string.IsNullOrEmpty(txtEmail.Text))
            args.IsValid = false;
        else
            args.IsValid = true;
    }

    public static void validationMSG(Page page, string message)
    {
        var validator = new CustomValidator();
        validator.IsValid = false;
        validator.ErrorMessage = message;
        page.Validators.Add(validator);
    }
}