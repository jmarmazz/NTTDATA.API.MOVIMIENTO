
using Microsoft.Extensions.DependencyInjection;
using NTTDATA.QUERY.DTOs;
using NTTDATA.QUERY.Interfaces.QueryServices;
using NTTDATA.QUERY.SQLSERVER.Models;
using System;
using System.Collections.Generic;

namespace NTTDATA.QUERY.SQLSERVER.QueryServices
{
    public sealed class CuentaQueryService : BaseQueryService, ICuentaQueryService
    {
        public CuentaQueryService(IServiceScopeFactory serviceScopeFactory) : base(serviceScopeFactory)
        {
        }

        public List<CuentaQueryDto> ConsultarCuentas(ref string mensaje)
        {
            try
            {
                using (var scope = serviceScopeFactory.CreateScope())
                {
                    using (var QueryContext = scope.ServiceProvider.GetRequiredService<QueryContext>())
                    {
                        var result = QueryContext.ConsultarCuentas();
                        if (result == null) return new List<CuentaQueryDto>();
                        return result;
                    };
                };
            }
            catch (Exception ex)
            {
                mensaje = $"ERROR CONSULTANDO CUENTAS. EX: {ex.Message}";
                return null;
            }
        }
         
    }
}
