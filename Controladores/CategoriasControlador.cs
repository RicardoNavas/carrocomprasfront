using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using BackendProductos.Dtos;
using BackendProductos.Servicios;

namespace BackendProductos.Controladores
{
    

    [ApiController]
    [Route("api/[controller]")]
    public class CategoriasController : ControllerBase
    {
        private readonly ICategoriaServicio _service;

        public CategoriasController(ICategoriaServicio service)
        {
            _service = service;
        }
        
        [HttpGet]
        public IActionResult GetAll() => Ok(_service.ListarCategorias());

        // GET api/categoria/{id}
        [HttpGet("{id:int}")]
        public IActionResult Get(int id)
        {
            var cat = _service.BuscarCategoria(id);
            if (cat == null) return NotFound();
            return Ok(cat);
        }

        // GET api/categoria/producto/{cproId}
        [HttpGet("producto/{cproId:int}")]
        public IActionResult GetProducto(int cproId)
        {
            var p = _service.BuscarProducto(cproId);
            if (p == null) return NotFound();
            return Ok(p);
        }


        // PUT api/categoria/{id}
        [HttpPut("{id}")]
        public IActionResult UpdateCategoria(int id, [FromBody] CategoriaDto categoria)
        {
            if (id != categoria.CaprId) return BadRequest(new { mensaje = "ID no encontrado" });

            var ok = _service.ActualizarCategoria(categoria);
            if (!ok) return NotFound(new { mensaje = "Categoria no encontrada" });
            return Ok(new { mensaje = "Categoria actualizada correctamente", categoria });
        }

        // DELETE api/categoria/{id}
        [HttpDelete("{id}")]
        public IActionResult DeleteCategoria(int id)
        {
            var ok = _service.EliminarCategoria(id);
            if (!ok) return NotFound(new { mensaje = "Categoria no encontrada" });
            return Ok(new { mensaje = "Categoria eliminada correctamente" });
        }

        // PUT api/categorias/producto/{cproId}
        [HttpPut("producto/{cproId}")]
        public IActionResult UpdateProducto(int cproId, [FromBody] ProductoDto producto)
        {
            var ok = _service.ActualizarProducto(cproId, producto);
            if (!ok) return NotFound(new { mensaje = "Producto no encontrado" });
            return Ok(new { mensaje = "Producto actualizado correctamente", producto });
        }

        // DELETE api/categoria/producto/{cproId}
        [HttpDelete("producto/{cproId}")]
        public IActionResult DeleteProducto(int cproId)
        {
            var ok = _service.EliminarProducto(cproId);
            if (!ok) return NotFound(new { mensaje = "Producto no encontrado" });
            return Ok(new { mensaje = "Producto eliminado correctamente" });
        }

        
    }

}
