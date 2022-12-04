namespace Ramcor.Data.Validators
{
    public record ValidationResult
    {
        public IEnumerable<string> Errors { get; init; }
        public bool IsInvalid => Errors.Any();
        public bool IsValid => !IsInvalid;

        public ValidationResult()
        {
            Errors = Enumerable.Empty<string>();
        }
    }
}
