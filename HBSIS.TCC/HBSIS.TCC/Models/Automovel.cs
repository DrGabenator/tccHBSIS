using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace HBSIS.TCC.Models
{
    public class Automovel
    {
        [Key]
        public int Codigo { get; set; }
        [Required]
        public MarcaAutomovel MarcaAutomovel { get; set; }
        [Required]
        public ModeloAutomovel ModeloAutomovel { get; set; }
    }
}