using System.ComponentModel.DataAnnotations;
using Ramcor.Data.Models;

namespace Ramcor.Data.Validators;

public class CharacterUniquenessValidator: ValidationAttribute
{
    public override bool IsValid(object value) =>
        value is string code
        && !code.Where(x => code.Count(y => y == x) != 1).Any();
}