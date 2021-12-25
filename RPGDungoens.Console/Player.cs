namespace RPGDungeons.TextAdventure
{
    public class Player
    {
        private ConsoleColor _playerColor;
        private string _lastTile;
        private int _lastY;
        private int _lastX;

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
            Console.SetCursorPosition(_lastX, _lastY);
            Console.Write(_lastTile);

            Console.ForegroundColor = _playerColor;
            Console.SetCursorPosition(X, Y);
            Console.Write(Global.SymbolPlayer);
            Console.ResetColor();
        }

        public void SetCurrentTile(string tile)
        {
            _lastTile = tile;
            _lastX = X;
            _lastY = Y;
        }

    }
}
