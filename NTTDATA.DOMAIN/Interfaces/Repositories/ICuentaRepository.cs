using NTTDATA.DOMAIN.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NTTDATA.DOMAIN.Interfaces.Repositories
{ 
    public interface ICuentaRepository
    {
        bool CrearCuenta(Cuenta cuenta, ref string mensaje);
        bool ActualizarCuenta(Cuenta cuenta, ref string mensaje);
        bool EliminarCuenta(Cuenta cuenta, ref string mensaje);
    }
}
