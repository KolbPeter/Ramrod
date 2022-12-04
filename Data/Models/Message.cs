namespace Ramcor.Data.Models
{
    public record Message
    {
        public string Text { get; init; }
        public string ProcessedText { get; init; }
        public string Codeword { get; init; }
    }
}
