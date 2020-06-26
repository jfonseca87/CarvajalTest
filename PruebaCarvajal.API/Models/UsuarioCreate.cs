using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace PruebaCarvajal.API.Models
{
    public class UsuarioCreate
    {
        public int IdUsuario { get; set; }

        [Required(ErrorMessage = "Debe ingresar un nombre")]
        public string Nombre { get; set; }

        [Required(ErrorMessage = "Debe ingresar un apellido")]
        public string Apellido { get; set; }

        public int TipoIdentificacion { get; set; }

        [Required(ErrorMessage = "Debe ingresar un número de identificación")]
        public string NumeroIdentificacion { get; set; }

        [Required(ErrorMessage = "Debe ingresar un correo electrónico")]
        [EmailAddress(ErrorMessage = "El correo debe tener un formato válido")]
        public string CorreoElectronico { get; set; }

        [Required(ErrorMessage = "Debe ingresar una contraseña")]
        [MinLength(8, ErrorMessage = "La contraseña debe tener minimo 8 caracteres")]
        public string Contrasena { get; set; }
    }
}
