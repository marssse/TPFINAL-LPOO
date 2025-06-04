using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ClaseBase.Entities
{
    public class Usuario
    {
        public Usuario(string usuario, string contrasenia, string rol)
        {
            this.USU_NombreUsuario = usuario;
            this.USU_Contrasenia = contrasenia;
            this.ROL_Codigo = rol;
        }

        public int USU_ID { get; set; }
        public string USU_NombreUsuario { get; set; }
        public string USU_Contrasenia { get; set; }
        public string USU_ApellidoNombre { get; set; }
        public string ROL_Codigo { get; set; }
    }
}
