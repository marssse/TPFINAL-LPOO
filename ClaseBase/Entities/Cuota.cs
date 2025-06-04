using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ClaseBase.Entities
{
    public class Cuota
    {
        public int CUO_Codigo { get; set; }
        public int PRE_Numero { get; set; } 
        public int CUO_Numero { get; set; }
        public DateTime CUO_Vencimiento { get; set; }
        public decimal CUO_Importe { get; set; }
        public string CUO_Estado { get; set; }
    }
}
