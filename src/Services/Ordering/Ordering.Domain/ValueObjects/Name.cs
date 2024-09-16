namespace Ordering.Domain.ValueObjects
{
    public record Name
    {
        private const int DefaultLength = 5;

        public string Value { get; }

        private Name(string value) => Value = value;

        public static Name Of(string value)
        {
            ArgumentException.ThrowIfNullOrWhiteSpace(value);
            ArgumentOutOfRangeException.ThrowIfNotEqual(value.Length, DefaultLength);

            return new Name(value);
        }
    }
}
