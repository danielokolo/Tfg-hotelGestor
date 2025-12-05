namespace Tfg_hotelGestor.Entities
{
    public class UserType
    {
        public int Id { get; set; }
        public string Type { get; set; } = string.Empty;

        public ICollection<User> Users { get; set; }
    }
}
