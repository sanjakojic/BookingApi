using BookingApi.Models;

namespace BookingApi.Provider
{
    /// <summary>
    /// Provides data from the json file.
    /// </summary>
    public interface IDataProvider
    {
        /// <summary>
        /// Gets a list of all services from the json file.
        /// </summary>
        /// <returns>All services.</returns>
        IEnumerable<Data> GetData();
    }
}
