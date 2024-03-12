using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using CallBaseCRM.Business.Workflows;
using CallBaseCRM.WebLang;

public partial class publication_display_file : System.Web.UI.Page
{
    /// <summary>
    /// 
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void Page_Load(object sender, EventArgs e)
    {
        Session["thispage"] = "display_file.aspx";

        Language oLang = new Language(Session);

        WebCatalogManager wcMan = new WebCatalogManager(Request.ServerVariables["REMOTE_ADDR"], Session.SessionID);
        wcMan.LogActivity("CRMweb.Catalog",
            Request.ServerVariables["URL"],
            "View",
            "Document Download",
            ((Request.QueryString["pdf"] == "y") ? "PDF" : "HTML"),
            Request.QueryString["item"],
            oLang.CurrentLanguage);

        Response.Redirect(Server.UrlDecode(Request.QueryString["link"]), true);
    }
}