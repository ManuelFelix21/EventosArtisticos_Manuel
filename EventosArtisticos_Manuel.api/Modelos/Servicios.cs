using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;


namespace EventosArtisticos_Manuel.api.Modelos
{
    public class Servicios

    {

        [Key]
        public int IdServicios { get; set; }


        [MaxLength(30)]
        [Required]
        public String Nombre { get; set; }
       
        [Required]
        public decimal Precio { get; set; }

        [Required]
        public string TipoDeServicio { get; set; }

        [Required]
        public bool Activo { get; set; }

       

        [ForeignKey("IdCategoria")]
        public virtual Categoria Categoria { get; set; }

        

    }   
}
