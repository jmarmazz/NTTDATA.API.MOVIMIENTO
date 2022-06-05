using AutoMapper;
using NTTDATA.APPLICATION.Dtos;
using NTTDATA.DOMAIN.Entities; 

namespace NTTDATA.APPLICATION.AppServices.Extensions
{
    public static class AppExtensions
    {
        internal static Cliente MapToCliente(this ClienteAppDto obj)
        {
            var configuration = new MapperConfiguration(cfg => cfg.CreateMap<ClienteAppDto, Cliente>() 
            );
            var mapper = configuration.CreateMapper();
            return mapper.Map<Cliente>(obj);
        }
        internal static Cuenta MapToCuenta(this CuentaAppDto obj)
        {
            var configuration = new MapperConfiguration(cfg => cfg.CreateMap<CuentaAppDto, Cuenta>()
            );
            var mapper = configuration.CreateMapper();
            return mapper.Map<Cuenta>(obj);
        }

        internal static Movimiento MapToMovimiento(this MovimientoAppDto obj)
        {
            var configuration = new MapperConfiguration(cfg => cfg.CreateMap<MovimientoAppDto, Movimiento>()
            );
            var mapper = configuration.CreateMapper();
            return mapper.Map<Movimiento>(obj);
        }
    }
}
