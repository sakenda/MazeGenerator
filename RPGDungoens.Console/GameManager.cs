using RPGDungeons.Library.World;

namespace RPGDungeons.TextAdventure
{
    public class GameManager
    {
        private int _money = 0;
        private bool _isMapDrawn = false;
        private string[] _nextTiles;

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

                if (elementAtPlayerPos == Global.SymbolTreasure)
                {
                    _money++;
                    GameMap.RemoveElementAt(Player.X, Player.Y);
                }

                if (elementAtPlayerPos == Global.SymbolExit)
                    break;

                Thread.Sleep(6);
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
            if (!_isMapDrawn)
            {
                Console.Clear();

                Console.SetCursorPosition(0, GameMap.Rows + 2);
                Console.WriteLine("  [MONEY]: " + _money);

                GameMap.Draw();
                _isMapDrawn = true;
            }

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

            Player.SetCurrentTile(GameMap.GetElementAt(Player.X, Player.Y));

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
