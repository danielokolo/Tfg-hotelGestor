namespace Tfg_hotelGestor.Entities
{
    public class Product
    {
        public int Id { get; set; } 
        public string Name { get; set; } = string.Empty;
        public string? Description { get; set; }
        public int ProductTypeId { get; set; }
        public decimal Price { get; set; }


        public ProductType ProductType { get; set; }
        public ICollection<InvoiceDetails> InvoicesDetails { get; set; }
    }
}
