using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data; //lo agregamos
using System.Data.SqlClient;//
using System.Windows.Forms; //lo agregamos para validar el formulario

namespace LibreriaDLL
{
    public class Biblioteca
    {
        public static DataSet Herramientas(string cmd) //DataSet es como un contenedor que guarda temporalmente los datos que se recuperan
        {
            SqlConnection conexion = new SqlConnection("Data Source=.;Initial Catalog=SistemaVentas;Integrated Security=True");
            conexion.Open();

            DataSet dll = new DataSet();

            SqlDataAdapter dll1 = new SqlDataAdapter(cmd, conexion); //Adaptador que hace de intermediario para rellenar el dataSet con la conexión a BD.

            dll1.Fill(dll); //le pasamos al adaptar el dataset

            conexion.Close();

            return dll; //retornamos el datset
        }
        public static Boolean ValidarFormulario(Control ObjetoError, ErrorProvider ErrorProvider)//creamos método con esos parámetros
        {
            Boolean siError = false;
            foreach (Control campo in ObjetoError.Controls) //Recorremos todos los campos asociados a ese control del textbox en el objeto error
            {
                if (campo is ErrortxtBox) //mira en cada campo si es un error de txtbox
                {
                    ErrortxtBox objeto = (ErrortxtBox)campo; //si el objeto es de tipo errortxtbox

                    if (objeto.Validar == true) //si Error el objeto tiene activado el validar (lock has puesto en true)))
                    {
                        if (string.IsNullOrEmpty(objeto.Text.Trim()))//string es la cadena que guarda los valores, preguntamos si no es válida
                        {
                            ErrorProvider.SetError(objeto, "Los campos no pueden quedar vacíos");//le pasamos ese mensaje
                            siError = true;
                        }
                    }
                    if (objeto.ValidarNumeros == true) //Si al objeto se le ha activado la propiedad validarNumeros comprobar
                    {
                        int contador = 0, encontrarLetras = 0;
                        foreach (char letra in objeto.Text.Trim()) //recorremos todo el texto del objeto
                        {
                            if (char.IsLetter(objeto.Text.Trim(), contador)) //comprueba una por una si son todo letras
                            {
                                encontrarLetras++; //Marcas como que ha encontrado letras, podría haber sido un booleano
                            }
                            contador++;
                        }
                        if (encontrarLetras != 0)
                        {
                            siError = true; //Si hay alguna letra en el campo numérico entonces hay error
                            ErrorProvider.SetError(objeto, "Sólo se aceptan números");
                        }
                    }
                    //Método creado por mí para validar decimales
                    if (objeto.ValidarDecimales)
                    {
                        try
                        {
                            float dcimal = Convert.ToSingle(objeto.Text.Trim());
                        } catch (FormatException error)
                        {
                            siError = true;
                            ErrorProvider.SetError(objeto, "Ha de se run valor numérico o decimal");
                        }
                        
                    }
                }
            }
            return siError;
        }
    }
}
