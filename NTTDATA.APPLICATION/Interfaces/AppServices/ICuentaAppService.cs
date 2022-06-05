
using NTTDATA.APPLICATION.Dtos;
using NTTDATA.QUERY.DTOs;
using System.Collections.Generic;

namespace NTTDATA.APPLICATION.Interfaces.AppServices
{
    public interface ICuentaAppService
    {
        List<CuentaQueryDto> ConsultarCuentas();
        bool CrearCuenta(ref CuentaAppDto cta, ref string mensaje);
        bool ActualizarCuenta(ref CuentaAppDto cta, ref string mensaje);
        bool EliminarCuenta(int idCuenta, ref string mensaje);
    }
}
