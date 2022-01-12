using System.ComponentModel.DataAnnotations;

namespace EventosArtisticos_Manuel.api.DTOS
{
    public class ClienteDTO
    {
        [MaxLength(15)]
        public string Nombre { get; set; }
        [MaxLength(10)]
        public string Telefono { get; set; }

        [MaxLength(120)]
        public string Correo { get; set; }

        [MaxLength(250)]
        public string Direccion { get; set; }
    }
}
