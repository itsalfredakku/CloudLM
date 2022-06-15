using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace CloudLM.Classes
{
    internal class Utility
    {
        public static bool IsValidEmail(string _Email)
        {
            return (new System.Text.RegularExpressions
                .Regex(@"^([a-zA-Z0-9_\-\.]+)@((\[[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\.)|(([a-zA-Z0-9\-]+\.)+))([a-zA-Z]{2,4}|[0-9]{1,3})(\]?)$", 
                    System.Text.RegularExpressions.RegexOptions.CultureInvariant | System.Text.RegularExpressions.RegexOptions.Singleline))
                .IsMatch(_Email);
        }
        public static string ApplyRegEx(string pattern, string input)
        {
            var regex = new Regex(pattern);
            return regex.Match(input).Value;
        }
    }
}
