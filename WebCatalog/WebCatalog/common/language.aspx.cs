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
using System.Diagnostics;

public partial class common_language : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        int pos;
        string lang;
        string url = Request.ServerVariables["HTTP_REFERER"];

        if (Session["Language"] != null)
        {
            lang = (Session["Language"] != null) ? Session["Language"].ToString() : "E";
            Session["Language"] = (lang == "E") ? "F" : "E";
        }
        else
        {
            if (Request.QueryString["l"] != null)
            {
                lang = Request.QueryString["l"];
            }
            else
            {
                lang = "E";
            }
            Session["Language"] = lang;
        }

        Session["category"] = null;
        Session["search"] = null;
        Session["advSearch"] = null;

        pos = url.IndexOf("?");
        if (pos > 1)
        {
            url = url.Substring(0, pos);
        }
        url = url + "?l=" + Session["Language"].ToString();

        // Quickfix to force the breadcrumb to refresh
        Session.Remove("HASH_OF_CRUMPS");

        Response.Redirect(url, true);
    }
}
