using Tfg_hotelGestor.Entities;

namespace Tfg_hotelGestor.DTO_s.Requests
{
    public class VacancyRq
    {
        public DateTime EntryDate { get; set; }
        public DateTime ExitDate { get; set; }
        public int RoomId { get; set; }
    }
}
