using System.Data;
using System.Data.Common;
using CallBaseCRM.Shared.DataAccess.Helper;


namespace CallBaseCRM.DataAccess.Logic
{
    public class LangEntryDataService : DAHelper
    {
        public LangEntryDataService()
            : base()
        {
        }

        public DataSet Get(string langCode)
        {
            string strSQL =
                "SELECT * " +
                "FROM F_HTML_LANGUAGE " +
                "WHERE Lang_Code = :langCode";
            DbParameter[] parms = new DbParameter[]
            {
                CreateParameter(":langCode", DbType.String, langCode)
            };

            return Execute(strSQL, CommandType.Text, parms);
        }

        public void Save(string langCode, string langE, string langF)
        {
            // Make sure the language strings fit the underlying table
            langE = (langE.Length > 500) ? langE.Substring(0, 500) : langE;
            langF = (langF.Length > 500) ? langF.Substring(0, 500) : langF;

            string strSQL =
                "UPDATE F_HTML_LANGUAGE " +
                "SET Lang_EN = :langE, " +
                    "Lang_FR = :langF " +
                "WHERE Lang_Code = :langCode";
            DbParameter[] parms = new DbParameter[]
            {
                CreateParameter(":langE", DbType.String, langE),
                CreateParameter(":langF", DbType.String, langF),
                CreateParameter(":langCode", DbType.String, langCode)
            };

            ExecuteNonQuery(strSQL, CommandType.Text, parms);
        }

        public DataSet GetAllByModule(string moduleName, string sortLanguage)
        {
            string strSQL =
                "SELECT lang.* " +
                "FROM F_HTML_LABELS labels INNER JOIN F_HTML_LANGUAGE lang " +
                    "ON labels.Label_LangCode = lang.Lang_Code " +
                "WHERE labels.Label_PageName = :moduleName " +
                "ORDER BY lang.Lang_" + sortLanguage;
            DbParameter[] parms = new DbParameter[]
            {
                CreateParameter(":moduleName", DbType.String, moduleName)
            };

            return Execute(strSQL, CommandType.Text, parms);
        }

        public DataSet GetAllBySearch(string searchString, string sortLanguage)
        {
            string strSQL =
                "SELECT * " +
                "FROM F_HTML_LANGUAGE " +
                "WHERE (Lang_EN LIKE '%' || :searchString || '%') " +
                    "OR (Lang_FR LIKE '%' || :searchString || '%') " +
                "ORDER BY Lang_" + sortLanguage;
            DbParameter[] parms = new DbParameter[]
            {
                CreateParameter(":searchString", DbType.String, searchString)
            };

            return Execute(strSQL, CommandType.Text, parms);
        }
    }
}
