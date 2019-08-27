using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace HBSIS.TCC.Models
{
    public class TipoVeiculo
    {
        [Key]
        public int Id { get; set; }
        public virtual Automovel Automovel { get; set; }
        public virtual Moto Moto { get; set; }
        public virtual Bicicleta Bicicleta { get; set; }
        public virtual Patinete Patinete { get; set; }
    }
}