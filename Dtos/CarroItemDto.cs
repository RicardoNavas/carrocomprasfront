namespace BackendProductos.Dtos
{
    public class CarroItemDto
    {
        public int CproId { get; set; }
        public string? Nombre { get; set; }
        public decimal PrecioUnitario { get; set; }
        public int Cantidad { get; set; }
        public decimal Subtotal => PrecioUnitario * Cantidad;


    }
}
