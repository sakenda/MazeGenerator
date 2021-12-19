using RPGDungeons.Library;
using RPGDungeons.TextAdventure;

Console.CursorVisible = false;
Console.Title = "RPG Dungeon";

GameManager gameManager = new GameManager();
WorldGeneration worldGeneration = new WorldGeneration(RPGDungeons.Library.Enums.MapSize.Medium);

gameManager.GameMap = new World(worldGeneration.Map);
gameManager.Player = new Player(gameManager.GameMap.StartX, gameManager.GameMap.StartY);
gameManager.RunGameLoop();

Console.ReadKey(true);