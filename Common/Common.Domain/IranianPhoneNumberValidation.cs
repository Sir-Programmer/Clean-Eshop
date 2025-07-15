using System.Text.RegularExpressions;

namespace Common.Domain;

public static partial class IranianPhoneNumberValidation
{
    public static bool IsValidIranianPhoneNumber(this string input)
    {
        return !string.IsNullOrWhiteSpace(input) && PhoneNumberRegex().IsMatch(input.Trim());
    }

    [GeneratedRegex(@"^09\d{9}$")]
    private static partial Regex PhoneNumberRegex();
}