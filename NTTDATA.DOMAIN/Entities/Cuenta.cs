using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NTTDATA.DOMAIN.Entities
{
    public sealed class Cuenta
    {
        public int IdCuenta { get; set; }
        public int IdCliente { get; set; }
        public string NumeroCuenta { get; set; }
        public byte TipoCuenta { get; set; }
        public decimal SaldoInicial { get; set; } 
        public bool Estado { get; set; }
    } 
}
