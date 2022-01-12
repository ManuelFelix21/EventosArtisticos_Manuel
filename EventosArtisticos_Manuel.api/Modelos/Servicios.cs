using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
using EventosArtisticos_Manuel.api.DTOS;


namespace EventosArtisticos_Manuel.api.Modelos
{
    public class Servicios

    {
        public Servicios()
        {

        }

        public Servicios(ServiciosDTO nuevo)
        {
            this.Nombre = nuevo.Nombre;
            this.Monto = nuevo.Monto;
            this.Activo = true;
        }

        [Key]
        public int IdServicios { get; set; }


        [MaxLength(30)]
        [Required]
        public String Nombre { get; set; }
       
        [Required]
        public string Monto { get; set; }

        [Required]
        public bool Activo { get; set; }

        [ForeignKey("IdCategoria")]
        public Categoria Categoria { get; set; }


        public virtual List<Cliente> Cliente { get; set; }
    }   
}
