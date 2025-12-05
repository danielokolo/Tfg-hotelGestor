namespace Tfg_hotelGestor.Entities
{
    public class User
    {
        public int Id { get; set; }
        public int UserTypeId { get; set; }
        public string UserName { get; set; } = string.Empty;
        public string HashPassword { get; set; } = string.Empty;

        public UserType UserType { get; set; }
        public ICollection<Invoice> Invoices { get; set; }


    }
}
