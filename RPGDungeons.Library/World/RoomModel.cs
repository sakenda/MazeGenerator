namespace RPGDungeons.Library.World
{
    public class RoomModel
    {
        private double _chanceEnemy = 5;
        private double _chanceTreasure = 3;
        private double _chanceBoss = 1;

        internal bool Visited { get; set; }
        public int X { get; set; }
        public int Y { get; set; }
        public Enums.RoomType Type { get; set; }
        public TileModel[,] Tiles { get; set; }

        public RoomModel(int posY, int posX)
        {
            Y = posY;
            X = posX;
            Type = Enums.RoomType.None;
            Visited = false;
            Tiles = new TileModel[5, 5];
            InitializeTiles();
        }

        private void InitializeTiles()
        {
            for (int y = 0; y < 5; y++)
            {
                for (int x = 0; x < 5; x++)
                {
                    Tiles[y, x] = new TileModel();

                    if (y == 0 || y == 4 || x == 0 || x == 4)
                        Tiles[y, x].Type = Enums.TileType.Wall;
                    else
                        Tiles[y, x].Type = Enums.TileType.Nothing;
                }
            }
        }

        internal RoomModel CheckNeighbors(MapModel map)
        {
            var random = new Random();
            var neighbors = new List<RoomModel>();

            if (X > 0 &&
                map.Rooms[Y, X - 1].Visited == false) neighbors.Add(map.Rooms[Y, X - 1]);

            if (Y > 0 &&
                map.Rooms[Y - 1, X].Visited == false) neighbors.Add(map.Rooms[Y - 1, X]);

            if (X < map.Rooms.GetLength(1) - 1 &&
                map.Rooms[Y, X + 1].Visited == false) neighbors.Add(map.Rooms[Y, X + 1]);

            if (Y < map.Rooms.GetLength(0) - 1 &&
                map.Rooms[Y + 1, X].Visited == false) neighbors.Add(map.Rooms[Y + 1, X]);
            
            if (neighbors.Count > 0)
            {
                int rand = random.Next(0, neighbors.Count);
                return neighbors[rand];
            }
            
            return null;
        }

        internal void RemoveWall(RoomModel nextRoom)
        {
            int x = X - nextRoom.X;
            int y = Y - nextRoom.Y;

            if (x == 1)
            {
                for (int i = 1; i < 4; i++)
                {
                    Tiles[i, 0].Type = Enums.TileType.Nothing;
                    nextRoom.Tiles[i, 4].Type = Enums.TileType.Nothing;
                }
            }

            if (x == -1)
            {
                for (int i = 1; i < 4; i++)
                {
                    Tiles[i, 4].Type = Enums.TileType.Nothing;
                    nextRoom.Tiles[i, 0].Type = Enums.TileType.Nothing;
                }
            }

            if (y == 1)
            {
                for (int i = 1; i < 4; i++)
                {
                    Tiles[0, i].Type = Enums.TileType.Nothing;
                    nextRoom.Tiles[4, i].Type = Enums.TileType.Nothing;
                }
            }

            if (y == -1)
            {
                for (int i = 1; i < 4; i++)
                {
                    Tiles[4, i].Type = Enums.TileType.Nothing;
                    nextRoom.Tiles[0, i].Type = Enums.TileType.Nothing;
                }
            }

        }

        internal void FillRoom()
        {
            var random = new Random();

            if (random.Next(100) < _chanceEnemy)
                Tiles[2, 2].Type = Enums.TileType.Enemy;
            else if (random.Next(100) < _chanceTreasure)
                Tiles[2, 2].Type = Enums.TileType.Treasure;
            else if (random.Next(100) < _chanceBoss)
                Tiles[2, 2].Type = Enums.TileType.Boss;
        }
    }
}
