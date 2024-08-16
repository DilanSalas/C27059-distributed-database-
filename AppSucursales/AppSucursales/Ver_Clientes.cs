using AppSucursales.M.V.C.Controlador;
using AppSucursales.M.V.C.Modelo;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.DirectoryServices.Protocols;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AppSucursales
{
    public partial class Ver_Clientes : Form
    {
        private Conexion conexion;
        public Ver_Clientes()
        {
            InitializeComponent();
            conexion = new Conexion();
            MostrarProductos();
        }
        public void MostrarProductos()
        {
            List<Clientes> dtClientes = conexion.ObtenerTodosLosClientes();
            dataGridView1.DataSource = dtClientes;
        }


        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
