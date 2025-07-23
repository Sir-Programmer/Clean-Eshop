using System.Globalization;

namespace Common.Application
{
    public static class NumberExtensions
    {
        private static readonly CultureInfo PersianCulture = new CultureInfo("fa-IR");

        public static string ToStringTooMan(this int price)
        {
            return $"{price.ToString("N0", PersianCulture)} تومان";
        }

        public static string SplitNumber(this int price)
        {
            return price.ToString("N0", PersianCulture);
        }
    }
}