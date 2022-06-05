using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NTTDATA.DOMAIN.Entities
{
    public sealed class Movimiento
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
