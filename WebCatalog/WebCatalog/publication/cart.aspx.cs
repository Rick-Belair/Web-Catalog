using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.Common;
using System.Diagnostics;
using CallBaseCRM.WebLang;
using CallBaseCRM.Business.Entities;
using CallBaseCRM.Business.Workflows;


public partial class cart : System.Web.UI.Page
{
    protected Language oLang;
    protected WebCatalogManager catMan;
    protected Collection<BasketItem> basket;
    protected bool msg;


    protected void Page_Load(object sender, EventArgs e)
    {

        string strUrlLang;

        Session["thispage"] = "cart.aspx";

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
        oLang.SetLabel("ViewCart");

        BreadCrumb1.TailName = oLang.GetLabel("Cart");

        basket = new Collection<BasketItem>();
        if (Session["basket"] != null)
        {
            basket = (Collection<BasketItem>)Session["basket"];
        }

        catMan = new WebCatalogManager(Request.ServerVariables["REMOTE_ADDR"], Session.SessionID);

        if (!IsPostBack)
        {
            catMan.LogActivity("CRMweb.Basket",
                Request.ServerVariables["URL"],
                "Open",
                "Viewing Page",
                "INV",
                null,
                oLang.CurrentLanguage);

            PopulateFields();
        }
    }

    private void PopulateFields()
    {
        Master.PageTitle = oLang.GetLabel("Cart");
        lblTitle.InnerText = oLang.GetLabel("Cart");
        pMsg.InnerText = oLang.GetLabel("OUT_OF_STOCK2");

        modMsg.Visible = false;

        if (basket.Count == 0)
        {
            divGrid.Visible = false;
            lblPubMsg.Text = oLang.GetLabel("ShoppingCartEmpty");
            lblPubMsg.CssClass = "color-attention";
            lblMsg.CssClass = "color-attention";
        }
        else
        {
            lblPubMsg.Text = oLang.GetLabel("FreePubsMsg");
            lblInstructions.InnerText = oLang.GetLabel("YouCanChange");
            btnContinue.Text = oLang.GetLabel("Continue");
            btnEmpty.Text = oLang.GetLabel("EmptyCart");
            btnUpdate.Text = oLang.GetLabel("UpdateCart");
            //if (oLang.CurrentLanguage == "F")
            //    btnUpdate.CssClass = "button span-2 float-right";
            FillDataGrid();
        }
    }


    private void FillDataGrid()
    {
        Master.PageTitle = oLang.GetLabel("Cart");

        grdvData.DataSource = basket;
        grdvData.DataBind();
    }

    protected void grdvData_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        // Dispatch according to the row type
        switch (e.Row.RowType)
        {
            case DataControlRowType.Header:
                // Add the column header labels
                int i = 0;
                e.Row.Cells[i++].Text = oLang.GetLabel("Title");
                e.Row.Cells[i++].Text = oLang.GetLabel("OrderedQuantity");
                e.Row.Cells[i++].Text = oLang.GetLabel("Delete");

                break;

            case DataControlRowType.DataRow:
                // Fill Grid
                Label lblTitle = (Label)e.Row.FindControl("lblTitle");
                lblTitle.Text = (string)DataBinder.Eval(e.Row.DataItem, "Description").ToString();

                // Quantity Drop Down list
                DropDownList ddlQty = (DropDownList)e.Row.FindControl("ddlQTY");
                int quota = int.Parse(DataBinder.Eval(e.Row.DataItem, "Quota").ToString());
                for (int cnt = 0; cnt < quota; cnt++)
                {
                    ddlQty.Items.Insert(cnt, new ListItem((cnt + 1).ToString(), (cnt + 1).ToString()));
                }
                string qty = (string)DataBinder.Eval(e.Row.DataItem, "Quantity").ToString();
                ddlQty.SelectedValue = qty;

                HiddenField hidSeq = (HiddenField)e.Row.FindControl("hidSeq");
                hidSeq.Value = (string)DataBinder.Eval(e.Row.DataItem, "InvSeq").ToString();

                HiddenField hidItem = (HiddenField)e.Row.FindControl("hidItem");
                hidItem.Value = (string)DataBinder.Eval(e.Row.DataItem, "Item").ToString();

                Button btnDeleteItem = (Button)e.Row.FindControl("btnDeleteItem");
                btnDeleteItem.CommandArgument = hidSeq.Value;

                Label lblStatus = (Label)e.Row.FindControl("lblStatus");
                string status = (string)DataBinder.Eval(e.Row.DataItem, "Description").ToString();
                if ((status == "B") || (status == "BackOrder"))
                {
                    lblStatus.CssClass = "wb-icon-exclamation-alt";
                    msg = true;

                }
                else if (qty != null)
                {
                    decimal available = catMan.GetQuantityAvailable(hidItem.Value);
                    if (available < int.Parse(qty))
                    {
                        lblStatus.CssClass = "wb-icon-exclamation-alt";
                        msg = true;
                    }
                }

                break;

            default:
                break;
        }
        if (msg == true)
            modMsg.Visible = true;
            
    }


    protected void grdvData_RowCommand(Object sender, GridViewCommandEventArgs e)
    {

        // Check to see if the session has 'timed out'. If so, don't try to save anything.

        if (Session["basket"] == null)
        {
            string strURL;
            string lang;
            lang = Request.QueryString["l"];
            if (lang == null)
            {
                lang = "E";
            }
            strURL = "SessionTimeout.aspx?l=" + lang;
            Response.Redirect(strURL);
        }

        if (e.CommandName == "DeleteItem")
        {
            catMan.LogActivity("CRMweb.Basket",
                Request.ServerVariables["URL"],
                "Remove",
                "Remove Item from Basket",
                "INV",
                null,
                oLang.CurrentLanguage);

            BasketItem bi = new BasketItem();
            bi.InvSeq = int.Parse(e.CommandArgument.ToString());
            int invSeq = basket.IndexOf(bi);

            basket.RemoveAt(invSeq);

            Session["basket"] = basket;
            FillDataGrid();

            if (basket.Count == 0)
            {
                PopulateFields();
            }
        }
    }

    protected void btnUpdate_Click(object sender, EventArgs e)
    {
        // Check to see if the session has 'timed out'. If so, don't try to save anything.
        if (Session["basket"] == null)
        {
            string strURL;
            string lang;
            lang = Request.QueryString["l"];
            if (lang == null)
            {
                lang = "E";
            }
            strURL = "SessionTimeout.aspx?l=" + lang;
            Response.Redirect(strURL);
        }

        catMan.LogActivity("CRMweb.Basket",
            Request.ServerVariables["URL"],
            "Modify",
            "Viewing Page",
            "INV",
            null,
            oLang.CurrentLanguage);

        int i = 0;
        int qty;
        foreach (GridViewRow row in grdvData.Rows)
        {
            DropDownList ddlQty = (DropDownList)row.FindControl("ddlQty");
            qty = int.Parse(ddlQty.SelectedValue);
            basket[i].Quantity = qty;

            i++;
        }

        Session["basket"] = basket;
        FillDataGrid();
    }


    protected void btnEmpty_Click(object sender, EventArgs e)
    {
        catMan.LogActivity("CRMweb.Basket",
            Request.ServerVariables["URL"],
            "Remove",
            "Remove All Items from Basket",
            "INV",
            null,
            oLang.CurrentLanguage);

        basket.Clear();
        Session["basket"] = basket;
        PopulateFields();
       
    }

    protected void btnContinue_Click(object sender, EventArgs e)
    {
        Response.Redirect("shipping2.aspx");

    }
}