

using System.ComponentModel.DataAnnotations;

namespace NTTDATA.API.MOVIMIENTO.DataContracts
{
    public sealed class Cliente : Persona
    {
        public int IdCliente { get; set; }
        [Required]
        public string Clave { get; set; } 
    } 

}
