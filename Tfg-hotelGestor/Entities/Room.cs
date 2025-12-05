namespace Tfg_hotelGestor.Entities
{
    public class Room
    {
        public int Id { get; set; }
        public int RoomNumber { get; set; }
        public int RoomTypeId { get; set; }
        public RoomType RoomType { get; set; }
        public ICollection<Vacancy> Vacancies { get; set; }
        public ICollection<Invoice> Invoices { get; set; }
    }
}
