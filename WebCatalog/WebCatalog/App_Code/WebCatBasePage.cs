using System;

/// <summary>
/// Summary description for WebCatBasePage
/// </summary>
public class WebCatBasePage : System.Web.UI.Page 
{


    protected void Page_Init(object sender, EventArgs e)
    {
        Context.Response.AddHeader("X-UA-Compatible", "IE=8");
    }

	public WebCatBasePage()
	{
		//
		// TODO: Add constructor logic here
		//
	}
}