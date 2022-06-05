

namespace NTTDATA.APPLICATION.Dtos
{
    public sealed class CuentaAppDto
    {
        public int IdCuenta { get; set; }
        public int IdCliente { get; set; }
        public string NumeroCuenta { get; set; }
        public byte TipoCuenta { get; set; }
        public decimal SaldoInicial { get; set; }
        public bool Estado { get; set; }
    } 

}
