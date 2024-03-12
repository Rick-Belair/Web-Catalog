using System.Data;
using System.Data.Common;
using CallBaseCRM.Shared.DataAccess.Helper;

namespace CallBaseCRM.DataAccess.Logic
{
    public class LangManagerDataService : DAHelper
    {
        /// <summary>
        /// 
        /// </summary>
        public LangManagerDataService()
            : base()
        {
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="pageName"></param>
        /// <param name="code"></param>
        /// <returns></returns>
        public DataSet GetLabelRecord(
            string pageName,
            string code)
        {
            string strSQL =
                @"SELECT *
                FROM F_HTML_LABELS
                WHERE (Label_PageName = :pageName)
                    AND (Label_LangCode = :code)";
            DbParameter[] parms = new DbParameter[]
            {
                CreateParameter(":pageName", DbType.String, pageName),
                CreateParameter(":code", DbType.String, code)
            };

            return Execute(strSQL, CommandType.Text, parms);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="pageName"></param>
        /// <param name="code"></param>
        public void AddLabelRecord(
            string pageName,
            string code)
        {
            string strSQL =
                @"INSERT INTO F_HTML_LABELS
                    (Label_PageName, Label_LangCode)
                VALUES (:pageName, :code)";
            DbParameter[] parms = new DbParameter[]
            {
                CreateParameter(":pageName", DbType.String, pageName),
                CreateParameter(":code", DbType.String, code)
            };

            ExecuteNonQuery(strSQL, CommandType.Text, parms);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="code"></param>
        /// <returns></returns>
        public DataSet GetLangRecord(
            string code)
        {
            string strSQL =
                @"SELECT *
                FROM F_HTML_LANGUAGE
                WHERE Lang_Code = :code";
            DbParameter[] parms = new DbParameter[]
            {
                CreateParameter(":code", DbType.String, code)
            };

            return Execute(strSQL, CommandType.Text, parms);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="code"></param>
        /// <param name="eText"></param>
        /// <param name="fText"></param>
        public void AddLangRecord(
            string code,
            string eText,
            string fText)
        {
            string strSQL =
                @"INSERT INTO F_HTML_LANGUAGE
                    (Lang_Code, Lang_EN, Lang_FR)
                VALUES (:code, :eText, :fText)";
            DbParameter[] parms = new DbParameter[]
            {
                CreateParameter(":code", DbType.String, code),
                CreateParameter(":eText", DbType.String, eText),
                CreateParameter(":fText", DbType.String, fText)
            };

            ExecuteNonQuery(strSQL, CommandType.Text, parms);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="searchString"></param>
        /// <returns></returns>
        public DataSet GetLangRecordList(string searchString)
        {
            string strSQL =
                @"SELECT *
                FROM F_HTML_LANGUAGE
                WHERE Upper(Lang_EN) LIKE '%' || :searchString || '%'
                ORDER By Lang_Code";
            DbParameter[] parms = new DbParameter[]
            {
                CreateParameter(":searchString", DbType.String, searchString.ToUpper())
            };

            return Execute(strSQL, CommandType.Text, parms);
        }
    }
}
