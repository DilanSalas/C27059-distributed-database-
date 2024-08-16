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
    public partial class frmProductos : Form
    {
        private Conexion conexion;
        public frmProductos()
        {
            InitializeComponent();
            conexion = new Conexion();
            MostrarProductos();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
        public void MostrarProductos()
        {
            List<Productos> dtProductos = conexion.ObtenerTodosLosProductos();
            dataGridView1.DataSource = dtProductos;
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            Dispose();
        }
    }
}
