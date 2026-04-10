// Created by Anton Piruev in 2026. 
// Any direct commercial use of derivative work is strictly prohibited.

using System.Globalization;

namespace AccountManager.Services
{
  internal static class ErrorMessages
  {
    public const string EmailEmpty = "EMAIL_EMPTY";
    public const string EmailTooLong = "EMAIL_TOO_LONG";
    public const string EmailInvalidChars = "EMAIL_INVALID_CHARS";
    public const string EmailInvalidDomain = "EMAIL_INVALID_DOMAIN";
    public const string EmailInvalidFormat = "EMAIL_INVALID_FORMAT";

    public const string PhoneEmpty = "PHONE_EMPTY";
    public const string PhoneInvalidFormat = "PHONE_INVALID_FORMAT";
    public const string PhoneTimeout = "PHONE_TIMEOUT";

    public const string NameEmpty = "NAME_EMPTY";
    public const string NameInvalid = "NAME_INVALID";
    public const string NameTimeout = "NAME_TIMEOUT";

    public static string Get(string code)
    {
      var lang = CultureInfo.CurrentUICulture.TwoLetterISOLanguageName;

      if (lang == "ru")
        return GetRu(code);

      return GetEn(code);
    }

    private static string GetEn(string code)
    {
      switch (code)
      {
        case EmailEmpty: return "Email cannot be empty.";
        case EmailTooLong: return "Email is too long.";
        case EmailInvalidChars: return "Email contains invalid characters.";
        case EmailInvalidDomain: return "Email domain is invalid.";
        case EmailInvalidFormat: return "Email format is invalid.";

        case PhoneEmpty: return "Phone number cannot be empty.";
        case PhoneInvalidFormat: return "Phone number format is invalid.";
        case PhoneTimeout: return "Phone validation timeout.";

        case NameEmpty: return "Cannot be empty.";
        case NameInvalid: return "Contains invalid characters.";
        case NameTimeout: return "Validation timeout.";

        default: return "Unknown error.";
      }
    }

    private static string GetRu(string code)
    {
      switch (code)
      {
        case EmailEmpty: return "Email не может быть пустым.";
        case EmailTooLong: return "Email слишком длинный.";
        case EmailInvalidChars: return "Email содержит недопустимые символы.";
        case EmailInvalidDomain: return "Некорректный домен email.";
        case EmailInvalidFormat: return "Некорректный формат email.";

        case PhoneEmpty: return "Телефон не может быть пустым.";
        case PhoneInvalidFormat: return "Некорректный формат телефона.";
        case PhoneTimeout: return "Таймаут проверки телефона.";

        case NameEmpty: return "Не может быть пустым.";
        case NameInvalid: return "Содержит недопустимые символы.";
        case NameTimeout: return "Таймаут проверки имени.";

        default: return "Неизвестная ошибка.";
      }
    }
  }
}
