using System.ComponentModel.DataAnnotations.Schema;

namespace Tfg_hotelGestor.Entities
{
    public class CustomerContact
    {
        public int Id { get; set; }
        public string Tlf_number { get; set; } = string.Empty;
        public string Address { get; set; } = string.Empty;
        public string MailAddress { get; set; } = string.Empty;
        public Customer? Customer { get; set; }

    }
}
