using RPGDungeons.Library.Enums;
using RPGDungeons.Library.Models;

namespace RPGDungeons.TextAdventure
{
    public static class CharacterCreation
    {
        //public static void Start()
        //{
        //    string name;
        //    PlayerClass playerClass;

        //    ShowStartHeader();
        //    name = ChooseName();
        //    playerClass = ChooseClass();

        //    GameManager.Player = new PlayerModel(playerClass, name);

        //    ShowPlayer();            
        //}

        //private static void ShowStartHeader()
        //{
        //    System.Console.Clear();
        //    System.Console.WriteLine(
        //        "Welcome to RPGDungeon.\n" +
        //        new string('=', 30) + "\n"
        //    );
        //}

        //private static string ChooseName()
        //{
        //    System.Console.WriteLine("Please enter your character's name: ");
        //    string input = System.Console.ReadLine();

        //    if (string.IsNullOrEmpty(input))
        //        input = null;

        //    ShowStartHeader();
        //    return input;
        //}

        //private static PlayerClass ChooseClass()
        //{
        //    System.Console.WriteLine(
        //        "Choose your class: \n" +
        //        "[1] " + PlayerClass.Warrior.ToString() + "\n" +
        //        "[2] " + PlayerClass.Hunter.ToString() + "\n" +
        //        "[3] " + PlayerClass.Mage.ToString() + "\n" +
        //        "Class no.: "
        //    );

        //    int input;
        //    bool passed = int.TryParse(System.Console.ReadLine(), out input);

        //    if (!passed || input < 1 || input > 3)
        //    {
        //        ShowStartHeader();
        //        System.Console.WriteLine("Invalid option! Please retry.\n");
        //        return ChooseClass();
        //    }

        //    ShowStartHeader();

        //    return input switch
        //    {
        //        1 => PlayerClass.Warrior,
        //        2 => PlayerClass.Hunter,
        //        3 => PlayerClass.Mage,
        //        _ => throw new Exception()
        //    };
        //}

        //private static void ShowPlayer()
        //{
        //    System.Console.WriteLine("Successfully created charakter!\n");

        //    System.Console.WriteLine(GameManager.Player.ToString());

        //    System.Console.WriteLine("Press key to end character creation...");
        //    System.Console.ReadKey();
        //}
    }
}
