using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace NTTDATA.QUERY.DTOs
{
    public sealed class ReporteMovimientoQueryDto
    { 
        public int IdMovimiento { get; set; }
        public DateTime Fecha { get; set; }
        public string Cliente { get; set; }
        public string NumeroCuenta { get; set; }
        public string TipoCuenta { get; set; }
        [Column(TypeName = "decimal(18,2)")]
        public decimal SaldoInicial { get; set; }
        public string Descripcion { get; set; }
        [Column(TypeName = "decimal(18,2)")]
        public decimal Movimiento { get; set; }
        [Column(TypeName = "decimal(18,2)")]
        public decimal SaldoDisponible { get; set; }
        public bool Estado { get; set; }
    }
}
