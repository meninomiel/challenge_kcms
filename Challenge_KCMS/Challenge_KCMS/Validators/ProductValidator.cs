using System;
using Challenge_KCMS.Models;
using FluentValidation;

namespace Challenge_KCMS.Validators
{
    public class ProductValidator : AbstractValidator<Product>
    {
        // Gerando validadores para as propriedades
        // Ajuda do FluentValidator

        public ProductValidator()
        {
            // Verifica se Nome é vazio
            RuleFor(e => e.Name).Must(n => ValidateStringEmpty(n)).WithMessage("O nome não pode ser vazio.");

            // Verifica se Descrição é vazio
            RuleFor(e => e.Description).Must(n => ValidateStringEmpty(n)).WithMessage("A descrição não pode ser vazio.");

            // Verifica se Preço é vazio e se maior que zero
            RuleFor(e => e.Price).NotEmpty().WithMessage("Informe o preço").Must(ValidatePrice).WithMessage("O valor deve ser maior do que zero.");
        }

        #region Validator Methods

        private static bool ValidatePrice(decimal price)
        {
            return price > 0;
        }

        private bool ValidateStringEmpty(string value)
        {
            if (!string.IsNullOrEmpty(value))
                return true;
            return false;
        }

        #endregion
    }
}
