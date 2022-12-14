using System.ComponentModel.DataAnnotations;

namespace Ramrod.Data.Validators;

public class CharacterUniquenessValidator : ValidationAttribute
{
    public override bool IsValid(object value)
    {
        return value is string code
               && !code.Where(x => code.Count(y => y == x) != 1).Any();
    }
}