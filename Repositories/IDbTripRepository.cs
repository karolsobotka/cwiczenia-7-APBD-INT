using cwiczenia_7_APBD_INT.Models.DTO;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace cwiczenia_7_APBD_INT.Repositories
{
    public interface IDbTripRepository
    {
        Task<IEnumerable<GetTripsResponseDto>> GetTripsAsync();
        Task AddTripToClientAsync(int idTrip, AddTripToClientRequestDto dto);
    }
}