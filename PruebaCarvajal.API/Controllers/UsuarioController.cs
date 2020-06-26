using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using PruebaCarvajal.API.Models;
using PruebaCarvajal.API.Models.DTOs;
using PruebaCarvajal.Domain;
using PruebaCarvajal.Service.Interfaces;

namespace PruebaCarvajal.API.Controllers
{
    [ApiController]
    [Route("api/Usuario")]
    public class UsuarioController : ControllerBase
    {
        private ILogger<UsuarioController> log;
        private readonly IMapper mapper;
        private readonly IUsuarioService usuarioService;

        public UsuarioController(ILogger<UsuarioController> _log, IMapper _mapper, IUsuarioService _usuarioService)
        {
            log = _log;
            mapper = _mapper;
            usuarioService = _usuarioService;
        }

        [HttpGet]
        public async Task<ResponseModel> GetUsuarios()
        {
            ResponseModel response;

            try
            {
                var usuarios = await usuarioService.GetUsuarios();

                if (!usuarios.Any())
                {
                    return response = new ResponseModel
                    {
                        HttpResponse = (int)HttpStatusCode.NotFound,
                        Response = "No existen usuarios"
                    };
                }

                var usuariosResponse = mapper.Map<IList<UsuarioQuery>>(usuarios);
                response = new ResponseModel
                {
                    HttpResponse = (int)HttpStatusCode.OK,
                    Response = usuariosResponse
                };
            }
            catch (Exception)
            {
                response = new ResponseModel
                {
                    HttpResponse = (int)HttpStatusCode.InternalServerError,
                    ErrorResponse = "Ha ocurrido un error consulte al administrador de sistemas"
                };
            }

            return response;
        }

        [HttpGet("{idUsuario}")]
        public async Task<ResponseModel> Getusuario(int idUsuario)
        {
            ResponseModel response;

            try
            {
                var usuario = await usuarioService.GetUsuario(idUsuario);

                if (usuario == null)
                {
                    return response = new ResponseModel
                    {
                        HttpResponse = (int)HttpStatusCode.NotFound,
                        Response = "El usuario que esta buscando no existe"
                    };
                }

                var usuarioResponse = mapper.Map<UsuarioQuery>(usuario);
                response = new ResponseModel
                {
                    HttpResponse = (int)HttpStatusCode.OK,
                    Response = usuarioResponse
                };
            }
            catch (Exception ex)
            {
                log.LogError(ex, "Ocurrio un error al intentar consultar");

                response = new ResponseModel
                {
                    HttpResponse = (int)HttpStatusCode.InternalServerError,
                    ErrorResponse = "Ha ocurrido un error consulte al administrador de sistemas"
                };
            }

            return response;
        }

        [HttpPost]
        public async Task<ResponseModel> CreateUsuario(UsuarioCreate usuario)
        {
            ResponseModel response;

            try
            {
                var usuarioCreate = mapper.Map<Usuario>(usuario);
                var usuarioCreated = await usuarioService.CreateUsuario(usuarioCreate);

                response = new ResponseModel
                {
                    HttpResponse = (int)HttpStatusCode.Created,
                    Response = new { usuarioCreated.IdUsuario, Message = "Se ha creado exitosamente el usuario" }
                };
            }
            catch (Exception ex)
            {
                log.LogError(ex, "Ocurrio un error al intentar consultar");

                response = new ResponseModel
                {
                    HttpResponse = (int)HttpStatusCode.InternalServerError,
                    ErrorResponse = "Ha ocurrido un error consulte al administrador de sistemas"
                };
            }

            return response;
        }

        [HttpPost("Login")]
        public async Task<ResponseModel> LogIn(UsuarioLoginDTO usuario)
        {
            ResponseModel response;

            try
            {
                var usuarioLogIn = mapper.Map<Usuario>(usuario);
                var usuarioDB = await usuarioService.Login(usuarioLogIn);

                if (usuarioDB == null)
                {
                    return response = new ResponseModel
                    {
                        HttpResponse = (int)HttpStatusCode.NotFound,
                        Response = "Usuario o contraseña incorrectos, verifique por favor"
                    };
                }

                response = new ResponseModel
                {
                    HttpResponse = (int)HttpStatusCode.OK,
                    Response = new { Token = Guid.NewGuid().ToString() }
                };
            }
            catch (Exception ex)
            {
                log.LogError(ex, "Ocurrio un error al intentar loguearse");

                response = new ResponseModel
                {
                    HttpResponse = (int)HttpStatusCode.InternalServerError,
                    ErrorResponse = "Ha ocurrido un error consulte al administrador de sistemas"
                };
            }

            return response;
        }

        [HttpPut]
        public async Task<ResponseModel> UpdateUsuario(UsuarioUpdate usuario)
        {
            ResponseModel response;

            try
            {
                var usuarioUpdate = mapper.Map<Usuario>(usuario);
                await usuarioService.UpdateUsuario(usuarioUpdate);

                response = new ResponseModel
                {
                    HttpResponse = (int)HttpStatusCode.OK,
                    Response = "Se ha actulizado el usuario exitosamente"
                };
            }
            catch (Exception ex)
            {
                log.LogError(ex, "Ocurrio un error al intentar actualizar");

                response = new ResponseModel
                {
                    HttpResponse = (int)HttpStatusCode.InternalServerError,
                    ErrorResponse = "Ha ocurrido un error consulte al administrador de sistemas"
                };
            }

            return response;
        }

        [HttpDelete("{idUsuario}")]
        public async Task<ResponseModel> DeleteUsuario(int idUsuario)
        {
            ResponseModel response;

            try
            {
                await usuarioService.DeleteUsuario(idUsuario);

                response = new ResponseModel
                {
                    HttpResponse = (int)HttpStatusCode.OK,
                    Response = "Se ha eliminado el usuario exitosamente"
                };
            }
            catch (Exception ex)
            {
                log.LogError(ex, "Ocurrio un error al intentar eliminar");

                response = new ResponseModel
                {
                    HttpResponse = (int)HttpStatusCode.InternalServerError,
                    ErrorResponse = "Ha ocurrido un error consulte al administrador de sistemas"
                };
            }

            return response;
        }
    }
}
