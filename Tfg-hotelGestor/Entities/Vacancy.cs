namespace Tfg_hotelGestor.Entities
{
    public class Vacancy
    {
        public int Id { get; set; }
        public DateTime EntryDate { get; set; }
        public DateTime ExitDate { get; set; }
        public int RoomId { get; set; }
        public Room Room { get; set; }
    }
}
