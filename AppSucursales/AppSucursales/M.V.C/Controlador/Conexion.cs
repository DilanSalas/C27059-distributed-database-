using AppSucursales.M.V.C.Modelo;
using Oracle.ManagedDataAccess.Client;
using Oracle.ManagedDataAccess.Types;
using System;
using System.Data;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ListView;

namespace AppSucursales.M.V.C.Controlador
{
    internal class Conexion
    {
        private OracleConnection conexionCentral;
        private OracleConnection conexionAlajuela;

        public Conexion()
        {
            string connectionStringCentral = "User Id=usuario_Base_Central;Password=ucr224;Data Source=192.168.0.2";
            string connectionStringAlajuela = "User Id=usuario_Alajuela;Password=ucr2024;Data Source=localhost";
            conexionCentral = new OracleConnection(connectionStringCentral);
            conexionAlajuela = new OracleConnection(connectionStringAlajuela);
        }

        public void AbrirConexionCentral()
        {
            try
            {
                if (conexionCentral.State == System.Data.ConnectionState.Closed)
                {
                    conexionCentral.Open();
                    Console.WriteLine("Conexión a la base de datos central abierta exitosamente.");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error al abrir la conexión a la base de datos central: " + ex.Message);
            }
        }

        public void CerrarConexionCentral()
        {
            try
            {
                if (conexionCentral.State == System.Data.ConnectionState.Open)
                {
                    conexionCentral.Close();
                    Console.WriteLine("Conexión a la base de datos central cerrada exitosamente.");
                }
            }
            catch (Exception ex)
            {

                Console.WriteLine("Error al cerrar la conexión a la base de datos central: " + ex.Message);
            }
        }

        public void AbrirConexionAlajuela()
        {
            try
            {
                if (conexionAlajuela.State == System.Data.ConnectionState.Closed)
                {
                    conexionAlajuela.Open();
                    Console.WriteLine("Conexión a la base de datos Alajuela abierta exitosamente.");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error al abrir la conexión a la base de datos Alajuela: " + ex.Message);
            }
        }

        public void CerrarConexionAlajuela()
        {
            try
            {
                if (conexionAlajuela.State == System.Data.ConnectionState.Open)
                {
                    conexionAlajuela.Close();
                    Console.WriteLine("Conexión a la base de datos Alajuela cerrada exitosamente.");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error al cerrar la conexión a la base de datos Alajuela: " + ex.Message);
            }
        }

        public OracleConnection ObtenerConexionCentral()
        {
            return conexionCentral;
        }

        public OracleConnection ObtenerConexionAlajuela()
        {
            return conexionAlajuela;
        }
        public void Estado(out string resultadoConexionCentral, out string resultadoConexionAlajuela)
        {
            resultadoConexionCentral = "No se pudo establecer conexión con la base de datos central.";
            resultadoConexionAlajuela = "No se pudo establecer conexión con la base de datos de Alajuela.";

            try
            {
                // Abrir la conexión a la base de datos central
                AbrirConexionCentral();

                // Verificar si la conexión a la base de datos central está abierta
                if (ObtenerConexionCentral().State == System.Data.ConnectionState.Open)
                {
                    resultadoConexionCentral = "Conexión a la base de datos central abierta exitosamente.";

                 
                }
                else
                {
                    resultadoConexionCentral = "No se pudo establecer conexión con la base de datos central.";
                }
                // Abrir la conexión a la base de datos de Alajuela
                AbrirConexionAlajuela();

                // Verificar si la conexión a la base de datos de Alajuela está abierta
                if (ObtenerConexionAlajuela().State == System.Data.ConnectionState.Open)
                {
                    resultadoConexionAlajuela = "Conexión a la base de datos de Alajuela abierta exitosamente.";

                    // Sincronizar la base de datos de Alajuela con los datos de la base de datos central
                   
                }
                else
                {
                    resultadoConexionAlajuela = "No se pudo establecer conexión con la base de datos de Alajuela.";
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error al sincronizar datos desde la base de datos central: " + ex.Message);
            }
            finally
            {
                // Cerrar las conexiones
                CerrarConexionCentral();
                CerrarConexionAlajuela();
            }
        }

        public void SincronizarDatos()
        {
            try
            {
                // Sincronizar datos de clientes
                SincronizarClientes();

            }
            catch (Exception ex)
            {
                Console.WriteLine("Error al sincronizar datos desde la base de datos central: " + ex.Message);
            }
        }

        public void SincronizarClientes()
        {
            try
            {
                AbrirConexionCentral();
                AbrirConexionAlajuela();
                // Crear la consulta para seleccionar los datos de la tabla clientes en la base de datos central
                string queryCentral = "SELECT * FROM clientes";

                using (OracleCommand commandCentral = new OracleCommand(queryCentral, ObtenerConexionCentral()))
                {
                    using (OracleDataReader reader = commandCentral.ExecuteReader())
                    {
                        // Iterar a través de los resultados y actualizar la base de datos local
                        while (reader.Read())
                        {
                            string cedula = reader["cedula"].ToString();

                            // Verificar si el cliente ya existe en la base de datos local
                            string selectQuery = "SELECT COUNT(*) FROM clientes WHERE cedula = :cedula";
                            using (OracleCommand selectCommand = new OracleCommand(selectQuery, ObtenerConexionAlajuela()))
                            {
                                selectCommand.Parameters.Add(":cedula", OracleDbType.Varchar2).Value = cedula;
                                int count = Convert.ToInt32(selectCommand.ExecuteScalar());

                                if (count == 0)
                                {
                                    // Obtener los valores de las columnas
                                    string nombre = reader["nombre"].ToString();
                                    string direccion = reader["direccion"].ToString();
                                    string telefono = reader["telefono"].ToString();
                                    string correo = reader["correo"].ToString();

                                    // Insertar el cliente si no existe
                                    string insertQuery = "INSERT INTO clientes (cedula, nombre, direccion, telefono, correo) " +
                                                         "VALUES (:cedula, :nombre, :direccion, :telefono, :correo)";
                                    using (OracleCommand insertCommand = new OracleCommand(insertQuery, ObtenerConexionAlajuela()))
                                    {
                                        insertCommand.Parameters.Add(":cedula", OracleDbType.Varchar2).Value = cedula;
                                        insertCommand.Parameters.Add(":nombre", OracleDbType.Varchar2).Value = nombre;
                                        insertCommand.Parameters.Add(":direccion", OracleDbType.Varchar2).Value = direccion;
                                        insertCommand.Parameters.Add(":telefono", OracleDbType.Varchar2).Value = telefono;
                                        insertCommand.Parameters.Add(":correo", OracleDbType.Varchar2).Value = correo;
                                        insertCommand.ExecuteNonQuery();
                                    }

                                    Console.WriteLine("Cliente insertado: " + cedula);
                                }
                                else
                                {
                                    Console.WriteLine("Cliente ya existe: " + cedula);
                                }
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error al sincronizar clientes desde la base de datos central: " + ex.Message);
            }
            finally 
            {
                CerrarConexionAlajuela();
                CerrarConexionCentral();
            }
        }




        public void InsertarClienteYActualizarCentral(string cedula, string nombre, string direccion, string telefono, string correo)
        {
            try
            {
                // Abrir la conexión local
                AbrirConexionAlajuela();

                // Crear la consulta parametrizada para insertar los datos en la tabla clientes
                string query = "INSERT INTO clientes (cedula, nombre, direccion, telefono, correo) " +
                               "VALUES (:cedula, :nombre, :direccion, :telefono, :correo)";

                // Crear y configurar el comando SQL con la consulta y los parámetros
                using (OracleCommand command = new OracleCommand(query, conexionAlajuela))
                {
                    command.Parameters.Add(":cedula", OracleDbType.Varchar2).Value = cedula;
                    command.Parameters.Add(":nombre", OracleDbType.Varchar2).Value = nombre;
                    command.Parameters.Add(":direccion", OracleDbType.Varchar2).Value = direccion;
                    command.Parameters.Add(":telefono", OracleDbType.Varchar2).Value = telefono;
                    command.Parameters.Add(":correo", OracleDbType.Varchar2).Value = correo;

                    // Ejecutar la consulta para insertar los datos en la tabla clientes
                    command.ExecuteNonQuery();
                }

            }
            catch (Exception ex)
            {
                // Capturar y manejar cualquier excepción que ocurra durante la inserción local
                throw new Exception("Error al insertar datos en la base de datos local: " + ex.Message);
            }
            finally
            {
                // Cerrar la conexión local
                CerrarConexionAlajuela();
            }
            // Intentar sincronizar con la base de datos central
            try
            {
                AbrirConexionCentral();
                string query = "INSERT INTO clientes (cedula, nombre, direccion, telefono, correo) " +
                              "VALUES (:cedula, :nombre, :direccion, :telefono, :correo)";
                using (OracleCommand commandCentral = new OracleCommand(query, conexionCentral))
                {
                    commandCentral.Parameters.Add(":cedula", OracleDbType.Varchar2).Value = cedula;
                    commandCentral.Parameters.Add(":nombre", OracleDbType.Varchar2).Value = nombre;
                    commandCentral.Parameters.Add(":direccion", OracleDbType.Varchar2).Value = direccion;
                    commandCentral.Parameters.Add(":telefono", OracleDbType.Varchar2).Value = telefono;
                    commandCentral.Parameters.Add(":correo", OracleDbType.Varchar2).Value = correo;

                    // Ejecutar la consulta para insertar los datos en la tabla clientes en la base de datos central
                    commandCentral.ExecuteNonQuery();
                }
            }
            catch (Exception ex)
            {
                string correos = "Falla de conexion con la base de datos Central desde la sucursal de alajuela" +
                   "se informa la siguiente informacion que fue administrada mientras no existia conexión";
                correos += "<br><b>Usted ha se ha registrado como Administrtador </b> ";
                correos += "<br><b>Cedula del cliente: </b> " + cedula;
                correos += "<br><b>Nombre: </b>" + nombre;
                correos += "<br><b>Correo Electronico:</b> " + correo;
                correos += "<br><b>Direccion: </b>" + direccion;
                correos += "<br><b>numero de telefono: </b>" + telefono;
                correos += $"<br><b>Insert into Cliente values({cedula},{nombre},{correo},{direccion},{telefono}) </b>";
                correos += "<br>Sucursal de Alajuela.</b>";
                Email email = new Email();
                email.Enviar(correos);
                // Capturar y manejar cualquier excepción que ocurra durante la sincronización
                throw new Exception("Error al sincronizar con la base de datos central, ¡Se han enviado los datos por correo electronico al corre de la base de datos central! error: " + ex.Message  );

            }
            finally
            {
                // Cerrar la conexión con la base de datos central
                CerrarConexionCentral();
            }
        }

        public decimal ObtenerPrecioProducto(int idProducto, OracleConnection conexion)
        {
            try
            {
                // Asegurarse de que la conexión esté abierta antes de ejecutar el comando
                if (conexion.State != ConnectionState.Open)
                {
                    conexion.Open();
                }

                string query = "SELECT precio FROM productos WHERE id_producto = :idProducto";
                using (OracleCommand command = new OracleCommand(query, conexion))
                {

                    command.Parameters.Add(":idProducto", OracleDbType.Int32).Value = idProducto;
                    object result = command.ExecuteScalar();
                    if (result != null)
                    {
                        return Convert.ToDecimal(result);
                    }
                    else
                    {
                        throw new Exception("Producto no encontrado.");
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error al obtener el precio del producto: " + ex.Message);
            }
            finally
            {
                // Asegurarse de cerrar la conexión al finalizar
                if (conexion.State == ConnectionState.Open)
                {
                    conexion.Close();
                }
            }
        }
        public void InsertarUsuario(int cedula, string password, int idRol)
        {
            try
            {
                // Abrir la conexión local
                AbrirConexionAlajuela();

                // Crear la consulta parametrizada para insertar los datos en la tabla Usuarios y devolver el id generado
                string query = "INSERT INTO Usuarios (cedula, password, idRol) " +
                               "VALUES (:cedula, :password, :idRol)";

                // Crear y configurar el comando SQL con la consulta y los parámetros
                using (OracleCommand command = new OracleCommand(query, conexionAlajuela))
                {
                    command.Parameters.Add(":cedula", OracleDbType.Int32).Value = cedula;
                    command.Parameters.Add(":password", OracleDbType.Varchar2).Value = password;
                    command.Parameters.Add(":idRol", OracleDbType.Int32).Value = idRol;

                    // Ejecutar la consulta para insertar los datos en la tabla Usuarios
                    command.ExecuteNonQuery();

                    Console.WriteLine("Usuario insertado correctamente");
                }
            }
            catch (Exception ex)
            {
                // Capturar y manejar cualquier excepción que ocurra durante la inserción local
                throw new Exception("Error al insertar usuario en la base de datos local: " + ex.Message);
            }
            finally
            {
                // Cerrar la conexión local
                CerrarConexionAlajuela();
            }
        }




        public void InsertarFacturaYActualizarCentral(int cedula, int producto, int cantidad, DateTime fecha, decimal total)
        {
            int idFactura;
            try
            {
                // Abrir la conexión local
                AbrirConexionAlajuela();

                // Crear la consulta parametrizada para insertar los datos en la tabla factura y devolver el id_factura generado
                string query = "INSERT INTO factura (cedula, producto, cantidad, fecha, total) " +
                               "VALUES (:cedula, :producto, :cantidad, :fecha, :total) RETURNING id_factura INTO :id_factura";


                // Crear y configurar el comando SQL con la consulta y los parámetros
                using (OracleCommand command = new OracleCommand(query, conexionAlajuela))
                {
                    command.Parameters.Add(":cedula", OracleDbType.Varchar2).Value = cedula;
                    command.Parameters.Add(":producto", OracleDbType.Int32).Value = producto;
                    command.Parameters.Add(":cantidad", OracleDbType.Int32).Value = cantidad;
                    command.Parameters.Add(":fecha", OracleDbType.Date).Value = fecha;
                    command.Parameters.Add(":total", OracleDbType.Decimal).Value = total;
                    command.Parameters.Add(":id_factura", OracleDbType.Int32).Direction = ParameterDirection.Output;

                    // Ejecutar la consulta para insertar los datos en la tabla factura y obtener el id_factura generado
                    command.ExecuteNonQuery();
                    idFactura = int.Parse(command.Parameters[":id_factura"].Value.ToString());
                }
            }

            catch (Exception ex)
            {
                // Capturar y manejar cualquier excepción que ocurra durante la inserción local
                throw new Exception("Error al insertar datos en la base de datos local: " + ex.Message);
            }
            finally
            {
                // Cerrar la conexión local
                CerrarConexionAlajuela();
            }


            // Sincronizar con la base de datos central
            try
            {
                AbrirConexionCentral();
                string queryCentral = "INSERT INTO factura (id_factura, cedula, producto, cantidad, fecha, total) " +
                                      "VALUES (:id_factura, :cedula, :producto, :cantidad, :fecha, :total)";

                using (OracleCommand commandCentral = new OracleCommand(queryCentral, conexionCentral))
                {
                    commandCentral.Parameters.Add(":id_factura", OracleDbType.Int32).Value = idFactura;
                    commandCentral.Parameters.Add(":cedula", OracleDbType.Varchar2).Value = cedula;
                    commandCentral.Parameters.Add(":producto", OracleDbType.Int32).Value = producto;
                    commandCentral.Parameters.Add(":cantidad", OracleDbType.Int32).Value = cantidad;
                    commandCentral.Parameters.Add(":fecha", OracleDbType.Date).Value = fecha;
                    commandCentral.Parameters.Add(":total", OracleDbType.Decimal).Value = total;

                    // Ejecutar la consulta para insertar los datos en la tabla factura en la base de datos central
                    commandCentral.ExecuteNonQuery();
                }
            }
            catch (Exception ex)
            {
                
                string correos = "Falla de conexión con la base de datos central desde la sucursal de Alajuela. " +
                    "Se informa la siguiente información que fue administrada mientras no existía conexión:";
                correos += "<br><b>Información de la factura:</b>";
                correos += "<br><b>Número de Factura: </b> " + idFactura;
                correos += "<br><b>Cédula del Cliente: </b> " + cedula;
                correos += "<br><b>ID del Producto: </b>" + producto;
                correos += "<br><b>Cantidad: </b> " + cantidad;
                correos += "<br><b>Fecha: </b> " + fecha.ToString("yyyy-MM-dd");
                correos += $"<br><b>Insert into factura values ({idFactura}, {cedula}, {producto}, {cantidad}, {fecha}, {total});<b>";
                correos += "<br><b>Sucursal de Alajuela.</b>";

                // Enviar email de notificación
                Email email = new Email();
                email.Enviar(correos);
                // Capturar y manejar cualquier excepción que ocurra durante la sincronización
                throw new Exception("Error al sincronizar con la base de datos central, ¡Se han enviado los datos por correo electronico al correo de la base de datos central! error:" + ex.Message);

            }
            finally
            {
                // Cerrar la conexión con la base de datos central
                CerrarConexionCentral();
            }
        }


        public List<Productos> ObtenerTodosLosProductos()
        {
            List<Productos> listaProductos = new List<Productos>();

            try
            {
                if (conexionAlajuela.State == ConnectionState.Closed)
                {
                    conexionAlajuela.Open();
                }

                string query = "SELECT id_producto, nombre, descripcion, cantidad, precio FROM productos";

                OracleCommand cmd = new OracleCommand(query, conexionAlajuela);
                OracleDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    // Construir objeto Producto desde los datos del lector
                    Productos producto = new Productos
                    {
                        IdProducto = Convert.ToInt32(reader["id_producto"]),
                        Nombre = reader["nombre"].ToString(),
                        Descripcion = reader["descripcion"].ToString(),
                        Cantidad = Convert.ToInt32(reader["cantidad"]),
                        Precio = Convert.ToDecimal(reader["precio"])
                    };

                    listaProductos.Add(producto);
                }

                reader.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al obtener datos de productos: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                if (conexionAlajuela.State == ConnectionState.Open)
                {
                    conexionAlajuela.Close();
                }
            }

            return listaProductos;
        }
        public Usuario ValidarUsuario(string pCedula, string pPassword)
        {
            Usuario temp = null;
            try
            {
                AbrirConexionAlajuela();

                OracleCommand command = new OracleCommand();
                command.Connection = ObtenerConexionAlajuela();
                command.CommandType = CommandType.StoredProcedure;
                command.CommandText = "Sp_Cns_Usuario";

                // Parámetros de entrada
                command.Parameters.Add("pCedula", OracleDbType.Int32).Value = pCedula;
                command.Parameters.Add("pPw", OracleDbType.Varchar2).Value = pPassword;

                // Parámetro de salida para el cursor
                command.Parameters.Add("pUsuario", OracleDbType.RefCursor).Direction = ParameterDirection.Output;

                // Ejecutar el procedimiento almacenado
                command.ExecuteNonQuery();

                // Leer el cursor de salida
                OracleDataReader reader = ((OracleRefCursor)command.Parameters["pUsuario"].Value).GetDataReader();

                // Si se encontró un usuario, construir el objeto Usuario
                if (reader.Read())
                {
                    temp = new Usuario();
                    temp.cedula = reader["cedula"].ToString();
                    temp.password = reader["password"].ToString();
                }

                // Cerrar el lector
                reader.Close();
            }
            catch (Exception ex)
            {
                // Manejar excepciones
                throw ex;
            }
            finally
            {
                // Asegurar cerrar la conexión
                CerrarConexionAlajuela();
            }


            return temp;

        }

        public List<Clientes> ObtenerTodosLosClientes()
        {
            List<Clientes> listaClientes = new List<Clientes>();

            try
            {
                if (conexionAlajuela.State == ConnectionState.Closed)
                {
                    conexionAlajuela.Open();
                }

                string query = "SELECT Cedula, Nombre, Direccion, Telefono, Correo FROM clientes";

                OracleCommand cmd = new OracleCommand(query, conexionAlajuela);
                OracleDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    // Construir objeto Producto desde los datos del lector
                    Clientes clientes = new Clientes
                    {
                        cedula = Convert.ToInt64(reader["Cedula"]),
                        nombre = reader["nombre"].ToString(),
                        direccion = reader["direccion"].ToString(),
                        telefono = reader["telefono"].ToString(),
                        correo = reader["correo"].ToString()
                    };

                    listaClientes.Add(clientes);
                }

                reader.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al obtener datos de los clientes: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                if (conexionAlajuela.State == ConnectionState.Open)
                {
                    conexionAlajuela.Close();
                }
            }
            return listaClientes;
        }
        public List<Facturas> ObtenerTodasLasFactura()
        {
            List<Facturas> listaFactura = new List<Facturas>();

            try
            {
                if (conexionAlajuela.State == ConnectionState.Closed)
                {
                    conexionAlajuela.Open();
                }

                string query = "SELECT id_factura, cedula, producto, cantidad, fecha, total FROM factura";

                OracleCommand cmd = new OracleCommand(query, conexionAlajuela);
                OracleDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    // Construir objeto Producto desde los datos del lector
                    Facturas factura = new Facturas
                    {
                        id_factura = Convert.ToInt32(reader["id_factura"]),
                        cedula = Convert.ToInt32(reader["cedula"]),
                        producto = Convert.ToInt32(reader["producto"]),
                        cantidad = Convert.ToInt32(reader["cantidad"]),
                        fecha = reader.GetDateTime(reader.GetOrdinal("fecha")),
                        total = Convert.ToInt32(reader["cantidad"])
                    };

                    listaFactura.Add(factura);
                }

                reader.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al obtener datos de las facturas: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                if (conexionAlajuela.State == ConnectionState.Open)
                {
                    conexionAlajuela.Close();
                }
            }
            return listaFactura;
        }

        public int ObtenerIdRolPorCedula(int cedula)
        {
            string query = "SELECT idRol FROM Usuarios WHERE cedula = :cedula";
            int idRol = -1; // Valor predeterminado para indicar que no se encontró el idRol

            try
            {
                using (OracleConnection connection = ObtenerConexionAlajuela())
                {
                    connection.Open(); // Asegúrate de abrir la conexión

                    using (OracleCommand command = new OracleCommand(query, connection))
                    {
                        command.Parameters.Add(":cedula", OracleDbType.Int32).Value = cedula;

                        using (OracleDataReader reader = command.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                idRol = reader.GetInt32(0); // Obtener el valor del idRol
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error al obtener el idRol: " + ex.Message);
                throw; // Re-lanzar la excepción para que pueda ser manejada externamente si es necesario
            }

            return idRol;
        }

        public List<Usuario> ObtenerTodosLosUsuarios()
        {
            List<Usuario> listaUsuarios = new List<Usuario>();

            try
            {
                if (conexionAlajuela.State == ConnectionState.Closed)
                {
                    conexionAlajuela.Open();
                }

                // Asegúrate de seleccionar la columna password en la consulta
                string query = "SELECT cedula, password, idRol FROM usuarios";

                OracleCommand cmd = new OracleCommand(query, conexionAlajuela);
                OracleDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    // Construir objeto Usuario desde los datos del lector
                    string password = reader["password"].ToString();
                    string hiddenPassword = new string('*', password.Length);

                    Usuario usuario = new Usuario
                    {
                        cedula = reader["cedula"].ToString(),
                        password = hiddenPassword, // Almacenar la contraseña oculta
                        idRol = Convert.ToInt32(reader["idRol"])
                    };

                    listaUsuarios.Add(usuario);
                }

                reader.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al obtener datos de los usuarios: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                if (conexionAlajuela.State == ConnectionState.Open)
                {
                    conexionAlajuela.Close();
                }
            }
            return listaUsuarios;
        }

        public List<Ventas> ObtenerTodasLasVentas()
        {
            List<Ventas> listaVentas = new List<Ventas>();

            try
            {
                if (conexionAlajuela.State == ConnectionState.Closed)
                {
                    conexionAlajuela.Open();
                }

                string query = "SELECT idVenta,  idProducto,cantidad, total, detalle, fecha FROM ventas";

                OracleCommand cmd = new OracleCommand(query, conexionAlajuela);
                OracleDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    // Construir objeto Ventas desde los datos del lector
                    Ventas venta = new Ventas
                    {
                        idVenta = Convert.ToInt32(reader["idVenta"]),
                        idProducto = Convert.ToInt32(reader["idProducto"]),
                        cantidad = Convert.ToInt32(reader["cantidad"]),
                        total = Convert.ToInt32(reader["total"]),
                        detalle = reader["detalle"].ToString(),
                        fecha = Convert.ToDateTime(reader["fecha"])
                    };

                    listaVentas.Add(venta);
                }

                reader.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al obtener datos de ventas: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                if (conexionAlajuela.State == ConnectionState.Open)
                {
                    conexionAlajuela.Close();
                }
            }

            return listaVentas;
        }
        public int GetCantidadDeProductos(int productoId)
        {
            int cantidadProductos = 0;
            if (conexionAlajuela.State == ConnectionState.Closed)
            {
                conexionAlajuela.Open();
            }

                string query = @"
                SELECT cantidad
                FROM productos
                WHERE id_producto = :productoId";

                using (OracleCommand command = new OracleCommand(query, ObtenerConexionAlajuela()))
                {
                    command.Parameters.Add(new OracleParameter("productoId", OracleDbType.Int32)).Value = productoId;

                    object result = command.ExecuteScalar();
                    if (result != null && result != DBNull.Value)
                    {
                        cantidadProductos = Convert.ToInt32(result);
                    }
                }
            if (conexionAlajuela.State == ConnectionState.Open)
            {
                conexionAlajuela.Close();
            }
            return cantidadProductos;
        }



    }
}


