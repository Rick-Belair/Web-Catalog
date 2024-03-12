using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using CallBaseCRM.Business.Entities;

public partial class davec_utl_tinvtest : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        T_Inventory tinv = T_Inventory.Get(3264);
    }
}