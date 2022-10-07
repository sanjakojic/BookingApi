namespace BookingApi.Models
{
    public class ServiceData
    {
        public int TotalHits { get; set; }
        public int TotalDocuments { get; set; }
        public IEnumerable<DistanceResult>? Results { get; set; }
    }
}
