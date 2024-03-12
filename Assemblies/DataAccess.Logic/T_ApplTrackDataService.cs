using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.Common;
using CallBaseCRM.Shared.DataAccess.Helper;

namespace CallBaseCRM.DataAccess.Logic
{
    public class T_ApplTrackDataService: DAHelper
    {
        /// <summary>
        /// 
        /// </summary>
        public T_ApplTrackDataService()
            : base()
        {
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public DataSet Get(
            decimal? id)
        {
            string strSQL =
                @"SELECT *
                FROM T_ApplTrack
                WHERE APTR_ID = :id";
            DbParameter[] parms = new DbParameter[]
            {
                CreateParameter(":id", DbType.Decimal, ValueOrNull(id))
            };

            return Execute(strSQL, CommandType.Text, parms);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        public bool Exists(
            decimal? id)
        {
            DataSet ds = Get(id);

            return (ds.Tables[0].Rows.Count != 0);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        public void Delete(
            decimal? id)
        {
            string strSQL =
                @"DELETE FROM T_ApplTrack
                WHERE APTR_ID = :id";
            DbParameter[] parms = new DbParameter[]
            {
                CreateParameter(":id", DbType.Decimal, ValueOrNull(id))
            };

            ExecuteNonQuery(strSQL, CommandType.Text, parms);
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
        public decimal Save(
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
            // Create the parameter list
            DbParameter[] parms = new DbParameter[]
            {
                CreateParameter(":id", DbType.Decimal, ValueOrNull(id)),
                CreateParameter(":occurredAt", DbType.DateTime, ValueOrNull(occurredAt)),
                CreateParameter(":ipAddress", DbType.String, ValueOrNull(ipAddress)),
                CreateParameter(":sessionId", DbType.Decimal, ValueOrNull(sessionId)),
                CreateParameter(":application", DbType.String, ValueOrNull(application)),
                CreateParameter(":module", DbType.String, ValueOrNull(module)),
                CreateParameter(":function", DbType.String, ValueOrNull(function)),
                CreateParameter(":details", DbType.String, ValueOrNull(details)),
                CreateParameter(":docType", DbType.String, ValueOrNull(docType)),
                CreateParameter(":productCode", DbType.String, ValueOrNull(productCode)),
                CreateParameter(":userLanguage", DbType.String, ValueOrNull(userLanguage))
            };
            

            // Do an update or an insert
            string strSQL;
            decimal retval;
            if (Exists(id))
            {
                strSQL =
                    @"UPDATE T_ApplTrack
                    SET APTR_OCCURRED_AT = :occurredAt,
                        APTR_IP_ADDRESS = :ipAddress,
                        APTR_SESSION_ID = :sessionId,
                        APTR_APPLICATION = :application,
                        APTR_MODULE = :module,
                        APTR_FUNCTION = :function,
                        APTR_DETAILS = :details,
                        APTR_DOC_TYPE = :docType,
                        APTR_PRODUCT_CODE = :productCode,
                        APTR_USER_LANGUAGE = :userLanguage
                    WHERE APTR_ID = :id";

                ExecuteNonQuery(strSQL, CommandType.Text, parms);
                retval = id.Value;
            }
            else
            {
                strSQL =
                    @"INSERT INTO T_ApplTrack
                        (APTR_ID, APTR_OCCURRED_AT, APTR_IP_ADDRESS, APTR_SESSION_ID, APTR_APPLICATION,
                        APTR_MODULE, APTR_FUNCTION, APTR_DETAILS, APTR_DOC_TYPE, APTR_PRODUCT_CODE,
                        APTR_USER_LANGUAGE)
                    VALUES (APPLTRACK_SEQ.nextVal, :occurredAt, :ipAddress, :sessionId, :application,
                            :module, :function, :details, :docType, :productCode,
                            :userLanguage)
                    RETURNING APTR_ID INTO :id";

                parms[0].Direction = ParameterDirection.Output;
                ExecuteNonQuery(strSQL, CommandType.Text, parms);
                retval = (decimal)parms[0].Value;
            }

            return retval;
        }
    }
}
