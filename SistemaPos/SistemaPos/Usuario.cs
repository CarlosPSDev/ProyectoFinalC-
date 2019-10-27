using LibreriaDLL;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SistemaPos
{
    public partial class Usuario : FormBase
    {
        public Usuario()
        {
            InitializeComponent();
        }

        private void Usuario_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }

        private void Usuario_Load(object sender, EventArgs e)
        {
            string consulta = "SELECT * FROM usuarios WHERE id_usuario=" + Login.Codigo; //invocamos la variable código con el id_usuario
            DataSet data = Biblioteca.Herramientas(consulta); //le pasamos al data set la cadena de la base de datos 

            lNombre.Text = data.Tables[0].Rows[0]["username"].ToString(); //mostramos en esa etiqueta los datos del username
            lUsuario.Text = data.Tables[0].Rows[0]["account"].ToString();
            lCodigo.Text = data.Tables[0].Rows[0]["id_usuario"].ToString();

            string imagen = data.Tables[0].Rows[0]["imagen"].ToString();

            pictureBox1.Image = Image.FromFile(imagen);
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            ContenedorPrincipal cont = new ContenedorPrincipal(); //Si pinchan principal les lleva al contenedor
            this.Hide();
            cont.Show();
        }
    }
}
