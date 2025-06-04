using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ClaseBase.Entities
{
    public class Cliente
    {
        public string CLI_DNI { get; set; }
        public string CLI_Nombre { get; set; }
        public string CLI_Apellido { get; set; }
        public string CLI_Sexo { get; set; }
        public DateTime CLI_FechaNacimiento { get; set; }
        public decimal CLI_Ingresos { get; set; }
        public string CLI_Direccion { get; set; }
        public string CLI_Telefono { get; set; }
    }
}
