using System;
using System.Collections.Generic;
using System.Text;

namespace CallBaseCRM.Shared.DataAccess.Common
{
    // Constants for SQL Server to allow the use of NULL values
    // These constant are used in the BaseObject function class of the
    // Business.Entities module

    public sealed class Constants
    {
        //Null values
        public static DateTime NullDateTime = DateTime.MinValue;
        public static decimal NullDecimal = decimal.MinValue;
        public static double NullDouble = double.MinValue;
        public static int NullInt = int.MinValue;
        public static long NullLong = long.MinValue;
        public static float NullFloat = float.MinValue;

        //Types without MinValues properties
        public static string NullString = string.Empty;
        public static Guid NullGuid = Guid.Empty;

        //Helpfull values for SQL Server; SQL server can only handle dates
        //within the following range
        public static DateTime SQLMaxDate = new DateTime(9999, 1, 3, 23, 59, 59);
        public static DateTime SQLMinDate = new DateTime(1753, 1, 1, 00, 00, 00);
    }
}
