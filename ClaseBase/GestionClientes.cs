using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;

namespace ClaseBase
{
    public static class GestionClientes
    {
        // 1. Método para agregar cliente
        public static void AgregarCliente(string dni, string nombre, string apellido,
                                        string sexo, DateTime fechaNac,
                                        decimal ingresos, string direccion, string telefono)
        {
            string query = @"INSERT INTO Cliente 
                           (CLI_DNI, CLI_Nombre, CLI_Apellido, CLI_Sexo, 
                            CLI_FechaNacimiento, CLI_Ingresos, CLI_Direccion, CLI_Telefono)
                           VALUES (@dni, @nombre, @apellido, @sexo, 
                                   @fechaNac, @ingresos, @direccion, @telefono)";

            SqlParameter[] parameters = {
                new SqlParameter("@dni", dni),
                new SqlParameter("@nombre", nombre),
                new SqlParameter("@apellido", apellido),
                new SqlParameter("@sexo", sexo),
                new SqlParameter("@fechaNac", fechaNac),
                new SqlParameter("@ingresos", ingresos),
                new SqlParameter("@direccion", direccion),
                new SqlParameter("@telefono", telefono)
            };

            DatabaseHelper.ExecuteNonQuery(query, parameters);
        }

        // 2. Método para obtener todos los clientes
        public static DataTable ObtenerTodosClientes()
        {
            string query = @"
                SELECT 
                    CLI_DNI AS 'DNI',
                    CLI_Nombre AS 'Nombre',
                    CLI_Apellido AS 'Apellido',
                    CLI_Sexo AS 'Sexo',
                    CONVERT(VARCHAR(10), CLI_FechaNacimiento, 103) AS FechaNacimiento,
                    CLI_Ingresos AS 'Ingresos',
                    CLI_Direccion AS 'Direccion',
                    CLI_Telefono AS 'Telefono'
                FROM Cliente";

            return DatabaseHelper.ExecuteQuery(query);
        }

        // 3. Método para buscar clientes (por DNI y Apellido)
        public static DataTable BuscarClientesCombinado(string apellido, string nombre)
        {
            var query = new StringBuilder(@"
                SELECT 
                    CLI_DNI AS 'DNI',
                    CLI_Nombre AS 'Nombre',
                    CLI_Apellido AS 'Apellido',
                    CLI_Sexo AS 'Sexo',
                    CONVERT(VARCHAR(10), CLI_FechaNacimiento, 103) AS FechaNacimiento,
                    CLI_Ingresos AS 'Ingresos',
                    CLI_Direccion AS 'Direccion',
                    CLI_Telefono AS 'Telefono'
                FROM Cliente
                WHERE 1 = 1");

            var parameters = new List<SqlParameter>();

            if (!string.IsNullOrWhiteSpace(apellido))
            {
                query.Append(" AND CLI_Apellido LIKE @apellido");
                parameters.Add(new SqlParameter("@apellido", "%" + apellido.Trim() + "%"));
            }

            if (!string.IsNullOrWhiteSpace(nombre))
            {
                query.Append(" AND CLI_Nombre LIKE @nombre");
                parameters.Add(new SqlParameter("@nombre", "%" + nombre.Trim() + "%"));
            }

            return DatabaseHelper.ExecuteQuery(query.ToString(), parameters.ToArray());
        }

        // 4. Método para actualizar cliente
        public static void ActualizarCliente(string dni, string nombre, string apellido,
                                     string sexo, DateTime fechaNac,
                                     decimal ingresos, string direccion, string telefono)
        {
            string query = @"UPDATE Cliente SET 
                   CLI_Nombre = @nombre,
                   CLI_Apellido = @apellido,
                   CLI_Sexo = @sexo,
                   CLI_FechaNacimiento = @fechaNac,
                   CLI_Ingresos = @ingresos,
                   CLI_Direccion = @direccion,
                   CLI_Telefono = @telefono
                   WHERE CLI_DNI = @dni";

            SqlParameter[] parameters = {
                new SqlParameter("@dni", dni),
                new SqlParameter("@nombre", nombre),
                new SqlParameter("@apellido", apellido),
                new SqlParameter("@sexo", sexo),
                new SqlParameter("@fechaNac", fechaNac),
                new SqlParameter("@ingresos", ingresos),
                new SqlParameter("@direccion", direccion),
                new SqlParameter("@telefono", telefono)
            };

            DatabaseHelper.ExecuteNonQuery(query, parameters);
        }

        // 5. Método para eliminar cliente
        public static void EliminarCliente(string dni)
        {
            string query = "DELETE FROM Cliente WHERE CLI_DNI = @dni";
            SqlParameter param = new SqlParameter("@dni", dni);
            DatabaseHelper.ExecuteNonQuery(query, param);
        }
    }
}
