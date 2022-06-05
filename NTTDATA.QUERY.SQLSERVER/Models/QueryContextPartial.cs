
using Microsoft.EntityFrameworkCore;
using NTTDATA.QUERY.DTOs;

namespace NTTDATA.QUERY.SQLSERVER.Models
{
    public sealed partial class QueryContext
    {
        private DbSet<ClienteQueryDto> ClienteQueryDto { get; set; }
        private DbSet<CuentaQueryDto> CuentaQueryDto { get; set; }
        private DbSet<MovimientoQueryDto> MovimientoQueryDto { get; set; }
        private DbSet<ReporteMovimientoQueryDto> ReporteMovimientoQueryDto { get; set; }
        

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<MovimientoQueryDto>().HasNoKey().ToView(null); 
            modelBuilder.Entity<ClienteQueryDto>().HasNoKey().ToView(null);
            modelBuilder.Entity<CuentaQueryDto>().HasNoKey().ToView(null); 
            modelBuilder.Entity<ReporteMovimientoQueryDto>().HasNoKey().ToView(null); 
        }
    }
}