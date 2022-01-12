using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using EventosArtisticos_Manuel.api.Modelos;
using EventosArtisticos_Manuel.api.DTOS;

namespace EventosArtisticos_Manuel.api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ServiciosController : ControllerBase
    {
        private readonly Contexto _bd;

        public ServiciosController(Contexto contexto)
        {
            _bd = contexto;
        }
        [HttpGet]
        public IActionResult Listar()
        {
            var lista = _bd.Servicios.ToList();
            return Ok(lista);
        }
        [HttpGet]
        [Route("{id}")]
        public IActionResult Buscar(int id)
        {
            var obj = _bd.Servicios.Find(id);

            if (obj == null)
                return NotFound();

            return Ok(obj);
        }
        [HttpPost]
        public IActionResult Guardar(ServiciosDTO obj)
        {
            var nuevo = new Servicios(obj);
            _bd.Servicios.Add(nuevo);
            _bd.SaveChanges();
            return Ok(nuevo);
        }
        [HttpPut]
        [Route("{id}")]
        public IActionResult Modificar(int id, Servicios obj)
        {
            var modificar = _bd.Servicios.Find(id);
            if (modificar == null)
                return NoContent();
            modificar.Nombre = obj.Nombre;
            _bd.Servicios.Update(modificar);
            _bd.SaveChanges();
            return Ok(modificar);
        }
        [HttpPut]
        public IActionResult CambiarEtatus( int id)
        {

            var modificar = _bd.Servicios.Find(id);
            if (modificar == null)
                return NoContent();
            modificar.Activo = !modificar.Activo;
            _bd.Entry(modificar).State = EntityState.Modified;
            _bd.SaveChanges();


            return Ok(modificar);

            
        }
        [HttpDelete]
        public IActionResult Borrar(int id)
        {
            var borrar = _bd.Servicios.Find(id);

            if (borrar == null)
                return NoContent();
            _bd.Servicios.Remove(borrar);
            _bd.SaveChanges();
            return Ok(borrar);
        }
    }
}
