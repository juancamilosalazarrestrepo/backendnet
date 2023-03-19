using backendnet.Domain.IRepositories;
using backendnet.Domain.Models;
using backendnet.Persistence.Context;
using Microsoft.EntityFrameworkCore;

namespace backendnet.Persistence.Repositories
{
    public class UsuarioRepository: IUsuarioRepository
    {
        private readonly AplicationDbContext _context;
        public UsuarioRepository(AplicationDbContext context)
        {
            _context = context;
        }

        public async Task SaveUser(Usuario usuario)
        {
            _context.Add(usuario);
            await _context.SaveChangesAsync();
        }

        public async Task<bool> ValidateExistence(Usuario usuario)
        {
            var valiateExistence = await _context.Usuarios.AnyAsync(x => x.NombreUsuario == usuario.NombreUsuario);
            return valiateExistence;
        }
    }
}
