using System.ComponentModel.DataAnnotations;

namespace PruebaCarvajal.API.Models.DTOs
{
    public class UsuarioLoginDTO
    {
        [Required(ErrorMessage = "Debe ingresar un número de identificación")]
        public string NumeroIdentificacion { get; set; }

        [Required(ErrorMessage = "Debe ingresar una contraseña")]
        [MaxLength(8, ErrorMessage = "La contraseña debe tener minimo 8 caracteres")]
        public string Contrasena { get; set; }
    }
}
