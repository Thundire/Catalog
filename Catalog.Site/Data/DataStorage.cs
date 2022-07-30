namespace Catalog.Site.Data;

public class DataStorage
{
	private readonly DataTypes _dataTypes;
	private readonly Dictionary<Guid, Data> _data;
	public DataStorage(DataTypes dataTypes)
	{
		_dataTypes = dataTypes;
		_data = new();
	}

	public Guid Add(Data data)
	{
		if (data.Type is null) return Guid.Empty;

		Guid id = Guid.NewGuid();
		_data.Add(id, data);
		_dataTypes.Add(data.Type);
		return id;
	}

	public IEnumerable<(Guid, Data)> GetData(string type) => _data.Where(p => p.Value.Type == type).Select(p => (p.Key, p.Value)).ToList();
}