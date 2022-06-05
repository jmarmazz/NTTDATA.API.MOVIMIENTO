using AutoMapper;
using NTTDATA.API.MOVIMIENTO.DataContracts;
using NTTDATA.APPLICATION.Dtos; 

namespace NTTDATA.API.MOVIMIENTO.Extensions
{
    public static class AppExtensions
    {
        internal static ClienteAppDto MapToClienteAppDto(this Cliente obj)
        {
            var configuration = new MapperConfiguration(cfg => cfg.CreateMap<Cliente, ClienteAppDto>() 
            );
            var mapper = configuration.CreateMapper();
            return mapper.Map<ClienteAppDto>(obj);
        }

        internal static CuentaAppDto MapToCuentaAppDto(this Cuenta obj)
        {
            var configuration = new MapperConfiguration(cfg => cfg.CreateMap<Cuenta, CuentaAppDto>()
            );
            var mapper = configuration.CreateMapper();
            return mapper.Map<CuentaAppDto>(obj);
        }

        internal static MovimientoAppDto MapToMovimientoAppDto(this Movimiento obj)
        {
            var configuration = new MapperConfiguration(cfg => cfg.CreateMap<Movimiento, MovimientoAppDto>()
            );
            var mapper = configuration.CreateMapper();
            return mapper.Map<MovimientoAppDto>(obj);
        }
        
    }
}
