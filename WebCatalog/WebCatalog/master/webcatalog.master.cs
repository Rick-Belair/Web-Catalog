using System;
using System.Data;
using System.Configuration;
using System.Collections;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using CallBaseCRM.WebLang;
using System.Diagnostics;

public partial class master_WebCatalog : System.Web.UI.MasterPage
{
    protected Language oLang;

    public string PageTitle
    {
        /* FIXTHIS */
        get
        {
            return "";
            //return pageTitle.Text;
        }
        set
        {
            //pageTitle.Text = value;
        }
    }

    
    protected void Page_Load(object sender, EventArgs e)
    {
        string strUrlLang;
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
        /* FIX THIS */
        //rootHTML.Attributes.Remove("lang");

        /* FIX THIS */
        if (oLang.CurrentLanguage.Equals("F"))
        {
            //rootHTML.Attributes.Add("lang", "fr");
            //menuText.InnerText = "Menu secondaire";
        }
        else
        {
            //rootHTML.Attributes.Add("lang", "en");
            //menuText.InnerText = "Secondary menu";
        }

        oLang.SetLabel("Catalog");
        if (!IsPostBack)
        {
            PopulateFields();
        }
    }

    private void PopulateFields()
    {
        //hplLanguageSwitch.Text = oLang.GetLabel("LanguageSwitch");
    }
}
