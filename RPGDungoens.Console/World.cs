using RPGDungeons.Library.World;
using RPGDungeons.Library.World.Enums;

namespace RPGDungeons.TextAdventure
{
    public class World
    {
        private string[,] _grid;
        private int _rows;
        private int _columns;
        private int _roomSize = 5;

        public int Rows => _rows;
        public int Columns => _columns;
        public int StartX { get; private set; }
        public int StartY { get; private set; }

        public World(MapModel map)
        {
            _rows = (map.Rooms.GetLength(0) * _roomSize);
            _columns = (map.Rooms.GetLength(1) * _roomSize);

            _grid = new string[_rows, _columns];
            SetGrid(map);
        }

        private void SetGrid(MapModel map)
        {
            for (int roomY = 0; roomY < map.Rooms.GetLength(0); roomY++)
            {
                for (int roomX = 0; roomX < map.Rooms.GetLength(1); roomX++)
                {
                    if (map.Rooms[roomY, roomX] == null || map.Rooms[roomY, roomX].Tiles == null)
                        continue;

                    int tileSizeY = map.Rooms[roomY, roomX].Tiles.GetLength(0);
                    int tileSizeX = map.Rooms[roomY, roomX].Tiles.GetLength(1);

                    for (int tileY = 0; tileY < tileSizeY; tileY++)
                    {
                        for (int tileX = 0; tileX < tileSizeX; tileX++)
                        {
                            int currentTileInGridY = tileY + (roomY * _roomSize);
                            int currentTileInGridX = tileX + (roomX * _roomSize);

                            switch (map.Rooms[roomY, roomX].Tiles[tileY, tileX].Type)
                            {
                                case TileType.Enemy:
                                    _grid[currentTileInGridY, currentTileInGridX] = Global.SymbolEnemy;
                                    break;
                                case TileType.Boss:
                                    _grid[currentTileInGridY, currentTileInGridX] = Global.SymbolBoss;
                                    break;
                                case TileType.Treasure:
                                    _grid[currentTileInGridY, currentTileInGridX] = Global.SymbolTreasure;
                                    break;
                                case TileType.Start:
                                    _grid[currentTileInGridY, currentTileInGridX] = Global.SymbolStart;
                                    StartY = currentTileInGridY;
                                    StartX = currentTileInGridX;
                                    break;
                                case TileType.Exit:
                                    _grid[currentTileInGridY, currentTileInGridX] = Global.SymbolExit;
                                    break;
                                case TileType.Wall:
                                    _grid[currentTileInGridY, currentTileInGridX] = Global.SymbolWall;
                                    break;
                                case TileType.Passage:
                                    _grid[currentTileInGridY, currentTileInGridX] = " ";
                                    break;
                                default:
                                    _grid[currentTileInGridY, currentTileInGridX] = " ";
                                    break;
                            }
                        }
                    }
                }
            }

        }

        public void Draw()
        {
            for (int y = 0; y < _rows; y++)
            {
                for (int x = 0; x < _columns; x++)
                {
                    string element = _grid[y, x];

                    Console.ForegroundColor = element switch
                    {
                        Global.SymbolFloor => ConsoleColor.White,
                        Global.SymbolEnemy => ConsoleColor.DarkMagenta,
                        Global.SymbolBoss => ConsoleColor.Red,
                        Global.SymbolTreasure => ConsoleColor.Yellow,
                        Global.SymbolStart => ConsoleColor.DarkGreen,
                        Global.SymbolExit => ConsoleColor.DarkGreen,
                        Global.SymbolWall => ConsoleColor.Gray,
                        _ => ConsoleColor.White,
                    };

                    Console.SetCursorPosition(x, y);
                    Console.Write(element);
                }
            }
        }

        public string GetElementAt(int x, int y)
            => _grid[y, x];

        public bool IsPositionWalkable(int x, int y)
        {
            if (x < 0 || y < 0 || x >= _columns || y >= _rows || _grid[y, x] == Global.SymbolWall)
                return false;

            return true;
        }
    }
}
