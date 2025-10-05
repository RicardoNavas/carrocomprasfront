using System.Text.Json.Serialization;
namespace BackendProductos.Dtos
{

    public class ProductoDto
    {
        [JsonPropertyName("cproId")]
        public int CproId { get; set; }

        [JsonPropertyName("cproCodigo")]
        public int? CproCodigo { get; set; }

        [JsonPropertyName("caprId")]
        public int? CaprId { get; set; }

        [JsonPropertyName("unidCodigo")]
        public int? UnidCodigo { get; set; }

        [JsonPropertyName("cproCodigoint")]
        public string? CproCodigoint { get; set; }

        [JsonPropertyName("cproCodigobarras")]
        public string? CproCodigobarras { get; set; }

        [JsonPropertyName("cproNombre")]
        public string? CproNombre { get; set; }

        [JsonPropertyName("cproDescripcion")]
        public string? CproDescripcion { get; set; }

        [JsonPropertyName("cproMarca")]
        public string? CproMarca { get; set; }

        [JsonPropertyName("cproUbicacion")]
        public string? CproUbicacion { get; set; }

    
    }

}
