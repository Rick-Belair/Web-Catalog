using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;


// Starting page for webcatalog
// Accepts CGI Variables from the URL, and sets the language and default catagory
// After, the application is redirected to the catalog category page.

public partial class publication_WebCatalogStart : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        String url;
        String cat = Request.QueryString["cat"];
        String lang = Request.QueryString["l"];

        url = "catalog.aspx?l=" + lang;
        Session["test"] = "SetInWebCatalogStart";
        ProcessUrlParameterLanguage(lang);

        if (cat != null)
        {
            Session["InitialCategory"] = cat;
        }
        else
        {
            Session["InitialCategory"] = "";
        }

        Response.Redirect(url, true);
        
    }

    protected void ProcessUrlParameterLanguage(string lang)
    {
        if (lang == null)
        {
            Session["Language"] = "E";
        }
        else if (lang.ToUpper() == "F")
        {
            Session["Language"] = "F";
        }
        else
        {
            Session["Language"] = "E";
        }

    }
}