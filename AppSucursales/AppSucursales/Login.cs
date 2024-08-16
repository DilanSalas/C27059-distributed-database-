using AppSucursales.M.V.C.Controlador;
using AppSucursales.M.V.C.Modelo;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.DataFormats;

namespace AppSucursales
{
    public partial class Login : Form
    {
        private Usuario objUsuario = null;

        //Variable para manejar la conexion
        private Conexion conexion;

        private bool isPasswordVisible = false;
        public Login()
        {
            InitializeComponent();
            conexion = new Conexion();
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            if (isPasswordVisible)
            {
                txtPassword.PasswordChar = '*';  // Ocultar contraseña

            }
            else
            {
                txtPassword.PasswordChar = '\0';  // Mostrar contraseña

            }

            isPasswordVisible = !isPasswordVisible;

        }
        private void IntentoAutenticacion()
        {
            try
            {
                //se crea una instancia de tipo usuario
                objUsuario = new Usuario();

                //Se rellena el objeto con los datos ingresados en el front-end

                objUsuario.password = txtPassword.Text.Trim();

                //Se realiza la validación de credenciales
                objUsuario.cedula = txtCedula.Text.Trim();
                if (conexion.ValidarUsuario(objUsuario.cedula, objUsuario.password) != null)
                {
                    this.Close();// todo bien las credenciales, cerramos el formulario
                }
                else
                {
                    throw new Exception("Usuario o password incorrectos...");
                }

            }
            catch (Exception ex)
            {
                throw ex; //se retorna el error al evento que invoca al método
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                IntentoAutenticacion();

                string cedulaStr = txtCedula.Text.Trim();
                if (int.TryParse(cedulaStr, out int cedula))
                {
                    Conexion conexion = new Conexion();
                    int idRol = conexion.ObtenerIdRolPorCedula(cedula);

                    if (idRol == 2)
                    {
                      
                        Form1 form1 = Application.OpenForms.OfType<Form1>().FirstOrDefault();

                        if (form1 != null)
                        {

                            form1.DesactivarBotones();
                        }
                        else
                        {
                            MessageBox.Show("Form1 no está abierto.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                    }
                    else
                    {
                        MessageBox.Show("Ingreso como rol de administrador", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
                else
                {
                    MessageBox.Show("Por favor, ingrese un valor válido de cédula.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }
    }
}
