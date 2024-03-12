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

public partial class publication_shipping_result : System.Web.UI.Page
{
    protected Language oLang;
    protected WebCatalogManager catMan;
    protected Collection<BasketItem> basket;
    protected Dictionary<string, string> shippingInfo;
    protected int cnt = 1;
    protected void Page_Load(object sender, EventArgs e)
    {
        string strUrlLang;

        Session["thispage"] = "shipping_result.aspx";

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
        oLang.SetLabel("ShippingResult");

        BreadCrumb1.TailName = oLang.GetLabel("ShippingDetails");

        basket = new Collection<BasketItem>();
        if (Session["basket"] != null)
        {
            basket = (Collection<BasketItem>)Session["basket"];
        }

        shippingInfo = new Dictionary<string, string>();
        if (Session["shippingInfo"] != null)
            shippingInfo = (Dictionary<string, string>)Session["shippingInfo"];

        catMan = new WebCatalogManager(Request.ServerVariables["REMOTE_ADDR"], Session.SessionID);

        if (!IsPostBack)
            PopulateFields();       

    }


    private void PopulateFields()
    {
        string confirmation;
        string shippingEmail;

        Master.PageTitle = oLang.GetLabel("ShippingDetails");
        catMan.LogActivity("CRMweb.Shipping",
            Request.ServerVariables["URL"],
            "Open",
            "Viewing Page",
            "INV",
            null,
            oLang.CurrentLanguage);



        H1WebCat.InnerText = oLang.GetLabel("ShippingDetails");

        shippingEmail = shippingInfo["email"];
        if (shippingEmail == null)
        {
            shippingEmail = "";
        }
        if (shippingEmail.Trim().Length > 0)
        {
            confirmation = oLang.GetLabel("ConfirmationMessageEmail");
            confirmation = confirmation.Replace("[order_no]", Session["orderNumber"].ToString());
            confirmation = confirmation.Replace("[email]", shippingInfo["email"]);
        }
        else
        {
            confirmation = oLang.GetLabel("ConfirmationMessageNoEmail");
            confirmation = confirmation.Replace("[order_no]", Session["orderNumber"].ToString());
        }
        pConfirmation.InnerText = confirmation;
        pDetails.InnerText = oLang.GetLabel("DetailsOfOrder");
        pOrderShip.InnerHtml = oLang.GetLabel("InStockOrderShipMsg");
        pShipTo.InnerText = oLang.GetLabel("ThisOrderWillbe") + ":";

        lblName.Text = oLang.GetLabel("webName");
        lblAddress.Text = oLang.GetLabel("webAddress");
        lblCity.Text = oLang.GetLabel("webCity");
        lblProvince.Text = oLang.GetLabel("webProvince");
        lblPostal.Text = oLang.GetLabel("webPostal");
        lblCountry.Text = oLang.GetLabel("Country");
        lblPhone.Text = oLang.GetLabel("webPhone");

        txtName.Text = shippingInfo["firstName"] + " " + shippingInfo["lastName"];
        txtAddress.Text = shippingInfo["address"] + "<BR>" + shippingInfo["address2"];
        txtCity.Text = shippingInfo["city"];
        txtProvince.Text = shippingInfo["province"];
        txtPostal.Text = shippingInfo["postalCode"];
        txtCountry.Text = shippingInfo["country"];
        txtPhone.Text = shippingInfo["phone"];

        FillDataGrid();

        basket.Clear();
        Session["basket"] = null;
        
    }

    private void FillDataGrid()
    {
        grdvData.DataSource = basket;
        grdvData.DataBind();
    }


    protected void grdvData_RowDataBound(object sender, GridViewRowEventArgs e)
    {        
        // Dispatch according to the row type
        switch (e.Row.RowType)
        {   
            case DataControlRowType.Header:
                // Add the column header labels
                int i = 0;
                i++;
                e.Row.Cells[i++].Text = oLang.GetLabel("Item");
                e.Row.Cells[i++].Text = oLang.GetLabel("OrderedQuantity");
                break;

            case DataControlRowType.DataRow:
                // Fill Grid
                Label lblCnt = (Label)e.Row.FindControl("lblCnt");
                lblCnt.Text = (cnt++).ToString();

                Label lblTitle = (Label)e.Row.FindControl("lblTitle");
                lblTitle.Text = (string)DataBinder.Eval(e.Row.DataItem, "Description").ToString();

                Label lblQty = (Label)e.Row.FindControl("lblQTY");
                lblQty.Text = (string)DataBinder.Eval(e.Row.DataItem, "Quantity").ToString();

                break;

            default:
                break;
        }

    }


}