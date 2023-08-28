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
            _cuestionarioRepository = cuestionarioRepository;
        }

        public async Task<Cuestionario> BuscarCuestionario(int idCuestionario, int idUsuario)
        {
            return await _cuestionarioRepository.BuscarCuestionario(idCuestionario,idUsuario);
        }

        public async Task CreateCuestionario(Cuestionario cuestionario)
        {
            await _cuestionarioRepository.CreateCuestionario(cuestionario);
        }

        public async Task EliminarCuestionario(Cuestionario cuestionario)
        {
           await _cuestionarioRepository.EliminarCuestionario(cuestionario);
        }

        public async Task<Cuestionario> GetCuestionario(int idCuestionario)
        {
            return await _cuestionarioRepository.GetCuestionario(idCuestionario);
        }

        public async Task<List<Cuestionario>> GetListCuestionarioByUser(int idUsuario)
        {
            return await _cuestionarioRepository.GetListCuestionarioByUser(idUsuario);
        }

        public async Task<List<Cuestionario>> GetListCuestionarios()
        {
            return await _cuestionarioRepository.GetListCuestionarios();
        }
    }
}
