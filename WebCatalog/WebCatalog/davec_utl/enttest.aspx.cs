using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using CallBaseCRM.Business.Entities;

public partial class davec_utl_enttest : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        FConstant constants = FConstant.Get();
        constants.City = "Ottawa";
        constants.Save();
    }
}