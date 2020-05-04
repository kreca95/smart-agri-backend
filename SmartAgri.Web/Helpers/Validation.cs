using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SmartAgri.Web.Helpers
{
    public class Validation
    {
        public static bool IsValidEmail(string email)
        {
            try
            {
                var addr = new System.Net.Mail.MailAddress(email);
                return addr.Address == email;
            }
            catch
            {
                return false;
            }
        }

        public static List<string> ValidatePassword(string password)
        {
            List<string> errors = new List<string>();
            const int MIN_LENGTH = 8;
            const int MAX_LENGTH = 15;

            if (password == null) throw new ArgumentNullException();

            bool meetsLengthRequirements = password.Length >= MIN_LENGTH && password.Length <= MAX_LENGTH;
            bool hasUpperCaseLetter = false;
            bool hasLowerCaseLetter = false;
            bool hasDecimalDigit = false;

            if (meetsLengthRequirements || !string.IsNullOrEmpty(password))
            {
                foreach (char c in password)
                {
                    if (char.IsUpper(c)) hasUpperCaseLetter = true;
                    else if (char.IsLower(c)) hasLowerCaseLetter = true;
                    else if (char.IsDigit(c)) hasDecimalDigit = true;

                }
            }
            else
            {
                errors.Add("Password lenght must be at least 8 characters");
            }

            bool isValid = meetsLengthRequirements
                        && hasUpperCaseLetter
                        && hasLowerCaseLetter
                        && hasDecimalDigit
                        ;
            if (!hasUpperCaseLetter)
            {
                errors.Add("Password must contain upper case letter");
            }
            if (!hasLowerCaseLetter)
            {
                errors.Add("Password must contain lower case letter");
            }
            if (!hasDecimalDigit)
            {
                errors.Add("Password must contain a digit");
            }
            if (!isValid)
            {
                return errors;
            }

            return errors;
        }
    }
}
