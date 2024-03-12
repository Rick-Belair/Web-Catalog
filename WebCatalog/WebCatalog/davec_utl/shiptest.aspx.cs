using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using CallBaseCRM.Business.Workflows;

public partial class davec_utl_shiptest : System.Web.UI.Page
{
    private WebCatalogManager wcMan;

    protected void Page_Load(object sender, EventArgs e)
    {
        wcMan = new WebCatalogManager(Request.ServerVariables["REMOTE_ADDR"], Session.SessionID);

        ddlProvince.DataSource = wcMan.GetProvinceList(ddlLanguage.SelectedValue);
        ddlProvince.DataValueField = ddlProvince.DataTextField = "DEFINITION";
        ddlProvince.DataBind();

        ddlAffiliation.DataSource = wcMan.GetAffiliationList(ddlLanguage.SelectedValue);
        ddlAffiliation.DataValueField = "AFF_CODE";
        ddlAffiliation.DataTextField = "GEN_DEF";
        ddlAffiliation.DataBind();
        ddlAffiliation.Items.Insert(0, new ListItem("", ""));
    }
}