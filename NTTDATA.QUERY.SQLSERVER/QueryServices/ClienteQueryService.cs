
using Microsoft.Extensions.DependencyInjection;
using NTTDATA.QUERY.DTOs;
using NTTDATA.QUERY.Interfaces.QueryServices;
using NTTDATA.QUERY.SQLSERVER.Models;
using System;
using System.Collections.Generic;

namespace NTTDATA.QUERY.SQLSERVER.QueryServices
{
    public sealed class ClienteQueryService : BaseQueryService, IClienteQueryService
    {
        public ClienteQueryService(IServiceScopeFactory serviceScopeFactory) : base(serviceScopeFactory)
        {
        }

        public List<ClienteQueryDto> ConsultarClientes( ref string mensaje)
        {
            try
            {
                using (var scope = serviceScopeFactory.CreateScope())
                {
                    using (var QueryContext = scope.ServiceProvider.GetRequiredService<QueryContext>())
                    {
                        var result = QueryContext.ConsultarClientes();
                        if (result == null) return new List<ClienteQueryDto>();
                        return result;
                    };
                };
            }
            catch (Exception ex)
            {
                mensaje = $"ERROR CONSULTANDO CLIENTES. EX: {ex.Message}";
                return null;
            }
        }
         
    }
}
