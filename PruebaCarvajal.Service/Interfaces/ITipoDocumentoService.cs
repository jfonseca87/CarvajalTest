using System.Collections.Generic;
using System.Threading.Tasks;
using PruebaCarvajal.Domain;

namespace PruebaCarvajal.Service.Interfaces
{
    public interface ITipoDocumentoService
    {
        Task<IEnumerable<TipoDocumento>> GetTiposDocumento();
    }
}
