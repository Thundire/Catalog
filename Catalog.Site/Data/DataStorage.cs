namespace Catalog.Site.Data;

public class DataStorage
{
    private readonly Dictionary<Guid, Data> _data;
    private readonly HashSet<string> _datatypes;

    private readonly Dictionary<(string mapName, string type), List<string>> _baseMaps;

    public DataStorage()
    {
        _data = new();
        _datatypes = new();
    }

    public event Action<string>? OnDataTypeAdded;

    public Guid Add(Data data)
    {
        if(data.Type is null) return Guid.Empty;

        Guid id = Guid.NewGuid();
        _data.Add(id, data);
        if (_datatypes.Add(data.Type))
        {
            OnDataTypeAdded?.Invoke(data.Type);
        }
        return id;
    }

    public IEnumerable<(Guid, Data)> GetData(string type) => _data.Where(p => p.Value.Type == type).Select(p => (p.Key, p.Value)).ToList();

    public void SaveMap(string mapName, Data data)
    {
        _baseMaps.TryAdd((mapName, data.Type), data.Fields.Select(f=>f.Name).ToList());
    }

    public Data GetBaseMap(string type, string mapName)
    {
        if (!_baseMaps.TryGetValue((mapName, type), out var map)) return new ();
        return new () { Fields = map.Select(n => new Field { Name = n }).ToList() };
    }

    public IEnumerable<string> DataTypes => _datatypes;
    public IEnumerable<string> Maps(string type) => _baseMaps.Keys.Where(t => t.type == type).Select(t => t.mapName).ToList();
}