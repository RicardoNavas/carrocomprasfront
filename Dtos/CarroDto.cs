namespace BackendProductos.Dtos
{
    public class CarroDto
    {
        public List<CarroItemDto> Items { get; set; } = new();
        public decimal Total => Items.Sum(i => i.Subtotal);
    }
}
