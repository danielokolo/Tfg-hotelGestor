namespace Tfg_hotelGestor.DTO_s.Response
{
    public class CustomerBasicInfoRs
    {
        public int Id { get; set; }
        public string Nif { get; set; } = string.Empty;
        public string Name { get; set; } = string.Empty;
        public string BankAcountNumber { get; set; }
        public string FirstSurname { get; set; } = string.Empty;
        public string? LastSurname { get; set; }
        public int CustomerId { get; set; }
    }
}
