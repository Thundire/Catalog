namespace Catalog.Site.Data;

public class DataMap
{
    public static DataMap Empty { get; } = new (Array.Empty<string>());

    public DataMap(string[] map)
    {
        Map = map;
        ShortMap = map.Length > 0 ? string.Join(' ', map) : string.Empty;
    }
    public string ShortMap { get; set; }
    public string[] Map { get; set; }
}