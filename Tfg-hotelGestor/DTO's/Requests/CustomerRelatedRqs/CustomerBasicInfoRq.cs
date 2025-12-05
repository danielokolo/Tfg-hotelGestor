using Tfg_hotelGestor.Entities;

namespace Tfg_hotelGestor.DTO_s.Requests
{
    public class CustomerBasicInfoRq
    {
        public string Nif { get; set; } = string.Empty;
        public string Name { get; set; } = string.Empty;
        public string BankAcountNumber { get; set; } = string.Empty;
        public string FirstSurname { get; set; } = string.Empty;
        public string? LastSurname { get; set; }
    }
}
