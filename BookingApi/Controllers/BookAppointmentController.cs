using BookingApi.Helper;
using BookingApi.Provider;
using BookingApi.Repository;
using BookingApi.Request;
using BookingApi.Response;
using BookingApi.Service;
using Microsoft.AspNetCore.Mvc;

namespace BookingApi.Controllers;

[ApiController]
[Route("api/[controller]")]
public class BookAppointmentController : ControllerBase
{
    private readonly IBookingService _service;

    public BookAppointmentController()
    {
        _service = new BookingService(new DataProvider(new DataRepository()), new DistanceCalculator(), new NameMatcher()); ;
    }

    [HttpPost]
    [Produces("application/json")]
    [Route("[action]")]
    public IActionResult GetServices([FromBody] GetServiceRequest request)
    {
        try
        {
            if (string.IsNullOrEmpty(request.ServiceName))
            {
                return BadRequest("Service name must be entered.");
            }

            if (request.ServiceName == null && request.GeoLocation == null)
            {
                return BadRequest("Failed to get ");
            }

            var response = new ServiceDataResponse
            {
                ServiceData = _service.GetServiceData(request),
            };

            return Ok(response);
        }
        catch (Exception e)
        {
            return BadRequest(e.Message);
        }
    }
}