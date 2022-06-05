using NTTDATA.DOMAIN.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NTTDATA.DOMAIN.Interfaces.Repositories
{ 
    public interface IClienteRepository
    {
        bool CrearCliente(Cliente cliente, ref string mensaje);
        bool ActualizarCliente(Cliente cliente, ref string mensaje);
        bool EliminarCliente(Cliente cliente, ref string mensaje);
    }
}
