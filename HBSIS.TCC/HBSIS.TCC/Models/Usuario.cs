using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace HBSIS.TCC.Models
{
    public class Usuario : UserControl
    {
        [Key]
        public int Codigo { get; set; }
        public int IdRegistration { get; set; }
        public string Email { get; set; }
        public bool PCD { get; set; }
        public bool TrabalhoNoturno { get; set; }
        public bool ResideFora { get; set; } = false;
        public bool Carona { get; set; } = false;
    }
}