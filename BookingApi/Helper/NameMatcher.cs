namespace BookingApi.Helper
{
    public class NameMatcher : INameMatcher
    {
        /// <inheritdoc />
        public IDictionary<string, int> GetMatchedNames(IEnumerable<string?> data, string serviceName)
        {
            return MatchName(data, serviceName);
        }

        private static IDictionary<string, int> MatchName(IEnumerable<string?> names, string serviceName)
        {
            IDictionary<string, int> scoredName = new Dictionary<string, int>();
            var counter = 0;

            foreach (string? name in names)
            {
                if (!string.IsNullOrEmpty(name) && FilterNames(name, serviceName))
                {
                    if (!scoredName.ContainsKey(name))
                    {
                        scoredName.Add(name, counter);
                        counter++;
                    }
                }
            }
            return scoredName;
        }

        private static bool FilterNames(string name, string searchedName)
        {
            return name.StartsWith(searchedName[0]) && searchedName.Length > 1 && searchedName.Contains(searchedName[1]);
        }
    }
}
