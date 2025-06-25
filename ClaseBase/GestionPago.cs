using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.Data;
using System.Data.SqlClient;

namespace ClaseBase
{
    public static class GestionPago
    {
        // a. Obtener clientes para ComboBox
        public static DataTable ObtenerClientes()
        {
            string query = "SELECT CLI_DNI, CLI_Apellido + ', ' + CLI_Nombre AS NombreCompleto FROM Cliente";
            return DatabaseHelper.ExecuteQuery(query);
        }

        // b. Obtener préstamos pendientes de un cliente
        public static DataTable ObtenerPrestamosPendientes(string clienteDni)
        {
            string query = @"
                            SELECT P.PRE_Numero,
                                   CAST(P.PRE_Numero AS VARCHAR) + ' - ' + D.DES_Descripcion AS Descripcion
                            FROM Prestamo P
                            INNER JOIN Destino D ON P.DES_Codigo = D.DES_Codigo
                            WHERE P.CLI_DNI = @dni AND P.PRE_Estado = 'PENDIENTE'";
            SqlParameter param = new SqlParameter("@dni", clienteDni);
            return DatabaseHelper.ExecuteQuery(query, param);
        }

        // c. Obtener cuotas pendientes de un préstamo
        public static DataTable ObtenerCuotasPendientes(int prestamoNumero)
        {
            string query = @"SELECT CUO_Codigo, CUO_Numero, CUO_Importe 
                          FROM Cuota 
                          WHERE PRE_Numero = @prestamo AND CUO_Estado = 'PENDIENTE'";
            SqlParameter param = new SqlParameter("@prestamo", prestamoNumero);
            return DatabaseHelper.ExecuteQuery(query, param);
        }

        //registrar pago (?

        public static void RegistrarPago(int cuotaCodigo, DateTime fechaPago)
        {
            // 1. Obtener datos necesarios de la cuota
            var datosCuota = ObtenerDatosCuota(cuotaCodigo);
        
            // 2. Registrar el pago en la base de datos
            RegistrarPagoEnBaseDatos(cuotaCodigo, fechaPago, datosCuota.Item1);
        
            // 3. Actualizar estado de la cuota a PAGADA
            ActualizarEstadoCuota(cuotaCodigo, "PAGADA");
        
            // 4. Verificar y actualizar estado del préstamo si corresponde
            VerificarEstadoPrestamo(datosCuota.Item2);
        }

        private static Tuple<int, int> ObtenerDatosCuota(int cuotaCodigo)
        {
            string query = @"SELECT CUO_Importe, PRE_Numero 
                     FROM Cuota 
                     WHERE CUO_Codigo = @cuota";

            DataTable dt = DatabaseHelper.ExecuteQuery(query, new SqlParameter("@cuota", cuotaCodigo));

            if (dt.Rows.Count == 0)
                throw new Exception("No se encontró la cuota especificada");

            return Tuple.Create(
                Convert.ToInt32(dt.Rows[0]["CUO_Importe"]),
                Convert.ToInt32(dt.Rows[0]["PRE_Numero"])
            );
        }


        private static void RegistrarPagoEnBaseDatos(int cuotaCodigo, DateTime fechaPago, decimal importe)
        {
            string query = @"INSERT INTO Pago (CUO_Codigo, PAG_Fecha, PAG_Importe)
                           VALUES (@cuota, @fecha, @importe)";

            DatabaseHelper.ExecuteNonQuery(query,
                new SqlParameter("@cuota", cuotaCodigo),
                new SqlParameter("@fecha", fechaPago),
                new SqlParameter("@importe", importe));
        }

        private static void ActualizarEstadoCuota(int cuotaCodigo, string estado)
        {
            string query = @"UPDATE Cuota 
                           SET CUO_Estado = @estado 
                           WHERE CUO_Codigo = @cuota";

            DatabaseHelper.ExecuteNonQuery(query,
                new SqlParameter("@cuota", cuotaCodigo),
                new SqlParameter("@estado", estado));
        }

        public static void VerificarEstadoPrestamo(int prestamoNumero)
        {
            if (!TieneCuotasPendientes(prestamoNumero))
            {
                ActualizarEstadoPrestamo(prestamoNumero, "CANCELADO");
            }
        }

        private static bool TieneCuotasPendientes(int prestamoNumero)
        {
            string query = @"SELECT COUNT(*) 
                           FROM Cuota 
                           WHERE PRE_Numero = @prestamo 
                           AND CUO_Estado = 'PENDIENTE'";

            int count = Convert.ToInt32(DatabaseHelper.ExecuteScalar(query,
                new SqlParameter("@prestamo", prestamoNumero)));

            return count > 0;
        }

        private static void ActualizarEstadoPrestamo(int prestamoNumero, string estado)
        {
            string query = @"UPDATE Prestamo 
                           SET PRE_Estado = @estado 
                           WHERE PRE_Numero = @prestamo";

            DatabaseHelper.ExecuteNonQuery(query,
                new SqlParameter("@prestamo", prestamoNumero),
                new SqlParameter("@estado", estado));
        }

        //listar pagos por clientes
        public static DataTable ObtenerPagosPorCliente(string dniCliente)
        {
            string query = @"
                SELECT 
                    PAG.PAG_Codigo AS Codigo,
                    PAG.PAG_Fecha AS Fecha,
                    C.CLI_Apellido + ', ' + C.CLI_Nombre AS Cliente,
                    P.PRE_Numero AS NumeroPrestamo,
                    CUO.CUO_Numero AS NumeroCuota,
                    PAG.PAG_Importe AS Importe
                FROM Pago PAG
                INNER JOIN Cuota CUO ON PAG.CUO_Codigo = CUO.CUO_Codigo
                INNER JOIN Prestamo P ON CUO.PRE_Numero = P.PRE_Numero
                INNER JOIN Cliente C ON P.CLI_DNI = C.CLI_DNI
                WHERE C.CLI_DNI = @dni
                ORDER BY PAG.PAG_Fecha DESC";

            SqlParameter param = new SqlParameter("@dni", dniCliente);
            return DatabaseHelper.ExecuteQuery(query, param);
        }

    }
    
}
