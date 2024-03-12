using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
// This class represents a usercontrol helps to implement a breadcrump system
// Usage : Add the user control to the page where bread crump system to be implemented
// Add this page to the DefaultLinks property if it not exist there

using System.Collections.Specialized;
using System.Text;
using CallBaseCRM.WebLang;
public partial class BreadCrumb : System.Web.UI.UserControl
{

    //This call is required by the Web Form Designer.
    [System.Diagnostics.DebuggerStepThrough()]

    private void InitializeComponent()
    {
    }

    //NOTE: The following placeholder declaration is required by the Web Form Designer.
    //Do not delete or move it.

    private System.Object designerPlaceholderDeclaration;
    private void Page_Init(System.Object sender, System.EventArgs e)
    {
        //CODEGEN: This method call is required by the Web Form Designer
        //Do not modify it using the code editor.
        InitializeComponent();
    }

    //Variable holding the Link name of the page
    private string _tailName;
    //Variable holding the level of the page
    private short _level;

    //The pagecrumb object of the current page
    private PageCrumb _pageCrumb = new PageCrumb();
    //We will use a sorted list as we can use the level as key 

    private SortedList _crumbList;
    //Each page has a level. The page should declare its level
    public short Level
    {
        // TO DO : We can check for some constraints here
        get { return _level; }
        set { _level = value; }
    }


    //Each page needs a meaningful name of it. Let them declare it
    public string TailName
    {
        // TO DO : We can check for some constraints here
        get { return _tailName; }
        set { _tailName = value; }
    }

    private Language oLang;

    public string GetPageTitle()
    {
        // TODO : do a for() like for the breadcrumb
        oLang = new Language(Session);
        oLang.SetLabel("MasterPage");
        return "TEST" + " - " + TailName;
    }

    public string GetLabelCode(String code)
    {
        oLang = new Language(Session);
        oLang.SetLabel("MasterPage");

        string labelCode = "";        

        switch (code)
        {
            case "OMM":
                labelCode = "Orders";
                this.Level = 1;
                break;
            case "MM":
                labelCode = "home";
                this.Level = 1;
                break;
            case "LL":            
                labelCode = "Landline";
                break;
            case "W":
                labelCode = "Wireless";
                break;
            case "O":
                labelCode = "Orders";
                break;
            case "AP":
                labelCode = "CorrespondenceTracking";
                break;
            case "M":
                labelCode = "Maintenance";
                break;
            default:
                labelCode = GetLabelCodeLevel3(code);
                break;
        }
        return oLang.GetLabel(labelCode);
    }

    public string GetLabelCodeLevel3(string code)
    {
        string labelCode = "";
        switch (code)
        {
            case "WR":
            case "LLR":
                labelCode = "Reports";
                break;
            case "WU":
            case "LLU":
                labelCode = "Utilities";
                break;
        }
        this.Level = 3;
        return labelCode;
    }

    private void Page_Load(System.Object sender, System.EventArgs e)
    {
        //We are not disabling viewstate
        if (!(Page.IsPostBack))
        {
            oLang = new Language(Session);
            oLang.SetLabel("MasterPage");

            //Minimum level is 1
            if ((_level <= 0))
            {
                _level = 1;
            }

            //If no friendly name gives Untitled as default
            if ((string.IsNullOrEmpty(_tailName)))
            {
                _tailName = "Untitled";
            }

            //Create a Crumb object based on the properties of this page
            _pageCrumb = new PageCrumb(_level, Request.RawUrl, _tailName);

            //Check our Crumb is there in the session...if not create and add it...else get it    
            if (Session["HASH_OF_CRUMPS"] == null)
            {
                _crumbList = new SortedList();
                Session.Add("HASH_OF_CRUMPS", _crumbList);
            }
            else
            {
                _crumbList = (SortedList) Session["HASH_OF_CRUMPS"];
            }

            //Now modify the List of the breadcrumb
            ModifyList(oLang);
            // Put the breadcrumb from the session of sortlist
            PutBreadCrumbs();
        }
        
    }

    public BreadCrumb()
    {
        Load += Page_Load;
        Init += Page_Init;
    }

    private void ModifyList(Language oLang)
    {

        string homeName;

        homeName = "HOME";
        if (Session["Language"] != null)
        {
            if (Session["Language"].ToString() == "F")
            {
                homeName = "ACCUEIL";
            }
        }
        //Remove all Entries from the list which is higher or equal in level
        //Because at a level there can be max 1 entry in the list
        RemoveLowerLevelCrumbs();
        //If level is 1 set the Crumb as home
        if ((_pageCrumb.Level == 1))// || (_pageCrumb.Level == 2))
        {
            _crumbList.Clear();
            _crumbList.Add(Convert.ToInt16(1), new PageCrumb(1, "http://www.aadnc-aandc.gc.ca/", homeName));
        }
        else
        {
            //If nothing in the list adds the home link first
            if (_crumbList.Count == 0)
            {
                _crumbList.Add(Convert.ToInt16(1), new PageCrumb(1, "http://www.aadnc-aandc.gc.ca/", homeName));
            }
            //Now add the present list also no other check is required here as we have cleaned up the 
            //List at the start of the function
            _crumbList.Add(_level, _pageCrumb);
        }
    }

    //Function will remove all the entries from the list which is higher or equal to the
    //present level

    private void RemoveLowerLevelCrumbs()
    {
        short level = 0;
        ArrayList removalList = new ArrayList(_crumbList.Count);
        foreach (short level_loopVariable in _crumbList.Keys)
        {
            level = level_loopVariable;
            if ((level >= _level))
            {
                removalList.Add(level);
            }
        }
        //Now remove all keys in the list
        foreach (short level_loopVariable in removalList)
        {
            level = level_loopVariable;
            _crumbList.Remove(level);
        }
    }


    private void PutBreadCrumbs()
    {
        StringBuilder linkString = new StringBuilder();

        PageCrumb pageCrumb = new PageCrumb();
        int index = 0;

        for (index = 0; index <= _crumbList.Count - 2; index++)
        {            
            pageCrumb = (PageCrumb) _crumbList.GetByIndex(index);
            linkString.Append(string.Format("<li><a href = {0} >{1} </a></li>", pageCrumb.Url, pageCrumb.LinkName));
        }
        //Add the tail also
        pageCrumb = (PageCrumb) _crumbList.GetByIndex(index);
        linkString.Append("<li>" + pageCrumb.LinkName + "</li>");
        lblTrail.Text = linkString.ToString();
    }
}
