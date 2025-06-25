using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;

namespace ClaseBase
{
    public static class GestionDestino
    {
        // Obtener todos los destinos
        public static DataTable ObtenerTodosDestinos()
        {
            string query = "SELECT DES_Codigo AS 'Codigo', DES_Descripcion AS 'Descripcion' FROM Destino";
            return DatabaseHelper.ExecuteQuery(query);
        }

        // Buscar destinos por descripción
        public static DataTable BuscarDestinos(string descripcion)
        {
            string query = "SELECT DES_Codigo AS 'Codigo', DES_Descripcion AS 'Descripcion' FROM Destino " +
                          "WHERE DES_Descripcion LIKE @descripcion";
            SqlParameter param = new SqlParameter("@descripcion", "%" + descripcion + "%");
            return DatabaseHelper.ExecuteQuery(query, param);
        }

        // Agregar nuevo destino
        public static void AgregarDestino(string descripcion)
        {
            string query = "INSERT INTO Destino (DES_Descripcion) VALUES ( @descripcion)";
            SqlParameter[] parameters = {
                new SqlParameter("@descripcion", descripcion)
            };
            DatabaseHelper.ExecuteNonQuery(query, parameters);
        }

        // Actualizar destino
        public static void ActualizarDestino(string codigoOriginal,string nuevaDescripcion)
        {
            string query = "UPDATE Destino SET DES_Descripcion = @nuevaDescripcion " +
                          "WHERE DES_Codigo = @codigoOriginal";
            SqlParameter[] parameters = {
                new SqlParameter("@nuevaDescripcion", nuevaDescripcion),
                new SqlParameter("@codigoOriginal", codigoOriginal)
            };
            DatabaseHelper.ExecuteNonQuery(query, parameters);
        }

        // Eliminar destino
        public static void EliminarDestino(string codigo)
        {
            string query = "DELETE FROM Destino WHERE DES_Codigo = @codigo";
            SqlParameter param = new SqlParameter("@codigo", codigo);
            DatabaseHelper.ExecuteNonQuery(query, param);
        }

        // Verificar si el código ya existe
        public static bool ExisteCodigo(string codigo)
        {
            string query = "SELECT COUNT(*) FROM Destino WHERE DES_Codigo = @codigo";
            SqlParameter param = new SqlParameter("@codigo", codigo);
            int count = (int)DatabaseHelper.ExecuteScalar(query, param);
            return count > 0;
        }
    }
}
