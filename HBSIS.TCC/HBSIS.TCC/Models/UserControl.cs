using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HBSIS.TCC.Models
{
    public class UserControl
    {
        public bool? Ativo { get; set; } = true;
        [JsonIgnore]
        public int? UsuInc { get; set; } = 0;
        [JsonIgnore]
        public int? UsuAlt { get; set; } = 0;
        [JsonIgnore]
        public DateTime? DatInc { get; set; } = DateTime.Now;
        [JsonIgnore]
        public DateTime? DatAlt { get; set; } = DateTime.Now;
    }
}