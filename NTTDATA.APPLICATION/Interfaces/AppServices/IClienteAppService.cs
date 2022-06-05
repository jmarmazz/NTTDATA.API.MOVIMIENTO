
using NTTDATA.APPLICATION.Dtos;
using NTTDATA.QUERY.DTOs;
using System.Collections.Generic;

namespace NTTDATA.APPLICATION.Interfaces.AppServices
{
    public interface IClienteAppService
    {
        bool CrearCliente(ref ClienteAppDto cli, ref string mensaje);
        bool ActualizarCliente(ref ClienteAppDto cli, ref string mensaje);
        bool EliminarCliente(int idcliente, ref string mensaje);
        List<ClienteQueryDto> ConsultarClientes();
    }
}
