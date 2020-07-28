using Challenge_KCMS.Models;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace Challenge_KCMS.Validators
{
    public class CategoryValidator : AbstractValidator<Category>
    {
        public CategoryValidator()
        {
            RuleFor(e => e.Name).Must(n => ValidateStringEmpty(n)).WithMessage(
                "O nome não pode ser vazio");
        }

        private bool ValidateStringEmpty(string stringValue)
        {
            if (!string.IsNullOrEmpty(stringValue))
                return true;
            return false;
        }
    }
}
