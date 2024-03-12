using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using CallBaseCRM.Business.Workflows;

public partial class davec_utl_invqty : System.Web.UI.Page
{
    /// <summary>
    /// 
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void Page_Load(object sender, EventArgs e)
    {
    }
    
    /// <summary>
    /// 
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void btnSubmit_Click(object sender, EventArgs e)
    {
        WebCatalogManager wcMan = new WebCatalogManager(Request.ServerVariables["REMOTE_ADDR"], Session.SessionID);
        decimal available = wcMan.GetNumberOfAvailableItems(txtItem.Text.Trim());
        lblAvailable.Text = available.ToString();
        available = wcMan.GetQuantityAvailable(txtItem.Text.Trim());
        lblAvailable2.Text = available.ToString();
    }
}