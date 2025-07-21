using System.Text.RegularExpressions;

namespace Common.Domain.Utils;

public static partial class TextHelper
{
    public static bool IsText(this string value)
    {
        return !IsOnlyDigitsRegex().IsMatch(value);
    }

    public static bool IsUniCode(this string value)
    {
        return value.Any(c => c > 255);
    }

    public static string ToSlug(this string url)
    {
        if (string.IsNullOrWhiteSpace(url))
            return string.Empty;

        url = url.Trim().ToLowerInvariant();
        url = UrlSanitizerRegex().Replace(url, "");
        url = SpaceToDashRegex().Replace(url, "-");
        return url;
    }

    public static string LimitTextLength(this string text, int length)
    {
        if (string.IsNullOrEmpty(text))
            return string.Empty;

        if (text.Length <= length)
            return text;

        return text[..Math.Max(0, length - 3)] + "...";
    }

    public static string GenerateCode(int length)
    {
        var random = new Random();
        return new string(Enumerable.Range(0, length)
            .Select(_ => (char)('0' + random.Next(10)))
            .ToArray());
    }

    public static string ConvertHtmlToText(this string text)
    {
        if (string.IsNullOrWhiteSpace(text))
            return string.Empty;

        return HtmlToTextRegex().Replace(text, " ")
            .Replace("&zwnj;", " ")
            .Replace(";&zwnj", " ")
            .Replace("&nbsp;", " ");
    }
    
    
    [GeneratedRegex(@"^\d+$", RegexOptions.Compiled)]
    private static partial Regex IsOnlyDigitsRegex();

    [GeneratedRegex("<.*?>", RegexOptions.Compiled)]
    private static partial Regex HtmlToTextRegex();

    [GeneratedRegex(@"[$+%?\^*@!#&~()=/\\\.]", RegexOptions.Compiled)]
    private static partial Regex UrlSanitizerRegex();

    [GeneratedRegex(@"\s+", RegexOptions.Compiled)]
    private static partial Regex SpaceToDashRegex();
}