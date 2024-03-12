using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using CallBaseCRM.Business.Workflows;
using CallBaseCRM.Business.Entities;

public partial class davec_utl_cattest : System.Web.UI.Page
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
            FillDropDown();
    }

    /// <summary>
    /// 
    /// </summary>
    private void FillDropDown()
    {
        ddlCategory.DataSource = wcMan.GetCatalogCategories(rblLanguage.SelectedValue);
        ddlCategory.DataValueField = "Pt_Code";
        ddlCategory.DataTextField = "Pt_Definition";
        ddlCategory.DataBind();
    }

    /// <summary>
    /// 
    /// </summary>
    private void LoadData()
    {
        DataSet ds = wcMan.GetPublicationList(
            rblLanguage.SelectedValue,
            rblPublicationLanguage.SelectedValue,
            ddlCategory.SelectedValue);
        lblRecordCount.Text = ds.Tables[0].Rows.Count.ToString();

        grdvwPublications.DataSource = ds;
        grdvwPublications.DataBind();
    }
    
    /// <summary>
    /// 
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void rblLanguage_SelectedIndexChanged(object sender, EventArgs e)
    {
        FillDropDown();
    }
    
    /// <summary>
    /// 
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void btnLoadData_Click(object sender, EventArgs e)
    {
        LoadData();
    }
    
    /// <summary>
    /// 
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void grdvwPublications_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            e.Row.Cells[1].Wrap = false;
            e.Row.Cells[2].Wrap = false;
        }
    }
    
    /// <summary>
    /// 
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void grdvwPublications_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        grdvwPublications.PageIndex = e.NewPageIndex;
        LoadData();
    }
}