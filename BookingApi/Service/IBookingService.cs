using BookingApi.Models;
using BookingApi.Request;

namespace BookingApi.Service
{
    /// <summary>
    /// Defines the methods for handling services.
    /// </summary>
    public interface IBookingService
    {
        /// <summary>
        /// Gets the service data.
        /// </summary>
        /// <returns>Details for the services within the specified name and location.</returns>
        ServiceData GetServiceData(GetServiceRequest request);
    }
}
