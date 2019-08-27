using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace HBSIS.TCC.Models
{
    public class ContextDB : DbContext
    {
        public DbSet<Cor> cores { get; set; }
        public DbSet<Locacao> locacoes { get; set; }
        public DbSet<Marca> marcas { get; set; }
        public DbSet<Modelo> modelos { get; set; }
        public DbSet<Periodo> periodos { get; set; }
        public DbSet<RegistroVeiculo> registroVeiculos { get; set; }
        public DbSet<Usuario> usuarios { get; set; }
    }
}