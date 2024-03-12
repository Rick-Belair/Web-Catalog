using System;
using System.Collections.Generic;
using System.Text;
using CallBaseCRM.DataAccess.Logic;

namespace CallBaseCRM.Business.Entities
{
    public class LangEntries : BaseCollection<LangEntry>
    {
        public static LangEntries GetAllByModule(string moduleName, string sortLanguage)
        {
            LangEntries colLangEntry = new LangEntries();
            colLangEntry.MapObjects(new LangEntryDataService().GetAllByModule(moduleName, sortLanguage));
            return colLangEntry;
        }

        public static LangEntries GetAllBySearch(string searchString, string sortLanguage)
        {
            LangEntries colLangEntry = new LangEntries();
            colLangEntry.MapObjects(new LangEntryDataService().GetAllBySearch(searchString, sortLanguage));
            return colLangEntry;
        }
    }
}
