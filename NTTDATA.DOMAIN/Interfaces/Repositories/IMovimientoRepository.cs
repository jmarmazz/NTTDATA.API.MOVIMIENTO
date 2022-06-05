using NTTDATA.DOMAIN.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NTTDATA.DOMAIN.Interfaces.Repositories
{ 
    public interface IMovimientoRepository
    {
        bool CrearMovimiento(Movimiento movimiento, ref string mensaje);
        bool ActualizarMovimiento(Movimiento movimiento, ref string mensaje);
        bool EliminarMovimiento(Movimiento movimiento, ref string mensaje);
    }
}
