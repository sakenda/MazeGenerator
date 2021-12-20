using RPGDungeons.Library.Player.Enums;

namespace RPGDungeons.Library.Player
{
    public class ItemsModel
    {
        public string Name { get; set; }
        public ItemType Type { get; set; }
        public StateProperty Property { get; set; }
        public int Value { get; set; }

        public ItemsModel(string name)
        {
            Name = name;
        }
    }
}
