namespace Ramrod.Data.Models;

public record Message
{
    public string Text { get; init; }
    public string ProcessedText { get; init; }
    public string Codeword { get; init; }

    public bool IsValid =>
        !string.IsNullOrEmpty(Text)
        && !string.IsNullOrEmpty(ProcessedText)
        && !string.IsNullOrEmpty(Codeword);
}