using System.ComponentModel.DataAnnotations;

namespace EventosArtisticos_Manuel.api.DTOS
{
    public class ServiciosDTO
    {
        [MaxLength(15)]
        public string Nombre { get; set; }
        public string Monto { get; set; }
    }
}
