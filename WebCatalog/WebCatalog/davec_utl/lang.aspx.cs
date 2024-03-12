using System;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;
using System.Configuration;
using System.Collections;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.Diagnostics;
using System.IO;
using System.Collections.Generic;
using CallBaseCRM.Business.Entities;
using CallBaseCRM.Business.Workflows;
using CallBaseCRM.WebLang;

public partial class davec_utl_lang : System.Web.UI.Page
{
    private LangManager lMan;

    /// <summary>
    /// 
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void Page_Load(object sender, EventArgs e)
    {
        lMan = new LangManager();
    }
    
    /// <summary>
    /// 
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void btnSearch_Click(object sender, EventArgs e)
    {
        //Debugger.Break();
        grdvwSearch.DataSource = lMan.GetLangRecordList(txtSearch.Text.Trim());
        grdvwSearch.DataBind();
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="message"></param>
    /// <param name="color"></param>
    private void PrintMessage(
        string message,
        string color)
    {
        divMessage.InnerText = message;
        divMessage.Style["color"] = color;
        divMessage.Style["display"] = "block";
    }
    
    /// <summary>
    /// 
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void btnAdd_Click(object sender, EventArgs e)
    {
        // If the form is ok
        if (IsValid)
        {
            // Make sure the label record doesn't already exist
            if (lMan.LabelRecordExists(txtPageName.Text.Trim(), txtCode.Text.Trim()))
            {
                PrintMessage("Page/Label already exists", "red");
                return;
            }

            string eText = txtEnglish.Text.Trim();
            eText = (eText.Length <= 500) ? eText : eText.Substring(0, 500);
            string fText = txtFrench.Text.Trim();
            fText = (fText.Length <= 500) ? fText : fText.Substring(0, 500);

            // Make sure the language entry doesn't already exist
            if ((lMan.LangRecordExists(txtCode.Text.Trim())) && (eText != ""))
            {
                PrintMessage("Language entry already exists", "red");
                return;
            }

            // Add the records
            lMan.AddLabelRecord(txtPageName.Text.Trim(), txtCode.Text.Trim());
            string message = "1 Record added";
            if (eText != "")
            {
                lMan.AddLangRecord(txtCode.Text.Trim(), eText, fText);
                message = "2 Records added";
            }

            PrintMessage(message, "blue");
        }
    }
}