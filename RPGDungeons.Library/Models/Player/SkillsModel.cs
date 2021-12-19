using RPGDungeons.Library.Enums;

namespace RPGDungeons.Library.Models
{
    public class SkillsModel
    {
        public string Name { get; set; }
        public double Attack { get; set; }
        public double Defense { get; set; }
        public StateProperty State { get; set; }

        public SkillsModel(string name)
        {
            Name = name;
        }
    }
}
