using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppSucursales.M.V.C.Modelo
{
    internal class Clientes
    {

        [Key]
        public long cedula { get; set; }

        [Required(ErrorMessage = "El nombre es obligatorio.")]
        public string nombre { get; set; }
        [Required(ErrorMessage = "la direccion es obligatoria.")]
        public string direccion { get; set; }
        [Required(ErrorMessage = "el telefono es obligatorio.")]
        public string telefono { get; set; }

        [EmailAddress(ErrorMessage = "El correo electrónico no es válido.")]
       
        public string correo { get; set; }
    }

}

