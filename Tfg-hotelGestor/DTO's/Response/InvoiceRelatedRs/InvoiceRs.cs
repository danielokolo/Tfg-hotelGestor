namespace Tfg_hotelGestor.DTO_s.Response

{
    public class InvoiceRs
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public int RoomId { get; set; }
        public DateTime InvoiceDate { get; set; }
        public decimal TotalAmount { get; set; }

    }
}
