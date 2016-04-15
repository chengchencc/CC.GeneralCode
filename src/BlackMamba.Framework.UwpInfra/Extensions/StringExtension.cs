using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlackMamba.Framework.UwpInfra.Extensions
{
    public static class StringExtension
    {
        public static DateTime ToExactDateTime(this string dateTimeString, string format)
        {
            var ret = DateTime.MinValue;

            if (!string.IsNullOrEmpty(dateTimeString))
            {
                DateTime.TryParseExact(dateTimeString.Trim(), format, System.Globalization.CultureInfo.InvariantCulture, DateTimeStyles.AllowWhiteSpaces, out ret);
            }
            return ret;
        }
    }
}
