using System.ComponentModel.DataAnnotations.Schema;

namespace Tfg_hotelGestor.Entities
{
    public class CustomerBasicInfo
    {
        public int Id { get; set; }
        public string Nif { get; set; } = string.Empty;
        public string Name { get; set; } = string.Empty;
        public string BankAcountNumber { get; set; }
        public string FirstSurname { get; set; } = string.Empty;
        public string? LastSurname { get; set; }
        public Customer? Customer { get; set; }
       
    }
}
