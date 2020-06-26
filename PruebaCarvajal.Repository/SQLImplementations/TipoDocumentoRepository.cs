using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using PruebaCarvajal.Domain;
using PruebaCarvajal.Repository.Interfaces;

namespace PruebaCarvajal.Repository.SQLImplementations
{
    public class TipoDocumentoRepository : ITipoDocumentoRepository
    {
        private readonly CarvajalContext db;

        public TipoDocumentoRepository(CarvajalContext _db)
        {
            db = _db;
        }

        public async Task<IEnumerable<TipoDocumento>> GetTiposDocumento()
        {
            return await db.TipoDocumento.ToListAsync();
        }
    }
}
