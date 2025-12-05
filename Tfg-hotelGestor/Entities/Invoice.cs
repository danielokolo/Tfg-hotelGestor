namespace Tfg_hotelGestor.Entities
{
    public class Invoice
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public int RoomId { get; set; }
        public DateTime InvoiceDate { get; set; }
        public decimal TotalAmount { get; set; }

        public Room Room { get; set; }
        public User User { get; set; }

        public ICollection<InvoiceDetails> InvoicesDetails { get; set; }


    }
}
