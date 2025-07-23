using Ganss.Xss;

namespace Common.Application.SecurityUtil
{
    public static class SanitizerExtensions
    {
        public static string SanitizeText(this string input)
        {
            var htmlSanitizer = new HtmlSanitizer
            {
                KeepChildNodes = true,
                AllowDataAttributes = true
            };
            return htmlSanitizer.Sanitize(input);
        }
    }

}
