using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace HBSIS.TCC.Models
{
    public class Vaga
    {
        [Key]
        public int Codigo { get; set; }
        public int VagaAutomovel { get; set; }
        public int VagaMoto { get; set; }
        public int VagasGeral { get; set; } //Vagas para bicicletas e patinetes
        public virtual Usuario Usuario { get; set; }
    }
}