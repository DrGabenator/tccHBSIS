using HBSIS.TCC.Enums;
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
        public int NumeroDePeriodos { get; set; }
        public virtual TipoVeiculo TipoVeiculo { get; set; }
        public DateTime DataInicial { get; set; } = DateTime.Now;
        public DateTime DataFinal { get; set; } = DateTime.Now.AddMonths(6);
    }
}