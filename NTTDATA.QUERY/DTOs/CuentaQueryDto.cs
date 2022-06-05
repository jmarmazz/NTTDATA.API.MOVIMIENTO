
namespace NTTDATA.QUERY.DTOs
{
    public sealed class CuentaQueryDto
    {
        public int IdCuenta { get; set; }
        public string NumeroCuenta { get; set; }
        public string Cliente { get; set; }
        public string Tipo { get; set; }
        public decimal SaldoInicial { get; set; }
        public bool Estado { get; set; }
    }
}
