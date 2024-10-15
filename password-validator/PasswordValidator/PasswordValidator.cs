using System;
using System.Linq;

namespace PasswordValidator
{
    public class PasswordValidator
    {
        public bool Validate(string password)
        {

            if (IsNullOrEmpty(password) ||
                IsTooShort(password) ||
                DoesNotContainUpperCase(password) ||
                DoesNotContainLowerCase(password) ||
                DoesNotContainNumber(password) ||
                DoesNotContainUnderscore(password)
                )

            {
                return false;
            }

            return true;
        }

        private bool DoesNotContainUnderscore(string password)
        {
            return !password.Contains("_");
        }

        private bool DoesNotContainNumber(string password)
        {
            return !password.Any(char.IsDigit);
        }

        private bool DoesNotContainLowerCase(string password)
        {
            return password.ToUpper() == password;
        }

        private bool DoesNotContainUpperCase(string password)
        {
            return password.ToLower() == password;
        }

        private bool IsTooShort(string password)
        {
            return password.Length <= 8;
        }

        private bool IsNullOrEmpty(string password)
        {
            return string.IsNullOrEmpty(password);
        }
    }
}