using System.Collections.Generic;
using System.Threading.Tasks;
using PruebaCarvajal.Domain;

namespace PruebaCarvajal.Repository.Interfaces
{
    public interface ITipoDocumentoRepository
    {
        Task<IEnumerable<TipoDocumento>> GetTiposDocumento();
    }
}
