
using NTTDATA.APPLICATION.Dtos;
using NTTDATA.QUERY.DTOs;
using System.Collections.Generic;

namespace NTTDATA.APPLICATION.Interfaces.AppServices
{
    public interface IMovimientoAppService
    {
        List<MovimientoQueryDto> ConsultarMovimientos(); 
        bool CrearMovimiento(ref MovimientoAppDto mov, ref string mensaje);
        bool ActualizarMovimiento(ref MovimientoAppDto mov, ref string mensaje);
        bool EliminarMovimiento(int idmovimiento, ref string mensaje);
        List<ReporteMovimientoQueryDto> ConsultarMovimientosXFechas(string FechaInicio, string FechaFin, string IdentificacionCliente);
    }
}
