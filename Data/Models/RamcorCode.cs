using System.ComponentModel.DataAnnotations;
using Ramcor.Data.Validators;

namespace Ramcor.Data.Models
{
    public class RamcorCode
    {
        [Required]
        [LengthValidator(ErrorMessage = "A kódszónak pontosan 10 karakter hosszúnak kell lennie!")]
        [CharacterUniquenessValidator(ErrorMessage = "Minden betű csak egyszer szerepelhet a kódszóban!")]
        [RegularExpression(@"^[a-zA-Z]+$", ErrorMessage = "A kódszó csak az angol abc betűit tartalmazhatja!")]
        public string CodeWord { get; set; }
    }
}
