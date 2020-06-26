using System.Collections.Generic;
using System.Threading.Tasks;
using PruebaCarvajal.Domain;
using PruebaCarvajal.Repository.Interfaces;
using PruebaCarvajal.Service.Interfaces;

namespace PruebaCarvajal.Service.ServiceImplementations
{
    public class TipoDocumentoService : ITipoDocumentoService
    {
        private readonly ITipoDocumentoRepository tipoDocumentoRepository;

        public TipoDocumentoService(ITipoDocumentoRepository _tipoDocumentoRepository)
        {
            tipoDocumentoRepository = _tipoDocumentoRepository;
        }

        public async Task<IEnumerable<TipoDocumento>> GetTiposDocumento()
        {
            return await tipoDocumentoRepository.GetTiposDocumento();
        }
    }
}
