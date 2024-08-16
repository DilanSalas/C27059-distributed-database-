using AppSucursales.M.V.C.Controlador;
using AppSucursales.M.V.C.Modelo;
using System;
using System.Windows.Forms;

namespace AppSucursales
{
    public partial class Form1 : Form
    {
        private Conexion conexion;

        public Form1(string resultadoConexionCentral, string resultadoConexionAlajuela)
        {
            InitializeComponent();
            conexion = new Conexion();
            MostrarEstadoConexiones(resultadoConexionCentral, resultadoConexionAlajuela);

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            MostrarLogin();
        }
        private void MostrarLogin()
        {
            Login formulario = new Login();
            //se muestra de forma exclusiva
            formulario.ShowDialog();

            //Se libera la memoria una vez finalizada la autenticación
            formulario.Dispose();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void AbrirConexiones()
        {
            conexion.AbrirConexionCentral();
            conexion.AbrirConexionAlajuela();
        }

        private void CerrarConexiones()
        {
            conexion.CerrarConexionCentral();
            conexion.CerrarConexionAlajuela();
        }

        private void MostrarEstadoConexiones(string resultadoConexionCentral, string resultadoConexionAlajuela)
        {
            MessageBox.Show($"Estado de las conexiones:\n\n{resultadoConexionCentral}\n{resultadoConexionAlajuela}", "Estado de Conexiones", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                CerrarConexiones();
            }
            base.Dispose(disposing);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            AgregarClientes();
        }

        private void AgregarClientes()
        {
            Crear_Cliente formulario = new Crear_Cliente();
            formulario.ShowDialog();
            formulario.Dispose();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            AgregarFacturas();
        }
        private void AgregarFacturas()
        {
            Crear_Facturas formulario = new Crear_Facturas();
            formulario.ShowDialog();
            formulario.Dispose();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            frmProductos frmProductos = new frmProductos();
            frmProductos.ShowDialog();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Ver_Clientes verClientes = new Ver_Clientes();
            verClientes.ShowDialog();
            verClientes.Dispose();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

            try
            {
                conexion.SincronizarClientes();
                MessageBox.Show("Se actualizaron correctamente los clientes desde la base de datos central", "Actualizar", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al sincornizar la base de datos central", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }


        }

        private void button5_Click(object sender, EventArgs e)
        {
            Ver_Facturas verFacturas = new Ver_Facturas();
            verFacturas.ShowDialog();
            verFacturas.Dispose();
        }


        private void button6_Click(object sender, EventArgs e)
        {
            Ver_Ventas formulario = new Ver_Ventas();
            formulario.ShowDialog();
            formulario.Dispose();
        }
        public void DesactivarBotones()
        {
            button5.Enabled = false;
            button5.BackColor = SystemColors.ControlLight;
            button5.ForeColor = SystemColors.ControlDarkDark;
            button6.Enabled = false;
            button6.BackColor = SystemColors.ControlLight;
            button6.ForeColor = SystemColors.ControlDarkDark;
            button7.Enabled = false;
            button7.BackColor = SystemColors.ControlLight;
            button7.ForeColor = SystemColors.ControlDarkDark;
            button9.Enabled = false;
            button9.BackColor = SystemColors.ControlLight;
            button9.ForeColor = SystemColors.ControlDarkDark;



            // Agrega aquí más botones si es necesario
        }

        private void button8_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            Crear_Usuario formulario = new Crear_Usuario();
            formulario.ShowDialog();

        }

        private void button9_Click(object sender, EventArgs e)
        {
            Ver_Usuarios formulario = new Ver_Usuarios();
            formulario.ShowDialog();
        }

        private void button10_Click(object sender, EventArgs e)
        {
            activarBotones();
            MostrarLogin();
        }
        private void activarBotones()
        {

            button1.Enabled = true;
            button1.BackColor = Color.Black;
            button1.ForeColor = Color.White;

            button2.Enabled = true;
            button2.BackColor = Color.Black;
            button2.ForeColor = Color.White;

            button3.Enabled = true;
            button3.BackColor = Color.Black;
            button3.ForeColor = Color.White;

            button4.Enabled = true;
            button4.BackColor = Color.Black;
            button4.ForeColor = Color.White;

            button5.Enabled = true;
            button5.BackColor = Color.Black;
            button5.ForeColor = Color.White;

            button6.Enabled = true;
            button6.BackColor = Color.Black;
            button6.ForeColor = Color.White;

            button7.Enabled = true;
            button7.BackColor = Color.Black;
            button7.ForeColor = Color.White;

            button8.Enabled = true;
            button8.BackColor = Color.Black;
            button8.ForeColor = Color.White;

            button9.Enabled = true;
            button9.BackColor = Color.Black;
            button9.ForeColor = Color.White;

            button3.Enabled = true;
            button3.BackColor = Color.Black;
            button3.ForeColor = Color.White;


        }
    }
}

