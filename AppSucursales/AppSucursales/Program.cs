using AppSucursales.M.V.C.Controlador;
using System;
using System.Windows.Forms;

namespace AppSucursales
{
    internal static class Program
    {
        [STAThread]
        static void Main()
        {
            Conexion conexion = new Conexion();

            string resultadoConexionCentral;
            string resultadoConexionAlajuela;
            conexion.Estado(out resultadoConexionCentral, out resultadoConexionAlajuela);

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Form1(resultadoConexionCentral, resultadoConexionAlajuela));
        }
    }
}

