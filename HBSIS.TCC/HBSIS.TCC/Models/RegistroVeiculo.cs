using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace HBSIS.TCC.Models
{
    public class RegistroVeiculo
    {
        [Key]
        public int Codigo { get; set; }
        public TipoVeiculo tipoVeiculo { get; set; }
        public Cor Cor { get; set; }
        public string Placa { get; set; }
        public bool Ativo { get; set; }
    }
}