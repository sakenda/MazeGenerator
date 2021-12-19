using RPGDungeons.Library;
using RPGDungeons.TextAdventure;

Console.CursorVisible = false;
Console.Title = "RPG Dungeon";

GameManager gameManager = new GameManager();

gameManager.RunGameLoop();

Console.ReadKey(true);