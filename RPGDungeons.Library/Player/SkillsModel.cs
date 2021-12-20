using RPGDungeons.Library.Player.Enums;

namespace RPGDungeons.Library.Player
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
