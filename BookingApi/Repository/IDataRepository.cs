using BookingApi.Models;

namespace BookingApi.Repository
{
    /// <summary>
    /// File repository
    /// </summary>
    public interface IDataRepository
    {
        /// <summary>
        /// Reads data from file.
        /// </summary>
        /// <param name="fileName">The name of the file.</param>
        /// <returns>Records from file.</returns>
        IEnumerable<Data>? ReadFromFile(string fileName);
    }
}
