using Tfg_hotelGestor.Entities;

namespace Tfg_hotelGestor.DTO_s.Requests
{
    public class CustomerContactRq
    {
        public string Tlf_number { get; set; } = string.Empty;
        public string Address { get; set; } = string.Empty;
        public string MailAddress { get; set; } = string.Empty;
    }
}
