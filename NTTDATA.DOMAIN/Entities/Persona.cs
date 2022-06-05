using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NTTDATA.DOMAIN.Entities
{
    public abstract class Persona
    { 
        public string Nombre { get; set; }
        public string Identificacion { get; set; }
        public char Genero { get; set; }
        public byte Edad { get; set; }
        public string Direccion { get; set; }
        public string Telefono { get; set; }
    }    
}
