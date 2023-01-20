using System.Threading.Tasks;

namespace cwiczenia_7_APBD_INT.Repositories
{
    public interface IDbClientRepository
    {
        Task DeleteClientAsync(int idClient);
    }
}