using BackendProductos.Dtos;
using BackendProductos.Repositorios;

namespace BackendProductos.Servicios
{
    public class CarroServicio : ICarroServicio
    {
        private readonly ICarroRepository _repo;
        private readonly ICategoriaRepository _productosRepo;

        public CarroServicio(ICarroRepository repo, ICategoriaRepository productosRepo)
        {
            _repo = repo;
            _productosRepo = productosRepo;
        }

        public void AgregarProducto(int cproId, int cantidad)
        {
            var producto = _productosRepo.ObtenerProductoPorId(cproId);
            if (producto == null) return;

            var item = new CarroItemDto
            {
                CproId = producto.CproId,
                Nombre = producto.CproNombre,
                PrecioUnitario = 10.00m, 
                Cantidad = cantidad
            };

            _repo.AgregarItem(item);
        }

        public void ActualizarCantidad(int cproId, int cantidad)
        {
            _repo.ActualizarCantidad(cproId, cantidad);
        }

        public void EliminarProducto(int cproId)
        {
            _repo.EliminarItem(cproId);
        }

        public void Vaciar()
        {
            _repo.VaciarCarrito();
        }

        public CarroDto ObtenerCarrito()
        {
            return _repo.ObtenerCarrito();
        }


    }
}
