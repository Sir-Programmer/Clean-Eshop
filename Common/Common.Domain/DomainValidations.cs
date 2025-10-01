using System.Globalization;
using System.Text.RegularExpressions;

namespace Common.Domain;

public static class EmailValidation
{
    public static bool IsValidEmail(this string email)
    {
        if (string.IsNullOrWhiteSpace(email))
            return false;

        try
        {
            email = Regex.Replace(email, @"(@)(.+)$", DomainMapper,
                RegexOptions.None, TimeSpan.FromMilliseconds(200));

            string DomainMapper(Match match)
            {
                var idn = new IdnMapping();
                var domainName = idn.GetAscii(match.Groups[2].Value);

                return match.Groups[1].Value + domainName;
            }
        }
        catch (RegexMatchTimeoutException)
        {
            return false;
        }
        catch (ArgumentException)
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
}

public static class IranianNationalIdValidation
{
    public static bool IsValidIranianNationalId(this string nationalId)
    {
        var isNumber = Regex.IsMatch(nationalId, @"^\d+$");
        if (isNumber == false)
            return false;

        var code = nationalId;

        if (Regex.IsMatch(code, @"/^\d{10}$/")) return false;
        code = ("0000" + code).Substring(code.Length + 4 - 10);

        if (Convert.ToInt32(code.Substring(3, 6), 10) == 0) return false;

        var lastNumber = Convert.ToInt32(code.Substring(9, 1), 10);
        var sum = 0;

        for (var i = 0; i < 9; i++)
        {
            sum += Convert.ToInt32(code.Substring(i, 1), 10) * (10 - i);
        }

        sum = sum % 11;

        return sum < 2 && lastNumber == sum || sum >= 2 && lastNumber == 11 - sum;
    }
}

public static partial class IranianPhoneNumberValidation
{
    public static bool IsValidIranianPhoneNumber(this string input)
    {
        return !string.IsNullOrWhiteSpace(input) && PhoneNumberRegex().IsMatch(input.Trim());
    }

    [GeneratedRegex(@"^09\d{9}$")]
    private static partial Regex PhoneNumberRegex();
}