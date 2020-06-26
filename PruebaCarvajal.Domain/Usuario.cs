using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PruebaCarvajal.Domain
{
    [Table("Usuario")]
    public class Usuario
    {
        [Key]
        public int IdUsuario { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public int TipoIdentificacion { get; set; }
        [NotMapped]
        public string NomTipoDocumento { get; set; }
        public string NumeroIdentificacion { get; set; }
        public string CorreoElectronico { get; set; }
        public string Contrasena { get; set; }
    }
}
