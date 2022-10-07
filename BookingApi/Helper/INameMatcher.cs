namespace BookingApi.Helper
{
    /// <summary>
    /// Matches the name against data
    /// </summary>
    public interface INameMatcher
    {
        /// <summary>
        /// Gets the matched names with the data for the provided string.
        /// </summary>
        public IDictionary<string, int> GetMatchedNames(IEnumerable<string?> data, string serviceName);
    }
}
