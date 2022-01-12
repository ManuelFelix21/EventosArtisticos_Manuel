using EventosArtisticos_Manuel.api.DTOS;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace EventosArtisticos_Manuel.api.Modelos
{
    public class Cliente
    {

        public Cliente()
        {

        }

        public Cliente(ClienteDTO nuevo)
        {
            this.Nombre = nuevo.Nombre;
            this.Telefono = nuevo.Telefono;
            this.Correo = nuevo.Correo;
            this.Direccion = nuevo.Direccion;
            this.Activo = true;
        }

        [Key]
        public int IdCliente { get; set; }
       
        [Required]
        [MaxLength(90)]
        public string Nombre { get; set; }
        
        [MaxLength(10)]
        public string Telefono { get; set; }
        
        [MaxLength(120)]
        public string Correo { get; set; }
        
        [MaxLength(250)]
        public string Direccion { get; set; }
        
        [Required]
        public bool Activo { get; set; }

        [ForeignKey("IdServicios")]
        public Servicios Servicios { get; set; }


        public virtual List<Venta> Venta { get; set; }

    }
}
