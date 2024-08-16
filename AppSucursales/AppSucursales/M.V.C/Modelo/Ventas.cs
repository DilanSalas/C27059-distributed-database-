using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppSucursales.M.V.C.Modelo
{
    internal class Ventas
    {
        public int idVenta { get; set; }


        public int idProducto { get; set; }

        public int cantidad { get; set; }

        public int total { get; set; }

        public string detalle { get; set; }

        public DateTime fecha { get; set; }
    }
}
