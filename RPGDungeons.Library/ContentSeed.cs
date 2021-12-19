using RPGDungeons.Library.Enums;
using RPGDungeons.Library.Models;

namespace RPGDungeons.Library
{
    public static class ContentSeed
    {
        public static SkillsModel[] Skills { get; private set; }
        public static PlayerClassModel[] Classes { get; private set; }
        public static ItemsModel[] Items { get; private set; }

        static ContentSeed()
        {
            InitializeSkills();
            InitializeClasses();
            InitializeItems();
        }

        private static void InitializeItems()
        {
            Items = new ItemsModel[]
            {
                new ItemsModel("Potion")
                {
                    Type = ItemType.Item,
                    Property = StateProperty.Healing,
                    Value = 5
                }
            };
        }

        private static void InitializeClasses()
        {
            Classes = new PlayerClassModel[]
            {
                new PlayerClassModel("Warrior")
                {
                    MultiplierHitPoints = 1,
                    MultiplierMagicPoints = 1,
                    MultiplierAgility = 1,
                    MultiplierStrength = 1,
                    MultiplierIntellignce = 1,
                    MultiplierAttack = 1,
                    MultiplierDefense = 1
                },
                new PlayerClassModel("Hunter")
                {
                    MultiplierHitPoints = 1,
                    MultiplierMagicPoints = 1,
                    MultiplierAgility = 1,
                    MultiplierStrength = 1,
                    MultiplierIntellignce = 1,
                    MultiplierAttack = 1,
                    MultiplierDefense = 1
                },
                new PlayerClassModel("Mage")
                {
                    MultiplierHitPoints = 1,
                    MultiplierMagicPoints = 1,
                    MultiplierAgility = 1,
                    MultiplierStrength = 1,
                    MultiplierIntellignce = 1,
                    MultiplierAttack = 1,
                    MultiplierDefense = 1
                }
            };
        }

        private static void InitializeSkills()
        {
            Skills = new SkillsModel[]
            {
                new SkillsModel("Punch")
                {
                    Attack = 1,
                    Defense = 0,
                    State = StateProperty.None
                }
            };
        }
    }
}
