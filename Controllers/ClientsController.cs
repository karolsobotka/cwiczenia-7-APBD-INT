using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using System;
using cwiczenia_7_APBD_INT.Repositories;

namespace cwiczenia_7_APBD_INT.Controllers
{
    [Route("api/clients")]
    [ApiController]
    public class ClientsController : ControllerBase
    {
        private readonly IDbClientRepository repository;

        public ClientsController(IDbClientRepository repository)
        {
            this.repository = repository;
        }

        [HttpDelete("{idClient}")]
        public async Task<IActionResult> DeleteClient([FromRoute] int idClient)
        {
            try
            {
                await repository.DeleteClientAsync(idClient);
                return Ok($"Client ID: {idClient} was deleted!");
            }
            catch (Exception e)
            {
                return NotFound(e.Message);
            }
        }
    }
}