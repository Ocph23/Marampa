using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace MarampaApp
{
    public class ModelValidationException : Exception
    {
        public ModelValidationException(string message, ICollection<ValidationResult> errors)
        {
            var exception = new Exception(message);
            if (errors.Count > 0)
            {
                foreach (var item in errors)
                {
                    exception.Data.Add(item.MemberNames, item.ErrorMessage);
                }
            }
            throw exception;
        }

    }
}