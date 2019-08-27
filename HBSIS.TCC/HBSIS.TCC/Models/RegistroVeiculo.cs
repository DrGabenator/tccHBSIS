using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace HBSIS.TCC.Models
{
    public class RegistroVeiculo
    {
        [Key]
        public int Codigo { get; set; }
        public virtual TipoVeiculo TipoVeiculo { get; set; }
        public virtual Cor Cor { get; set; }
        public string Placa { get; set; }
        public bool Ativo { get; set; }
    }
}