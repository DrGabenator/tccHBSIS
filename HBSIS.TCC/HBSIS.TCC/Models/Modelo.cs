using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace HBSIS.TCC.Models
{
    public class Modelo : UserControl
    {
        [Key]
        public int Codigo { get; set; }
        public string Descricaco { get; set; }
        [Required]
        public virtual Marca Marca { get; set; }
    }
}