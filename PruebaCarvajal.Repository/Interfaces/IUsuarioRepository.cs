using System.Collections.Generic;
using System.Threading.Tasks;
using PruebaCarvajal.Domain;

namespace PruebaCarvajal.Repository.Interfaces
{
    public interface IUsuarioRepository
    {
        Task<IEnumerable<Usuario>> GetUsuarios();
        Task<Usuario> GetUsuario(int id);
        Task<Usuario> CreateUsuario(Usuario usuario);
        Task UpdateUsuario(Usuario usuario);
        Task DeleteUsuario(Usuario usuario);
        Task<Usuario> Login(Usuario usuario);
    }
}
