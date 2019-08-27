using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HBSIS.TCC.Models
{
    public class UserControl
    {
        public bool? Ativo { get; set; } = true;
        public int? UsuInc { get; set; } = 0;
        public int? UsuAlt { get; set; } = 0;
        public DateTime? DatInc { get; set; } = DateTime.Now;
        public DateTime? DatAlt { get; set; } = DateTime.Now;
    }
}