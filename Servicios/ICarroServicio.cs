using BackendProductos.Dtos;

namespace BackendProductos.Servicios
{
    public interface ICarroServicio
    {

        void AgregarProducto(int cproId, int cantidad);
        void ActualizarCantidad(int cproId, int cantidad);
        void EliminarProducto(int cproId);
        void Vaciar();
        CarroDto ObtenerCarrito();

    }
}
