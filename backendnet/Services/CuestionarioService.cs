using backendnet.Domain.IRepositories;
using backendnet.Domain.IServices;
using backendnet.Domain.Models;

namespace backendnet.Services
{
    public class CuestionarioService: ICuestionarioService
    {
        private readonly ICuestionarioRepository _cuestionarioRepository;
        public CuestionarioService(ICuestionarioRepository cuestionarioRepository)
        {
         _cuestionarioRepository = cuestionarioRepository   
        }
        public async Task CreateCuestionario(Cuestionario cuestionario)
        {
            await _cuestionarioRepository.CreateCuestionario(cuestionario);
        }
    }
}
