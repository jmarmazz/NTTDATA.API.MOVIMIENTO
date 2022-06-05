using System;
using System.ComponentModel.DataAnnotations;
using System.Text; 

namespace NTTDATA.API.MOVIMIENTO.DataContracts
{
    public sealed class Movimiento
    {
        [Required]
        public string NumeroCuenta { get; set; } 
        [Required]
        public byte TipoMovimiento { get; set; }
        [Required]
        public string Descripcion { get; set; }
        [Required]
        public decimal Valor { get; set; }

    }
}
