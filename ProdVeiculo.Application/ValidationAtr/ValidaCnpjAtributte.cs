using ProdVeiculo.shared.Validadores;
using System.ComponentModel.DataAnnotations;

namespace ProdVeiculo.Api.ValidationAtr
{
    public class ValidaCnpjAtributte : ValidationAttribute
    {
        public ValidaCnpjAtributte() : base("Cnpj invalido")
        { }
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            bool valido = Validador.IsCnpj((string)value);
            if (valido)
                return null;

            return new ValidationResult(base.FormatErrorMessage(validationContext.MemberName)
             , new string[] { validationContext.MemberName });
        }
    }
}
