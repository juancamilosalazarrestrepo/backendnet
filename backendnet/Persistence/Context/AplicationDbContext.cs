using backendnet.Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace backendnet.Persistence.Context
{
    public class AplicationDbContext:DbContext
    {
        public DbSet<Usuario> Usuarios { get; set; }
        public DbSet<Pregunta> Pregunta { get; set; }
        public DbSet<Cuestionario> Cuestionario { get; set; }
        public DbSet<Respuesta> Respuesta { get; set; }

        public AplicationDbContext(DbContextOptions<AplicationDbContext> options): base(options)
        {

        }
    }
}
