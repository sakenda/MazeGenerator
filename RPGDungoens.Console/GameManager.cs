using RPGDungeons.Library.World;

namespace RPGDungeons.TextAdventure
{
    public class GameManager
    {
        public Player Player { get; set; }
        public World GameMap { get; set; }

        public void RunGameLoop()
        {
            DisplayIntro();

            WorldGeneration worldGeneration = new WorldGeneration(5, 24);

            GameMap = new World(worldGeneration.Map);
            Player = new Player(GameMap.StartX, GameMap.StartY);

            while (true)
            {
                DrawFrame();
                HandlePlayerInput();

                string elementAtPlayerPos = GameMap.GetElementAt(Player.X, Player.Y);

                if (elementAtPlayerPos == "E")
                    break;

                Thread.Sleep(20);
            }

            DisplayOutro();
        }

        private void DisplayIntro()
        {
            Console.WriteLine(Global.Logo + "  Press any key to start...");
            Console.ReadKey(true);
        }

        private void DisplayOutro()
        {
            Console.Clear();

            Console.WriteLine(Global.Logo);
            Console.WriteLine("  You escaped!");
            Console.WriteLine("  Thanks for playing.");
            Console.WriteLine("  Press any key to exit...");
            Console.ReadKey(true);
        }

        private void DrawFrame()
        {
            Console.Clear();

            Console.SetCursorPosition(0, GameMap.Rows + 2);
            Console.WriteLine("  Menu");

            GameMap.Draw();
            Player.Draw();
        }
    
        private void HandlePlayerInput()
        {
            ConsoleKey key;
            do
            {
                key = Console.ReadKey(true).Key;
            }
            while (Console.KeyAvailable);

            switch (key)
            {
                case ConsoleKey.UpArrow:
                    if (GameMap.IsPositionWalkable(Player.X, Player.Y - 1))
                        Player.Y--;
                    break;

                case ConsoleKey.DownArrow:
                    if (GameMap.IsPositionWalkable(Player.X, Player.Y + 1))
                        Player.Y++;
                    break;

                case ConsoleKey.LeftArrow:
                    if (GameMap.IsPositionWalkable(Player.X - 1, Player.Y))
                        Player.X--;
                    break;

                case ConsoleKey.RightArrow:
                    if (GameMap.IsPositionWalkable(Player.X + 1, Player.Y))
                        Player.X++;
                    break;

                default:
                    break;
            }
        }
    }
}
