
using Microsoft.EntityFrameworkCore;
using NTTDATA.QUERY.DTOs;
using System.Collections.Generic;
using System.Linq;

namespace NTTDATA.QUERY.SQLSERVER.Models
{

    public sealed partial class QueryContext
    {
        internal List<MovimientoQueryDto> ConsultarMovimientos()
        {
            return MovimientoQueryDto.FromSqlRaw("QRY_Movimientos ").ToList();
        }
    }
}
