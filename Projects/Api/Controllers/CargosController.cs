using CargoManager.Api.Platform.Http.Filters;
using CargoManager.Application.Contracts.Services;
using CargoManager.Application.DTOs;
using System;
using System.Web.Http;

namespace CargoManager.Api.Controllers
{
    public class CargosController : ApiController
    {

        private readonly ICargoService cargoService;

        public CargosController(ICargoService cargoService)
        {
            if (cargoService == null)
            {
                throw new ArgumentNullException("cargoService");
            }

            this.cargoService = cargoService;
        }

        [HttpGet]
        [ValidateModel]
        public IHttpActionResult GetCargos([FromUri]GetCargosInputDTO dto)
        {
            return Ok(cargoService.GetCargos(dto));
        }

        [HttpPost]
        [ValidateModel]
        public IHttpActionResult SearchCargos([FromBody]GetCargosInputDTO dto)
        {
            return Ok(cargoService.GetCargos(dto));
        }
    }
}