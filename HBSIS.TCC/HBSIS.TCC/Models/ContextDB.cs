using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace HBSIS.TCC.Models
{
    public class ContextDB : DbContext
    {
        public DbSet<Automovel> automoveis;
        public DbSet<Bicicleta> bicicletas;
        public DbSet<Cor> cores;
        public DbSet<Locacao> locacoes;
        public DbSet<MarcaAutomovel> marcaAutomoveis;
        public DbSet<MarcaMoto> marcaMotos;
        public DbSet<Moto> motos;
        public DbSet<Patinete> patinetes;
        public DbSet<Usuario> usuarios;
    }
}