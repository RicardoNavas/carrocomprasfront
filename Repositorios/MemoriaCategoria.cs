using BackendProductos.Dtos;
using System.Text.Json;

namespace BackendProductos.Repositorios
{

    public class MemoriaCategoria : ICategoriaRepository
    {
        private readonly object _lock = new();
        private List<CategoriaDto> _categorias = new();

        public void CargarDatos(List<CategoriaDto> categorias)
        {
            if (categorias == null) return;
            lock (_lock)
            {
                _categorias = categorias;
            }
        }

        public List<CategoriaDto> ObtenerCategorias()
        {
            lock (_lock)
            {
  
                return _categorias.Select(c => c).ToList();
            }
        }

        public CategoriaDto? ObtenerCategoriaPorId(int id)
        {
            lock (_lock)
            {
                return _categorias.FirstOrDefault(c => c.CaprId == id);
            }
        }

        public ProductoDto? ObtenerProductoPorId(int cproId)
        {
            lock (_lock)
            {
                foreach (var cat in _categorias)
                {
                    var p = cat.CatalogoProd.FirstOrDefault(x => x.CproId == cproId);
                    if (p != null) return p;
                }
                return null;
            }
        }

        public bool ActualizarCategoria(CategoriaDto categoria)
        {
            lock (_lock)
            {
                var existente = _categorias.FirstOrDefault(c => c.CaprId == categoria.CaprId);
                if (existente == null) return false;

                existente.CaprNombre = categoria.CaprNombre;
                existente.CaprCodigo = categoria.CaprCodigo;
                existente.CaprNombreRuta = categoria.CaprNombreRuta;
                existente.CaprPadre = categoria.CaprPadre;
                existente.CaprStatus = categoria.CaprStatus;
                return true;
            }
        }

        public bool EliminarCategoria(int id)
        {
            lock (_lock)
            {
                var existente = _categorias.FirstOrDefault(c => c.CaprId == id);
                if (existente == null) return false;
                _categorias.Remove(existente);
                return true;
            }
        }

        public bool ActualizarProducto(int cproId, ProductoDto producto)
        {
            lock (_lock)
            {
                foreach (var cat in _categorias)
                {
                    var existente = cat.CatalogoProd.FirstOrDefault(p => p.CproId == cproId);
                    if (existente != null)
                    {
                        existente.CproNombre = producto.CproNombre;
                        existente.CproDescripcion = producto.CproDescripcion;
                        existente.CproCodigoint = producto.CproCodigoint;
                        existente.CproCodigobarras = producto.CproCodigobarras;
                        existente.CproMarca = producto.CproMarca;
                        existente.CproUbicacion = producto.CproUbicacion;
                        return true;
                    }
                }
                return false;
            }
        }

        public bool EliminarProducto(int cproId)
        {
            lock (_lock)
            {
                foreach (var cat in _categorias)
                {
                    var existente = cat.CatalogoProd.FirstOrDefault(p => p.CproId == cproId);
                    if (existente != null)
                    {
                        cat.CatalogoProd.Remove(existente);
                        return true;
                    }
                }
                return false;
            }
        }  


        public void GuardarEnArchivo(string path)
        {
            lock (_lock)
            {
                var options = new JsonSerializerOptions { WriteIndented = true };
                var json = JsonSerializer.Serialize(_categorias, options);
                System.IO.Directory.CreateDirectory(System.IO.Path.GetDirectoryName(path) ?? ".");
                System.IO.File.WriteAllText(path, json);
            }
        }

        public void CargarDesdeArchivo(string path)
        {
            if (!System.IO.File.Exists(path)) return;
            var json = System.IO.File.ReadAllText(path);
            var options = new JsonSerializerOptions { PropertyNameCaseInsensitive = true };
            var data = JsonSerializer.Deserialize<List<CategoriaDto>>(json, options);
            if (data != null) CargarDatos(data);
        }
    }

}
