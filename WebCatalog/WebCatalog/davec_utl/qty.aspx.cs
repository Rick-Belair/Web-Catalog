using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Drawing;
using CallBaseCRM.Business.Workflows;

public partial class davec_utl_qty : System.Web.UI.Page
{
    WebCatalogManager wcMan;

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
        ddlCategory.DataValueField = "Pt_Code";
        ddlCategory.DataTextField = "Pt_Definition";
        ddlCategory.DataBind();

        ddlCategory.Items.Insert(0, new ListItem("", ""));
    }

    
    /// <summary>
    /// 
    /// </summary>
    private void FillGrid()
    {
        Dictionary<string, string> values = new Dictionary<string,string>();
        values["Lang"] = values["PubLang"] = "E";
        values["Category"] = ddlCategory.SelectedValue;
        DataSet ds = wcMan.GetPublicationList(values);
        grdvData.DataSource = ds;
        grdvData.DataBind();
        lblNrows.Text = ds.Tables[0].Rows.Count.ToString();
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void grdvData_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            Label lblQtyAvailable = (Label)e.Row.FindControl("lblQtyAvailable");
            decimal available = wcMan.GetQuantityAvailable(DataBinder.Eval(e.Row.DataItem, "Item").ToString());
            lblQtyAvailable.Text = available.ToString();
            if (available == -111111)
                lblQtyAvailable.ForeColor = Color.Red;
        }
    }
    
    /// <summary>
    /// 
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void btnGo_Click(object sender, EventArgs e)
    {
        FillGrid();
    }
}