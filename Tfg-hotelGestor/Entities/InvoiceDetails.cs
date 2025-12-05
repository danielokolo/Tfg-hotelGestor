namespace Tfg_hotelGestor.Entities
{
    public class InvoiceDetails
    {
        public int Id { get; set; }
        public int InvoiceId { get; set; }
        public int ProductId { get; set; }
        public int Quantity { get; set; }
        public decimal UnitPrice { get; set; }
        public decimal Subtotal { get; set; }

        public Product Product { get; set; }
        public Invoice Invoice { get; set; }

    }
}
