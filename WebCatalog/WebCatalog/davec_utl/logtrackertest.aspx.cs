using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using CallBaseCRM.Business.Workflows;

public partial class davec_utl_logtrackertest : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        WebCatalogManager wcMan = new WebCatalogManager(Request.ServerVariables["REMOTE_ADDR"], Session.SessionID);
        wcMan.LogActivity("WebCatalog", "davec_utl_logtrackertest", "Page_Load", "tester", "aspx", "testCode", "EN");
    }
}