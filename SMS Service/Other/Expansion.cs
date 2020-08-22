using SMS_Service.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SMS_Service.Other
{
    internal static class Expansion
    {
        internal static Info ToInfo(this string data)
        {
            Info info;
            var check = Enum.TryParse<Info>(data, out info);
            if (check == false)
                return Info.ERROR;

            return info;
        }

        internal static string GetValue(this string value)
        {
            return value != null ? value : "";
        }

        internal static string GetValue(this int? value)
        {
            return value != null ? value.Value.ToString() : "";
        }

        internal static string ToStrings(this List<string> list)
        {
            return string.Join(",", list);
        }

        internal static string ToInt32String(this bool param)
        {
            return param.GetHashCode().ToString();
        }

    }
}
