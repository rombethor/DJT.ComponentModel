using DJT.ComponentModel.Results;
using System.ComponentModel.DataAnnotations;

namespace DJT.ComponentModel
{
    public static class ModelValidationExtensions
    {
        public static bool TryValidate(this object model, out List<ValidationResult> results)
        {
            var context = new ValidationContext(model, null, null);
            results = new List<ValidationResult>();
            return Validator.TryValidateObject(model, context, results, true);
        }

        public static bool TryValidate(this object model, out IResult invalidResponse)
        {
            if (!TryValidate(model, out List<ValidationResult> results))
            {
                invalidResponse = Result.BadRequest(results);
                return false;
            }

            invalidResponse = Result.Success();
            return true;
        }

    }
}