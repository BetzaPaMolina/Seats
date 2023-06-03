using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Seats
{
    public partial class Frm_Login : Form
    {
        private Conexion conexion; //Establecemos la conexion con la base

        public int IdCliente { get; private set; } // Propiedad para obtener el ID del cliente que ha iniciado sesión
        public string NombreCliente { get; private set; } // Propiedad para obtener el nombre del cliente que ha iniciado sesión

        public Frm_Login()
        {
            InitializeComponent();
            conexion = new Conexion(); // Se crea una instancia de la clase 'Conexion' para establecer la conexión con la base de datos
        }

        private void Frm_Login_Load(object sender, EventArgs e)
        {
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
        }

        private void btnregistro_Click(object sender, EventArgs e)
        {
            Frm_Registro fm = new Frm_Registro();
            fm.Show();
            this.Hide();
        }

        private void btningresar_Click(object sender, EventArgs e)
        {
            string email = txtcorreo.Text; 
            string password = txtcontra.Text;

            SqlConnection sqlConnection = conexion.Conectar(); // Se establece la conexión con la base de datos

            // Consulta SQL para validar las credenciales
            string query = "SELECT idCliente FROM tbCliente WHERE Correo = @correo AND Contra = @password";
            SqlCommand command = new SqlCommand(query, sqlConnection);
            command.Parameters.AddWithValue("@correo", email);
            command.Parameters.AddWithValue("@password", password);

            object result = command.ExecuteScalar();  // Se ejecuta la consulta y se obtiene el resultado

            if (result != null) // Credenciales válidas
            {
                int idCliente = Convert.ToInt32(result);  // Se obtiene el ID del cliente

                // Crear una instancia del GestorOperaciones y pasar la conexión
                GestorOperaciones gestorOperaciones = new GestorOperaciones(sqlConnection);

                // Obtener el nombre del usuario utilizando el GestorOperaciones
                string nombreUsuario = gestorOperaciones.ObtenerNombreUsuario(idCliente);

                IdCliente = idCliente; // Asignar el ID del cliente a la propiedad
                NombreCliente = nombreUsuario; // Asignar el nombre del cliente a la propiedad

                Frm_Inicio frmInicio = new Frm_Inicio();  // Se crea una instancia del formulario Frm_Inicio
                frmInicio.NombreUsuario = nombreUsuario; // Establecer el nombre de usuario

                Frm_menu frmMenu = new Frm_menu(); // Se crea una instancia del formulario Frm_Inicio
                frmMenu.MostrarFormulario(frmInicio); // Mostrar el formulario Frm_Inicio en el panel del Frm_Menu

                frmMenu.Show(); //Se crea una instancia del formulario Frm_Menu
                this.Hide(); // Ocultar el formulario de inicio de sesión
            }
            else // Credenciales inválidas
            {
                MessageBox.Show("Credenciales inválidas. Inténtalo de nuevo.");
            }

            // Cerrar manualmente la conexión después de utilizarla
            conexion.CerrarConexion();
        }

        private void btnsalir_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}