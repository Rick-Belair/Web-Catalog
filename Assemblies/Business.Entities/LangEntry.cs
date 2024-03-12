using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using CallBaseCRM.DataAccess.Logic;

namespace CallBaseCRM.Business.Entities
{
    public class LangEntry : BaseObject
    {
        private string _LangCode;
        private string _LangE;
        private string _LangF;

        public string LangCode
        {
            get { return _LangCode; }
            set { _LangCode = value; }
        }

        public string LangE
        {
            get { return _LangE; }
            set { _LangE = value; }
        }

        public string LangF
        {
            get { return _LangF; }
            set { _LangF = value; }
        }


        public override void MapData(DataRow row)
        {
            LangCode = GetString(row, "Lang_Code");
            LangE = GetString(row, "Lang_EN");
            LangF = GetString(row, "Lang_FR");
        }

        public static LangEntry Get(string langCode)
        {
            LangEntry objLangEntry = new LangEntry();
            objLangEntry.MapData(new LangEntryDataService().Get(langCode));
            return objLangEntry;
        }

        public static void Save(
            string langCode,
            string langE,
            string langF)
        {
            LangEntryDataService leds = new LangEntryDataService();
            leds.Save(langCode, langE, langF);
        }
    }
}
