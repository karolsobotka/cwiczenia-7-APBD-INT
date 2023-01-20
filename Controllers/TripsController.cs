using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using System;
using cwiczenia_7_APBD_INT.Repositories;
using cwiczenia_7_APBD_INT.Models.DTO;

namespace cwiczenia_7_APBD_INT.Controllers
{
    [Route("api/trip")]
    [ApiController]
    public class TripsController : ControllerBase
    {
        private readonly IDbTripRepository repository;

        public TripsController(IDbTripRepository repository)
        {
            this.repository = repository;
        }

        [HttpGet]
        public async Task<IActionResult> GetTrips()
        {
            try
            {
                var trips = await repository.GetTripsAsync();
                return Ok(trips);
            }
            catch (Exception)
            {
                return NoContent();
            }
        }

        [HttpPost("{idTrip}/clients")]
        public async Task<IActionResult> AddTripToClient([FromRoute] int idTrip, [FromBody] AddTripToClientRequestDto dto)
        {
            try
            {
                await repository.AddTripToClientAsync(idTrip, dto);
                return Ok("Your request processed successfully!");
            }
            catch (Exception e)
            {
                return NotFound(e.Message);
            }
        }
    }
}