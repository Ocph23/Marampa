using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace MarampaApp
{
    public static class ValidateModel
    {
        public static bool Validate<T>(T obj, out ICollection<ValidationResult> results)
        {
            results = new List<ValidationResult>();

            return Validator.TryValidateObject(obj, new ValidationContext(obj), results, true);
        }
    }
}