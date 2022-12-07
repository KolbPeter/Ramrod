using System.ComponentModel.DataAnnotations;

namespace Ramcor.Data.Models
{
    public class MessageToDecode
    {
        [RegularExpression(@"^[a-zA-Z]+$", ErrorMessage = "A kódolt közlemény csak az angol ABC betűit tartalmazhatja!")]

        public string Message { get; set; }
    }
}
