using System.Text.Json;
using BookingApi.Models;

namespace BookingApi.Repository;

public class DataRepository : IDataRepository
{
    private const string JsonFolder = "Json";

    public IEnumerable<Data>? ReadFromFile(string fileName)
    {
        string path = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, JsonFolder, fileName);
        string jsonString = File.ReadAllText(path);
        return JsonSerializer.Deserialize<List<Data>>(jsonString);
    }
}