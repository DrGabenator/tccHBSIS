using HBSIS.TCC.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace HBSIS.TCC.Models
{
    public class Locacao : UserControl
    {
        [Key]
        public int Codigo { get; set; }
        [Required]
        public virtual RegistroVeiculo RegistroVeiculo { get; set; }
        [Required]
        public decimal Valor { get; set; }
        [Required]
        public virtual Periodo Periodo { get; set; }
        [Required]
        public virtual Usuario Usuario { get; set; }
        public Vaga Vaga { get; set; }
        public virtual StatusLocacao StatusLocacao { get; set; }
        public string TermoDeUso { get; set; }
    }
}