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
    public partial class Crear_Facturas : Form
    {
        private OracleConnection conexionLocal;
        private Conexion conexion;
        public Crear_Facturas()
        {
            InitializeComponent();
            txtCantidad.TextChanged += txtCantidad_TextChanged;
            conexion = new Conexion();
            string connectionStringLocal = "User Id=usuario_Alajuela;Password=ucr2024;Data Source=localhost";
            conexionLocal = new OracleConnection(connectionStringLocal);
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            Dispose();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string cedulaTexto = txtCedula.Text.Trim();
            string productoTexto = txtProducto.Text.Trim();
            string cantidadTexto = txtCantidad.Text.Trim();
            string totalTexto = txtTotal.Text.Trim();

            if (string.IsNullOrEmpty(cedulaTexto) ||
                string.IsNullOrEmpty(productoTexto) ||
                string.IsNullOrEmpty(cantidadTexto) ||
                string.IsNullOrEmpty(totalTexto))
            {
                // Mostrar mensaje de advertencia si alguno de los campos está vacío
                MessageBox.Show("Por favor, complete todos los campos antes de continuar.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                // Obtener los valores de los textbox
                int cedula = int.Parse(txtCedula.Text);
                int producto = int.Parse(txtProducto.Text);
                int cantidad = int.Parse(txtCantidad.Text);
                decimal total = Decimal.Parse(txtTotal.Text);
                DateTime fecha = DateTime.Now;

                if (conexion.GetCantidadDeProductos(producto) < cantidad || cantidad<0)
                {
                    MessageBox.Show("Escriba una cantidad correcta que haya en el inventario.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                else
                { 
                    try
                    {
                        // Llamar al método en la clase Conexion para insertar la factura y actualizar la base de datos central
                        conexion.InsertarFacturaYActualizarCentral(cedula, producto, cantidad, fecha, total);

                        // Mostrar mensaje de éxito
                        MessageBox.Show("Factura insertada correctamente en la base de datos local y sincronizada con la base de datos central.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
        }
        private void limpiar()
        {
            txtCedula.Text = "";
            txtProducto.Text = "";
            txtCantidad.Text = "";
            txtTotal.Text = "";
        }

        private void txtCantidad_TextChanged(object sender, EventArgs e)
        {
            if (int.TryParse(txtCantidad.Text, out int cantidad) && int.TryParse(txtProducto.Text, out int idProducto))
            {
                try
                {
                    // Obtener el precio del producto desde la base de datos local
                    decimal precioProducto = conexion.ObtenerPrecioProducto(idProducto, conexionLocal);

                    // Calcular el total
                    decimal total = precioProducto * cantidad;

                    // Mostrar el total en el cuadro de texto txtTotal
                    txtTotal.Text = total.ToString("0.00"); // Formatear el total como string con dos decimales
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error al calcular el total: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                txtTotal.Text = ""; // Limpiar el campo txtTotal si la cantidad no es válida
            }



        }

        private void txtTotal_TextChanged(object sender, EventArgs e)
        {
           
        }
    
    }
}
