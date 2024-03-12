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

public partial class publication_Advsearch : System.Web.UI.Page
{
    protected Language oLang;
    protected WebCatalogManager catMan;
    private Collection<BasketItem> basket;
    private Dictionary<string, string> searchValues;
    
    protected void Page_Load(object sender, EventArgs e)
    {
        string strUrlLang;

        Session["thispage"] = "advsearch.aspx";

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
        oLang.SetLabel("Catalog");

        BreadCrumb1.TailName = oLang.GetLabel("AdvTitle");

        basket = new Collection<BasketItem>();
        if (Session["basket"] != null)
        {
            basket = (Collection<BasketItem>)Session["basket"];
        }

        searchValues = new Dictionary<string, string>();
        if (Session["advSearch"] != null)
            searchValues = (Dictionary<string, string>)Session["advSearch"];

        catMan = new WebCatalogManager(Request.ServerVariables["REMOTE_ADDR"], Session.SessionID);

        if (!IsPostBack)
        {
            catMan.LogActivity("CRMweb.Catalog", Request.ServerVariables["URL"], "Open", "Viewing Page", "INV", null, oLang.CurrentLanguage);
            PopulateFields();
        }

    }

    private void PopulateFields()
    {
        Master.PageTitle = oLang.GetLabel("AdvTitle");
        lblTitle.InnerText = oLang.GetLabel("AdvTitle");
        lblInfo.InnerText = oLang.GetLabel("AdvSearchInfoMsg"); // +"\n\n" + oLang.GetLabel("FindResults");
        lblCategory.Text = oLang.GetLabel("Category");
        lblDisplay.Text = oLang.GetLabel("Display");
        lblSort.Text = oLang.GetLabel("SortBy");
        btnSumbit.Text = oLang.GetLabel("SearchBtn");

        // New stuff added by Allan
        //lblFind.Text = oLang.GetLabel("FindResults");
        lblAll.Text = oLang.GetLabel("AllWords");
        lblExact.Text = oLang.GetLabel("ExactPhrase");
        lblAny.Text = oLang.GetLabel("AnyWords");
        lblWithout.Text = oLang.GetLabel("WithoutWords");
        lblIsbn.Text = oLang.GetLabel("IsbnNumber");
        lblCatNumber.Text = oLang.GetLabel("CatNumber");
        lblAuthor.Text = oLang.GetLabel("Author");
        lblPubDate.Text = oLang.GetLabel("PubDateRange");
        lblFrom.Text = oLang.GetLabel("From");
        lblTo.Text = oLang.GetLabel("To");

        DataSet dsYear = catMan.GetPublicationYear();
        ddlFromDate.DataSource = dsYear;
        ddlFromDate.DataTextField = "Year";
        ddlFromDate.DataValueField = "Year";
        ddlFromDate.DataBind();
        ddlFromDate.Items.Insert(0, new ListItem("-", "-"));
        ddlFromDate.SelectedIndex = 0;

        ddlToDate.DataSource = dsYear;
        ddlToDate.DataTextField = "Year";
        ddlToDate.DataValueField = "Year";
        ddlToDate.DataBind();
        ddlToDate.Items.Insert(0, new ListItem("-", "-"));
        ddlToDate.SelectedIndex = 0;


        DataSet dsCat = catMan.GetCatalogCategories(oLang.CurrentLanguage);
        ddlCategory.DataSource = dsCat;
        ddlCategory.DataTextField = "Pt_Definition";
        ddlCategory.DataValueField = "Pt_Code";
        ddlCategory.DataBind();
        ddlCategory.Items.Insert(0, new ListItem(oLang.GetLabel("AllPublications"), "All")); 
        ddlCategory.SelectedIndex = 0;

        ddlDisplay.Items.Insert(0, new ListItem(oLang.GetLabel("English"), "E"));
        ddlDisplay.Items.Insert(1, new ListItem(oLang.GetLabel("French"), "F"));
        ddlDisplay.Items.Insert(2, new ListItem(oLang.GetLabel("All"), "B"));
        ddlDisplay.SelectedValue = oLang.CurrentLanguage;

        ddlSort.Items.Insert(0, new ListItem(oLang.GetLabel("Title"), "T"));
        ddlSort.Items.Insert(1, new ListItem(oLang.GetLabel("Date"), "D"));
        ddlSort.Items.Insert(2, new ListItem(oLang.GetLabel("Author"), "A"));
        ddlSort.SelectedIndex = 0;

        ViewCartBtn();

        if (Session["advSearch"] != null)
        {
            txtAll.Text = searchValues["AllWords"];
            txtExact.Text = searchValues["ExactPhrase"];
            txtAny.Text = searchValues["AnyWord"];
            txtWithout.Text = searchValues["Without"];
            ddlCategory.SelectedValue = searchValues["Category"];
            ddlFromDate.SelectedValue = searchValues["YearFrom"];
            ddlToDate.SelectedValue = searchValues["YearTo"];
            ddlDisplay.SelectedValue = searchValues["PubLang"];
            txtIsbn.Text = searchValues["ISBN"];
            txtCatNumber.Text = searchValues["CatNumber"];
            txtAuthor.Text = searchValues["Author"];
            FillDataGrid();
        }
        else
            dGridArea.Visible = false;

       
    }
    protected void btnSumbit_Click(object sender, EventArgs e)
    {
        /*
        catMan.LogActivity("CRMweb.Catalog", Request.ServerVariables["URL"], "Filter", "Main search", "INV", null, oLang.CurrentLanguage);
        searchValues.Clear();
        searchValues.Add("SearchField", txtSearchText.Text);
        searchValues.Add("Category", ddlCategory.SelectedValue);
        searchValues.Add("PubLang", ddlDisplay.SelectedValue);
        searchValues.Add("Sort", ddlSort.SelectedValue);
        searchValues.Add("Lang", oLang.CurrentLanguage);
        Session["advSearch"] = searchValues;
        FillDataGrid();
        */

        catMan.LogActivity("CRMweb.Catalog", Request.ServerVariables["URL"], "Filter", "Advanced search", "INV", null, oLang.CurrentLanguage);
        searchValues.Clear();
        searchValues.Add("AllWords", txtAll.Text);
        searchValues.Add("ExactPhrase", txtExact.Text);
        searchValues.Add("AnyWord", txtAny.Text);
        searchValues.Add("Without", txtWithout.Text);
        searchValues.Add("Category", ddlCategory.SelectedValue);
        searchValues.Add("YearFrom", ddlFromDate.SelectedValue);
        searchValues.Add("YearTo", ddlToDate.SelectedValue);
        searchValues.Add("PubLang", ddlDisplay.SelectedValue);
        searchValues.Add("ISBN", txtIsbn.Text);
        searchValues.Add("CatNumber", txtCatNumber.Text);
        searchValues.Add("Author", txtAuthor.Text);
        searchValues.Add("Lang", oLang.CurrentLanguage);
        searchValues.Add("Sort", ddlSort.SelectedValue);

        Session["advSearch"] = searchValues;
        FillDataGrid();

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
            hplViewCart.Text = oLang.GetLabel("View") + " " + oLang.GetLabel("Cart");
        }
        else
            dViewCart.Visible = false;
    }

    protected void hplViewCart_Click(object sender, EventArgs e)
    {
        Response.Redirect("~/publication/cart.aspx");
    }

    private void FillDataGrid()
    {
        Master.PageTitle = oLang.GetLabel("Search2");

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
                    hplHTML.NavigateUrl = "display_file.aspx?link=" + Server.UrlEncode(link)
                        + "&item=" + DataBinder.Eval(e.Row.DataItem, "item") + "&pdf=n";

                    strToolTip = oLang.GetLabel("ViewHTML");
                    strToolTip = strToolTip.Replace("[publication_title]", lblText.Text);
                    hplHTML.ToolTip = strToolTip;
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
                    hplPDF.NavigateUrl = "display_file.aspx?link=" + Server.UrlEncode(pdf)
                        + "&item=" + DataBinder.Eval(e.Row.DataItem, "item") + "&pdf=y";

                    strToolTip = oLang.GetLabel("ViewPDF");
                    strToolTip = strToolTip.Replace("[publication_title]", lblText.Text);
                    hplPDF.ToolTip = strToolTip;
                }

                status = (string)DataBinder.Eval(e.Row.DataItem, "Status").ToString();
                Button btnAdd = (Button)e.Row.FindControl("btnAdd");
                Label lblAdd = (Label)e.Row.FindControl("lblAdd");
                btnAdd.ToolTip = oLang.GetLabel("AddtoShoppingCart");
                btnAdd.Text = oLang.GetLabel("Add") ;



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
                        btnAdd.Text = "Add";
                        btnAdd.CommandArgument = hidItem.Value;
                    }
                }

                btnAdd.Text = oLang.GetLabel("Add");
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
                if (Session.Count <= 1)
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
            }

            decimal invSeq = decimal.Parse(e.CommandArgument.ToString());
            T_Inventory inv = T_Inventory.Get(invSeq);
            catMan.LogActivity("CRMweb.Basket", Request.ServerVariables["URL"], "Add", "Add Item to Basket", "INV",
                inv.Item, oLang.CurrentLanguage);

            catMan.AddToBasket(invSeq, basket);

            
            Session["basket"] = basket;
            Session["advSearch"] = searchValues;
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