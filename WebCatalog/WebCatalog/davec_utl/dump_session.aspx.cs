using System;
using System.Data;
using System.Configuration;
using System.Collections;
using System.Diagnostics;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;

public partial class davec_utl_dump_session : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        foreach (string key in Session.Keys)
        {
            HtmlTableRow tr = new HtmlTableRow();
            tblSessionVars.Rows.Add(tr);

            HtmlTableCell td = new HtmlTableCell();
            td.InnerText = key;
            tr.Cells.Add(td);
            td = new HtmlTableCell();
            td.InnerText = (Session[key] != null) ? Session[key].ToString() : "(null)";
            tr.Cells.Add(td);
        }

        lblTimeOut.Text = Session.Timeout.ToString();
    }
}
