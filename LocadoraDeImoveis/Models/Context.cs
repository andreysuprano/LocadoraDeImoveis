using Microsoft.EntityFrameworkCore;

namespace LocadoraDeImoveis.Models
{
    class Context : DbContext
    {
        public DbSet<Corretor> Corretores { get; set; }
        public DbSet<Contrato> Contratos { get; set; }
        public DbSet<Imovel> Imoveis { get; set; }
        public DbSet<Locatario> Locatarios { get; set; }
        public DbSet<TipoImovel> TipoImovel { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer
                (@"Server=mssql914.umbler.com,5003;Database=projetodecsharp;User Id=projeto;Password=projetocsharp;");
        }
    }
}
