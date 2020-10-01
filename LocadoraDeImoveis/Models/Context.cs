using Microsoft.EntityFrameworkCore;

namespace LocadoraDeImoveis.Models
{
    class Context : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer
                (@"Server=mssql914.umbler.com,5003;Database=projetodecsharp;User Id=projeto;Password=projetocsharp;");
        }
    }
}
