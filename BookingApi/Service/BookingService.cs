using BookingApi.Helper;
using BookingApi.Models;
using BookingApi.Provider;
using BookingApi.Request;

namespace BookingApi.Service;

public class BookingService : IBookingService
{
    private readonly IDataProvider _dataProvider;
    private readonly IDistanceCalculator _distanceCalculator;
    private readonly INameMatcher _nameMatcher;

    public BookingService(IDataProvider dataProvider, IDistanceCalculator distanceCalculator, INameMatcher nameMatcher)
    {
        _dataProvider = dataProvider ?? throw new ArgumentNullException(nameof(dataProvider));
        _distanceCalculator = distanceCalculator ?? throw new ArgumentNullException(nameof(distanceCalculator));
        _nameMatcher = nameMatcher ?? throw new ArgumentNullException(nameof(nameMatcher));
    }

    /// <inheritdoc />
    public ServiceData GetServiceData(GetServiceRequest request)
    {
        IDictionary<string, int> filteredNames = _nameMatcher.GetMatchedNames(_dataProvider.GetData().Select(x => x.Name), request.ServiceName!);

        return CalculateDistance(filteredNames, request.GeoLocation!.Latitude, request.GeoLocation.Longtitude);
    }

    private ServiceData CalculateDistance(IDictionary<string, int> filteredNames, double geoLat, double geoLng)
    {
        var results = new List<DistanceResult>();

        foreach (string name in filteredNames.Select(x => x.Key))
        {
            Data? data = _dataProvider.GetData().FirstOrDefault(x => x.Name == name);

            if (data != null)
            {
                double distance = _distanceCalculator.CalculateDistance(geoLat, data.Position?.Latitude, geoLng, data.Position?.Longitude);
                DistanceResult distanceResult = CreateDistanceResult(data, distance, filteredNames.FirstOrDefault(x => x.Key == name).Value);
                results.Add(distanceResult);
            }
        }

        return CreateServiceData(results);
    }

    private static DistanceResult CreateDistanceResult(Data data, double distance, int score)
    {
        return new DistanceResult
        {
            Id = data.Id,
            Name = data.Name,
            Position = new Position
            {
                Latitude = data.Position!.Latitude,
                Longitude = data.Position.Longitude,
            },
            Distance = $"{Math.Round(distance, 2)}km",
            Score = score,
        };
    }

    private ServiceData CreateServiceData(IList<DistanceResult> results)
    {
        return new ServiceData
        {
            TotalHits = results.Count,
            TotalDocuments = _dataProvider.GetData().ToList().Count,
            Results = results.AsEnumerable(),
        };
    }
}

