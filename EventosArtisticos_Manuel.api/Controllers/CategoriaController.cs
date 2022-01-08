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
    public class CategoriaController : ControllerBase
    {
        private readonly Contexto _bd;

        public CategoriaController(Contexto contexto)
        {
            _bd = contexto;
        }
        [HttpGet]
        public IActionResult Listar()
        {
            var lista = _bd.Categoria;
            return Ok(lista);
        }
        [HttpPost]
        public IActionResult Guardar(Categoria obj)
        {
            _bd.Categoria.Add(obj);
            _bd.SaveChanges();
            return Ok(obj);
        }
        [HttpPut]
        public IActionResult Modificar(Categoria obj, int id)
        {

            var modificar = _bd.Categoria.Find(id);
            modificar.Nombre = obj.Nombre;
            modificar.Activo = obj.Activo;

            _bd.Categoria.Update(modificar);
            _bd.SaveChanges();
            return Ok(modificar);
        }
        [HttpDelete]
        public IActionResult Borrar(int id)
        {
            var borrar = _bd.Categoria.Find(id);
            _bd.Categoria.Remove(borrar);
            _bd.SaveChanges();
            return Ok(borrar);
        }
    }
}