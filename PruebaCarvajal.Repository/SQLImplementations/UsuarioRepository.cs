using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using PruebaCarvajal.Domain;
using PruebaCarvajal.Repository.Interfaces;
using System.Linq;

namespace PruebaCarvajal.Repository.SQLImplementations
{
    public class UsuarioRepository : IUsuarioRepository
    {
        private readonly CarvajalContext db;

        public UsuarioRepository(CarvajalContext _db)
        {
            db = _db;
        }

        public async Task<Usuario> CreateUsuario(Usuario usuario)
        {
            db.Usuario.Add(usuario);
            await db.SaveChangesAsync();

            return usuario;
        }

        public async Task DeleteUsuario(Usuario usuario)
        {
            db.Usuario.Remove(usuario);
            await db.SaveChangesAsync();
        }

        public async Task<Usuario> GetUsuario(int id)
        {
            return await db.Usuario.FirstOrDefaultAsync(x => x.IdUsuario == id);
        }

        public async Task<IEnumerable<Usuario>> GetUsuarios()
        {
            return await (from u in db.Usuario
                          join td in db.TipoDocumento
                          on u.TipoIdentificacion equals td.IdTipoDocumento
                          select new Usuario
                          {
                              IdUsuario = u.IdUsuario,
                              Nombre = u.Nombre,
                              Apellido = u.Apellido,
                              NomTipoDocumento = td.NomTipoDocumento,
                              NumeroIdentificacion = u.NumeroIdentificacion,
                              CorreoElectronico = u.CorreoElectronico
                          }).ToListAsync();
        }

        public async Task<Usuario> Login(Usuario usuario)
        {
            return await db.Usuario.FirstOrDefaultAsync(x => x.NumeroIdentificacion == usuario.NumeroIdentificacion && x.Contrasena.Equals(usuario.Contrasena));
        }

        public async Task UpdateUsuario(Usuario usuario)
        {
            db.Entry(usuario).State = EntityState.Modified;
            await db.SaveChangesAsync();
        }
    }
}
