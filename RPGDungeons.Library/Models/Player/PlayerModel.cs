using RPGDungeons.Library.Enums;

namespace RPGDungeons.Library.Models
{
    public class PlayerModel
    {
        private string _name;
        private int _level;
        private double _hitPoints;
        private double _magicPoints;
        private double _agility;
        private double _strength;
        private double _intelligence;
        private double _attack;
        private double _defense;
        private int _carryCapacity;
        private int _armor;
        private PlayerClass _playerClass;
        private SkillsModel[] _skills;
        private ItemsModel[] _inventory;

        public string Name
        {
            get { return _name; }
            set { _name = value; }
        }
        public int Level
        {
            get { return _level; }
            set { _level = value; }
        }
        public double HitPoints
        {
            get { return _hitPoints; }
            set { _hitPoints = value; }
        }
        public double MagicPoints
        {
            get { return _magicPoints; }
            set { _magicPoints = value; }
        }
        public double Agility
        {
            get { return _agility; }
            set { _agility = value; }
        }
        public double Strength
        {
            get { return _strength; }
            set { _strength = value; }
        }
        public double Intelligence
        {
            get { return _intelligence; }
            set { _intelligence = value; }
        }
        public double Attack
        {
            get { return _attack; }
            set { _attack = value; }
        }
        public double Defense
        {
            get { return _defense; }
            set { _defense = value; }
        }
        public int CarryCapacity
        {
            get { return _carryCapacity; }
            set { _carryCapacity = value; }
        }
        public int Armor
        {
            get { return _armor; }
            set { _armor = value; }
        }
        public PlayerClass PlayerClass => _playerClass;
        public SkillsModel[] Skills => _skills;
        public ItemsModel[] Inventory => _inventory;

        public PlayerModel(PlayerClass playerClass, string name)
        {
            if (name == null)
                name = "Jeremy";

            InitializePlayer(playerClass, name);
        }

        public override string ToString()
        {
            return "Name:\t\t" + Name + "\n" +
                   "Class:\t\t" + PlayerClass + "\n" +
                   "Level:\t\t" + Level + "\n" +
                   "HitPoints:\t" + HitPoints + "\n" +
                   "MagicPoints:\t" + MagicPoints + "\n" +
                   "Agility:\t" + Agility + "\n" +
                   "Strengt:\t" + Strength + "\n" +
                   "Intelligence:\t" + Intelligence + "\n" +
                   "Attack:\t\t" + Attack + "\n" +
                   "Defense:\t" + Defense + "\n";
        }

        private void InitializePlayer(PlayerClass playerClass, string name)
        {
            _name = name;
            _playerClass = playerClass;

            _level = 1;

            AddSkills(playerClass);
            AddInventory(playerClass);
        }

        private void AddInventory(PlayerClass playerClass)
        {
            _inventory = new ItemsModel[5];

            switch (playerClass)
            {
                case PlayerClass.Warrior:
                    break;
                case PlayerClass.Hunter:
                    break;
                case PlayerClass.Mage:
                    break;
                default:
                    break;
            }
        }

        private void AddSkills(PlayerClass playerClass)
        {
            _skills = new SkillsModel[3];

            switch (playerClass)
            {
                case PlayerClass.Warrior:
                    break;
                case PlayerClass.Hunter:
                    break;
                case PlayerClass.Mage:
                    break;
                default:
                    break;
            }
        }
    }
}
