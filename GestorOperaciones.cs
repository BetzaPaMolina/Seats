using System.Data.SqlClient;

namespace Seats
{
    public class GestorOperaciones
    {
        private SqlConnection conexion;

        public GestorOperaciones(SqlConnection conexion)
        {
            this.conexion = conexion;
        }

        public string ObtenerNombreUsuario(int idCliente)
        {
            string nombreUsuario = string.Empty;

            // Crea una consulta SQL para obtener el nombre del usuario
            string query = "SELECT Nombre FROM tbCliente WHERE idCliente = @idCliente";

            // Crea un objeto SqlCommand y asigna los parámetros
            using (SqlCommand command = new SqlCommand(query, conexion))
            {
                command.Parameters.AddWithValue("@idCliente", idCliente);

                // Ejecuta la consulta y obtiene el nombre del usuario
                using (SqlDataReader reader = command.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        nombreUsuario = reader["Nombre"].ToString();
                    }
                }
            }

            return nombreUsuario;
        }
    }
}