using System;
using CallBaseCRM.WebLang;
using CallBaseCRM.Business.Entities;
using CallBaseCRM.Business.Workflows;
using System.Diagnostics;

public partial class publication_moreinfo : System.Web.UI.Page
{
    protected Language oLang;
    protected void Page_Load(object sender, EventArgs e)
    {
        decimal seq = 0;
        string lang;

        string strUrlLang;

        Session["thispage"] = "moreinfo.aspx";

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


        if (Request.QueryString["seq"] != null)
        {
            seq = Convert.ToInt32(Request.QueryString["seq"]);
            Session["moreinfo_seq"] = seq;
        }
        else if (Session["moreinfo_seq"] != null)
        {
            seq = Convert.ToInt32(Session["moreinfo_seq"]);
        }
        else
        {
            // redirect
            string strURL;

            lang = Request.QueryString["l"];
            if (lang == null)
            {
                lang = "E";
            }
            strURL = "SessionTimeout.aspx?l=" + lang;
            Response.Redirect(strURL);
        }

        oLang = new Language(Session);
        oLang.SetLabel("WCMoreInfo");

        BreadCrumb1.TailName = oLang.GetLabel("MoreInfo");        

        if (!IsPostBack)
        {
            //T_Inventory inv = T_Inventory.Get(decimal.Parse(Request.QueryString["seq"]));
            T_Inventory inv = T_Inventory.Get(seq);
            WebCatalogManager wcMan = new WebCatalogManager(Request.ServerVariables["REMOTE_ADDR"], Session.SessionID);
            wcMan.LogActivity("CRMweb.Catalog",
                Request.ServerVariables["URL"],
                "Open",
                "More info",
                "INV",
                inv.Item,
                oLang.CurrentLanguage);
            PopulateFields();
        }
    }

    private void PopulateFields()
    {
        if (Request != null)
        {
            if (Request.UrlReferrer != null)
            {
                if (hidRefPage.Value == "")
                    hidRefPage.Value = Request.UrlReferrer.ToString();
            }
        }

        int seq = 0;
        string lang;

        if (Request.QueryString["seq"] != null)
        {
            seq = Convert.ToInt32(Request.QueryString["seq"]);
            Session["moreinfo_seq"] = seq;
        }
        else if (Session["moreinfo_seq"] != null)
        {
            seq = Convert.ToInt32(Session["moreinfo_seq"]);
        }
        else
        {
            // redirect
            string strURL;
            
            lang = Request.QueryString["l"];
            if (lang == null)
            {
                lang = "E";
            }
            strURL = "SessionTimeout.aspx?l=" + lang;
            Response.Redirect(strURL);
        }

        T_Inventory inv = T_Inventory.Get(seq);


        lang = oLang.CurrentLanguage;
        Master.PageTitle = oLang.GetLabel("MoreInfo");
        lblMoreInfo.InnerText = oLang.GetLabel("MoreInfo");
        lblTitle.Text =  lang == "E" ? inv.Title : inv.TitleAlternate;
        lblDesc.InnerText = lang == "E" ? inv.InvDescription : inv.InvFrDescription;

        lblAuthor.Text = oLang.GetLabel("Author") + ": " + inv.InvAuthor;
        lblPrinted.Text = oLang.GetLabel("YearPrinted") + ": " + inv.InvDatePrinted;
        bntReturn.Text = oLang.GetLabel("ReturnToList");

        lang = inv.Language;
        switch (lang)
        {
            case "E":
                lang = oLang.GetLabel("English");
                break;
            case "F":
                lang = oLang.GetLabel("French");
                break;
            case "B":
                lang = oLang.GetLabel("Bilingual");
                break;
            default:
                lang = oLang.GetLabel("English");
                break;

        }

        lblLang.Text = oLang.GetLabel("Language") + ": " + lang;
        lblPub.Text = oLang.GetLabel("InacPubNo") + ": " + inv.Item;

    }

    protected void bntReturn_Click(object sender, EventArgs e)
    {
        Response.Redirect(hidRefPage.Value);
    }
}