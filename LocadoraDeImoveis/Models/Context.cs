﻿using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System.IO;
using System.Reflection;

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
            optionsBuilder.UseSqlServer(@"Server=mssql914.umbler.com,5003;Database=projetocsharp;User Id=projeto;Password=projetocsharp;")
                .EnableSensitiveDataLogging();
        }
        
    }
}
