using backendnet.Domain.Models;

namespace backendnet.Domain.IRepositories
{
    public interface ICuestionarioRepository
    {
        Task CreateCuestionario(Cuestionario cuestionario);
    }
}
