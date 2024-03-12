using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using CallBaseCRM.Business.Entities;

public partial class davec_utl_biequals : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        Collection<BasketItem> basket = new Collection<BasketItem>();

        BasketItem bi = new BasketItem();
        bi.InvSeq = 1;
        basket.Add(bi);
        bi = new BasketItem();
        bi.InvSeq = 2;
        basket.Add(bi);
        bi = new BasketItem();
        bi.InvSeq = 3;
        basket.Add(bi);

        bi = new BasketItem();
        bi.InvSeq = 1;
        int index = basket.IndexOf(bi);
        bi = new BasketItem();
        bi.InvSeq = 5;
        index = basket.IndexOf(bi);
        bi = new BasketItem();
        bi.InvSeq = 3;
        index = basket.IndexOf(bi);
    }
}