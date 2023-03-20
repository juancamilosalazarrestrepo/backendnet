using backendnet.Domain.Models;

namespace backendnet.Domain.IRepositories
{
    public interface ILoginRepository
    {
        Task<Usuario> ValidateUser(Usuario usuario);

    }
}
