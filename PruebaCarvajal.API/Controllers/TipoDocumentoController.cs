using System;
using System.Collections.Generic;
using System.Net;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using PruebaCarvajal.API.Models;
using PruebaCarvajal.API.Models.DTOs;
using PruebaCarvajal.Service.Interfaces;

namespace PruebaCarvajal.API.Controllers
{
    [ApiController]
    [Route("api/TipoDocumento")]
    public class TipoDocumentoController : ControllerBase
    {
        private ILogger<TipoDocumentoController> log;
        private readonly IMapper mapper;
        private readonly ITipoDocumentoService tipoDocumentoService;

        public TipoDocumentoController(ILogger<TipoDocumentoController> _log, IMapper _mapper, ITipoDocumentoService _tipoDocumentoService)
        {
            log = _log;
            mapper = _mapper;
            tipoDocumentoService = _tipoDocumentoService;
        }

        [HttpGet]
        public async Task<ResponseModel> GetTiposDocumento()
        {
            ResponseModel response;

            try
            {
                var tiposDocumento = await tipoDocumentoService.GetTiposDocumento();
                var tiposDocumentoResponse = mapper.Map<List<TipoDocumentoDTO>>(tiposDocumento);

                response = new ResponseModel
                {
                    HttpResponse = (int)HttpStatusCode.OK,
                    Response = tiposDocumentoResponse
                };
            }
            catch (Exception ex)
            {
                log.LogError(ex, "Ocurrio un error al intentar consultar los tipos de documentos");

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
