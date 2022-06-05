
using Microsoft.EntityFrameworkCore;
using NTTDATA.QUERY.DTOs;
using System.Collections.Generic;
using System.Linq;

namespace NTTDATA.QUERY.SQLSERVER.Models
{

    public sealed partial class QueryContext
    {
        internal List<ReporteMovimientoQueryDto> ConsultarMovimientosXFechas(string FechaInicio, string FechaFin, string IdentificacionCliente)
        {
            return ReporteMovimientoQueryDto.FromSqlRaw("QRY_MovimientosxFechas @p0,@p1,@p2", FechaInicio, FechaFin, IdentificacionCliente).ToList();
        }
    }
}
