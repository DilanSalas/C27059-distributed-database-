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
    public partial class Ver_Ventas : Form
    {
        private Conexion conexion;
        public Ver_Ventas()
        {
            InitializeComponent();
            conexion = new Conexion();
            MostrarVentas();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Dispose();
        }
        public void MostrarVentas()
        {
            List<Ventas> dtVentas = conexion.ObtenerTodasLasVentas();
            dataGridView1.DataSource = dtVentas;
        }
    }
}
