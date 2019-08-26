using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace HBSIS.TCC.Models
{
    public class ContextDB : DbContext
    {
        public DbSet<Automovel> automoveis { get; set; }
        public DbSet<Bicicleta> bicicletas { get; set; }
        public DbSet<Cor> cores { get; set; }
        public DbSet<Locacao> locacoes { get; set; }
        public DbSet<MarcaAutomovel> marcaAutomoveis { get; set; }
        public DbSet<MarcaMoto> marcaMotos { get; set; }
        public DbSet<ModeloAutomovel> modeloAutomoveis { get; set; }
        public DbSet<ModeloMoto> modeloMotos { get; set; }
        public DbSet<Moto> motos { get; set; }
        public DbSet<Patinete> patinetes { get; set; }
        public DbSet<RegistroVeiculo> registroVeiculos { get; set; }
        public DbSet<Usuario> usuarios { get; set; }
    }
}