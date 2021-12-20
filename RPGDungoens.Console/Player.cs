namespace RPGDungeons.TextAdventure
{
    public class Player
    {
        private ConsoleColor _playerColor;

        public int X { get; set; }
        public int Y { get; set; }

        public Player(int initX, int initY)
        {
            X = initX;
            Y = initY;
            _playerColor = ConsoleColor.Red;
        }

        public void Draw()
        {
            Console.ForegroundColor = _playerColor;
            Console.SetCursorPosition(X, Y);
            Console.Write(Global.SymbolPlayer);
            Console.ResetColor();
        }
    }
}
