
using NTTDATA.APPLICATION.AppServices.Extensions;
using NTTDATA.APPLICATION.Dtos;
using NTTDATA.APPLICATION.Interfaces.AppServices;
using NTTDATA.DOMAIN.Entities;
using NTTDATA.DOMAIN.Interfaces.Repositories;
using NTTDATA.QUERY.DTOs;
using NTTDATA.QUERY.Interfaces.QueryServices;
using System;
using System.Collections.Generic;

namespace NTTDATA.APPLICATION.AppServices
{
    public sealed class MovimientoAppService: IMovimientoAppService
    {
        private readonly IMovimientoQueryService movimientoQueryService; 
        private readonly IMovimientoRepository movimientoRepository;
         
        public MovimientoAppService(IMovimientoRepository movimientoRepository,
                                    IMovimientoQueryService movimientoQueryService)
        {
            this.movimientoRepository = movimientoRepository;
            this.movimientoQueryService = movimientoQueryService;
        }
        public List<MovimientoQueryDto> ConsultarMovimientos()
        {
            try
            {
                string mensaje = null;
                var result = movimientoQueryService.ConsultarMovimientos(ref mensaje);
                if (result == null) throw new Exception(mensaje);
                return result;
            }
            catch (Exception ex)
            {
                return null;
            }
        }
        public bool CrearMovimiento(ref MovimientoAppDto cta, ref string mensaje)
        {
            try
            {
                var movimiento = cta.MapToMovimiento();
                var result = movimientoRepository.CrearMovimiento(movimiento, ref mensaje);
                return result;
            }
            catch (Exception)
            {
                return false;
            }
        }
        public bool ActualizarMovimiento(ref MovimientoAppDto cta, ref string mensaje)
        {
            try
            {
                var movimiento = cta.MapToMovimiento();
                var result = movimientoRepository.ActualizarMovimiento(movimiento, ref mensaje);
                return result;
            }
            catch (Exception)
            {
                return false;
            }
        }
        public bool EliminarMovimiento(int idmovimiento, ref string mensaje)
        {
            try
            {
                var movimiento = new Movimiento() { IdMovimiento = idmovimiento };
                var result = movimientoRepository.EliminarMovimiento(movimiento, ref mensaje);
                return result;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public List<ReporteMovimientoQueryDto> ConsultarMovimientosXFechas(string FechaInicio, string FechaFin, string IdentificacionCliente)
        {
            try
            {
                string mensaje = null; 
                var result = movimientoQueryService.ConsultarMovimientosXFechas(FechaInicio, FechaFin, IdentificacionCliente, ref mensaje);
                if (result == null) throw new Exception (mensaje); 
                return result;
            }
            catch (Exception )
            { 
                return null;
            }
        }
          
    }
}
