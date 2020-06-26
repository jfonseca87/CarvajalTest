using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.Extensions.Logging;
using Moq;
using PruebaCarvajal.API.Controllers;
using PruebaCarvajal.API.Models;
using PruebaCarvajal.Domain;
using PruebaCarvajal.Service.Interfaces;
using Xunit;

namespace PruebaCarvajal.APITest
{
    public class TipoDocumentoControllerTest
    {
        [Fact]
        public void GetTODOsCorrectFlow()
        {
            var mockLogger = new Mock<ILogger<TipoDocumentoController>>();
            ILogger<TipoDocumentoController> logger = mockLogger.Object;

            var mockAutoMapper = new Mock<IMapper>();
            IMapper mapper = mockAutoMapper.Object;

            var mockService = new Mock<ITipoDocumentoService>();
            mockService.Setup(x => x.GetTiposDocumento()).Returns(Task.FromResult(this.GetTiposDocumento()));

            TipoDocumentoController tipoDocumentoController = new TipoDocumentoController(logger, mapper, mockService.Object);
            var result = tipoDocumentoController.GetTiposDocumento();

            Assert.NotNull(result);
            var response = Assert.IsType<ResponseModel>(result.Result);
            Assert.Equal(200, response.HttpResponse);
        }

        [Fact]
        public void GetTODOsIncorrectFlow()
        {
            var mockLogger = new Mock<ILogger<TipoDocumentoController>>();
            ILogger<TipoDocumentoController> logger = mockLogger.Object;

            var mockAutoMapper = new Mock<IMapper>();
            IMapper mapper = mockAutoMapper.Object;

            var mockService = new Mock<ITipoDocumentoService>();
            mockService.Setup(x => x.GetTiposDocumento()).Throws(new Exception());

            TipoDocumentoController tipoDocumentoController = new TipoDocumentoController(logger, mapper, mockService.Object);
            var result = tipoDocumentoController.GetTiposDocumento();

            Assert.NotNull(result);
            var response = Assert.IsType<ResponseModel>(result.Result);
            Assert.Equal(500, response.HttpResponse);
        }

        private IEnumerable<TipoDocumento> GetTiposDocumento()
        {
            return new List<TipoDocumento>
            {
                new TipoDocumento
                {
                    IdTipoDocumento = 1,
                    NomTipoDocumento = "CC"
                },
                new TipoDocumento
                {
                    IdTipoDocumento = 1,
                    NomTipoDocumento = "TI"
                }
            };
        }

        private Exception GetWrongMockData()
        {
            throw new Exception("Ocurrio un error al intentar traer la data");
        }
    }
}
