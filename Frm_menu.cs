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
    public partial class Frm_menu : Form
    {
        public Frm_menu()
        {
            InitializeComponent();
        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void btncerrarsesion_Click(object sender, EventArgs e)
        {
            Frm_Login fl = new Frm_Login();
            fl.Show();
            this.Hide();
        }

        private void PanelForms_Paint(object sender, PaintEventArgs e)
        {

        }

        private void btninicio_Click(object sender, EventArgs e)
        {
            //Llamamos el metodo y enviamos el form
            AbrirFormulario<Frm_Inicio>();
        }

        private void btnreservar_Click(object sender, EventArgs e)
        {
            //Llamamos el metodo y enviamos el form
            AbrirFormulario<Frm_reservar>();
        }

        private void btnverreservas_Click(object sender, EventArgs e)
        {
            //Llamamos el metodo y enviamos el form
            AbrirFormulario<Frm_VerReservas>();
        }

        //Metodo generico para abrir formularios dentro del panel, donde el form sea de tipo form y tenga un constructor vacio
        private void AbrirFormulario<MiForm>() where MiForm : Form, new()
        {
            //Declaramos un form
            Form formulario;
            //Se busca si el form existe en una coleccion
            formulario = PanelForms.Controls.OfType<MiForm>().FirstOrDefault();
            //Si el form no existe
            if (formulario == null)
            {
                //Nueva instancia
                formulario = new MiForm();
                //No es de nivel superior
                formulario.TopLevel = false;
                //Agregamos el form a la coleccion de paneles
                PanelForms.Controls.Add(formulario);
                //Especificamos la propiedad tag (almacena datos personalizados que no están directamente relacionados con la funcionalidad principal del control)
                PanelForms.Tag = formulario;
                //Lo mostramos
                formulario.Show();
            }
            //Si el form existe
            else
            {
                formulario.BringToFront();
            }

        }

        private void Frm_menu_Load(object sender, EventArgs e)
        {
            //Llamamos el metodo y enviamos el form
            AbrirFormulario<Frm_Inicio>();

        }

        private void PanelForms_Paint_1(object sender, PaintEventArgs e)
        {

        }

        public void MostrarFormulario(Form formulario)
        {
            PanelForms.Controls.Clear();
            formulario.TopLevel = false;
            formulario.FormBorderStyle = FormBorderStyle.None;
            formulario.Dock = DockStyle.Fill;
            PanelForms.Controls.Add(formulario);
            formulario.Show();
        }

    }
}
