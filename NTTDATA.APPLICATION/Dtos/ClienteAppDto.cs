

namespace NTTDATA.APPLICATION.Dtos
{
    public sealed class ClienteAppDto
    {
        public int IdCliente { get; set; }
        public string Clave { get; set; }
        public string Nombre { get; set; }
        public string Identificacion { get; set; }
        public char Genero { get; set; }
        public byte Edad { get; set; }
        public string Direccion { get; set; }
        public string Telefono { get; set; }
        public bool Estado { get; set; }
    } 

}
