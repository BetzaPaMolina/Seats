using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Seats
{
    public partial class Frm_Inicio : Form
    {
        public string NombreUsuario { get; set; }

        public Frm_Inicio()
        {
            InitializeComponent();
        }

        private void Frm_Inicio_Load(object sender, EventArgs e)
        {
            MostrarNombreUsuario();
        }

        private void MostrarNombreUsuario()
        {
            // Mostrar el nombre de usuario en un control de tu formulario
            lblnombre.Text = NombreUsuario;
        }
    }
}