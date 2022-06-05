
using NTTDATA.APPLICATION.AppServices.Extensions;
using NTTDATA.APPLICATION.Dtos;
using NTTDATA.APPLICATION.Interfaces.AppServices;
using NTTDATA.DOMAIN.Entities;
using NTTDATA.DOMAIN.Interfaces.Repositories;
using NTTDATA.QUERY.DTOs;
using NTTDATA.QUERY.Interfaces.QueryServices;
using System;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;
using System.Xml;

namespace NTTDATA.APPLICATION.AppServices
{
    public sealed class ClienteAppService : IClienteAppService
    { 
        private readonly IClienteQueryService clienteQueryService;
        private readonly IClienteRepository clienteRepository;
        public ClienteAppService(IClienteRepository clienteRepository, 
                                IClienteQueryService clienteQueryService)
        {
            this.clienteRepository = clienteRepository;
            this.clienteQueryService = clienteQueryService;
        }
        public List<ClienteQueryDto> ConsultarClientes()
        {
            try
            {
                string mensaje = null;
                var result = clienteQueryService.ConsultarClientes(ref mensaje);
                if (result == null) throw new Exception(mensaje);
                return result;
            }
            catch (Exception )
            {
                return null;
            }
        }

        public bool CrearCliente(ref ClienteAppDto cli, ref string mensaje)
        {
            try
            {
                var cliente = cli.MapToCliente(); 
                var result = clienteRepository.CrearCliente(cliente, ref mensaje);
                return result;
            }
            catch (Exception)
            {
                return false;
            }
        }
        public bool ActualizarCliente(ref ClienteAppDto cli, ref string mensaje)
        {
            try
            {
                var cliente = cli.MapToCliente(); 
                var result = clienteRepository.ActualizarCliente(cliente, ref mensaje); 
                return result;
            }
            catch (Exception)
            {
                return false;
            }
        }
        public bool EliminarCliente(int idcliente, ref string mensaje)
        {
            try
            { 
                var cliente = new Cliente() { IdCliente = idcliente };
                var result = clienteRepository.EliminarCliente(cliente, ref mensaje); 
                return result;
            }
            catch (Exception)
            {
                return false;
            }
        }
    }
}
