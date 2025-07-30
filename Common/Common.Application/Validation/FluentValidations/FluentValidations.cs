using Common.Application.FileUtil;
using Common.Application.ImageUtil;
using Common.Domain;
using FluentValidation;
using Microsoft.AspNetCore.Http;

namespace Common.Application.Validation.FluentValidations
{
    public static class FluentValidations
    {
        public static IRuleBuilderOptionsConditions<T, TProperty> JustImageFile<T, TProperty>(this IRuleBuilder<T, TProperty> ruleBuilder, string errorMessage = "شما فقط قادر به وارد کردن عکس میباشید") where TProperty : IFormFile?
        {
            return ruleBuilder.Custom((file, context) =>
            {
                if (file == null)
                    return;

                if (!file.IsImage())
                {
                    context.AddFailure(errorMessage);
                }
            });
        }
        
        public static IRuleBuilderOptionsConditions<T, TProperty> MaxFileSize<T, TProperty>(
            this IRuleBuilder<T, TProperty> ruleBuilder,
            double maxFileSize,
            string errorMessage = "حجم فایل بیشتر از حد مجاز است") where TProperty : IFormFile?
        {
            var maxBytes = (long)(maxFileSize * 1024 * 1024);

            return ruleBuilder.Custom((file, context) =>
            {
                if (file == null)
                    return;

                if (file.Length > maxBytes)
                {
                    context.AddFailure(errorMessage);
                }
            });
        }

        public static IRuleBuilderOptionsConditions<T, string> ValidNationalId<T>(this IRuleBuilder<T, string> ruleBuilder, string errorMessage = "کدملی نامعتبر است")
        {
            return ruleBuilder.Custom((nationalCode, context) =>
            {
                if (!nationalCode.IsValidIranianNationalId())
                    context.AddFailure(errorMessage);
            });
        }
        public static IRuleBuilderOptionsConditions<T, string> ValidPhoneNumber<T>(this IRuleBuilder<T, string> ruleBuilder, string errorMessage = ValidationMessages.InvalidPhoneNumberText)
        {
            return ruleBuilder.Custom((phoneNumber, context) =>
            {
               if(!phoneNumber.IsValidIranianPhoneNumber())
                   context.AddFailure(errorMessage);

            });
        }

        public static IRuleBuilderOptionsConditions<T, TProperty> JustValidFile<T, TProperty>(this IRuleBuilder<T, TProperty> ruleBuilder, string errorMessage = "فایل نامعتبر است") where TProperty : IFormFile
        {
            return ruleBuilder.Custom((file, context) =>
            {
                if (file == null)
                    return;

                if (!file.IsValidFile())
                {
                    context.AddFailure(errorMessage);
                }
            });
        }
    }
}