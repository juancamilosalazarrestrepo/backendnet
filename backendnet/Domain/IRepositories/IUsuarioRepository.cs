using backendnet.Domain.Models;

namespace backendnet.Domain.IRepositories
{
    public interface IUsuarioRepository
    {

        Task SaveUser(Usuario usuario);
        Task<bool> ValidateExistence(Usuario usuario);
        Task<Usuario> ValidatePassword(int idUsuario, string passwordAnterior);
        Task UpdatePassword(Usuario usuario);


    }
}
