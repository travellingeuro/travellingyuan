using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;

namespace travellingyuan.Helper
{
   public class PhoneValidator
    {

        public string NotValidMessage = "Ensure this format +ContryCodePhoneNumber";
        const string emailRegex = @"^\+\d{10,14}$";

        public bool IsValid(string email)

        {
            return Regex.IsMatch(email, emailRegex, RegexOptions.IgnoreCase, TimeSpan.FromMilliseconds(250));

        }
    }
}
