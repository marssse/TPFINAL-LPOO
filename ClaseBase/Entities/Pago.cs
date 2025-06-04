using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ClaseBase.Entities
{
    public class Pago
    {
        public int PAG_Codigo { get; set; }
        public int CUO_Codigo { get; set; } 
        public DateTime PAG_Fecha { get; set; }
        public decimal PAG_Importe { get; set; }
    }
}
