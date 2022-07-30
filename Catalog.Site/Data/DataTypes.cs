namespace Catalog.Site.Data;

public class DataTypes
{
    private readonly HashSet<string> _datatypes;

    private readonly Dictionary<(string mapName, string type), List<string>> _baseMaps;

    public DataTypes()
    {
        _datatypes = new();
        _baseMaps = new();
    }

    public void SaveMap(string mapName, Data data)
    {
        _baseMaps.TryAdd((mapName, data.Type), data.Fields.Select(f => f.Name).ToList());
    }

    public Data GetBaseMap(string type, string mapName)
    {
        if (!_baseMaps.TryGetValue((mapName, type), out var map)) return new();
        return new() { Fields = map.Select(n => new Field { Name = n }).ToList() };
    }

    public bool Add(string type) => _datatypes.Add(type);

    public IEnumerable<string> Types => _datatypes.ToArray();
    public IEnumerable<string> Maps(string type) => _baseMaps.Keys.Where(t => t.type == type).Select(t => t.mapName).ToList();
}