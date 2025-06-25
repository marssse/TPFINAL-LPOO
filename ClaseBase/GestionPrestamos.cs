using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.Data;
using System.Data.SqlClient;

namespace ClaseBase
{
    public class GestionPrestamos
    {
        private static string connectionString = ClaseBase.Properties.Settings.Default.prestamosConnectionString;

        // 1. Obtener lista de clientes para ComboBox
        public static DataTable ObtenerClientes()
        {
            DataTable dt = new DataTable();
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                con.Open();
                string query = "SELECT CLI_DNI, CLI_Apellido + ', ' + CLI_Nombre AS NombreCompleto FROM Cliente";
                SqlDataAdapter da = new SqlDataAdapter(query, con);
                da.Fill(dt);
            }
            return dt;
        }

        // 2. Obtener destinos de préstamo
        public static DataTable ObtenerDestinos()
        {
            DataTable dt = new DataTable();
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                con.Open();
                SqlDataAdapter da = new SqlDataAdapter("SELECT DES_Codigo, DES_Descripcion FROM Destino", con);
                da.Fill(dt);
            }
            return dt;
        }

        // 3. Obtener períodos de pago
        public static DataTable ObtenerPeriodos()
        {
            DataTable dt = new DataTable();
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                con.Open();
                SqlDataAdapter da = new SqlDataAdapter("SELECT PER_Codigo, PER_Descripcion FROM Periodo", con);
                da.Fill(dt);
            }
            return dt;
        }

        // Método para registrar préstamo y cuotas
        public static bool RegistrarPrestamoConInteres(string clienteDni, int destinoCodigo, int periodoCodigo,
                                                     decimal importe, string tasaInteresTexto, int cantidadCuotas)
        {
            try
            {
                decimal tasaInteres = ConvertirTasaInteres(tasaInteresTexto);
        
                using (SqlConnection con = new SqlConnection(connectionString))
                {
                    con.Open();

                    decimal importeTotal = importe * (1 + tasaInteres/100);

                    string queryPrestamo = @"INSERT INTO Prestamo 
                                           (CLI_DNI, DES_Codigo, PER_Codigo, PRE_Fecha, 
                                            PRE_Importe, PRE_TasaInteres, PRE_CantidadCuotas, PRE_Estado)
                                           VALUES 
                                           (@dni, @destino, @periodo, GETDATE(), 
                                            @importe, @tasa, @cuotas, 'PENDIENTE');
                                           SELECT SCOPE_IDENTITY();";

                    SqlCommand cmd = new SqlCommand(queryPrestamo, con);
            
                    // ¡ESTOS SON LOS PARÁMETROS QUE FALTABAN!
                    cmd.Parameters.AddWithValue("@dni", clienteDni);
                    cmd.Parameters.AddWithValue("@destino", destinoCodigo);
                    cmd.Parameters.AddWithValue("@periodo", periodoCodigo);
                    cmd.Parameters.AddWithValue("@importe", importe);
                    cmd.Parameters.AddWithValue("@tasa", (float)tasaInteres);
                    cmd.Parameters.AddWithValue("@cuotas", cantidadCuotas);

                    int prestamoId = Convert.ToInt32(cmd.ExecuteScalar());

                    // Resto del código para insertar cuotas...
                    decimal importeCuota = importeTotal / cantidadCuotas;
                    string intervalo = ObtenerIntervaloPeriodo(periodoCodigo, con);

                    for (int i = 1; i <= cantidadCuotas; i++)
                    {
                        string queryCuota = @"INSERT INTO Cuota 
                                            (PRE_Numero, CUO_Numero, CUO_Vencimiento, 
                                             CUO_Importe, CUO_Estado)
                                            VALUES 
                                            (@prestamoId, @numero, 
                                             DATEADD(" + intervalo + ", @i, GETDATE()), @importe, 'PENDIENTE')";

                        SqlCommand cmdCuota = new SqlCommand(queryCuota, con);
                        cmdCuota.Parameters.AddWithValue("@prestamoId", prestamoId);
                        cmdCuota.Parameters.AddWithValue("@numero", i);
                        cmdCuota.Parameters.AddWithValue("@i", i);
                        cmdCuota.Parameters.AddWithValue("@importe", importeCuota);
                        cmdCuota.ExecuteNonQuery();
                    }
                    return true;
                }
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        private static decimal ConvertirTasaInteres(string tasaTexto)
        {
            // Quitar el % si existe y convertir a decimal
            tasaTexto = tasaTexto.Replace("%", "").Trim();
            return decimal.Parse(tasaTexto);
        }

        private static string ObtenerIntervaloPeriodo(int periodoCodigo, SqlConnection con)
        {
            string query = "SELECT PER_Descripcion FROM Periodo WHERE PER_Codigo = @codigo";
            SqlCommand cmd = new SqlCommand(query, con);
            cmd.Parameters.AddWithValue("@codigo", periodoCodigo);
            string descripcion = cmd.ExecuteScalar().ToString();

            switch (descripcion.ToUpper())
            {
                case "SEMANAL": return "WEEK";
                case "MENSUAL": return "MONTH";
                case "ANUAL": return "YEAR";
                default: return "MONTH"; // Por defecto mensual
            }
        }

        // 5. Obtener listado de préstamos
        // Método para obtener préstamos con todos los campos requeridos
        public static DataTable ObtenerPrestamos(int? destinoCodigo = null)
        {
            DataTable dt = new DataTable();
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                con.Open();
                string query = @"SELECT 
                                p.PRE_Numero AS [N° Préstamo],
                                c.CLI_Apellido + ', ' + c.CLI_Nombre AS Cliente,
                                d.DES_Descripcion AS Destino,
                                p.PRE_Fecha AS Fecha,
                                p.PRE_Importe AS Importe,
                                per.PER_Descripcion AS Período,
                                p.PRE_TasaInteres AS [Tasa de Interés],
                                p.PRE_CantidadCuotas AS [Cantidad de Cuotas],
                                p.PRE_Estado AS Estado
                            FROM Prestamo p
                            JOIN Cliente c ON p.CLI_DNI = c.CLI_DNI
                            JOIN Destino d ON p.DES_Codigo = d.DES_Codigo
                            JOIN Periodo per ON p.PER_Codigo = per.PER_Codigo
                            WHERE (@DestinoCodigo IS NULL OR p.DES_Codigo = @DestinoCodigo)
                            ORDER BY p.PRE_Fecha DESC";

                SqlCommand cmd = new SqlCommand(query, con);
                cmd.Parameters.AddWithValue("@DestinoCodigo", destinoCodigo ?? (object)DBNull.Value);

                SqlDataAdapter da = new SqlDataAdapter(cmd);
                da.Fill(dt);
            }
            return dt;
        }

        public static DataTable ObtenerDestinosEnPrestamo()
        {
            DataTable dt = new DataTable();
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                con.Open();
                string query = "SELECT DES_Codigo, DES_Descripcion FROM Destino ORDER BY DES_Descripcion";
                SqlDataAdapter da = new SqlDataAdapter(query, con);
                da.Fill(dt);

                // Agregar fila para "Todos los destinos" de manera explícita
                DataRow row = dt.NewRow();
                row["DES_Codigo"] = DBNull.Value;
                row["DES_Descripcion"] = "Todos los destinos";
                dt.Rows.InsertAt(row, 0);

                // Asegurar que la columna DES_Codigo es de tipo int
                dt.Columns["DES_Codigo"].DataType = typeof(int);
            }
            return dt;
        }

        public static DataTable ObtenerPrestamosPorRangoFechas(DateTime fechaDesde, DateTime fechaHasta)
        {
            DataTable dt = new DataTable();
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                con.Open();
                string query = @"SELECT 
                                p.PRE_Numero AS [N° Préstamo],
                                c.CLI_Apellido + ', ' + c.CLI_Nombre AS Cliente,
                                d.DES_Descripcion AS Destino,
                                p.PRE_Fecha AS Fecha,
                                p.PRE_Importe AS Importe,
                                per.PER_Descripcion AS Período,
                                p.PRE_TasaInteres AS [Tasa de Interés],
                                p.PRE_CantidadCuotas AS [Cantidad de Cuotas],
                                p.PRE_Estado AS Estado
                            FROM Prestamo p
                            JOIN Cliente c ON p.CLI_DNI = c.CLI_DNI
                            JOIN Destino d ON p.DES_Codigo = d.DES_Codigo
                            JOIN Periodo per ON p.PER_Codigo = per.PER_Codigo
                            WHERE p.PRE_Fecha BETWEEN @FechaDesde AND @FechaHasta
                            ORDER BY p.PRE_Fecha DESC";

                SqlCommand cmd = new SqlCommand(query, con);
                cmd.Parameters.AddWithValue("@FechaDesde", fechaDesde.Date);
                cmd.Parameters.AddWithValue("@FechaHasta", fechaHasta.Date.AddDays(1).AddSeconds(-1)); // Para incluir todo el día

                SqlDataAdapter da = new SqlDataAdapter(cmd);
                da.Fill(dt);
            }
            return dt;
        }
    }
}
