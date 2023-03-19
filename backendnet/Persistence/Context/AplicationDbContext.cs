using backendnet.Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace backendnet.Persistence.Context
{
    public class AplicationDbContext:DbContext
    {
        public DbSet<Usuario> Usuarios { get; set; }
        public AplicationDbContext(DbContextOptions<AplicationDbContext> options): base(options)
        {

        }
    }
}
