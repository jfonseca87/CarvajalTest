using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PruebaCarvajal.Domain
{
    [Table("TipoDocumento")]
    public class TipoDocumento
    {
        [Key]
        public int IdTipoDocumento { get; set; }
        public string NomTipoDocumento { get; set; }
    }
}
