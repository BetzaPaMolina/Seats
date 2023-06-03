using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
/*
namespace Seats
{
    public class GestorBD
    {
        private SqlConnection connection;

        public GestorBD(SqlConnection connection)
        {
            this.connection = connection;
        }
        public static bool ValidarCredenciales(string correo, string contra)
        {
            SqlConnection sqlConnection = Conexion.Conectar();
            string query = "SELECT idCliente FROM tbCliente WHERE Correo = @correo AND Contra = @contra";
            SqlCommand command = new SqlCommand(query, conexion);
            command.Parameters.AddWithValue("@correo", correo);
            command.Parameters.AddWithValue("@contra", contra);

            object result = command.ExecuteScalar();

            conexion.Close();

            if (result != null)
            {
                ClienteActual.IdCliente = Convert.ToInt32(result);
                ClienteActual.NombreCliente = ObtenerNombreCliente(ClienteActual.IdCliente);
                return true;
            }
            else
            {
                return false;
            }
        }

        public static string ObtenerNombreCliente(int idCliente)
        {
            SqlConnection sqlConnection = Conexion.Conectar();
            string query = "SELECT Nombre FROM tbCliente WHERE idCliente = @idCliente";
            SqlCommand command = new SqlCommand(query, conexion);
            command.Parameters.AddWithValue("@idCliente", idCliente);

            object result = command.ExecuteScalar();

            conexion.Close();

            if (result != null)
            {
                return result.ToString();
            }
            else
            {
                return string.Empty;
            }
        }

        public static DataTable ObtenerServicios()
        {
            SqlConnection sqlConnection = Conexion.Conectar();
            string query = "SELECT idObjeto, Nombre FROM tbObjeto";
            SqlCommand command = new SqlCommand(query, conexion);

            SqlDataAdapter adapter = new SqlDataAdapter(command);
            DataTable dt = new DataTable();
            adapter.Fill(dt);

            conexion.Close();

            return dt;
        }

        public static DataTable ObtenerEmpresasPorServicio(int idServicio)
        {
            SqlConnection conexion = Conexion.ObtenerConexion();
            string query = "SELECT idEmpresa, Nombre FROM tbEmpresa WHERE idObjeto = @idObjeto";
            SqlCommand command = new SqlCommand(query, conexion);
            command.Parameters.AddWithValue("@idObjeto", idServicio);

            SqlDataAdapter adapter = new SqlDataAdapter(command);
            DataTable dt = new DataTable();
            adapter.Fill(dt);

            conexion.Close();

            return dt;
        }

        public static bool RegistrarReserva(int idServicio, int idEmpresa, DateTime fecha, DateTime hora)
        {
            SqlConnection conexion = Conexion.ObtenerConexion();

            // Verificar si ya existe una reserva para la misma empresa, fecha y hora
            string verificaQuery = "SELECT COUNT(*) FROM tbReserva WHERE idEmpresa = @idEmpresa AND Fecha = @fecha AND Hora = @hora";
            SqlCommand verificaCommand = new SqlCommand(verificaQuery, conexion);
            verificaCommand.Parameters.AddWithValue("@idEmpresa", idEmpresa);
            verificaCommand.Parameters.AddWithValue("@fecha", fecha);
            verificaCommand.Parameters.AddWithValue("@hora", hora);

            int count = Convert.ToInt32(verificaCommand.ExecuteScalar());

            if (count > 0)
            {
                // Ya existe una reserva en la misma empresa, fecha y hora
                conexion.Close();
                return false;
            }

            // Insertar la reserva en la base de datos
            string insertQuery = "INSERT INTO tbReserva (idCliente, idObjeto, idEmpresa, Fecha, Hora, idTipoPago) VALUES (@idCliente, @idObjeto, @idEmpresa, @fecha, @hora, 1)";
            SqlCommand insertCommand = new SqlCommand(insertQuery, conexion);
            insertCommand.Parameters.AddWithValue("@idCliente", ClienteActual.IdCliente);
            insertCommand.Parameters.AddWithValue("@idObjeto", idServicio);
            insertCommand.Parameters.AddWithValue("@idEmpresa", idEmpresa);
            insertCommand.Parameters.AddWithValue("@fecha", fecha);
            insertCommand.Parameters.AddWithValue("@hora", hora);

            insertCommand.ExecuteNonQuery();

            conexion.Close();
            return true;
        }
    }
}*/