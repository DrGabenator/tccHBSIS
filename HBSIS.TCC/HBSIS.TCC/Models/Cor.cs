using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace HBSIS.TCC.Models
{
    public class Cor
    {
        [Key]
        public int Codigo { get; set; }
        public string Descricao { get; set; }
    }
}