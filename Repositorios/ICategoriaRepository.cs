
using BackendProductos.Dtos;

namespace BackendProductos.Repositorios
{
    public interface ICategoriaRepository
    {
        void CargarDatos(List<CategoriaDto> categorias);
        List<CategoriaDto> ObtenerCategorias();
        CategoriaDto? ObtenerCategoriaPorId(int id);
        ProductoDto? ObtenerProductoPorId(int cproId);

        bool ActualizarCategoria(CategoriaDto categoria);
        bool EliminarCategoria(int id);
        bool ActualizarProducto(int cproId, ProductoDto producto);
        bool EliminarProducto(int cproId);
        void GuardarEnArchivo(string path);
        void CargarDesdeArchivo(string path);


  
    }

}
