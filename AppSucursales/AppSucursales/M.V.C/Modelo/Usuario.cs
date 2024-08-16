using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppSucursales.M.V.C.Modelo
{
    internal class Usuario
    {
        public string cedula { get; set; }
        public string password { get; set; }
       
        public int idRol { get; set; }

        public bool ConfirmarPassword(string pw)
        {
            bool autorizado = false;

            if (string.IsNullOrEmpty(pw))
            {
                return false;
            }
            else
            {
                if (password.Equals(pw))
                {
                    autorizado = true;
                }
            }
            return autorizado;
        }
    }
}
