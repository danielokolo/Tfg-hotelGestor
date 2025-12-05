namespace Tfg_hotelGestor.DTO_s.Requests
{
    public class UserRq
    {
        public int UserTypeId { get; set; }
        public string UserName { get; set; } = string.Empty;
        public string HashPassword { get; set; } = string.Empty;
    }
}
