
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
    public sealed class MovimientoRepository : BaseRepository, IMovimientoRepository
    {
        public MovimientoRepository(IServiceScopeFactory serviceScopeFactory) : base(serviceScopeFactory)
        {
        }

        public bool CrearMovimiento (Movimiento movimiento, ref string mensaje)
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
                                CmdContext.RegistrarMovimiento(movimiento, (byte)OperacionCRUD.Insertar);

                                trans.Commit();
                                mensaje = "REGISTRO Movimiento EN BD - EXITOSO";
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

        public bool ActualizarMovimiento(Movimiento movimiento, ref string mensaje)
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
                                CmdContext.RegistrarMovimiento(movimiento, (byte)OperacionCRUD.Actualizar);

                                trans.Commit();
                                mensaje = "ACTUALIZAR Movimiento EN BD - EXITOSO";
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

        public bool EliminarMovimiento(Movimiento movimiento, ref string mensaje)
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
                                CmdContext.RegistrarMovimiento(movimiento, (byte)OperacionCRUD.Eliminar);

                                trans.Commit();
                                mensaje = "ELIMINAR Movimiento EN BD - EXITOSO";
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
