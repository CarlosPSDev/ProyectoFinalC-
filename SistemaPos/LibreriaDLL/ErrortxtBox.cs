using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LibreriaDLL //Clase para control de errores por si se dejan campos vacíos
{
    public partial class ErrortxtBox : TextBox //Hereda de Textbox
    {
        public ErrortxtBox()
        {
            InitializeComponent();
        }
        public Boolean Validar //cuidado, es boolean no Bool, y es sin ()
        {
            set;
            get;            
        }

        public Boolean ValidarNumeros //Otro método para validar que sean números y no letras
        {
            set;
            get;
        }

        //Método creado por mí para validar el precio
        public Boolean ValidarDecimales //Otro método para validar que sean números y no letras
        {
            set;
            get;
        }
    }
}