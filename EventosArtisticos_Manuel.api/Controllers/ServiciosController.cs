using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using EventosArtisticos_Manuel.api.Modelos;

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
            var lista = _bd.Servicios;
            return Ok(lista);
        }
        [HttpPost]
        public IActionResult Guardar(Servicios obj)
        {
            _bd.Servicios.Add(obj);
            _bd.SaveChanges();
            return Ok(obj);
        }
        [HttpPut]
        public IActionResult Modificar(Servicios obj, int id)
        {

            var modificar = _bd.Servicios.Find(id);
            modificar.Nombre = obj.Nombre;
            modificar.Precio = obj.Precio;
            modificar.Activo = obj.Activo;

            _bd.Servicios.Update(modificar);
            _bd.SaveChanges();
            return Ok(modificar);
        }
        [HttpDelete]
        public IActionResult Borrar(int id)
        {
            var borrar = _bd.Servicios.Find(id);
            _bd.Servicios.Remove(borrar);
            _bd.SaveChanges();
            return Ok(borrar);
        }
    }
}
