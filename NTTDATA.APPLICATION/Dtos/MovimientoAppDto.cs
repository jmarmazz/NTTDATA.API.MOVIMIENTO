

using System;

namespace NTTDATA.APPLICATION.Dtos
{
    public sealed class MovimientoAppDto
    {
        public int IdMovimiento { get; set; }
        public int IdCuenta { get; set; }
        public string NumeroCuenta { get; set; }
        public DateTime Fecha { get; set; }
        public byte TipoMovimiento { get; set; }
        public string Descripcion { get; set; }
        public decimal Valor { get; set; }
        public decimal Saldo { get; set; }
        public bool Estado { get; set; }
    } 

}
