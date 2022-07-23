namespace Catalog.Site.Data;

public sealed class Data
{
    public string? Type { get; set; }
    public List<Field> Fields { get; set; } = new();
}