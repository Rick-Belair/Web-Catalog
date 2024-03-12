using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using CallBaseCRM.Shared.DataAccess.Helper;

public partial class davec_utl_oracletypemapping : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        DAHelper da = new DAHelper();
        string strSQL =
            @"SELECT *
            FROM T_Client_Order";
        DataSet ds = da.Execute(strSQL, CommandType.Text);
    }
}