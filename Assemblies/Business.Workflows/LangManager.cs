using System.Data;
using CallBaseCRM.DataAccess.Logic;

namespace CallBaseCRM.Business.Workflows
{
    public class LangManager
    {
        private LangManagerDataService dataService;

        /// <summary>
        /// 
        /// </summary>
        public LangManager()
        {
            dataService = new LangManagerDataService();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="pageName"></param>
        /// <param name="code"></param>
        /// <returns></returns>
        public bool LabelRecordExists(
            string pageName,
            string code)
        {
            DataSet ds = dataService.GetLabelRecord(pageName, code);

            return (ds.Tables[0].Rows.Count != 0);
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
            dataService.AddLabelRecord(pageName, code);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="code"></param>
        /// <returns></returns>
        public bool LangRecordExists(string code)
        {
            DataSet ds = dataService.GetLangRecord(code);

            return (ds.Tables[0].Rows.Count != 0);
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
            dataService.AddLangRecord(code, eText, fText);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="searchString"></param>
        /// <returns></returns>
        public DataSet GetLangRecordList(string searchString)
        {
            return dataService.GetLangRecordList(searchString);
        }
    }
}
