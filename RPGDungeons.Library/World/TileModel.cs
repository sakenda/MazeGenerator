using RPGDungeons.Library.World.Enums;

namespace RPGDungeons.Library.World
{
    public class TileModel
    {
        public int X { get; set; }
        public int Y { get; set; }
        public TileType Type { get; set; }

        public TileModel()
        {
            Type = TileType.Nothing;
        }

    }
}
