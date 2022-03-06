using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Text.RegularExpressions;
using System.Web;
namespace eFahionStore.Common.Helpers
{
    public static class ValidateHelper
    {
        public static bool ValidateWrongStringName(string s)
        {
            if (string.IsNullOrEmpty(s) || string.IsNullOrWhiteSpace(s))
                return true;
            return false;
        }
        public static bool ValidateWrongStringEmail(string s)
        {
            try
            {
                MailAddress m = new MailAddress(s);

                return false;
            }
            catch (FormatException)
            {
                return true;
            }
        }
        public static bool ValidateWrongStringPhoneNumber(string s)
        {
            if (!Regex.Match(s, @"^[(]{0,1}[0-9]{1,4}[)]{0,1}[-\s\./0-9]*$").Success || string.IsNullOrEmpty(s) || string.IsNullOrWhiteSpace(s))
                return true;
            return false;
        }
        public static bool ValidateWrongStringCompanyNumber(string s)
        {
            if (string.IsNullOrEmpty(s) || string.IsNullOrWhiteSpace(s))
                return true;
            return false;
        }
        public static bool ValidateWrongPostalCode(string s)
        {
            if (!Regex.Match(s, @"^[(]{0,1}[0-9]{1,4}[)]{0,1}[-\s\./0-9]*$").Success || string.IsNullOrEmpty(s) || string.IsNullOrWhiteSpace(s))
                return true;
            return false;
        }
        public static bool InValidURL(string URL)
        {
            string Pattern = @"^(?:http(s)?:\/\/)?[\w.-]+(?:\.[\w\.-]+)+[\w\-\._~:/?#[\]@!\$&'\(\)\*\+,;=.]+$";
            Regex Rgx = new Regex(Pattern, RegexOptions.Compiled | RegexOptions.IgnoreCase);
            return !Rgx.IsMatch(URL);
        }
    }
}