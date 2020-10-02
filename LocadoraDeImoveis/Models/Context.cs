using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace LocadoraDeImoveis.Models
{
    class Context : DbContext
    {
        public DbSet<Corretor> Corretores { get; set; }
        public DbSet<Contrato> Contratos { get; set; }
        public DbSet<Imovel> Imoveis { get; set; }
        public DbSet<Locatario> Locatarios { get; set; }
        public DbSet<TipoImovel> TipoImovel { get; set; }
        private IConfiguration Configuration { get; set; }
        string ConnectionString { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer($@"{GetConnectionString()}");
        }

        private string GetConnectionString()
        {
            ConnectionString = Configuration.GetSection("ConnectionString").Value;
            return ConnectionString;
        }
    }
}
