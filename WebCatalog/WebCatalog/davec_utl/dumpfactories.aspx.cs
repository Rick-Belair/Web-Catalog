using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.Common;

public partial class davec_utl_dumpfactories : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        DataTable dt = DbProviderFactories.GetFactoryClasses();
        grdvwFactories.DataSource = dt;
        grdvwFactories.DataBind();
    }
}