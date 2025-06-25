using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.Data;
using System.Data.SqlClient;

namespace ClaseBase
{
    public class GestionUsuarios
    {
        private static string connectionString = ClaseBase.Properties.Settings.Default.prestamosConnectionString;

        // 1. Método para obtener todos los roles (para ComboBox)
        public static DataTable ObtenerRoles()
        {
            DataTable dt = new DataTable();
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("SELECT ROL_Codigo, ROL_Descripcion FROM Rol", con);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                da.Fill(dt);
            }
            return dt;
        }

        // 2. Método para agregar nuevo usuario
        public static void AgregarUsuario(string usuario, string contraseña, string nombreCompleto, string rolCodigo)
        {
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                con.Open();
                string query = @"INSERT INTO Usuario (USU_NombreUsuario, USU_Contrasenia, USU_ApellidoNombre, ROL_Codigo) 
                              VALUES (@user, @pass, @nombre, @rol)";

                SqlCommand cmd = new SqlCommand(query, con);
                cmd.Parameters.AddWithValue("@user", usuario);
                cmd.Parameters.AddWithValue("@pass", contraseña);
                cmd.Parameters.AddWithValue("@nombre", nombreCompleto);
                cmd.Parameters.AddWithValue("@rol", rolCodigo);

                cmd.ExecuteNonQuery();
                con.Close();
            }
        }

        // 7. Método para obtener todos los usuarios (opcional)
        public static DataTable ObtenerTodosUsuarios()
        {
            DataTable dt = new DataTable();
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                con.Open();
                SqlCommand cmd = new SqlCommand();
                cmd.CommandText = @"
                    SELECT 
                        U.USU_ID AS [ID],
                        R.ROL_Descripcion AS [Rol],
                        U.USU_ApellidoNombre AS [Apellido y Nombre],
                        U.USU_NombreUsuario AS [Usuario],
                        U.USU_Contrasenia AS [Contraseña],
                        U.ROL_Codigo AS [Código de Rol]
                    FROM Usuario U
                    LEFT JOIN Rol R ON R.ROL_Codigo = U.ROL_Codigo
                ";
                cmd.CommandType = CommandType.Text;
                cmd.Connection = con;

                SqlDataAdapter da = new SqlDataAdapter(cmd);
                da.Fill(dt);
            }
            return dt;
        }
        // Busqueda
        public static DataTable BuscarUsuarios(string busqueda)
        {
            DataTable dt = new DataTable();
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                con.Open();
                SqlCommand cmd = new SqlCommand();
                cmd.CommandText = @"
                    SELECT 
                        U.USU_ID AS [ID],
                        R.ROL_Descripcion AS [Rol],
                        U.USU_ApellidoNombre AS [Apellido y Nombre],
                        U.USU_NombreUsuario AS [Usuario],
                        U.USU_Contrasenia AS [Contraseña],
                        U.ROL_Codigo AS [Código de Rol]
                    FROM Usuario U
                    LEFT JOIN Rol R ON R.ROL_Codigo = U.ROL_Codigo
                    WHERE U.USU_ApellidoNombre LIKE '%' + @busqueda + '%'
                       OR U.USU_NombreUsuario LIKE '%' + @busqueda + '%'
                ";

                cmd.Parameters.AddWithValue("@busqueda", busqueda);
                cmd.CommandType = CommandType.Text;
                cmd.Connection = con;

                SqlDataAdapter da = new SqlDataAdapter(cmd);
                da.Fill(dt);
            }
            return dt;
        }

        public static void ActualizarUsuario(int id, string usuario, string contraseña, string nombreCompleto, string rolCodigo)
        {
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                con.Open();
                string query = @"UPDATE Usuario SET 
                         USU_NombreUsuario = @user, 
                         USU_Contrasenia = @pass, 
                         USU_ApellidoNombre = @nombre, 
                         ROL_Codigo = @rol 
                         WHERE USU_ID = @id";

                SqlCommand cmd = new SqlCommand(query, con);
                cmd.Parameters.AddWithValue("@user", usuario);

                // Actualizar contraseña solo si se proporcionó una nueva
                if (!string.IsNullOrWhiteSpace(contraseña))
                    cmd.Parameters.AddWithValue("@pass", contraseña);
                else
                    cmd.Parameters.AddWithValue("@pass", DBNull.Value);

                cmd.Parameters.AddWithValue("@nombre", nombreCompleto);
                cmd.Parameters.AddWithValue("@rol", rolCodigo);
                cmd.Parameters.AddWithValue("@id", id);

                cmd.ExecuteNonQuery();
            }
        }

        // 4. Método para eliminar usuario
        public static void EliminarUsuario(int id)
        {
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("DELETE FROM Usuario WHERE USU_ID = @id", con);
                cmd.Parameters.AddWithValue("@id", id);
                cmd.ExecuteNonQuery();
            }
        }

        public static object ValidarLogin(string usuario, string password)
        {
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                con.Open();
                string query = @"SELECT ROL_Codigo FROM Usuario 
                                WHERE USU_NombreUsuario = @user 
                                AND USU_Contrasenia = @pass";
        
                SqlCommand cmd = new SqlCommand(query, con);
                cmd.Parameters.AddWithValue("@user", usuario);
                cmd.Parameters.AddWithValue("@pass", password);
        
                object result = cmd.ExecuteScalar();
                return result; // Devuelve null si no encuentra coincidencia
            }
        }

        // metodos del tp3
        // Método para obtener usuarios ordenados por UserName
        public static DataTable ObtenerUsuariosOrdenadosPorUsuario()
        {
            string query = @"
        SELECT 
            U.USU_ID AS [ID],
            R.ROL_Descripcion AS [Rol],
            U.USU_ApellidoNombre AS [Apellido y Nombre],
            U.USU_NombreUsuario AS [Usuario],
            U.ROL_Codigo AS [Código de Rol]
        FROM Usuario U
        LEFT JOIN Rol R ON R.ROL_Codigo = U.ROL_Codigo
        ORDER BY U.USU_NombreUsuario ASC";

            return DatabaseHelper.ExecuteQuery(query);
        }

        // Método para obtener usuarios ordenados por ApellidoNombre
        public static DataTable ObtenerUsuariosOrdenadosPorApellido()
        {
            string query = @"
        SELECT 
            U.USU_ID AS [ID],
            R.ROL_Descripcion AS [Rol],
            U.USU_ApellidoNombre AS [Apellido y Nombre],
            U.USU_NombreUsuario AS [Usuario],
            U.ROL_Codigo AS [Código de Rol]
        FROM Usuario U
        LEFT JOIN Rol R ON R.ROL_Codigo = U.ROL_Codigo
        ORDER BY U.USU_ApellidoNombre ASC";

            return DatabaseHelper.ExecuteQuery(query);
        }
    }
}
