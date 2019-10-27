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
    public partial class MantenimientoClientes : Mantenimiento //Hereda de mantenimiento que a su vez hereda de FormBase
    {
        public MantenimientoClientes()
        {
            InitializeComponent();
        }

        public override Boolean Guardar() //Es override porque sobreescribimos el método de la clase padre que era virtual
        {
           if (Biblioteca.ValidarFormulario(this, errorProvider1) == false) //Comprueba que no estén vacíos los campos
            { //Si no se ha producido error en la validación del formulario entonces guarda los campos
                try
                {
                    string insertar = string.Format("EXEC ActualizarClientes '{0}', '{1}', '{2}'", //la palabra EXEC ejecuta el procedure guardado en la BD
                        textIdC.Text.Trim(), textNombreC.Text.Trim(), textApellidoC.Text.Trim()); //invoca el proc ActualizarP y le pasa esos 3 parámetros
                    Biblioteca.Herramientas(insertar); //invocamos el método de la librería que hicimos y le pasamos esta query

                    MessageBox.Show("Cliente guardado correctamente");
                    return true;
                }
                catch (Exception error)
                {
                    MessageBox.Show("Ha ocurrido un error " + error);                    
                    return false;
                }
            }
            else //Si hay campos vacíos retornar false y mostrar el error "los campos no pueden estar vacios" de la clase Biblioteca
            {
                return false;
            }
        }

        public override void Eliminar()
        {
            try
            {
                string eliminar = string.Format("EXEC eliminarClientes '{0}'", textIdC.Text.Trim()); //Invoca el procedimiento Eliminar
                Biblioteca.Herramientas(eliminar);

                MessageBox.Show("Cliente eliminado correctamente");
            }
            catch (Exception error)
            {
                MessageBox.Show("Ha ocurrido un error " + error);
            }
        }

        private void TextIdC_TextChanged(object sender, EventArgs e)
        {
            errorProvider1.Clear(); //Limpiamos que salga el error con el simbolito rojo al lado del txtBox que es creado por nosotros con el errorProvider
        }
    }
}
