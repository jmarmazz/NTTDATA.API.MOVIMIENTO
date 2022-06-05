

namespace NTTDATA.API.MOVIMIENTO.DataContracts
{
    public sealed class Cuenta
    {
        public int IdCuenta { get; set; }
        public int IdCliente { get; set; }
        public string NumeroCuenta { get; set; }
        public byte TipoCuenta { get; set; }
        public decimal SaldoInicial { get; set; } 
    } 

}
