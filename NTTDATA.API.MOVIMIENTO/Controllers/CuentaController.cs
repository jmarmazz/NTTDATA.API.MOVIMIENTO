
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NTTDATA.API.MOVIMIENTO.DataContracts;
using NTTDATA.API.MOVIMIENTO.Extensions;
using NTTDATA.APPLICATION.Interfaces.AppServices;
using NTTDATA.DOMAIN.Constants;
using NTTDATA.QUERY.DTOs;
using System;
using System.Collections.Generic;
using System.Net;

namespace NTTDATA.API.MOVIMIENTO.Controllers
{
    [ApiController]
    [Route("/cuentas")]
    public class CuentaController : ControllerBase
    {
        private readonly ICuentaAppService cuentaAppService;

        public CuentaController(ICuentaAppService cuentaAppService)
        {
            this.cuentaAppService = cuentaAppService;
        }

        [HttpGet]
        public List<CuentaQueryDto> Consultar()
        {
            try
            {
                var result = cuentaAppService.ConsultarCuentas();
                if (result == null) { throw new Exception(null); }
                Response.StatusCode = StatusCodes.Status200OK;
                return result;
            }
            catch (Exception ex)
            {
                Response.StatusCode = StatusCodes.Status500InternalServerError;
                return null;
            }
        }

        [HttpPost]
        public IActionResult Crear(Cuenta cuenta)
        {
            string mensaje = "";
            bool result = false;
            try
            {
                var cuentadto = cuenta.MapToCuentaAppDto();
                result = cuentaAppService.CrearCuenta(ref cuentadto, ref mensaje);
                if (!result) return new ObjectResult(mensaje) { StatusCode = DomainConstants.ObtenerHttpStatusCode(mensaje.Substring(0, 3)) };

                return StatusCode(StatusCodes.Status200OK, "Registro ingresado correctamente");
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Ocurrió un error interno, por favor vuelva a intentar");
            }
        }

        [HttpPut]
        public IActionResult Actualizar(Cuenta cuenta)
        {
            string mensaje = "";
            bool result = false;
            try
            { 
                var cuentadto = cuenta.MapToCuentaAppDto();
                result = cuentaAppService.ActualizarCuenta(ref cuentadto, ref mensaje);
                if (!result) return new ObjectResult(mensaje) { StatusCode = StatusCodes.Status500InternalServerError };

                return StatusCode(StatusCodes.Status200OK, "Registro actualizado correctamente");
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Ocurrió un error interno, por favor vuelva a intentar");
            }
        }

        [HttpDelete]
        public IActionResult Eliminar(int idcuenta)
        {
            string mensaje = "";
            bool result = false;
            try
            { 
                result = cuentaAppService.EliminarCuenta(idcuenta, ref mensaje);
                if (!result) return new ObjectResult(mensaje) { StatusCode = StatusCodes.Status500InternalServerError };

                return StatusCode(StatusCodes.Status200OK, "Registro eliminado correctamente");
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Ocurrió un error interno, por favor vuelva a intentar");
            }
        }
    }
}
