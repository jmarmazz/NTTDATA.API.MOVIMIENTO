using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NTTDATA.DOMAIN.Entities
{
    public sealed class Cliente : Persona
    {
        public int IdCliente { get; set; } 
        public string Clave { get; set; } 
        public bool Estado { get; set; }
    } 

}
