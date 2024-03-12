using System;
using System.Collections.Generic;
using System.Linq;
using System.Data;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using CallBaseCRM.Business.Workflows;

public partial class search : System.Web.UI.Page
{
    /// <summary>
    /// Instance variables
    /// </summary>
    private WebCatalogManager wcMan;

    /// <summary>
    /// 
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void Page_Load(object sender, EventArgs e)
    {
        wcMan = new WebCatalogManager(Request.ServerVariables["REMOTE_ADDR"], Session.SessionID);

        if (!IsPostBack)
            PopulateFields();
    }

    /// <summary>
    /// 
    /// </summary>
    private void PopulateFields()
    {
        ddlCategory.DataSource = wcMan.GetCatalogCategories("E");
        ddlCategory.DataTextField = "Pt_Definition";
        ddlCategory.DataValueField = "Pt_Code";
        ddlCategory.DataBind();
        ddlCategory.Items.Insert(0, new ListItem("All Publications", ""));

        ddlYearFrom.DataSource = wcMan.GetPublicationYear();
        ddlYearFrom.DataValueField = ddlYearFrom.DataTextField = "Year";
        ddlYearFrom.DataBind();
        ddlYearFrom.Items.Insert(0, new ListItem("", ""));
        ddlYearTo.DataSource = wcMan.GetPublicationYear();
        ddlYearTo.DataValueField = ddlYearTo.DataTextField = "Year";
        ddlYearTo.DataBind();
        ddlYearTo.Items.Insert(0, new ListItem("", ""));
    }
    
    /// <summary>
    /// 
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void btnGenerateList_Click(object sender, EventArgs e)
    {
        Dictionary<string, string> values = new Dictionary<string, string>();
        values["Lang"] = ddlLang.SelectedValue;
        values["PubLang"] = ddlPubLang.SelectedValue;
        values["SearchField"] = txtSearch.Text.Trim();
        values["Category"] = ddlCategory.SelectedValue;
        values["YearFrom"] = ddlYearFrom.SelectedValue;
        values["YearTo"] = ddlYearTo.SelectedValue;
        values["ISBN"] = txtISBN.Text.Trim();
        values["CatNumber"] = txtCatNumber.Text.Trim();
        values["Author"] = txtAuthor.Text.Trim();
        if (ddlSortBy.SelectedValue != "")
            values["Sort"] = ddlSortBy.SelectedValue;

        values["AllWords"] = txtAllWords.Text.Trim();
        values["ExactPhrase"] = txtExactPhrase.Text.Trim();
        values["AnyWord"] = txtAnyWord.Text.Trim();
        values["Without"] = txtWithout.Text.Trim();

        DataSet ds = wcMan.GetPublicationList(values);
        lblItemsFound.Text = ds.Tables[0].Rows.Count.ToString();
        grdvwList.DataSource = ds;
        grdvwList.DataBind();
    }
}