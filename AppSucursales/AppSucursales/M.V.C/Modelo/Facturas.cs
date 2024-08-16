using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppSucursales.M.V.C.Modelo
{
    internal class Facturas
    {

        public int id_factura { get; set; }
        public int cedula { get; set; }
        public int producto { get; set; }
        public int cantidad { get; set; }
        public DateTime fecha { get; set; }
        public int total { get; set; }


    }
}
