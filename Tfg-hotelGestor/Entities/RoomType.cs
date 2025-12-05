namespace Tfg_hotelGestor.Entities
{
    public class RoomType
    {
        public int Id { get; set; } 
        public string TypeRoom { get; set; } = String.Empty;
        public int RoomCapacity { get; set; }
        public ICollection<Room> Rooms { get; set; }
    }
}
