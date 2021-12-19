using RPGDungeons.Library.Enums;

namespace RPGDungeons.Library.Models.World
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
