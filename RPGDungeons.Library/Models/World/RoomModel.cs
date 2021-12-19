namespace RPGDungeons.Library.Models.World
{
    public class RoomModel
    {
        public int X { get; set; }
        public int Y { get; set; }
        public TileModel[,] Tiles { get; set; }
        public Enums.RoomDirection LastDirection { get; set; }
        public Enums.RoomDirection NextDirection { get; set; }

        public Enums.RoomType Type { get; set; }
    }
}
