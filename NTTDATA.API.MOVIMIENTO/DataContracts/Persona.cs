
using System.ComponentModel.DataAnnotations; 

namespace NTTDATA.API.MOVIMIENTO.DataContracts
{
    public abstract class Persona
    {
        [Required]
        public string Nombre { get; set; }
        [Required]
        public string Identificacion { get; set; } 
        public char Genero { get; set; } 
        public byte Edad { get; set; } 
        public string Direccion { get; set; } 
        public string Telefono { get; set; }
    }    
}
