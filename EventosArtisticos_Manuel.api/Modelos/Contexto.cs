using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EventosArtisticos_Manuel.api.Modelos
{
    public class Contexto : DbContext
    {
        public Contexto(DbContextOptions<Contexto> Options) : base(Options)
        {

        }
      
        public DbSet<Servicios> Servicios { get; set; }

        public DbSet<Cliente> Cliente { get; set; }

        public DbSet<Categoria> Categoria { get; set; }

        public DbSet<Proveedor> Proveedor { get; set; }
       

     
    }
}
