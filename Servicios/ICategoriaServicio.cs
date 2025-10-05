using BackendProductos.Dtos;

namespace BackendProductos.Servicios
{
    public interface ICategoriaServicio
    {
        void InicializarDatos(List<CategoriaDto> categorias);
        List<CategoriaDto> ListarCategorias();
        CategoriaDto? BuscarCategoria(int id);
        ProductoDto? BuscarProducto(int cproId);
        bool ActualizarCategoria(CategoriaDto categoria);
        bool EliminarCategoria(int id);
        bool ActualizarProducto(int cproId, ProductoDto producto);
        bool EliminarProducto(int cproId);
        void GuardarDatosEnArchivo(string path);
        void CargarDatosDesdeArchivo(string path);
    }

}
