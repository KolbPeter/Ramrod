using System.ComponentModel.DataAnnotations;

namespace Ramrod.Data.Validators;

public class LengthValidator : ValidationAttribute
{
    public override bool IsValid(object value)
    {
        return value is string code
               && code.Length == 10;
    }
}