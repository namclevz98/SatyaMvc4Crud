using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace SatyaMvc4Crud.Models
{
    public class CustomValidationAttributeDemo
    {
        [AttributeUsage(AttributeTargets.Property, AllowMultiple = false, Inherited = true)]
        public sealed class ValidBirthDate : ValidationAttribute
        {
            protected override ValidationResult IsValid(object value, ValidationContext validationContext)
            {
                if (value != null)
                {
                    DateTime _brithJoin = Convert.ToDateTime(value);
                    if (_brithJoin > DateTime.Now)
                    {
                        return new ValidationResult("Birth date can not be greater than the current date.");
                    }
                }
                return ValidationResult.Success;
            }
        }
    }
}