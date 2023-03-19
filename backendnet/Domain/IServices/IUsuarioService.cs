using backendnet.Domain.Models;

namespace backendnet.Domain.IServices
{
    public interface IUsuarioService
    {
        Task SaveUser(Usuario usuario);
        Task<bool> ValidateExistence(Usuario usuario);
    }
}
