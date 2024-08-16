using AppSucursales.M.V.C.Controlador;
using AppSucursales.M.V.C.Modelo;
using Oracle.ManagedDataAccess.Client;
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
    public partial class Crear_Cliente : Form
    {
        private OracleConnection conexionLocal;
        private Conexion conexion;


        public Crear_Cliente()
        {
            InitializeComponent();
            conexion = new Conexion();
            string connectionStringLocal = "User Id=usuario_Alajuela;Password=ucr2024;Data Source=localhost";
            conexionLocal = new OracleConnection(connectionStringLocal);

        }

        private void label2_Click(object sender, EventArgs e)
        {
            // No se necesita implementación para este evento
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            // No se necesita implementación para este evento
        }

        private void button1_Click(object sender, EventArgs e)
        {
            // Obtener los valores de los textbox
            string cedula = txtCedula.Text.Trim();
            string nombre = txtNombre.Text.Trim();
            string direccion = txtDireccion.Text.Trim();
            string telefono = txtTelefono.Text.Trim();
            string correo = txtCorreo.Text.Trim();

            // Verificar si alguno de los campos está vacío
            if (string.IsNullOrEmpty(cedula) ||
                string.IsNullOrEmpty(nombre) ||
                string.IsNullOrEmpty(direccion) ||
                string.IsNullOrEmpty(telefono) ||
                string.IsNullOrEmpty(correo))
            {
                // Mostrar mensaje de advertencia si alguno de los campos está vacío
                MessageBox.Show("Por favor, complete todos los campos antes de continuar.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                try
                {
                    // Llamar al método en la clase Conexion para insertar el cliente y actualizar la base de datos central
                    conexion.InsertarClienteYActualizarCentral(cedula, nombre, direccion, telefono, correo);

                    // Mostrar mensaje de éxito
                    MessageBox.Show("Datos insertados correctamente en la base de datos local y sincronizados con la base de datos central.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    limpiar();
                }
                catch (Exception ex)
                {
                    // Mostrar mensaje de error en caso de fallo en la inserción o sincronización
                    MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    limpiar();
                }
            }
        }

        private void limpiar()
        {
            txtCedula.Text = " ";
            txtNombre.Text = " ";
            txtDireccion.Text = " ";
            txtTelefono.Text = " ";
            txtCorreo.Text = " ";
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Dispose();
        }
    }
}
