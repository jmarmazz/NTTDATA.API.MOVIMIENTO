
using Microsoft.Extensions.DependencyInjection;
using NTTDATA.QUERY.DTOs;
using NTTDATA.QUERY.Interfaces.QueryServices;
using NTTDATA.QUERY.SQLSERVER.Models;
using System;
using System.Collections.Generic;

namespace NTTDATA.QUERY.SQLSERVER.QueryServices
{
    public sealed class MovimientoQueryService : BaseQueryService, IMovimientoQueryService
    {
        public MovimientoQueryService(IServiceScopeFactory serviceScopeFactory) : base(serviceScopeFactory)
        {
        }

        public List<MovimientoQueryDto> ConsultarMovimientos(ref string mensaje)
        {
            try
            {
                using (var scope = serviceScopeFactory.CreateScope())
                {
                    using (var QueryContext = scope.ServiceProvider.GetRequiredService<QueryContext>())
                    {
                        var result = QueryContext.ConsultarMovimientos();
                        if (result == null) return new List<MovimientoQueryDto>();
                        return result;
                    };
                };
            }
            catch (Exception ex)
            {
                mensaje = $"ERROR CONSULTANDO MOVIMIENTOS. EX: {ex.Message}";
                return null;
            }
        }

        public List<ReporteMovimientoQueryDto> ConsultarMovimientosXFechas(string FechaInicio, string FechaFin, string IdentificacionCliente, ref string mensaje)
        {
            try
            {
                using (var scope = serviceScopeFactory.CreateScope())
                {
                    using (var QueryContext = scope.ServiceProvider.GetRequiredService<QueryContext>())
                    {
                        var result = QueryContext.ConsultarMovimientosXFechas(FechaInicio, FechaFin, IdentificacionCliente);
                        if (result == null) return new List<ReporteMovimientoQueryDto>();
                        return result;
                    };
                };
            }
            catch (Exception ex)
            {
                mensaje = $"ERROR CONSULTANDO MOVIMIENTOS. EX: {ex.Message}";
                return null;
            }
        }
         
    }
}
