namespace Tfg_hotelGestor.Entities
{
    public class ProductType
    {
        public int Id { get; set; }
        public string Type { get; set; } = string.Empty;

        public ICollection<Product> Products { get; set; }
    }
}
