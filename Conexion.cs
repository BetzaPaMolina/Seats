using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace Seats
{
    public class Conexion
    {
        private SqlConnection conexion;

        // Método para conectarnos
        public SqlConnection Conectar()
        {
            // Escribimos nuestra cadena de conexión: nombre de servidor (nuestro equipo), nombre de la BD y seguridad integrada
            conexion = new SqlConnection("Data Source=IBETH\\SQLEXPRESS;Initial Catalog=bdReserva;Integrated Security=true");
            // Abrimos la cadena de conexión
            conexion.Open();
            return conexion;
        }

        // Método para cerrar la conexión
        public void CerrarConexion()
        {
            //Si la variable conexion no es nula y el estatus de la conexion no está cerrado (para cerrarlo)
            if (conexion != null && conexion.State != System.Data.ConnectionState.Closed)
            {
                //Se cierra la conexión
                conexion.Close();
            }
        }
    }
}