
using System.Text.Json.Serialization;

namespace BackendProductos.Dtos
{
    public class CategoriaDto
    {
        [JsonPropertyName("caprId")]
        public int CaprId { get; set; }

        [JsonPropertyName("caprCodigo")]
        public int? CaprCodigo { get; set; }

        [JsonPropertyName("caprNombre")]
        public string? CaprNombre { get; set; }

        [JsonPropertyName("caprNombreRuta")]
        public string? CaprNombreRuta { get; set; }

        [JsonPropertyName("caprPadre")]
        public string? CaprPadre { get; set; }

        [JsonPropertyName("caprStatus")]
        public string? CaprStatus { get; set; }

        [JsonPropertyName("catalogoProd")]
        public List<ProductoDto> CatalogoProd { get; set; } = new();
    }


}
