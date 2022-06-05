﻿
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
    [Route("/clientes")]
    public class ClienteController : ControllerBase
    {
        private readonly IClienteAppService clienteAppService;

        public ClienteController(IClienteAppService clienteAppService)
        {
            this.clienteAppService = clienteAppService;
        }

        [HttpGet]
        public List<ClienteQueryDto> Consultar()
        {
            try
            {
                var result = clienteAppService.ConsultarClientes();
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
        public IActionResult Crear(Cliente cliente)
        {
            string mensaje = "";
            bool result = false;
            try
            {
                var clientedto = cliente.MapToClienteAppDto();
                result = clienteAppService.CrearCliente(ref clientedto, ref mensaje);
                if (!result) return new ObjectResult(mensaje) { StatusCode = DomainConstants.ObtenerHttpStatusCode(mensaje.Substring(0, 3)) };

                return StatusCode(StatusCodes.Status200OK, "Registro ingresado correctamente");
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Ocurrió un error interno, por favor vuelva a intentar");
            }
        }

        [HttpPut]
        public IActionResult Actualizar(Cliente cliente)
        {
            string mensaje = "";
            bool result = false;
            try
            { 
                var clientedto = cliente.MapToClienteAppDto();
                result = clienteAppService.ActualizarCliente(ref clientedto, ref mensaje);
                if (!result) return new ObjectResult(mensaje) { StatusCode = StatusCodes.Status500InternalServerError };

                return StatusCode(StatusCodes.Status200OK, "Registro actualizado correctamente");
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Ocurrió un error interno, por favor vuelva a intentar");
            }
        }

        [HttpDelete]
        public IActionResult Eliminar(int idcliente)
        {
            string mensaje = "";
            bool result = false;
            try
            { 
                result = clienteAppService.EliminarCliente(idcliente, ref mensaje);
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
