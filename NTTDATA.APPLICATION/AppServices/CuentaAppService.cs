
using NTTDATA.APPLICATION.AppServices.Extensions;
using NTTDATA.APPLICATION.Dtos;
using NTTDATA.APPLICATION.Interfaces.AppServices;
using NTTDATA.DOMAIN.Entities;
using NTTDATA.DOMAIN.Interfaces.Repositories;
using NTTDATA.QUERY.DTOs;
using NTTDATA.QUERY.Interfaces.QueryServices;
using System;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;
using System.Xml;

namespace NTTDATA.APPLICATION.AppServices
{
    public sealed class CuentaAppService : ICuentaAppService
    { 
        private readonly ICuentaQueryService cuentaQueryService;
        private readonly ICuentaRepository cuentaRepository;
        public CuentaAppService(ICuentaRepository cuentaRepository, 
                                ICuentaQueryService cuentaQueryService)
        {
            this.cuentaRepository = cuentaRepository;
            this.cuentaQueryService = cuentaQueryService;
        }
        public List<CuentaQueryDto> ConsultarCuentas()
        {
            try
            {
                string mensaje = null;
                var result = cuentaQueryService.ConsultarCuentas(ref mensaje);
                if (result == null) throw new Exception(mensaje);
                return result;
            }
            catch (Exception ex)
            {
                return null;
            }
        }
        public bool CrearCuenta(ref CuentaAppDto cta, ref string mensaje)
        {
            try
            {
                var cuenta = cta.MapToCuenta(); 
                var result = cuentaRepository.CrearCuenta(cuenta, ref mensaje);
                return result;
            }
            catch (Exception)
            {
                return false;
            }
        }
        public bool ActualizarCuenta(ref CuentaAppDto cta, ref string mensaje)
        {
            try
            {
                var cuenta = cta.MapToCuenta(); 
                var result = cuentaRepository.ActualizarCuenta(cuenta, ref mensaje); 
                return result;
            }
            catch (Exception)
            {
                return false;
            }
        }
        public bool EliminarCuenta(int idcuenta, ref string mensaje)
        {
            try
            { 
                var cuenta = new Cuenta() { IdCuenta = idcuenta };
                var result = cuentaRepository.EliminarCuenta(cuenta, ref mensaje); 
                return result;
            }
            catch (Exception)
            {
                return false;
            }
        }
    }
}
