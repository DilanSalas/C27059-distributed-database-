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

namespace AppSucursales
{
    public partial class Ver_Facturas : Form
    {
        private Conexion conexion;
        public Ver_Facturas()
        {
            InitializeComponent();
            conexion = new Conexion();
            MostrarFacturas();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
        public void MostrarFacturas()
        {
            List<Facturas> dtFacturas = conexion.ObtenerTodasLasFactura();
            dataGridView1.DataSource = dtFacturas;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }
    }
}
