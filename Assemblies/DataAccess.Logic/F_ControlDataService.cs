using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.Common;
using CallBaseCRM.Shared.DataAccess.Helper;

namespace CallBaseCRM.DataAccess.Logic
{

    public class F_ControlDataService: DAHelper
    {
        /// <summary>
        /// 
        /// </summary>
        ///         
        public F_ControlDataService()
            : base()
        {
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        public DataSet Get(
            string item)
        {
            string strSQL =
                @"SELECT *
                FROM F_CONTROL
                WHERE CNTR_PARAMETER = :item";
            DbParameter[] parms = new DbParameter[]
            {
                CreateParameter(":item", DbType.String, ValueOrNull(item))
            };

            return Execute(strSQL, CommandType.Text, parms);
        }

    }
}
