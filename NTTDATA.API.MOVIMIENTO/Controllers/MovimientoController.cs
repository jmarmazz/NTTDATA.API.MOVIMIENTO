
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NTTDATA.API.MOVIMIENTO.DataContracts;
using NTTDATA.API.MOVIMIENTO.Extensions;
using NTTDATA.APPLICATION.Interfaces.AppServices;
using NTTDATA.DOMAIN.Constants;
using NTTDATA.QUERY.DTOs;
using System;
using System.Collections.Generic;

namespace NTTDATA.API.MOVIMIENTO.Controllers
{
    [ApiController]
    [Route("/movimientos")]
    public class MovimientoController : ControllerBase
    {
        private readonly IMovimientoAppService movimientoAppService;

        public MovimientoController(IMovimientoAppService movimientoAppService)
        {
            this.movimientoAppService = movimientoAppService;
        }

        [HttpGet]
        public List<MovimientoQueryDto> Consultar()
        {
            try
            {
                var result = movimientoAppService.ConsultarMovimientos();
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
        public IActionResult Crear(Movimiento movimiento)
        {
            string mensaje = "";
            bool result = false;
            try
            {
                var movimientodto = movimiento.MapToMovimientoAppDto();
                result = movimientoAppService.CrearMovimiento(ref movimientodto, ref mensaje);
                if (!result) return new ObjectResult(mensaje) { StatusCode = DomainConstants.ObtenerHttpStatusCode(mensaje.Substring(0,3)) };

                return StatusCode(StatusCodes.Status200OK, "Registro ingresado correctamente");
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Ocurrió un error interno, por favor vuelva a intentar");
            }
        }

        [HttpPut]
        public IActionResult Actualizar(Movimiento movimiento)
        {
            string mensaje = "";
            bool result = false;
            try
            {
                var movimientodto = movimiento.MapToMovimientoAppDto();
                result = movimientoAppService.ActualizarMovimiento(ref movimientodto, ref mensaje);
                if (!result) return new ObjectResult(mensaje) { StatusCode = StatusCodes.Status500InternalServerError };

                return StatusCode(StatusCodes.Status200OK, "Registro actualizado correctamente");
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Ocurrió un error interno, por favor vuelva a intentar");
            }
        }

        [HttpDelete]
        public IActionResult Eliminar(int idmovimiento)
        {
            string mensaje = "";
            bool result = false;
            try
            {
                result = movimientoAppService.EliminarMovimiento(idmovimiento, ref mensaje);
                if (!result) return new ObjectResult(mensaje) { StatusCode = StatusCodes.Status500InternalServerError };

                return StatusCode(StatusCodes.Status200OK, "Registro eliminado correctamente");
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Ocurrió un error interno, por favor vuelva a intentar");
            }
        }

        [Route("/reportes")]
        [HttpGet] 
        public List<ReporteMovimientoQueryDto> ConsultarMovimientosXFechas(DateTime FechaInicio, DateTime FechaFin, string IdentificacionCliente)
        {  
            try
            {
                var fechaInicio = FechaInicio.ToString("yyyy-MM-dd");
                var fechaFin = FechaFin.ToString("yyyy-MM-dd");
                var result = movimientoAppService.ConsultarMovimientosXFechas(fechaInicio, fechaFin, IdentificacionCliente);
                Response.StatusCode = StatusCodes.Status200OK;
                return result;
            }
            catch (Exception ex)
            {
                Response.StatusCode = StatusCodes.Status500InternalServerError;
                return null;
            }
        }
    }
}
