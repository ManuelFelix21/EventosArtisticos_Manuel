using EventosArtisticos_Manuel.api.DTOS;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;


namespace EventosArtisticos_Manuel.api.Modelos
{
    public class Categoria
    {
        public Categoria()
        {

        }

        public Categoria(CategoriaDTO nuevo)
        {
            this.Nombre = nuevo.Nombre;
            this.Activo = true;
        }

        [Key]
        public int IdCategoria { get; set; }



        [Required]
        [MaxLength(50)]
        public string Nombre { get; set; }

        [Required]
        public bool Activo { get; set; }

        public virtual List<Servicios> Servicios { get; set; }

    }
}
