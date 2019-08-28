using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace HBSIS.TCC.Models
{
    public class Periodo : UserControl
    {
        [Key]
        public int Codigo { get; set; }
        [Required]
        public int NumeroDePeriodos { get; set; }
        [Required]
        public DateTime DataInicial { get; set; } = DateTime.Now;
        [Required]
        public DateTime DataFinal { get; set; } = DateTime.Now;
        public Usuario usuario { get; set; }
    }
}