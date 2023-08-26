using backendnet.Domain.IRepositories;
using backendnet.Domain.Models;
using backendnet.Persistence.Context;

namespace backendnet.Persistence.Repositories
{
    public class CuestionarioRepository: ICuestionarioRepository
    {
        private readonly AplicationDbContext _context;
        public CuestionarioRepository(AplicationDbContext context)
        {
            _context = context;

        }
        public async Task CreateCuestionario(Cuestionario cuestionario)
        {
            _context.Add(cuestionario);
            await _context.SaveChangesAsync();
        }
    }
}
