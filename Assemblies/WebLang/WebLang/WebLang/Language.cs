using System.Web.SessionState;
using System.Data;
using System.Data.Common;
using CallBaseCRM.Shared.DataAccess.Helper;

namespace CallBaseCRM.WebLang
{
    public class Language: DAHelper
    {
        //
        //
        // Instance variables
        //
        //
        HttpSessionState session;
        DataSet ds;

        //
        //
        //  Constructor
        //
        //
        public Language(HttpSessionState s)
        {
            // Store the session state reference
            session = s;
        }

        //
        //
        //  Set the page name for subsequent lookups
        //
        //
        public void SetLabel(string pageName)
        {
            // Fill in the data table
            string strSQL =
                "SELECT Lang_Code, Lang_En, Lang_Fr " +
                "FROM F_Html_Labels INNER JOIN F_Html_Language ON Label_LangCode = Lang_Code " +
                "WHERE Label_PageName = :pageName";
            DbParameter[] parms = new DbParameter[]
            {
                CreateParameter(":pageName", DbType.String, pageName)
            };
            ds = Execute(strSQL, CommandType.Text, parms);

            // Set the result table's primary key
            DataTable dt = ds.Tables[0];
            int rowcount = dt.Rows.Count;
            int colcount = dt.Columns.Count;
            DataColumn[] key = new DataColumn[1];
            key[0] = dt.Columns["Lang_Code"];
            dt.PrimaryKey = key;
        }

        //
        //
        //  Retrieve the English or French text associated with the given label
        //
        //
        public string GetLabel(string label)
        {
            // Try and find the text
            DataTable dt = ds.Tables[0];
            int count = dt.Rows.Count;
            DataRow dr = dt.Rows.Find(label);

            if (dr != null)
            {

                string lang = CurrentLanguage;
                lang = (lang == "E") ? "En" : "Fr";
                return dr["Lang_" + lang].ToString().Trim();
            }
            else
                return "";
        }

        public string CurrentLanguage
        {
            get
            {
                return (session["Language"] != null) ? session["Language"].ToString() : "E";
            }
            set
            {
                session["Language"] = value;
            }
        }
    }
}
