namespace Common.Application.Validation
{
    public static class ValidationMessages
    {
        public const string RequiredText = "وارد کردن این فیلد اجباری است";
        public const string InvalidPhoneNumberText = "شماره تلفن نامعتبر است";
        public const string NotFoundText = "اطلاعات درخواستی یافت نشد";
        public const string MaxLengthText = "تعداد کاراکترهای وارد شده بیشتر از حد مجاز است";
        public const string MinLengthText = "تعداد کاراکترهای وارد شده کمتر از حد مجاز است";
        public const string InvalidEmailText = "ایمیل وارد شده معتبر نیست";
        public const string RangeText = "مقدار وارد شده خارج از بازه مجاز است";
        public const string InvalidFormatText = "فرمت وارد شده صحیح نیست";


        public static string Required(string field) => $"فیلد {field} اجباری است";

        public static string MaxLength(string field, int maxLength) =>
            $"فیلد {field} باید حداکثر {maxLength} کاراکتر باشد";

        public static string MinLength(string field, int minLength) =>
            $"فیلد {field} باید حداقل {minLength} کاراکتر باشد";

        public static string Range(string field, object min, object max) =>
            $"فیلد {field} باید بین {min} و {max} باشد";

        public static string InvalidEmail(string field) =>
            $"فیلد {field} یک ایمیل معتبر نیست";

        public static string InvalidPhoneNumber(string field) =>
            $"فیلد {field} یک شماره تلفن معتبر نیست";

        public static string InvalidFormat(string field) =>
            $"فرمت فیلد {field} صحیح نیست";

        public static string EqualTo(string field, string otherField) =>
            $"فیلد {field} باید برابر با {otherField} باشد";

        public static string NotFound(string entity) =>
            $"موردی از {entity} یافت نشد";
        
        public static string NullOrEmpty(string field) =>
            $"فیلد {field} نمی‌تواند خالی باشد";
        
        public static string PasswordsDoNotMatch => "رمزهای عبور با هم مطابقت ندارند";
        
        public static string NumberMustBePositive(string field) =>
            $"فیلد {field} باید عددی مثبت باشد";

        public static string NumberMustBeNonNegative(string field) =>
            $"فیلد {field} باید عددی غیر منفی باشد";
        
        private static readonly Dictionary<string, string> Messages = new()
        {
            { nameof(RequiredText), RequiredText },
            { nameof(InvalidPhoneNumberText), InvalidPhoneNumberText },
            { nameof(NotFoundText), NotFoundText },
            { nameof(MaxLengthText), MaxLengthText },
            { nameof(MinLengthText), MinLengthText },
            { nameof(InvalidEmailText), InvalidEmailText },
            { nameof(RangeText), RangeText },
            { nameof(InvalidFormatText), InvalidFormatText },
        };

        public static string GetMessage(string key) =>
            Messages.TryGetValue(key, out var message) ? message : "پیام یافت نشد";
    }
}