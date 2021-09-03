using System.Text;

namespace LocalStore.WebApp.Common.Helper
{
    public static class HelperClass
    {
        #region ErrorMessageValidator
        // Xuất lỗi validate
        public static string ErrorMessageValidate(FluentValidation.Results.ValidationResult validatorResult)
        {
            StringBuilder errors = new StringBuilder();
            validatorResult.Errors.ForEach(e =>
            {
                errors.Append(e.ErrorMessage);
                errors.Append("<br>");
            });
            return errors.ToString();
        }
        #endregion
    }
}