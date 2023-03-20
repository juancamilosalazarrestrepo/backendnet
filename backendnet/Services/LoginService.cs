using backendnet.Domain.IRepositories;
using backendnet.Domain.IServices;
using backendnet.Domain.Models;

namespace backendnet.Services
{
    public class LoginService:ILoginService
    {
        private readonly ILoginRepository _loginRepository;
        public LoginService(ILoginRepository loginRepository)
        {
            _loginRepository = loginRepository;
        }
        public async  Task<Usuario> ValidateUser(Usuario usuario)
        {
            return await _loginRepository.ValidateUser(usuario);
        }


    }
}
