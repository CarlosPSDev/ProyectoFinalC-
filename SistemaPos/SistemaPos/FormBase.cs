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
    public partial class FormBase : Form
    {
        public FormBase()
        {
            InitializeComponent();
        }

        private void BtnSalir_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Desea salir?", "Aviso", MessageBoxButtons.YesNo, MessageBoxIcon.Question, //Muestra esa ventana con icono de ? 
                MessageBoxDefaultButton.Button1) == DialogResult.Yes)   // y el botón por defecto para aceptar será el primero que salga
            {
                MessageBox.Show("Gracias por su visita", "Salida", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                this.Close();
            }
        }
        public virtual void Eliminar() //Lo ponemos virtual para que las clases que lo hereden lo puedna modificar.
        {

        }

        public virtual void Nuevo()
        {

        }
        public virtual void Consultar()
        {

        }
        public virtual Boolean Guardar()
        {
            return false;
        }
    }
}
