using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CovidItalyAnalyzer
{
    public static class ExtendedString
    {
        public static bool IsEmpty(this string strings)
        {
            return string.IsNullOrEmpty(strings);
        }

        public static void Clear(this string strings)
        {
            strings = string.Empty;
        }
    }
}
