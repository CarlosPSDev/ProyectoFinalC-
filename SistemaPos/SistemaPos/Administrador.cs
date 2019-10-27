using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using LibreriaDLL; //la importamos

namespace SistemaPos
{
    public partial class Administrador : FormBase //En vez de ponerle que hereda de Form lo hace de uno que ya tiene un botón salir programado
    {
        public Administrador()
        {
            InitializeComponent();
        }

        private void Administrador_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }

        private void Administrador_Load(object sender, EventArgs e)
        {
            string consulta = "SELECT * FROM usuarios WHERE id_usuario=" + Login.Codigo; //invocamos la variable código con el id_usuario
            DataSet data = Biblioteca.Herramientas(consulta); //le pasamos al data set la cadena de la base de datos 

            lAdmin.Text = data.Tables[0].Rows[0]["username"].ToString(); //mostramos en esa etiqueta los datos del username
            lAdminUser.Text = data.Tables[0].Rows[0]["account"].ToString();
            lAdminCodigo.Text = data.Tables[0].Rows[0]["id_usuario"].ToString();

            string imagen = data.Tables[0].Rows[0]["imagen"].ToString();

            pictureBox1.Image = Image.FromFile(imagen); //No es imageLocation porque no viene de una carpeta sino url de la BD
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            ContenedorPrincipal cont = new ContenedorPrincipal();
            this.Hide();
            cont.Show();
        }
    }
}
