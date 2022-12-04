using Ramcor.Data.Models;

namespace Ramcor.Data.TransCoders
{
    public static class TransCoderExtensions
    {
        public static Task<IEnumerable<char>> EncodeToChars(this RamcorCode code, string text) =>
            Task.Run(() => text.Select(x => char.ToUpper(x).EncodeChar(code.CodeWord.ToUpper())));

        public static Task<IEnumerable<string>> EncodeToPhonetic(this RamcorCode code, string text) =>
            Task.Run(() =>
            {
                return code
                    .EncodeToChars(text)
                    .Result
                    .Select(x => Enum.GetNames<PhoneticAlphabet>().First(y => y.StartsWith(x)));
            });

        public static Task<string> Decode(this RamcorCode code, string text) =>
            Task.Run(() => 
                string
                    .Concat(text
                    .Select(x => x.DecodeChar(code.CodeWord))));

        public static Task<string> DecodeAsPosition(this RamcorCode code, string text) =>
            Task.Run(() => 
                string
                    .Concat(text
                    .Select((x,i) => i is < 2 or > 4
                        ? x.DecodeChar(code.CodeWord)
                        : char.ToUpper(x))));

        private static char EncodeChar(this char character, string codeWord)
        {
            return char.IsNumber(character)
                ? codeWord
                    .ToUpperInvariant()[(int)char.GetNumericValue(char.ToUpperInvariant(character))]
                : char.ToUpperInvariant(character);
        }

        private static char DecodeChar(this char character, string codeWord)
        {
            return codeWord
                .ToUpper()
                .Contains(char.ToUpperInvariant(character))
                ? Convert.ToChar('0' + codeWord.ToUpper().IndexOf(char.ToUpperInvariant(character)))
                : char.ToUpperInvariant(character);
        }
    }
}
