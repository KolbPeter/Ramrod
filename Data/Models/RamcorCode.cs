using System.ComponentModel.DataAnnotations;
using Ramrod.Data.Validators;

namespace Ramrod.Data.Models;

public class RamrodCode
{
    [Required]
    [LengthValidator(ErrorMessage = "A kódszónak pontosan 10 karakter hosszúnak kell lennie!")]
    [CharacterUniquenessValidator(ErrorMessage = "Minden betű csak egyszer szerepelhet a kódszóban!")]
    [RegularExpression(@"^[a-zA-Z]+$", ErrorMessage = "A kódszó csak az angol abc betűit tartalmazhatja!")]
    public string CodeWord { get; set; }
}