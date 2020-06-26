using System.Collections.Generic;
using System.Threading.Tasks;
using PruebaCarvajal.Domain;
using PruebaCarvajal.Repository.Interfaces;
using PruebaCarvajal.Service.Interfaces;
using PruebaCarvajal.Service.Utilities;

namespace PruebaCarvajal.Service.ServiceImplementations
{
    public class UsuarioService : IUsuarioService
    {
        private readonly IUsuarioRepository usuarioRepository;

        public UsuarioService(IUsuarioRepository _usuarioRepository)
        {
            usuarioRepository = _usuarioRepository;
        }

        public async Task<Usuario> CreateUsuario(Usuario usuario)
        {
            usuario.Contrasena = Password.CreateMD5Password(usuario.Contrasena);
            await usuarioRepository.CreateUsuario(usuario);

            return usuario;
        }

        public async Task DeleteUsuario(int id)
        {
            Usuario usuarioDelete = await usuarioRepository.GetUsuario(id);

            if (usuarioDelete == null)
            {
                return;
            }

            await usuarioRepository.DeleteUsuario(usuarioDelete);
        }

        public async Task<Usuario> GetUsuario(int id)
        {
            return await usuarioRepository.GetUsuario(id);
        }

        public async Task<IEnumerable<Usuario>> GetUsuarios()
        {
            return await usuarioRepository.GetUsuarios();
        }

        public async Task<Usuario> Login(Usuario usuario)
        {
            usuario.Contrasena = Password.CreateMD5Password(usuario.Contrasena);
            return await usuarioRepository.Login(usuario);
        }

        public async Task UpdateUsuario(Usuario usuario)
        {
            Usuario usuarioUpdate = await usuarioRepository.GetUsuario(usuario.IdUsuario);

            if (usuarioUpdate == null)
            {
                return;
            }

            usuarioUpdate.Nombre = usuario.Nombre;
            usuarioUpdate.Apellido = usuario.Apellido;
            usuarioUpdate.CorreoElectronico = usuario.CorreoElectronico;

            await usuarioRepository.UpdateUsuario(usuarioUpdate);
        }
    }
}
