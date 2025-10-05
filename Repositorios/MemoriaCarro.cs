using BackendProductos.Dtos;

namespace BackendProductos.Repositorios
{
    public class MemoriaCarro : ICarroRepository
    {
        private readonly object _lock = new();
        private readonly CarroDto _carrito = new();

        public void AgregarItem(CarroItemDto item)
        {
            lock (_lock)
            {
                var existente = _carrito.Items.FirstOrDefault(i => i.CproId == item.CproId);
                if (existente != null)
                {
                    existente.Cantidad += item.Cantidad;
                }
                else
                {
                    _carrito.Items.Add(item);
                }
            }
        }

        public void ActualizarCantidad(int cproId, int cantidad)
        {
            lock (_lock)
            {
                var existente = _carrito.Items.FirstOrDefault(i => i.CproId == cproId);
                if (existente != null)
                {
                    existente.Cantidad = cantidad;
                }
            }
        }

        public void EliminarItem(int cproId)
        {
            lock (_lock)
            {
                var existente = _carrito.Items.FirstOrDefault(i => i.CproId == cproId);
                if (existente != null)
                {
                    _carrito.Items.Remove(existente);
                }
            }
        }

        public void VaciarCarrito()
        {
            lock (_lock)
            {
                _carrito.Items.Clear();
            }
        }

        public CarroDto ObtenerCarrito()
        {
            lock (_lock)
            {
                return _carrito;
            }
        }


    }
}
