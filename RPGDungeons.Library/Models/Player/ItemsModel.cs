using RPGDungeons.Library.Enums;

namespace RPGDungeons.Library.Models
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
