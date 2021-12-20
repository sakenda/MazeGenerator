namespace RPGDungeons.Library.World
{
    public class WorldGeneration
    {
        private int _rows = 4;
        private int _columns = 12;
        private RoomModel _currentRoom;
        private Stack<RoomModel> _path;

        public MapModel Map { get; private set; }

        public WorldGeneration(int rows, int columns)
        {
            _rows = rows;
            _columns = columns;
            _path = new Stack<RoomModel>();

            GenerateMap();
        }

        private void GenerateMap()
        {
            InitializeMap();
            SetStartRoom();
            SetPath();
        }

        private void InitializeMap()
        {
            Map = new MapModel();
            Map.Rooms = new RoomModel[_rows, _columns];
            for (int y = 0; y < Map.Rooms.GetLength(0); y++)
                for (int x = 0; x < Map.Rooms.GetLength(1); x++)
                    Map.Rooms[y, x] = new RoomModel(y, x);
        }

        private void SetStartRoom()
        {
            var random = new Random();

            int y = random.Next(0, _rows);
            int x = random.Next(0, _columns);
            Map.Rooms[y, x].Type = Enums.RoomType.Start;
            Map.Rooms[y, x].Tiles[2, 2].Type = Enums.TileType.Start;

            // Set start room as current room
            _currentRoom = Map.Rooms[y, x];
            Map.Rooms[y, x].Visited = true;
        }

        private void SetExitRoom()
        {
            var random = new Random();

            int y = random.Next(0, _rows);
            int x = random.Next(0, _columns);

            if (Map.Rooms[y, x].Type == Enums.RoomType.Start)
            {
                SetExitRoom(); 
            }
            else
            {
                Map.Rooms[y, x].Type = Enums.RoomType.Exit;
                Map.Rooms[y, x].Tiles[2, 2].Type = Enums.TileType.Exit;
            }
        }

        private void SetPath()
        {
            do
            {
                var nextRoom = Map.Rooms[_currentRoom.Y, _currentRoom.X].CheckNeighbors(Map);

                if (nextRoom != null)
                {
                    if (Map.Rooms[nextRoom.Y, nextRoom.X].Type != Enums.RoomType.Start)
                        Map.Rooms[nextRoom.Y, nextRoom.X].Type = Enums.RoomType.Room;

                    Map.Rooms[nextRoom.Y, nextRoom.X].Visited = true;

                    _path.Push(_currentRoom);
                    _currentRoom.RemoveWall(nextRoom);
                    _currentRoom.FillRoom();

                    _currentRoom = nextRoom;
                }
                else if (_path.Count > 0)
                {
                    _currentRoom = _path.Pop();
                }
                else
                {
                    SetExitRoom();
                    break;
                }
            }
            while (true);
        }

    }
}
