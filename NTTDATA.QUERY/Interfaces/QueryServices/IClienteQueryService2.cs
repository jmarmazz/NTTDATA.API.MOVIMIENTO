
using NTTDATA.QUERY.DTOs;
using System.Collections.Generic;

namespace NTTDATA.QUERY.Interfaces.QueryServices
{
    public interface IClienteQueryService
    {
        List<ClienteQueryDto> ConsultarClientes(ref string mensaje);
    }
}
