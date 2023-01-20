using System.Threading.Tasks;
using System;
using cwiczenia_7_APBD_INT.Models;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace cwiczenia_7_APBD_INT.Repositories
{
    public class DbClientRepository : IDbClientRepository
    {
        private readonly Context context;

        public DbClientRepository(Context context)
        {
            this.context = context;
        }

        public async Task DeleteClientAsync(int idClient)
        {
            bool hasTrips = await context.ClientTrips.AnyAsync(row => row.IdClient == idClient);

            if (hasTrips) throw new Exception("Client has one or more trips!");

            Client client = await context.Clients.Where(row => row.IdClient == idClient).FirstOrDefaultAsync();
            context.Remove(client);

            await context.SaveChangesAsync();
        }
    }
}