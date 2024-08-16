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
    public partial class Ver_Usuarios : Form
    {
        private Conexion conexion;
        public Ver_Usuarios()
        {
            InitializeComponent();
            conexion = new Conexion();
            MostrarUsuarios();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }
        public void MostrarUsuarios()
        {
            List<Usuario> dtUsuarios = conexion.ObtenerTodosLosUsuarios();
            dataGridView1.DataSource = dtUsuarios;
        }
    }
}
