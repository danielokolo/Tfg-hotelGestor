namespace Tfg_hotelGestor.DTO_s.Response
{
    public class ProductRs
    {
        public string Name { get; set; } = string.Empty;
        public string? Description { get; set; }
        public int ProductTypeId { get; set; }
        public decimal Price { get; set; }
    }
}
