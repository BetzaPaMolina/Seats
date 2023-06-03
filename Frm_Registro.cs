using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Seats
{
    public partial class Frm_Registro : Form
    {
        public Frm_Registro()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void Frm_Registro_Load(object sender, EventArgs e)
        {

        }

        private void btnregresar_Click(object sender, EventArgs e)
        {
            Frm_Login fl = new Frm_Login();
            fl.Show();
            this.Hide();
        }

        private void tbningresar_Click(object sender, EventArgs e)
        {
            string nombre = txtnombre.Text;
            string apellidos = txtapellidos.Text;
            string correo = txtcorreo.Text;
            string password = txtcontra.Text;
            string tarjeta = txttarjeta.Text;

            // Validar que los campos no estén vacíos
            if (string.IsNullOrWhiteSpace(nombre) ||
                string.IsNullOrWhiteSpace(apellidos) ||
                string.IsNullOrWhiteSpace(correo) ||
                string.IsNullOrWhiteSpace(password) ||
                string.IsNullOrWhiteSpace(tarjeta))
            {
                MessageBox.Show("Todos los campos son obligatorios");
                return;
            }

            // Realiza la conexión a la base de datos
            Conexion conexion = new Conexion();
            SqlConnection sqlConnection = conexion.Conectar();

            // Crea una consulta SQL para insertar los datos en la tabla correspondiente
            string query = "INSERT INTO tbCliente (Nombre, Apellidos, Correo, Contra, Tarjeta) VALUES (@nombre, @apellidos, @correo, @password, @tarjeta)";

            // Crea un objeto SqlCommand y asigna los parámetros
            SqlCommand command = new SqlCommand(query, sqlConnection);
            command.Parameters.AddWithValue("@nombre", nombre);
            command.Parameters.AddWithValue("@apellidos", apellidos);
            command.Parameters.AddWithValue("@correo", correo);
            command.Parameters.AddWithValue("@password", password);
            command.Parameters.AddWithValue("@tarjeta", tarjeta);

            // Ejecuta la consulta
            int rowsAffected = command.ExecuteNonQuery();
            object result = command.ExecuteScalar(); 

            if (rowsAffected > 0)
            {
                MessageBox.Show("Registro exitoso, por favor, ingresa con tus credenciales.");
                int idCliente = Convert.ToInt32(result);
                Frm_Login frm_Login = new Frm_Login();
                frm_Login.Show();
                this.Hide(); // Ocultar el formulario de inicio de sesión
            }
            else
            {
                MessageBox.Show("Error al registrar");
            }

            // Cerrar manualmente la conexión después de utilizarla
            conexion.CerrarConexion();

        }

        private void tbningresar_Click_1(object sender, EventArgs e)
        {

        }
    }
}
