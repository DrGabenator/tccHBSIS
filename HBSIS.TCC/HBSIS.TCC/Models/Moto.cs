using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace HBSIS.TCC.Models
{
    public class Moto
    {
        [Key]
        public int Codigo { get; set; }
        [Required]
        public MarcaMoto MarcaMoto { get; set; }
        [Required]
        public ModeloMoto ModeloMoto { get; set; }
        public int ModeloMotoFK { get; set; }
    }
}