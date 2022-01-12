using System.ComponentModel.DataAnnotations;

namespace EventosArtisticos_Manuel.api.DTOS
{
    public class VentaDTO
    {
        public string Monto { get; set; }
        [MaxLength(90)]
        public string DescripcionServicio { get; set; }
        [MaxLength(10)]
        public string NombreCliente { get; set; }
        
    }
}
