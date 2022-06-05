using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace NTTDATA.QUERY.DTOs
{
    public sealed class MovimientoQueryDto
    { 
        public int IdMovimiento { get; set; }
        public int IdCuenta { get; set; }
        public string NumeroCuenta { get; set; }
        public DateTime Fecha { get; set; }
        public byte TipoMovimiento { get; set; }
        public string Descripcion { get; set; }
        [Column(TypeName = "decimal(18,2)")]
        public decimal SaldoInicial { get; set; }
        [Column(TypeName = "decimal(18,2)")]
        public decimal Valor { get; set; }
        [Column(TypeName = "decimal(18,2)")]
        public decimal SaldoDisponible { get; set; }
        public bool Estado { get; set; }
    }
}
