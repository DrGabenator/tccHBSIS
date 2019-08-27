using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace HBSIS.TCC.Models
{
    public class Locacao
    {
        [Key]
        public int Codigo { get; set; }
        public virtual RegistroVeiculo RegistroVeiculo { get; set; }
        [Required]
        public DateTime DataInicial { get; set; }
        [Required]
        public DateTime DataFinal { get; set; }
        [Required]
        public decimal Valor { get; set; }
        public string TermoDeUso { get; set; }
    }
}