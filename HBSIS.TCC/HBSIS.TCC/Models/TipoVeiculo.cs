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
        [Required]
        public Automovel Automovel { get; set; }
        [Required]
        public Moto Moto { get; set; }
        [Required]
        public Bicicleta Bicicleta { get; set; }
        [Required]
        public Patinete Patinete { get; set; }
    }
}