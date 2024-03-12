using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using CallBaseCRM.DataAccess.Logic;

namespace CallBaseCRM.Business.Entities
{
    /// <summary>
    /// Instance variables
    /// </summary>
    public class F_Control:BaseObject
    {
        private string _CNTR_PARAMETER;
        private string _CNTR_DESCRIPTION;
        private string _CNTR_VALUE;
        private string _CNTR_COMMENT;

        /// <summary>
        /// Property getter/setters
        /// </summary>
        public string CNTR_PARAMETER
        {
            get { return _CNTR_PARAMETER; }
            set { _CNTR_PARAMETER = FixUpString(value); }
        }
        public string CNTR_DESCRIPTION
        {
            get { return _CNTR_DESCRIPTION; }
            set { _CNTR_DESCRIPTION = FixUpString(value); }
        }
        public string CNTR_VALUE
        {
            get { return _CNTR_VALUE; }
            set { _CNTR_VALUE = FixUpString(value); }
        }
        public string CNTR_COMMENT
        {
            get { return _CNTR_COMMENT; }
            set { _CNTR_COMMENT = FixUpString(value); }
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="row"></param>
        public override void MapData(DataRow row)
        {
            _CNTR_PARAMETER = GetString(row, "CNTR_PARAMETER");
            _CNTR_DESCRIPTION = GetString(row, "CNTR_DESCRIPTION");
            _CNTR_VALUE = GetString(row, "CNTR_VALUE");
            _CNTR_COMMENT = GetString(row, "CNTR_COMMENT");
        }
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public static F_Control Get(string item)
        {
            F_Control control = new F_Control();
            control.MapData(new F_ControlDataService().Get(item));

            return control;
        }
    }
}
