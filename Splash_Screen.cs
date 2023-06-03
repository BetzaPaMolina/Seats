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
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            //Designamos un color
            this.BackColor = Color.LightSlateGray;
            //Metodo de transparencia
            this.TransparencyKey = Color.LightSlateGray;
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        //Barrita loading
        private void timer1_Tick(object sender, EventArgs e)
        {
            //Se suma 6 de ancho al panel
            panel1.Width += 6;
            //Al llegar al límite establecido por este parámetro
            if (panel1.Width >= 320)
            {
                //El timer se detiene
                timer1.Stop();
                //Abrir otro form 
                Frm_Login f2 = new Frm_Login();
                f2.Show();
                this.Hide();
            }

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }
    }
}
