namespace Catalog.Site.Data;

public abstract class Field
{
    public string? Name { get; set; }
    public string? Value { get; set; }
}

public sealed class StringField : Field
{
}

public sealed class NumberField : Field
{
    public int ExactValue => int.TryParse(Value, out var number) ? number : 0;
}

public sealed class FloatField : Field
{
    public double ExactValue => double.TryParse(Value, out var number) ? number : 0;
}