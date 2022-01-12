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
    public class VentaController : ControllerBase
    {
        private readonly Contexto _bd;

        public VentaController(Contexto contexto)
        {
            _bd = contexto;
        }
        [HttpGet]
        public IActionResult Listar()
        {
            var lista = _bd.Venta.ToList();
            return Ok(lista);
        }
        [HttpGet]
        [Route("{id}")]
        public IActionResult Buscar(int id)
        {
            var obj = _bd.Venta.Find(id);

            if (obj == null)
                return NotFound();

            return Ok(obj);
        }
        [HttpPost]
        public IActionResult Guardar(VentaDTO obj)
        {
            var nuevo = new Venta(obj);
            _bd.Venta.Add(nuevo);
            _bd.SaveChanges();
            return Ok(nuevo);
        }
        [HttpPut]
        [Route("{id}")]
        public IActionResult Modificar(int id, Venta obj)
        {
            var modificar = _bd.Venta.Find(id);
            if (modificar == null)
                return NoContent();
            modificar.Monto = obj.Monto;
            modificar.DescripcionServicio = obj.DescripcionServicio;
            modificar.NombreCliente = obj.NombreCliente;
            _bd.Venta.Update(modificar);
            _bd.SaveChanges();
            return Ok(modificar);
        }
        [HttpPut]
        public IActionResult CambiarEtatus(int id)
        {

            var modificar = _bd.Venta.Find(id);
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
            var borrar = _bd.Venta.Find(id);

            if (borrar == null)
                return NoContent();
            _bd.Venta.Remove(borrar);
            _bd.SaveChanges();
            return Ok(borrar);
        }
    }
}