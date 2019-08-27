using HBSIS.TCC.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace HBSIS.TCC.Models
{
    public class Marca : UserControl
    {
        [Key]
        public int Codigo { get; set; }
        public string Descricao { get; set; }
        [Required]
        public virtual TipoVeiculo TipoVeiculo { get; set; }
    }
}