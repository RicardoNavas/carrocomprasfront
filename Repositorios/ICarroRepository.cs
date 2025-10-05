using BackendProductos.Dtos;

namespace BackendProductos.Repositorios
{
    public interface ICarroRepository
    {
        void AgregarItem(CarroItemDto item);
        void ActualizarCantidad(int cproId, int cantidad);
        void EliminarItem(int cproId);
        void VaciarCarrito();
        CarroDto ObtenerCarrito();

    }
}
