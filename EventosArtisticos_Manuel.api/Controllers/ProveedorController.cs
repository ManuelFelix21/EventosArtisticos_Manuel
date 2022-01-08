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
    public class ProveedorController : ControllerBase
    {
        private readonly Contexto _bd;

        public ProveedorController(Contexto contexto)
        {
            _bd = contexto;
        }
        [HttpGet]
        public IActionResult Listar()
        {
            var lista = _bd.Proveedor;
            return Ok(lista);
        }
        [HttpPost]
        public IActionResult Guardar(Proveedor obj)
        {
            _bd.Proveedor.Add(obj);
            _bd.SaveChanges();
            return Ok(obj);
        }
        [HttpPut]
        public IActionResult Modificar(Proveedor obj, int id)
        {

            var modificar = _bd.Proveedor.Find(id);
            modificar.RFC = obj.RFC;
            modificar.Nombre = obj.Nombre;
            modificar.Telefono = obj.Telefono;
            modificar.Correo = obj.Correo;
            modificar.Direccion = obj.Direccion;
            modificar.Activo = obj.Activo;

            _bd.Proveedor.Update(modificar);
            _bd.SaveChanges();
            return Ok(modificar);
        }
        [HttpDelete]
        public IActionResult Borrar(int id)
        {
            var borrar = _bd.Proveedor.Find(id);
            _bd.Proveedor.Remove(borrar);
            _bd.SaveChanges();
            return Ok(borrar);
        }
    }
}