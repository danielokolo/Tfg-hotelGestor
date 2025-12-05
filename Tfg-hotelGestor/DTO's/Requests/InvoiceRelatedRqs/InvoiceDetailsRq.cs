using Tfg_hotelGestor.Entities;

namespace Tfg_hotelGestor.DTO_s.Requests
{
    public class InvoiceDetailsRq
    {
        public int InvoiceId { get; set; }
        public int ProductId { get; set; }
        public int Quantity { get; set; }
        public decimal UnitPrice { get; set; }
        public decimal Subtotal { get; set; }
    }
}
