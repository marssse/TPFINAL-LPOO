using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ClaseBase.Entities
{
    public class Prestamo
    {
        public int PRE_Numero { get; set; }
        public string CLI_DNI { get; set; } 
        public int DES_Codigo { get; set; } 
        public int PER_Codigo { get; set; } 
        public DateTime PRE_Fecha { get; set; }
        public decimal PRE_Importe { get; set; }
        public double PRE_TasaInteres { get; set; }
        public int PRE_CantidadCuotas { get; set; }
        public string PRE_Estado { get; set; }
    }
}
