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
        public int IdRegistrarion { get; set; }
        public string Email { get; set; }
        public bool PCD { get; set; }
        public bool TrabalhoNoturno { get; set; }
    }
}