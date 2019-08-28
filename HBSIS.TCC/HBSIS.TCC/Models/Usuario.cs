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
        [Required]
        public string Email { get; set; }
        [Required]
        public bool PCD { get; set; }
        [Required]
        public bool TrabalhoNoturno { get; set; }
        public bool Gestor { get; set; }
    }
}