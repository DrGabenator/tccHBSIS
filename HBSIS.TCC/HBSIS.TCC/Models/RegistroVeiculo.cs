using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace HBSIS.TCC.Models
{
    public class RegistroVeiculo : UserControl
    {
        [Key]
        public int Codigo { get; set; }
        [Required]
        public virtual Modelo Modelo { get; set; }
        public string Descricaco { get; set; }
        [Required]
        public virtual Cor Cor { get; set; }
        public string Placa { get; set; }
    }
}