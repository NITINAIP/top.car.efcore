namespace Top.Car.Service.Domain.ValueObject;
public struct Document
{
    public DocumentWf Value { get; }

    public Document(DocumentWf value)
    {
        if (value == null)
        {
            throw new ArgumentException("Document number cannot be null or empty.", nameof(value));
        }

        Value = value;
    }

    public override string ToString() => Value.ToString();

    public static implicit operator string(Document documentNo) => documentNo.Value.ToString();
    public static implicit operator Document(DocumentWf value) => new Document(value);
}
public record DocumentWf(string DocumentNo,int MaxId, int Year, int Month, int RunningNo);