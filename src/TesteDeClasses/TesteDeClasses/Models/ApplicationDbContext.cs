using Microsoft.EntityFrameworkCore;

namespace TesteDeClasses.Models
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }

        public DbSet<UsuarioOng> Usuarios_ong { get; set; }
        public DbSet<UsuarioVoluntario> Usuarios_voluntarios { get; set; }
    }
}
