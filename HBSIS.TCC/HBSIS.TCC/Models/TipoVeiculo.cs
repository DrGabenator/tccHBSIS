using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HBSIS.TCC.Models
{
    public class TipoVeiculo
    {
        public Automovel automovel { get; set; }
        public Moto moto { get; set; }
        public Bicicleta bicicleta { get; set; }
        public Patinete patinete { get; set; }
    }
}