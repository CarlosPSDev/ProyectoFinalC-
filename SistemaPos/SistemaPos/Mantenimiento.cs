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
    public partial class Mantenimiento : FormBase
    {
        public Mantenimiento()
        {
            InitializeComponent();
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            Consultar(); //Llamamos al método consultar del FormBase
        }

        private void Button2_Click(object sender, EventArgs e)
        {
            Guardar();
        }

        private void Button3_Click(object sender, EventArgs e)
        {
            Nuevo();
        }

        private void Button4_Click(object sender, EventArgs e)
        {
            Eliminar();
        }
    }
}
