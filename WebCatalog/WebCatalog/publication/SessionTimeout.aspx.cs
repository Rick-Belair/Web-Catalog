using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using CallBaseCRM.WebLang;

public partial class publication_SessionTimeout : System.Web.UI.Page
{
    protected Language oLang;

    protected void Page_Load(object sender, EventArgs e)
    {
        string strUrlLang;

        Session["thispage"] = "sessiontimeout.aspx";

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
        oLang.SetLabel("Basket");

        txtMsg.Text = oLang.GetLabel("SESSION_EXPIRED");

    }
}