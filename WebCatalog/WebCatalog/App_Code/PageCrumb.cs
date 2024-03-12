using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Description résumée de PageCrumb
/// </summary>
public class PageCrumb
{
    private short _level;
    private string _url;

    private string _linkName;
    public PageCrumb(short level, string url, string linkName)
    {
        _level = level;
        _url = url;
        _linkName = linkName;
    }

    public PageCrumb()
    {
        // TODO: Complete member initialization
    }

    public short Level
    {
        get { return _level; }
    }
    public string Url
    {
        get { return _url; }
    }
    public string LinkName
    {
        get { return _linkName; }
    }

}