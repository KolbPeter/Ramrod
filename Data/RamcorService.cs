using Ramcor.Data.Models;
using Ramcor.Data.Validators;
using Ramcor.Data.TransCoders;

namespace Ramcor.Data
{
    public class RamcorService
    {
        public RamcorCode Code { get; set; }

        public ValidationResult Validate => Code.Validate();

        public Task<IEnumerable<char>> Encode(string text) => Code.EncodeToChars(text);

        public Task<IEnumerable<string>> EncodeToPhonetic(string text) => Code.EncodeToPhonetic(text);
        
        public Task<string> Decode(string text) => Code.Decode(text);

        public Task<string> DecodeAsPosition(string text) => Code.DecodeAsPosition(text);

        public ValidationResult SetCode(string newCodeWord)
        {
            var newCode = new RamcorCode { CodeWord = newCodeWord };
            var validationResult = newCode.Validate();
            if (validationResult.IsValid)
            {
                Code = newCode;
            }

            return validationResult;
        }

        public RamcorService()
        {
            Code = new RamcorCode();
        }
    }
}
