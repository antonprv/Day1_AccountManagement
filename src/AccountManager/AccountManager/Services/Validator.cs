// Created by Anton Piruev in 2026. 
// Any direct commercial use of derivative work is strictly prohibited.

using System;
using System.Linq;
using System.Net.Mail;
using System.Text.RegularExpressions;

namespace AccountManager.Services
{
  internal static class Validator
  {
    public static bool IsValidEmailMailAddress(string email, out string error)
    {
      error = null;

      if (string.IsNullOrWhiteSpace(email))
      {
        error = ErrorMessages.EmailEmpty;
        return false;
      }

      if (email.Length > 254)
      {
        error = ErrorMessages.EmailTooLong;
        return false;
      }

      try
      {
        var addr = new MailAddress(email);

        if (addr.Address != email)
        {
          error = ErrorMessages.EmailInvalidChars;
          return false;
        }

        if (!addr.Host.Contains('.'))
        {
          error = ErrorMessages.EmailInvalidDomain;
          return false;
        }

        return true;
      }
      catch (FormatException)
      {
        error = ErrorMessages.EmailInvalidFormat;
        return false;
      }
    }

    public static bool IsValidPhone(string phone, out string error)
    {
      error = null;

      if (string.IsNullOrWhiteSpace(phone))
      {
        error = ErrorMessages.PhoneEmpty;
        return false;
      }

      try
      {
        string sep = @"( |-| - )";
        string prefix = @"(\+\d{1,4}|8)";

        string withSeparators =
            $@"^{prefix}{sep}\d{{3}}{sep}\d{{3}}{sep}\d{{2}}{sep}\d{{2}}$";

        string noSeparators =
            $@"^{prefix}\d{{9,13}}$";

        bool isValid =
            Regex.IsMatch(phone, withSeparators, RegexOptions.None, TimeSpan.FromMilliseconds(200)) ||
            Regex.IsMatch(phone, noSeparators, RegexOptions.None, TimeSpan.FromMilliseconds(200));

        if (!isValid)
        {
          error = ErrorMessages.PhoneInvalidFormat;
          return false;
        }

        return true;
      }
      catch (RegexMatchTimeoutException)
      {
        error = ErrorMessages.PhoneTimeout;
        return false;
      }
    }

    public static bool IsValidName(string name, out string error)
    {
      error = null;

      if (string.IsNullOrWhiteSpace(name))
      {
        error = ErrorMessages.NameEmpty;
        return false;
      }

      try
      {
        bool isValid = Regex.IsMatch(name,
            @"^[a-zA-Zа-яА-ЯёЁ]+([\-'\s][a-zA-Zа-яА-ЯёЁ]+)*$",
            RegexOptions.None,
            TimeSpan.FromMilliseconds(200));

        if (!isValid)
        {
          error = ErrorMessages.NameInvalid;
          return false;
        }

        return true;
      }
      catch (RegexMatchTimeoutException)
      {
        error = ErrorMessages.NameTimeout;
        return false;
      }
    }
  }
}
