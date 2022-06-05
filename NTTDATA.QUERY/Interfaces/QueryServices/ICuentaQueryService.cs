
using NTTDATA.QUERY.DTOs;
using System.Collections.Generic;

namespace NTTDATA.QUERY.Interfaces.QueryServices
{
    public interface ICuentaQueryService
    {
        List<CuentaQueryDto> ConsultarCuentas(ref string mensaje);
    }
}
