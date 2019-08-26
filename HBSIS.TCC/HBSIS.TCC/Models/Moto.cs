using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace HBSIS.TCC.Models
{
    public class Moto
    {
        [Key]
        public int Codigo { get; set; }
        public MarcaMoto marcaMoto { get; set; }
        public ModeloMoto modeloMoto { get; set; }
    }
}