
using Microsoft.EntityFrameworkCore.Storage;
using Microsoft.Extensions.DependencyInjection;
using NTTDATA.DOMAIN.Entities;
using NTTDATA.DOMAIN.Interfaces.Repositories;
using NTTDATA.INFRA.REPOSITORY.SQLSERVER.Models;
using System;
using System.Collections.Generic;
using System.Text;
using static NTTDATA.APPLICATION.Constants.AppConstants;

namespace NTTDATA.INFRA.REPOSITORY.SQLSERVER.Repositories
{
    public sealed class CuentaRepository : BaseRepository, ICuentaRepository
    {
        public CuentaRepository(IServiceScopeFactory serviceScopeFactory) : base(serviceScopeFactory)
        {
        }

        public bool CrearCuenta (Cuenta cuenta, ref string mensaje)
        { 
            try
            {
                using (var scope = serviceScopeFactory.CreateScope())
                {
                    using (var CmdContext = scope.ServiceProvider.GetRequiredService<CmdContext>())
                    {
                        using (IDbContextTransaction trans = CmdContext.Database.BeginTransaction())
                        {
                            try
                            { 
                                CmdContext.RegistrarCuenta(cuenta, (byte)OperacionCRUD.Insertar);

                                trans.Commit();
                                mensaje = "REGISTRO Cuenta EN BD - EXITOSO";
                               return true;
                            }
                            catch (Exception ex)
                            { 
                                trans.Rollback();
                                throw ex;
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                mensaje = ex.Message;
                return false;
            }
        }

        public bool ActualizarCuenta(Cuenta cuenta, ref string mensaje)
        {
            try
            {
                using (var scope = serviceScopeFactory.CreateScope())
                {
                    using (var CmdContext = scope.ServiceProvider.GetRequiredService<CmdContext>())
                    {
                        using (IDbContextTransaction trans = CmdContext.Database.BeginTransaction())
                        {
                            try
                            {
                                CmdContext.RegistrarCuenta(cuenta, (byte)OperacionCRUD.Actualizar);

                                trans.Commit();
                                mensaje = "ACTUALIZAR Cuenta EN BD - EXITOSO";
                                return true;
                            }
                            catch (Exception ex)
                            {
                                trans.Rollback();
                                throw ex;
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public bool EliminarCuenta(Cuenta cuenta, ref string mensaje)
        {
            try
            {
                using (var scope = serviceScopeFactory.CreateScope())
                {
                    using (var CmdContext = scope.ServiceProvider.GetRequiredService<CmdContext>())
                    {
                        using (IDbContextTransaction trans = CmdContext.Database.BeginTransaction())
                        {
                            try
                            {
                                CmdContext.RegistrarCuenta(cuenta, (byte)OperacionCRUD.Eliminar);

                                trans.Commit();
                                mensaje = "ELIMINAR Cuenta EN BD - EXITOSO";
                                return true;
                            }
                            catch (Exception ex)
                            {
                                trans.Rollback();
                                throw ex;
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                return false;
            }
        }
    }
}
