using System.Collections.Generic;
using System.Threading.Tasks;
using PruebaCarvajal.Domain;

namespace PruebaCarvajal.Service.Interfaces
{
    public interface IUsuarioService
    {
        Task<IEnumerable<Usuario>> GetUsuarios();
        Task<Usuario> GetUsuario(int id);
        Task<Usuario> CreateUsuario(Usuario usuario);
        Task UpdateUsuario(Usuario usuario);
        Task DeleteUsuario(int id);
        Task<Usuario> Login(Usuario usuario);
    }
}
