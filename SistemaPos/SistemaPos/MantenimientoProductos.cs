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
    public partial class MantenimientoProductos : Mantenimiento
    {
        public MantenimientoProductos()
        {
            InitializeComponent();
        }

        public override bool Guardar() //Es override porque sobreescribimos el método de la clase padre que era virtual
        {
            if (Biblioteca.ValidarFormulario(this, errorProvider1) == false) //Comprueba que no estén vacíos los campos
            {
                try
                {
                    string insertar = string.Format("EXEC ActualizarProductos '{0}', '{1}', '{2}'", //la palabra EXEC ejecuta el procedure guardado en la BD
                        textIdP.Text.Trim(), textDescP.Text.Trim(), textPrecioP.Text.Trim()); //invoca el proc ActualizarP y le pasa esos 3 parámetros
                    Biblioteca.Herramientas(insertar); //invocamos el método de la librería que hicimos y le pasamos esta query

                    MessageBox.Show("Producto guardado correctamente");
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
                string eliminar = string.Format("EXEC eliminarProductos '{0}'", textIdP.Text.Trim()); //Invoca el procedimiento Eliminar
                Biblioteca.Herramientas(eliminar);

                MessageBox.Show("Producto eliminado correctamente");
            } catch (Exception error)
            {
                MessageBox.Show("Ha ocurrido un error " + error);                
            }
        }

        private void TextIdP_TextChanged(object sender, EventArgs e)
        {
            errorProvider1.Clear(); //Limpiamos que salga el error con el simbolito rojo al lado del txtBox que es creado por nosotros con el errorProvider
        }

        private void TextPrecioP_TextChanged(object sender, EventArgs e)
        {
            errorProvider1.Clear(); //Limpiamos que salga el error con el simbolito rojo al lado del txtBox que es creado por nosotros con el errorProvider
        }
    }
}
