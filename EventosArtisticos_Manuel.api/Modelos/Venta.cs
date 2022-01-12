using EventosArtisticos_Manuel.api.DTOS;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EventosArtisticos_Manuel.api.Modelos
{
    public class Venta
    {

        public Venta()
        {

        }

        public Venta(VentaDTO nuevo)
        {
            this.Monto = nuevo.Monto;
            this.DescripcionServicio = nuevo.DescripcionServicio;
            this.NombreCliente = nuevo.NombreCliente;
            this.Activo = true;
        }

        [Key]
        public int IdVenta { get; set; }
        [Required]
        [MaxLength(13)]
        public string Monto { get; set; }
        [MaxLength(90)]
        public string DescripcionServicio { get; set; }
        [MaxLength(10)]
        public string NombreCliente { get; set; }
        [MaxLength(120)]
        public bool Activo { get; set; }
        
        [ForeignKey("IdCliente")]
        public Cliente Cliente { get; set; }
    }
}
