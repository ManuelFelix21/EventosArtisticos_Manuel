using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using EventosArtisticos_Manuel.api.Modelos;
using EventosArtisticos_Manuel.api.DTOS;
using Microsoft.EntityFrameworkCore;

namespace EventosArtisticos_Manuel.api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClienteController : ControllerBase
    {
        private readonly Contexto _bd;

        public ClienteController(Contexto contexto)
        {
            _bd = contexto;
        }
        [HttpGet]
        public IActionResult Listar()
        {
            var lista = _bd.Cliente.ToList();
            return Ok(lista);
        }
        [HttpGet]
        [Route("{id}")]
        public IActionResult Buscar(int id)
        {
            var obj = _bd.Cliente.Find(id);

            if (obj == null)
                return NotFound();

            return Ok(obj);
        }
        [HttpPost]
        public IActionResult Guardar(ClienteDTO obj)
        {
            var nuevo = new Cliente(obj);
            _bd.Cliente.Add(nuevo);
            _bd.SaveChanges();
            return Ok(nuevo);
        }
        [HttpPut]
        [Route("{id}")]
        public IActionResult Modificar(int id, Cliente obj)
        {
            var modificar = _bd.Cliente.Find(id);
            if (modificar == null)
                return NoContent();
            modificar.Nombre = obj.Nombre;
            modificar.Telefono = obj.Telefono;
            modificar.Correo = obj.Correo;
            modificar.Direccion = obj.Direccion;
            _bd.Cliente.Update(modificar);
            _bd.SaveChanges();
            return Ok(modificar);
        }
        [HttpPut]
        public IActionResult CambiarEtatus(int id)
        {

            var modificar = _bd.Cliente.Find(id);
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
            var borrar = _bd.Cliente.Find(id);

            if (borrar == null)
                return NoContent();
            _bd.Cliente.Remove(borrar);
            _bd.SaveChanges();
            return Ok(borrar);
        }
    }
}