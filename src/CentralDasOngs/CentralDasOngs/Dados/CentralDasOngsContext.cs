using Microsoft.EntityFrameworkCore;
using CentralDasOngs.Models;
using Microsoft.AspNetCore.Razor.Language;

namespace CentralDasOngs.Dados
{
    public class CentralDasOngsContext : DbContext
    {
        public CentralDasOngsContext(DbContextOptions<CentralDasOngsContext> options) : base(options)
        {
        }
        public DbSet<UsuarioVoluntario> UsuariosVoluntarios { get; set; }
        public DbSet<Endereco> Enderecos { get; set; }
        public DbSet<UnidadeFederativa> Ufs { get; set; }
        public DbSet<Banco> Bancos { get; set; }
        public DbSet<DadoBancario> DadosBancarios { get; set; }
        public DbSet<UsuarioOng> UsuariosOng { get; set; }

    }
}