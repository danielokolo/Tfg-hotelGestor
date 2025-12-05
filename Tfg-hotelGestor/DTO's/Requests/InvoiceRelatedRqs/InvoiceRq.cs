
namespace Tfg_hotelGestor.DTO_s.Requests
{
    public class InvoiceRq
    {
        public int UserId { get; set; }
        public int RoomId { get; set; }
        public DateTime InvoiceDate { get; set; }
        public decimal TotalAmount { get; set; }
    }
}
