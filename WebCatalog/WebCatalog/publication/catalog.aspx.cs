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

public partial class catalog_catalog : System.Web.UI.Page
{
    protected Language oLang;
    protected WebCatalogManager catMan;
    private Collection<BasketItem> basket;
    private Dictionary<string, string> searchValues;
    
    protected void Page_Load(object sender, EventArgs e)
    {

        string strInitialCategory;
        
        Session.Timeout = 60;

        Session["thispage"] = "catalog.aspx";

       // if (Session.Count == 0)
       // {
            string strUrlLang;
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

            if (strUrlLang == null)
            {
                strUrlLang = "E";
            }
        /*
            if (Session["Language"] == null)
            {
                if (strUrlLang.ToUpper() == "F")
                {
                    Session["Language"] = "F";
                }
                else
                {
                    Session["Language"] = "E";
                }
            }
         * */
       // }

        oLang = new Language(Session);
        oLang.SetLabel("Catalog");

        BreadCrumb1.TailName = oLang.GetLabel("PublicationsCatalog");


        basket = new Collection<BasketItem>();
        if (Session["basket"] != null)
        {
            basket = (Collection<BasketItem>)Session["basket"];            
        }

        // Might be loosing the session variable here... (AllanS)
        searchValues = new Dictionary<string, string>();
        if (Session["category"] != null)
            searchValues = (Dictionary<string, string>)Session["category"];

        catMan = new WebCatalogManager(Request.ServerVariables["REMOTE_ADDR"], Session.SessionID);        
        
        if (!IsPostBack)
        {
            catMan.LogActivity("CRMweb.Catalog", Request.ServerVariables["URL"], "Open", "Viewing Page", "INV", null, oLang.CurrentLanguage);
            PopulateFields();
        }

        if (Session["InitialCategory"] != null)
        {
            strInitialCategory = Session["InitialCategory"].ToString();
            if (strInitialCategory.Length > 0)
            {
                SetUpInitialCategory(strInitialCategory);
            }
            Session["InitialCategory"] = "";
        }

    }

    private void PopulateFields()
    {
        // set labels
        Master.PageTitle = oLang.GetLabel("PublicationsCatalog");


        /* FIXTHIS */
        //H1WebCat.InnerText = oLang.GetLabel("PublicationsCatalog");
        imgProdCat.AlternateText = oLang.GetLabel("PublicationImages");
        lblWelcome.InnerText = oLang.GetLabel("SelectAndGo");       
        lblCategory.Text = oLang.GetLabel("Category");
        lblSelect.Text = oLang.GetLabel("SelectCategoryAndClickGo");
        btnGo.Text = oLang.GetLabel("Go");

        DataSet dsCat = catMan.GetCatalogCategories(oLang.CurrentLanguage);         
        ddlCategory.DataSource = dsCat;
        ddlCategory.DataTextField = "Pt_Definition";
        ddlCategory.DataValueField = "Pt_Code";
        ddlCategory.DataBind();
        ddlCategory.SelectedIndex = 0;

        ViewCartBtn();

        if (Session["category"] != null)
        {
            ddlCategory.SelectedValue = searchValues["Category"].ToString();
            FillDataGrid();
        }
        else
            dGridArea.Visible = false;
            
    }

    protected void SetUpInitialCategory(string cat)
    {
        int c;
        Boolean blnItemFound;

        blnItemFound = false;
        for (c = 0; c < ddlCategory.Items.Count; c++)
        {
            if (cat == ddlCategory.Items[c].Value.ToString())
            {
                blnItemFound = true;
            }
        }

        if (blnItemFound == true)
        {
            ddlCategory.SelectedValue = cat;

            if (ddlCategory.SelectedIndex >= 0)
            {
                catMan.LogActivity("CRMweb.Catalog", Request.ServerVariables["URL"], "Filter", "Go search", "INV", null, oLang.CurrentLanguage);
                searchValues.Clear();
                searchValues.Add("Category", cat);
                searchValues.Add("PubLang", "E");
                searchValues.Add("Lang", "E");
                Session["category"] = searchValues;
                FillDataGrid();
            }
        }

    }

    protected void btnGo_Click(object sender, EventArgs e)
    {
        catMan.LogActivity("CRMweb.Catalog", Request.ServerVariables["URL"], "Filter", "Go search", "INV", null, oLang.CurrentLanguage);
        searchValues.Clear();
        searchValues.Add("Category", ddlCategory.SelectedValue);
        searchValues.Add("PubLang", oLang.CurrentLanguage);
        searchValues.Add("Lang", oLang.CurrentLanguage);
        Session["category"] = searchValues;
        FillDataGrid();

        Master.PageTitle = oLang.GetLabel("PublicationsCatalog");

    }

    public static void validationMSG(Page page, string message)
    {
        var validator = new CustomValidator();
        validator.IsValid = false;
        validator.ErrorMessage = message;
        page.Validators.Add(validator);
    }

    #region Grid

    private void ViewCartBtn()
    {
        if (basket.Count > 0)
        {
            dViewCart.Visible = true;
            lblItemInCart.InnerText = oLang.GetLabel("ItemIsInCart") + " - " + basket.Count.ToString();
            hplViewCart.Text = oLang.GetLabel("View") + " " + oLang.GetLabel("Cart") ;
        }
        else
            dViewCart.Visible = false;
    }

    protected void hplViewCart_Click(object sender, EventArgs e)
    {
        string strUrlLang;
        strUrlLang = Request.QueryString["l"];

        if (strUrlLang == null)
        {
            strUrlLang = "E";
        }
        if (Session["Language"] == null)
        {
            if (strUrlLang.ToUpper() == "F")
            {
                Session["Language"] = "F";
            }
            else
            {
                Session["Language"] = "E";
            }
        }

        Response.Redirect("~/publication/cart.aspx?l=" + Session["Language"].ToString());
    }

    private void FillDataGrid()
    {
        Master.PageTitle = oLang.GetLabel("PublicationsCatalog");

        dGridArea.Visible = true;
        DataSet ds = catMan.GetPublicationList(searchValues);
        int cnt = ds.Tables[0].Rows.Count;
        grdvData.DataSource = ds;
        grdvData.DataBind();
        string found = oLang.GetLabel("FoundNoResults");

        if (grdvData.Rows.Count > 0)
        {
            found = found.Replace("[NO]", cnt.ToString());
            lblToOrder.InnerText = oLang.GetLabel("ToOrderPubs");
        }
        else
        {
            found = found.Replace("[NO]", "0");
            dGridArea.Visible = false;
            validationMSG(this, oLang.GetLabel("RepNoResult"));
        }
        found = found.Replace("[CATAGORY]", ddlCategory.SelectedItem.ToString());
        lblFound.InnerText = found;
        ViewCartBtn();
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void grdvData_RowDataBound(object sender, GridViewRowEventArgs e)
    {
       // Debugger.Break();
        string link;
        string pdf;
        string status;
        string title;
        string strToolTip;
        string strHtmlBroke;
        string strPdfBroke;

        // Dispatch according to the row type
        switch (e.Row.RowType)
        {
            case DataControlRowType.Header:
                // Add the column header labels
                int i = 0;
                e.Row.Cells[i++].Text = oLang.GetLabel("MoreInfo");
                e.Row.Cells[i++].Text = oLang.GetLabel("PubTitle");
                e.Row.Cells[i++].Text = oLang.GetLabel("Language");
                e.Row.Cells[i++].Text = oLang.GetLabel("PubHTML");
                e.Row.Cells[i++].Text = "PDF";
                e.Row.Cells[i++].Text = oLang.GetLabel("Add");
                break;

            case DataControlRowType.DataRow:
                // Fill in some fields
                HiddenField hidItem = (HiddenField)e.Row.FindControl("hidItem");
                hidItem.Value = (string)DataBinder.Eval(e.Row.DataItem, "inv_seq").ToString();
                HyperLink hplCode = (HyperLink)e.Row.FindControl("hplCode");
                hplCode.NavigateUrl = "moreinfo.aspx?l=" + Session["language"].ToString() + "&seq=" + hidItem.Value;
                Label lblText = (Label)e.Row.FindControl("lblText");
                title = (string)DataBinder.Eval(e.Row.DataItem, "Title").ToString();
                lblText.Text = (string)DataBinder.Eval(e.Row.DataItem, "Title").ToString();
                HyperLink hplHTML = (HyperLink)e.Row.FindControl("hplHtml");
                link = (string)DataBinder.Eval(e.Row.DataItem, "inv_picture_filename").ToString();
                strHtmlBroke = (string)DataBinder.Eval(e.Row.DataItem, "inv_html_brk").ToString();
                if (link == "")
                {
                    hplHTML.NavigateUrl = "";
                }
                else if (strHtmlBroke == "YES")
                {
                    hplHTML.CssClass = "wb-icon-x-alt2";
                    strToolTip = oLang.GetLabel("HTMLLinkBrokenAltText");
                    hplHTML.ToolTip = strToolTip;
                }
                else
                {
                    hplHTML.CssClass = "wb-icon-drive-arrow";

                    strToolTip = oLang.GetLabel("ViewHTML");
                    strToolTip = strToolTip.Replace("[publication_title]", title);
                    hplHTML.ToolTip = strToolTip;

                    hplHTML.NavigateUrl = "display_file.aspx?link=" + Server.UrlEncode(link) + "&item="
                        + DataBinder.Eval(e.Row.DataItem, "item").ToString() + "&pdf=n";
                }

                HyperLink hplPDF = (HyperLink)e.Row.FindControl("hplPDF");
                pdf = (string)DataBinder.Eval(e.Row.DataItem, "inv_pdf_filename").ToString();
                strPdfBroke = (string)DataBinder.Eval(e.Row.DataItem, "inv_pdf_brk").ToString();

                if (pdf == "")
                {
                    hplPDF.NavigateUrl = "";
                }
                else if (strPdfBroke == "YES")
                {
                    hplPDF.CssClass = "wb-icon-x-alt2";
                    strToolTip = oLang.GetLabel("PDFNotFoundAltText");
                    hplPDF.ToolTip = strToolTip;
                }
                else
                {
                    hplPDF.CssClass = "wb-icon-drive-download";

                    strToolTip = oLang.GetLabel("ViewPDF");
                    strToolTip = strToolTip.Replace("[publication_title]", title);
                    hplPDF.ToolTip = strToolTip;

                    hplPDF.NavigateUrl = "display_file.aspx?link=" + Server.UrlEncode(pdf) + "&item="
                        + DataBinder.Eval(e.Row.DataItem, "item").ToString() + "&pdf=y";
                }      
          
                status = (string)DataBinder.Eval(e.Row.DataItem, "Status").ToString();
                Button btnAdd = (Button)e.Row.FindControl("btnAdd");
                Label lblAdd = (Label)e.Row.FindControl("lblAdd");
                btnAdd.ToolTip = oLang.GetLabel("AddtoShoppingCart");

               

                if (status == "E")
                {
                    btnAdd.Visible = false;
                    lblAdd.Visible = true;
                    lblAdd.Text = oLang.GetLabel("NotAvailable");      
                }
               else
                {
                    BasketItem bi = new BasketItem();
                    bi.InvSeq = decimal.Parse(hidItem.Value);
                    if (basket.IndexOf(bi) >= 0)
                    {

                        btnAdd.Visible = false;
                        lblAdd.Visible = true;
                        lblAdd.CssClass = "wb-icon-tick";
                    }
                    else
                    {
                        btnAdd.Text = oLang.GetLabel("Add");
                        btnAdd.CommandArgument = hidItem.Value;
                    }
                }

                btnAdd.Text = oLang.GetLabel("Add");
                btnAdd.CommandArgument = hidItem.Value;


                switch (status)
                {
                    case "E": //online only
                
                        break;

                    case "B": //Backorder
                        //lblAdd.Visible = false;
                        
                        break;

                    case "A": // Available
                       // lblAdd.Visible = false;
                        break;

                    case "N": //New
                       // lblAdd.Visible = false;
                        break;
                }

                break;

            default:
                break;
        }


        
    }

    protected void grdvData_RowCommand(Object sender, GridViewCommandEventArgs e)
    {

        if (e.CommandName == "AddToCart")
        {
            if (Session.Count <= 1)
            {
                String strUrl;
                string lang;
                lang = Request.QueryString["l"];
                if (lang == null)
                {
                    lang = "E";
                }
                strUrl = "SessionTimeout.aspx?l=" + lang;

                Response.Redirect(strUrl);
            }

            decimal invSeq = decimal.Parse(e.CommandArgument.ToString());
            T_Inventory inv = T_Inventory.Get(invSeq);
            catMan.LogActivity("CRMweb.Basket", Request.ServerVariables["URL"], "Add", "Add Item to Basket", "INV",
                inv.Item, oLang.CurrentLanguage);
            
            catMan.AddToBasket(invSeq, basket);

            Session["basket"] = basket;
            Session["category"] = searchValues;
            FillDataGrid();
        }
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void grdvData_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        // Get the new page index and redisplay the grid
        grdvData.PageIndex = e.NewPageIndex;
        FillDataGrid();
    }

    #endregion
}