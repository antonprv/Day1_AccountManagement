// Created by Anton Piruev in 2026. 
// Any direct commercial use of derivative work is strictly prohibited.

using System;
using System.Globalization;
using System.Text.RegularExpressions;

namespace AccountManager.Services
{
  internal static class Validator
  {
    public static bool IsValidEmail(string email)
    {
      if (string.IsNullOrWhiteSpace(email))
        return false;

      try
      {
        // Normalize the domain
        email = Regex.Replace(email, @"(@)(.+)$", DomainMapper,
                              RegexOptions.None, TimeSpan.FromMilliseconds(200));

        // Examines the domain part of the email and normalizes it.
        string DomainMapper(Match match)
        {
          // Use IdnMapping class to convert Unicode domain names.
          var idn = new IdnMapping();

          // Pull out and process domain name (throws ArgumentException on invalid)
          string domainName = idn.GetAscii(match.Groups[2].Value);

          return match.Groups[1].Value + domainName;
        }
      }
      catch (RegexMatchTimeoutException e)
      {
        return false;
      }
      catch (ArgumentException e)
      {
        return false;
      }

      try
      {
        return Regex.IsMatch(email,
            @"^[^@\s]+@[^@\s]+\.[^@\s]+$",
            RegexOptions.IgnoreCase, TimeSpan.FromMilliseconds(250));
      }
      catch (RegexMatchTimeoutException)
      {
        return false;
      }
    }

    public static bool IsValidPhone(string phone)
    {
      if (string.IsNullOrWhiteSpace(phone))
        return false;

      try
      {
        // Разделитель: пробел | тире | пробел-тире-пробел
        string sep = @"( |-| - )";

        // Префикс: +код(1-4 цифры) ИЛИ 8
        string prefix = @"(\+\d{1,4}|8)";

        // Вариант 1: с разделителями
        string withSeparators =
            $@"^{prefix}{sep}\d{{3}}{sep}\d{{3}}{sep}\d{{2}}{sep}\d{{2}}$";

        // Вариант 2: только цифры
        string noSeparators =
            $@"^{prefix}\d{{9,13}}$"; // чтобы суммарно было 10–14 цифр

        return Regex.IsMatch(phone, withSeparators, RegexOptions.None, TimeSpan.FromMilliseconds(200))
            || Regex.IsMatch(phone, noSeparators, RegexOptions.None, TimeSpan.FromMilliseconds(200));
      }
      catch (RegexMatchTimeoutException)
      {
        return false;
      }
    }

    public static bool IsValidName(string name)
    {
      if (string.IsNullOrWhiteSpace(name))
        return false;

      try
      {
        return Regex.IsMatch(name,
            @"^[a-zA-Zа-яА-ЯёЁ]+([\-'\s][a-zA-Zа-яА-ЯёЁ]+)*$",
            RegexOptions.None,
            TimeSpan.FromMilliseconds(200));
      }
      catch (RegexMatchTimeoutException)
      {
        return false;
      }
    }
  }
}
