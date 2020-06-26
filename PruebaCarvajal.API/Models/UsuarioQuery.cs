using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PruebaCarvajal.API.Models
{
    public class UsuarioQuery
    {
        public int IdUsuario { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public int TipoIdentificacion { get; set; }
        public string NomTipoDocumento { get; set; }
        public string NumeroIdentificacion { get; set; }
        public string CorreoElectronico { get; set; }
    }
}
