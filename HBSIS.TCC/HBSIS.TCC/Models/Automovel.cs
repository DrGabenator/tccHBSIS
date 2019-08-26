using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace HBSIS.TCC.Models
{
    public class Automovel
    {
        [Key]
        public int Codigo { get; set; }
        public MarcaAutomovel marcaAutomovel { get; set; }
        public ModeloAutomovel modeloAutomovel { get; set;}
    }
}