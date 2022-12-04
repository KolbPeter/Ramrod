using System.Text.RegularExpressions;
using Ramcor.Data.Models;

namespace Ramcor.Data.Validators
{
    public static class RamcorCodeValidators
    {
        public static ValidationResult Validate(this RamcorCode code)
        {
            var result = new ValidationResult().ValidateCodeNullability(code);

            return result.IsInvalid
                ? result
                : result
                    .ValidateCharacterSet(code!)
                    .ValidateCharacterUniqueness(code!)
                    .ValidateLength(code!);
        }

        private static ValidationResult ValidateCharacterSet(this ValidationResult result, RamcorCode code)
        {
            if (!Regex.IsMatch(code.CodeWord, @"^[a-zA-Z]+$"))
            {
                result = result with { Errors = result.Errors.Append("A kódszó csak az angol ABC betűit tartalmazhatja!") };
            }

            return result;
        }

        private static ValidationResult ValidateCharacterUniqueness(this ValidationResult result, RamcorCode code)
        {
            var stuff = code.CodeWord.Select(x => code.CodeWord.Count(y => y == x) != 1);
            if (code.CodeWord.Select(x => code.CodeWord.Count(y => y == x) != 1).Any(x => x))
            {
                result = result with { Errors = result.Errors.Append("Egy karakter sem szerepelhet kétszer a kódszóban!") };
            }

            return result;
        }

        private static ValidationResult ValidateLength(this ValidationResult result, RamcorCode code)
        {
            if (code.CodeWord.Length != 10)
            {
                result = result with { Errors = result.Errors.Append("A kódszónak pontosan 10 karakter hosszúnak kell lennie!") };
            }

            return result;
        }

        private static ValidationResult ValidateCodeNullability(this ValidationResult result, RamcorCode code)
        {
            if (string.IsNullOrEmpty(code.CodeWord))
            {
                result = result with { Errors = result.Errors.Append("A kódszó nem lett meghatározva!") };
            }

            return result;
        }
    }
}
