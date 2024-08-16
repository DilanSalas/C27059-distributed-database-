using Oracle.ManagedDataAccess.Client;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppSucursales.M.V.C.Controlador
{
    internal class LeerDatos
    {
        private string connectionStringCentral;

        public LeerDatos(string usuarioCentral, string passwordCentral, string dataSourceCentral)
        {
            connectionStringCentral = $"User Id={usuarioCentral};Password={passwordCentral};Data Source={dataSourceCentral}";
        }

        public void LeerClientes()
        {
            using (var conexionCentral = new OracleConnection(connectionStringCentral))
            {
                conexionCentral.Open();
                string consulta = "SELECT * FROM clientes";
                using (var comando = new OracleCommand(consulta, conexionCentral))
                using (var adaptador = new OracleDataAdapter(comando))
                {
                    DataSet dataSet = new DataSet();
                    adaptador.Fill(dataSet);
                    foreach (DataRow fila in dataSet.Tables[0].Rows)
                    {
                        Console.WriteLine($"Cédula: {fila["cedula"]}, Nombre: {fila["nombre"]}, Dirección: {fila["direccion"]}, Teléfono: {fila["telefono"]}, Correo: {fila["correo"]}");
                    }
                }
                conexionCentral.Close();
            }
        }

        public void LeerProductos()
        {
            using (var conexionCentral = new OracleConnection(connectionStringCentral))
            {
                conexionCentral.Open();
                string consulta = "SELECT * FROM productos";
                using (var comando = new OracleCommand(consulta, conexionCentral))
                using (var adaptador = new OracleDataAdapter(comando))
                {
                    DataSet dataSet = new DataSet();
                    adaptador.Fill(dataSet);
                    foreach (DataRow fila in dataSet.Tables[0].Rows)
                    {
                        Console.WriteLine($"ID Producto: {fila["id_producto"]}, Nombre: {fila["nombre"]}, Descripción: {fila["descripcion"]}, Precio: {fila["precio"]}");
                    }
                }
                conexionCentral.Close();
            }
        }

        public void LeerBodega()
        {
            using (var conexionCentral = new OracleConnection(connectionStringCentral))
            {
                conexionCentral.Open();
                string consulta = "SELECT * FROM bodega";
                using (var comando = new OracleCommand(consulta, conexionCentral))
                using (var adaptador = new OracleDataAdapter(comando))
                {
                    DataSet dataSet = new DataSet();
                    adaptador.Fill(dataSet);
                    foreach (DataRow fila in dataSet.Tables[0].Rows)
                    {
                        Console.WriteLine($"ID Bodega: {fila["id_bodega"]}, Nombre: {fila["nombre"]}, Dirección: {fila["direccion"]}, Teléfono: {fila["telefono"]}");
                    }
                }
                conexionCentral.Close();
            }
        }

        public void LeerInventarioBodega()
        {
            using (var conexionCentral = new OracleConnection(connectionStringCentral))
            {
                conexionCentral.Open();
                string consulta = "SELECT * FROM inventario_bodega";
                using (var comando = new OracleCommand(consulta, conexionCentral))
                using (var adaptador = new OracleDataAdapter(comando))
                {
                    DataSet dataSet = new DataSet();
                    adaptador.Fill(dataSet);
                    foreach (DataRow fila in dataSet.Tables[0].Rows)
                    {
                        Console.WriteLine($"ID Inventario: {fila["id_inventario"]}, ID Bodega: {fila["id_bodega"]}, ID Producto: {fila["id_producto"]}, Cantidad: {fila["cantidad"]}");
                    }
                }
                conexionCentral.Close();
            }
        }

        public void LeerFactura()
        {
            using (var conexionCentral = new OracleConnection(connectionStringCentral))
            {
                conexionCentral.Open();
                string consulta = "SELECT * FROM factura";
                using (var comando = new OracleCommand(consulta, conexionCentral))
                using (var adaptador = new OracleDataAdapter(comando))
                {
                    DataSet dataSet = new DataSet();
                    adaptador.Fill(dataSet);
                    foreach (DataRow fila in dataSet.Tables[0].Rows)
                    {
                        Console.WriteLine($"ID Factura: {fila["id_factura"]}, Cédula: {fila["cedula"]}, Fecha: {fila["fecha"]}, Total: {fila["total"]}");
                    }
                }
                conexionCentral.Close();
            }
        }

        public void LeerFacturaDetalle()
        {
            using (var conexionCentral = new OracleConnection(connectionStringCentral))
            {
                conexionCentral.Open();
                string consulta = "SELECT * FROM facturaDetalle";
                using (var comando = new OracleCommand(consulta, conexionCentral))
                using (var adaptador = new OracleDataAdapter(comando))
                {
                    DataSet dataSet = new DataSet();
                    adaptador.Fill(dataSet);
                    foreach (DataRow fila in dataSet.Tables[0].Rows)
                    {
                        Console.WriteLine($"ID Detalle: {fila["id_detalle"]}, ID Factura: {fila["id_factura"]}, ID Producto: {fila["id_producto"]}, Cantidad: {fila["cantidad"]}, Subtotal: {fila["subtotal"]}");
                    }
                }
                conexionCentral.Close();
            }
        }
    }
}
