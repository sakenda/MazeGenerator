namespace RPGDungeons.Library.Models.World
{
    public class MapModel
    {
        public RoomModel[,] Rooms { get; set; }
        public int Floor { get; set; }
    }
}
