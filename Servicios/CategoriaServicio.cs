using BackendProductos.Dtos;
using BackendProductos.Repositorios;

namespace BackendProductos.Servicios
{
    public class CategoriaServicio : ICategoriaServicio
    {
        private readonly ICategoriaRepository _repo;

        public CategoriaServicio(ICategoriaRepository repo)
        {
            _repo = repo;
        }

        public void InicializarDatos(List<CategoriaDto> categorias)
        {
            _repo.CargarDatos(categorias);
        }

        public List<CategoriaDto> ListarCategorias() => _repo.ObtenerCategorias();

        public CategoriaDto? BuscarCategoria(int id) => _repo.ObtenerCategoriaPorId(id);

        public ProductoDto? BuscarProducto(int cproId) => _repo.ObtenerProductoPorId(cproId);

        public bool ActualizarCategoria(CategoriaDto categoria) => _repo.ActualizarCategoria(categoria);

        public bool EliminarCategoria(int id) => _repo.EliminarCategoria(id);

        public bool ActualizarProducto(int cproId, ProductoDto producto) => _repo.ActualizarProducto(cproId, producto);

        public bool EliminarProducto(int cproId) => _repo.EliminarProducto(cproId);


        public void GuardarDatosEnArchivo(string path) => _repo.GuardarEnArchivo(path);

        public void CargarDatosDesdeArchivo(string path) => _repo.CargarDesdeArchivo(path);
    }

}
