namespace BookingApi.Models
{
    public class DistanceResult
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public Position? Position { get; set; }
        public string? Distance { get; set; }
        public int Score { get; set; }
    }
}
