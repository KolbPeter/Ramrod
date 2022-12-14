using System.ComponentModel.DataAnnotations;

namespace Ramrod.Data.Models;

public record MessageToEncode
{
    [RegularExpression(@"^[a-zA-Z0-9]+$",
        ErrorMessage = "A kódolatlan közlemény csak az angol ABC betűit és számokat tartalmazhat!")]
    public string Message { get; set; }
}