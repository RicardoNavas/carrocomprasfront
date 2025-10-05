using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BackendProductos.Controladores
{
    using BackendProductos.Servicios;
    using Microsoft.AspNetCore.Mvc;

    [ApiController]
    [Route("api/[controller]")]
    public class CarroController : ControllerBase
    {
        private readonly ICarroServicio _service;

        public CarroController(ICarroServicio service)
        {
            _service = service;
        }

        // POST api/carro/agregar_producto
        [HttpPost("agregar_producto")]
        public IActionResult Add([FromQuery] int cproId, [FromQuery] int cantidad = 1)
        {
            _service.AgregarProducto(cproId, cantidad);
            return Ok(new { mensaje = "Producto agregado al carro de compras" });
        }

        // PUT api/carro/actualizar_cantidadproducto/1
        [HttpPut("actualizar_cantidadproducto/{cproId}")]
        public IActionResult Update(int cproId, [FromQuery] int cantidad)
        {
            _service.ActualizarCantidad(cproId, cantidad);
            return Ok(new { mensaje = "Cantidad actualizada" });
        }

        // DELETE api/carro/eliminar_producto/1
        [HttpDelete("eliminar_producto/{cproId}")]
        public IActionResult Remove(int cproId)
        {
            _service.EliminarProducto(cproId);
            return Ok(new { mensaje = "Producto eliminado correctamente" });
        }

        // DELETE api/carro/limpiar_producto
        [HttpDelete("limpiar_producto")]
        public IActionResult Clear()
        {
            _service.Vaciar();
            return Ok(new { mensaje = "Carro vacío sin productos" });
        }

        // GET api/carro
        [HttpGet]
        public IActionResult Get()
        {
            return Ok(_service.ObtenerCarrito());
        }

        

        // POST api/carro/comprafinal
        [HttpPost("comprafinal")]
        public IActionResult Comprafinal()
        {
            var carrito = _service.ObtenerCarrito();

            if (!carrito.Items.Any())
                return BadRequest(new { mensaje = "El carro está vacío" });

            
            var log = $"Compra realizada: {DateTime.Now}\n" +
                      $"Total: {carrito.Total}\n" +
                      $"Productos:\n" +
                      string.Join("\n", carrito.Items.Select(i => $"- {i.Nombre} x{i.Cantidad} = {i.Subtotal}")) +
                      "\n-----------------------------\n";

            
            var path = Path.Combine("Data", "comprascarrito_realizadas.txt");
            Directory.CreateDirectory(Path.GetDirectoryName(path)!);
            System.IO.File.AppendAllText(path, log);

            
            _service.Vaciar();

            return Ok(new { mensaje = "Compra final almacenada en log", total = carrito.Total });
        }

    }

}
