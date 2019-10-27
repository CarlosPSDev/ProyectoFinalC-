using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using LibreriaDLL; //importamos la libreria a utilizar

namespace SistemaPos
{
    public partial class Login : FormBase
    {
        public Login()
        {
            InitializeComponent();
        }
        public static string Codigo = ""; //creamos esta variable estática para poder serinvocada desde otra clase

        private void Button1_Click(object sender, EventArgs e)
        {
            try
            { //Generamos la query
                string validar = string.Format("Select * FROM Usuarios where account= '{0}' AND password= '{1}'", textUsuario.Text.Trim(), textPwd.Text.Trim());
                DataSet conectar = Biblioteca.Herramientas(validar); //Le pasamos al dataSet la query

                Codigo = conectar.Tables[0].Rows[0]["id_usuario"].ToString().Trim();
                string cuenta = conectar.Tables[0].Rows[0]["account"].ToString().Trim(); //Obtenemos los datos de la cuenta, como una matriz
                string passwd = conectar.Tables[0].Rows[0]["password"].ToString().Trim();

                if (cuenta == textUsuario.Text.Trim() & passwd == textPwd.Text.Trim())
                {
                    if (Convert.ToBoolean(conectar.Tables[0].Rows[0]["validar_admin"].ToString().Trim())) //Convertimos la cadena a booleano
                    {
                        Administrador admin = new Administrador();
                        this.Hide();
                        admin.Show(); //Si tiene permisos se le muestra la ventana de administrador
                    }
                    else
                    { //Si no, le llevamos a la ventana de usuario
                        Usuario user = new Usuario();
                        this.Hide();
                        user.Show();
                    }
                    //MessageBox.Show("Inicio de sesión correcto");
                }                
            } catch (Exception error)
            {                
                MessageBox.Show("Usuario o contraseña inválidos " + error.Message); //Si la pwd está mal sañtará la excepción
            }

            
        }

        private void TextBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void Login_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit(); //Hace que al cerrar el formulario se cierre la aplicación
        }
    }
}
