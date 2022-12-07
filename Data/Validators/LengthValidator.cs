using System.ComponentModel.DataAnnotations;

namespace Ramcor.Data.Validators;

public class LengthValidator : ValidationAttribute
{
    public override bool IsValid(object value) =>
        value is string code
        && code.Length == 10;
}