using backendnet.Domain.Models;

namespace backendnet.Domain.IServices
{
    public interface ICuestionarioService
    {
        Task CreateCuestionario(Cuestionario cuestionario);
    }
}
