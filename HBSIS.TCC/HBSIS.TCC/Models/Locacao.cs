using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace HBSIS.TCC.Models
{
    public class Locacao
    {
        [Key]
        public int Codigo { get; set; }
        public RegistroVeiculo registroVeiculo { get; set; }
        public DateTime DataInicial { get; set; }
        public DateTime DataFinal { get; set; }
        public decimal Valor { get; set; }
        public string TermoDeUso { get; set; }
    }
}