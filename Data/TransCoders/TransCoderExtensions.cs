using Ramcor.Data.Models;

namespace Ramcor.Data.TransCoders
{
    public static class TransCoderExtensions
    {
        public static Task<string> Encode(this RamcorCode code, string text) =>
            Task.Run(() => 
                string
                    .Concat(text
                    .Select(x => char.ToUpper(x).EncodeChar(code.CodeWord.ToUpper()))));

        public static Task<IEnumerable<string>> ToPhonetic(this string text) =>
            Task.Run(() =>
            {
                return text
                    .Select(x => Enum.GetNames<PhoneticAlphabet>().First(y => y.StartsWith(x)));
            });

        public static Task<string> Decode(this RamcorCode code, string text) =>
            Task.Run(() => 
                string
                    .Concat(text
                    .Select(x => x.DecodeChar(code.CodeWord))));

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
