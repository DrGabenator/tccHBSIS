using HBSIS.TCC.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web;

namespace HBSIS.TCC.Models
{
    public class CustomValidateField : ValidationAttribute
    {
        ContextDB dB = new ContextDB();

        private ValidateFields typeField;

        public CustomValidateField(ValidateFields type)
        {
            typeField = type;
        }

        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            if (value != null)
            {
                switch (typeField)
                {
                    case ValidateFields.ValidarPlaca:
                        {
                            return ValidarPlaca(value, validationContext.DisplayName);
                        }
                    default:
                        break;
                }
            }
            return new ValidationResult($"O campo {validationContext.DisplayName} é obrigatório.");
        }

        private ValidationResult ValidarPlaca(object value, string displayField)
        {
            bool placaBr = Regex.IsMatch(value.ToString(), @"^[a-zA-Z]{3}[-][0-9]{4}$");
            bool placaMs = Regex.IsMatch(value.ToString(), @"^[a-zA-Z]{3}[0-9]{1}[a-zA-Z]{1}[0-9]{2}$");
            bool placaMt = Regex.IsMatch(value.ToString(), @"^[a-zA-Z]{3}[0-9]{2}[a-zA-Z]{1}[0-9]{1}$");

            if (placaBr || placaMs || placaMt)
            {
                return ValidationResult.Success;
            }

            return new ValidationResult($"A {displayField} informada não está no formato aceitável.");
        }

        //private ValidationResult ValidarSenha(object value, string displayField)
        //{
        //    bool result = Regex.IsMatch(value.ToString(), @"^(?=.*?[A-Z])(?=.*?[a-z])(?=.*?[0-9])(?=.*?[#?!@$%^&*-]).{8,15}$");
        //
        //    if (result)
        //    {
        //        return ValidationResult.Success;
        //    }
        //
        //    return new ValidationResult($"O campo {displayField} é inválido.");
        //}
        //
        //private ValidationResult ValidarNome(object value, string displayField)
        //{
        //    bool result = Regex.IsMatch(value.ToString(), @"^[a-zA-Z\s]+$");
        //
        //    if (result)
        //    {
        //        return ValidationResult.Success;
        //    }
        //
        //    return new ValidationResult($"O campo {displayField} é inválido.");
        //}
        //
        //private ValidationResult ValidarLogin(object value, ValidationContext validationContext)
        //{
        //    if (value != null)
        //    {
        //        if (value.ToString().Contains("GIOMAR"))
        //        {
        //            return ValidationResult.Success;
        //        }
        //        else
        //        {
        //            return new ValidationResult("Você perdeu 9001 pontos");
        //        }
        //    }
        //
        //    return new ValidationResult("O campo: " + validationContext.DisplayName + " é um campo obrigatório.");
        //}
    }
}