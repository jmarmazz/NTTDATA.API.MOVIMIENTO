
using NTTDATA.QUERY.DTOs;
using System.Collections.Generic;

namespace NTTDATA.QUERY.Interfaces.QueryServices
{
    public interface IMovimientoQueryService
    {
        List<MovimientoQueryDto> ConsultarMovimientos(ref string mensaje);
        List<ReporteMovimientoQueryDto> ConsultarMovimientosXFechas(string FechaInicio, string FechaFin, string IdentificacionCliente, ref string mensaje);
    }
}
