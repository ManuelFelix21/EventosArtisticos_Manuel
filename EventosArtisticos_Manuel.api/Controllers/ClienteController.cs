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
            var lista = _bd.Cliente;
            return Ok(lista);
        }
        [HttpPost]
        public IActionResult Guardar(Cliente obj)
        {
            _bd.Cliente.Add(obj);
            _bd.SaveChanges();
            return Ok(obj);
        }
        [HttpPut]
        public IActionResult Modificar(Cliente obj, int id)
        {

            var modificar = _bd.Cliente.Find(id);
            modificar.Nombre = obj.Nombre;
            modificar.Telefono = obj.Telefono;
            modificar.Correo = obj.Correo;
            modificar.Direccion = obj.Direccion;
            modificar.Activo = obj.Activo;

            _bd.Cliente.Update(modificar);
            _bd.SaveChanges();
            return Ok(modificar);
        }
        [HttpDelete]
        public IActionResult Borrar(int id)
        {
            var borrar = _bd.Cliente.Find(id);
            _bd.Cliente.Remove(borrar);
            _bd.SaveChanges();
            return Ok(borrar);
        }
    }
}