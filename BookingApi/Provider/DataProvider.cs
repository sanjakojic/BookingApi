using BookingApi.Models;
using BookingApi.Repository;

namespace BookingApi.Provider;

public class DataProvider : IDataProvider
{
    private const string JsonFileName = "data.json";

    private readonly IDataRepository _dataRepository;

    public DataProvider(IDataRepository dataRepository)
    {
        _dataRepository = dataRepository ?? throw new ArgumentNullException(nameof(dataRepository));
    }

    /// <inheritdoc />
    public IEnumerable<Data> GetData()
    {
        IEnumerable<Data>? data = _dataRepository.ReadFromFile(JsonFileName);
        return data ?? Enumerable.Empty<Data>();
    }

}