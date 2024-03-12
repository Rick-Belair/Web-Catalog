using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CallBaseCRM.DataAccess.Logic;

namespace CallBaseCRM.Business.Entities
{
    public class T_ApplTrack: BaseObject
    {
        /// <summary>
        /// Instance variables
        /// </summary>
        private decimal? _ID;
        private DateTime? _OccurredAt;
        private string _IPAddress;
        private decimal? _SessionId;
        private string _Application;
        private string _Module;
        private string _Function;
        private string _Details;
        private string _DocType;
        private string _ProductCode;
        private string _UserLanguage;

        /// <summary>
        /// Property getter/setters
        /// </summary>
        public decimal? ID
        {
            get { return _ID; }
            set { _ID = value; }
        }

        public DateTime? OccurredAt
        {
            get { return _OccurredAt; }
            set { _OccurredAt = value; }
        }

        public string IPAddress
        {
            get { return _IPAddress; }
            set { _IPAddress = FixUpString(value); }
        }

        public decimal? SessionId
        {
            get { return _SessionId; }
            set { _SessionId = value; }
        }

        public string Application
        {
            get { return _Application; }
            set { _Application = FixUpString(value); }
        }

        public string Module
        {
            get { return _Module; }
            set { _Module = FixUpString(value); }
        }

        public string Function
        {
            get { return _Function; }
            set { _Function = FixUpString(value); }
        }

        public string Details
        {
            get { return _Details; }
            set { _Details = FixUpString(value); }
        }

        public string DocType
        {
            get { return _DocType; }
            set { _DocType = FixUpString(value); }
        }

        public string ProductCode
        {
            get { return _ProductCode; }
            set { _ProductCode = FixUpString(value); }
        }

        public string UserLanguage
        {
            get { return _UserLanguage; }
            set { _UserLanguage = FixUpString(value); }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="row"></param>
        public override void MapData(System.Data.DataRow row)
        {
            _ID = GetDecimal(row, "APTR_ID");
            _OccurredAt = GetDateTime(row, "APTR_OCCURRED_AT");
            _IPAddress = GetString(row, "APTR_IP_ADDRESS");
            _SessionId = GetDecimal(row, "APTR_SESSION_ID");
            _Application = GetString(row, "APTR_APPLICATION");
            _Module = GetString(row, "APTR_MODULE");
            _Function = GetString(row, "APTR_FUNCTION");
            _Details = GetString(row, "APTR_DETAILS");
            _DocType = GetString(row, "APTR_DOC_TYPE");
            _ProductCode = GetString(row, "APTR_PRODUCT_CODE");
            _UserLanguage = GetString(row, "APTR_USER_LANGUAGE");
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public static T_ApplTrack Get(
            decimal? id)
        {
            T_ApplTrack aptr = new T_ApplTrack();
            aptr.MapData(new T_ApplTrackDataService().Get(id));

            return aptr;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public static bool Exists(
            decimal? id)
        {
            return new T_ApplTrackDataService().Exists(id);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        public static void Delete(
            decimal? id)
        {
            new T_ApplTrackDataService().Delete(id);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <param name="occurredAt"></param>
        /// <param name="ipAddress"></param>
        /// <param name="sessionId"></param>
        /// <param name="application"></param>
        /// <param name="module"></param>
        /// <param name="function"></param>
        /// <param name="details"></param>
        /// <param name="docType"></param>
        /// <param name="productCode"></param>
        /// <param name="userLanguage"></param>
        /// <returns></returns>
        public static decimal Save(
            decimal? id,
            DateTime? occurredAt,
            string ipAddress,
            decimal? sessionId,
            string application,
            string module,
            string function,
            string details,
            string docType,
            string productCode,
            string userLanguage)
        {
            return new T_ApplTrackDataService().Save(
                id, occurredAt, ipAddress, sessionId, application,
                module, function, details, docType, productCode,
                userLanguage);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public decimal Save()
        {
            return Save(
                ID, OccurredAt, IPAddress, SessionId, Application,
                Module, Function, Details, DocType, ProductCode,
                UserLanguage);
        }
    }
}
