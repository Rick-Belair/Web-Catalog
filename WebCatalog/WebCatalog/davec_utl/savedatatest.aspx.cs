using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using CallBaseCRM.Business.Workflows;
using CallBaseCRM.Business.Entities;
using CallBaseCRM.WebLang;

public partial class davec_utl_savedatatest : System.Web.UI.Page
{
    /// <summary>
    /// 
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void Page_Load(object sender, EventArgs e)
    {
        WebCatalogManager wcMan = new WebCatalogManager(Request.ServerVariables["REMOTE_ADDR"], Session.SessionID);
        Language oLang = new Language(Session);
        oLang.SetLabel("ShippingResult");

        Dictionary<string, string> values = new Dictionary<string, string>();
        Collection<BasketItem> basket = new Collection<BasketItem>();

        values["salutation"] = "Mr";
        values["firstName"] = "Dave";
        values["lastName"] = "Christie";
        values["position"] = "Systems Analyst";
        values["organization"] = "SSC";
        values["address"] = "99 Metcalfe Street";
        values["address2"] = "9th Floor";
        values["city"] = "Ottawa";
        values["province"] = "Ontario";
        values["postalCode"] = "K1P 6L7";
        values["country"] = "Canada";
        values["cType"] = "???";
        values["phone"] = "613-960-0739";
        values["email"] = "dave.christie@ssc.gc.ca";
        values["language"] = "E";
        values["sessionID"] = "???";
        values["aboriginal"] = "1";
        wcMan.SaveData(values, basket, oLang);
    }
}