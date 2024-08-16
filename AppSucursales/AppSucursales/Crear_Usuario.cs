using AppSucursales.M.V.C.Controlador;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AppSucursales
{
    public partial class Crear_Usuario : Form
    {
        private Conexion conexion;
        public Crear_Usuario()
        {
            InitializeComponent();
            conexion = new Conexion();
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            // Obtener los datos del formulario o de donde sea necesario
            int cedula = int.Parse(txtCedula.Text); // Asegúrate de manejar adecuadamente la conversión
            string password = txtContraseña.Text; // Obtener el password desde el formulario
            string valorSeleccionado = cbRol.SelectedItem.ToString();
            int idRol = int.Parse(valorSeleccionado);

            try
            {
                // Llamar al método InsertarUsuario de la conexión
                conexion.InsertarUsuario(cedula, password, idRol);

                // Mostrar mensaje de éxito
                MessageBox.Show("Usuario insertado correctamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                // Mostrar mensaje de error en caso de excepción
                MessageBox.Show("Error al insertar usuario: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            limpiar();
        }

        private void txtProducto_TextChanged(object sender, EventArgs e)
        {

        }
        public void limpiar()
        {
            txtCedula.Text = " ";
            txtContraseña.Text = " ";
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Dispose();
        }
    }
}
