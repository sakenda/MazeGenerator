using RPGDungeons.Library.Models.World;

namespace RPGDungeons.Library
{
    public class WorldGeneration
    {
        private double _chanceEnemy = 5;
        private double _chanceTreasure = 1;
        private double _chanceSidePath = 50;
        private int _rows = 4;
        private int _columns = 12;
        private int _tileSize = 5;
        private int _startX;
        private int _startY;
        private int _endX;
        private int _endY;
        private RoomModel _currentRoom;
        private List<RoomModel> _floorPath;

        private RoomModel CurrentRoom
        {
            set
            {
                _currentRoom = value;
                _floorPath.Add(_currentRoom);
            }
        }
        private RoomModel StartRoom
        {
            get => Map.Rooms[_startY, _startX];
            set => Map.Rooms[_startY, _startX] = value;
        }
        private RoomModel ExitRoom
        {
            get => Map.Rooms[_endY, _endX];
            set => Map.Rooms[_endY, _endX] = value;
        }

        public MapModel Map { get; private set; }

        public WorldGeneration(Enums.MapSize size = Enums.MapSize.Small)
        {
            _rows *= (int)size / 100;
            _columns *= (int)size / 100;

            _floorPath = new List<RoomModel>();
            Map = new MapModel();
            Map.Rooms = new RoomModel[_rows, _columns];

            GenerateMap();
        }

        private void GenerateMap()
        {
            SetStartEndPoints();
            SetPath();
            SetSidePaths();
            BuildRooms();
        }


        private void SetStartEndPoints()
        {
            var random = new Random();

            // Instantiate start room
            _startX = random.Next(0, _columns);
            _startY = random.Next(0, _rows);
            StartRoom = new RoomModel();
            StartRoom.X = _startX;
            StartRoom.Y = _startY;
            StartRoom.Type = Enums.RoomType.Start;
            StartRoom.LastDirection = Enums.RoomDirection.None;

            // Instantiate exit room
            _endX = random.Next(0, _columns);
            _endY = random.Next(0, _rows);
            ExitRoom = new RoomModel();
            ExitRoom.X = _endX;
            ExitRoom.Y = _endY;
            ExitRoom.Type = Enums.RoomType.Exit;
            ExitRoom.NextDirection = Enums.RoomDirection.None;

            // Set start room as current room
            CurrentRoom = StartRoom;
        }

        private void SetPath()
        {
            // Store path in order (start => exit) to place bosses in specific rooms

            if (_currentRoom.Y > ExitRoom.Y)
            {
                Map.Rooms[_currentRoom.Y, _currentRoom.X].NextDirection = Enums.RoomDirection.Top;
                InstantiateNextRoom(_currentRoom.Y - 1, _currentRoom.X, Enums.RoomDirection.Bottom);
            }
            else if (_currentRoom.Y < ExitRoom.Y)
            {
                Map.Rooms[_currentRoom.Y, _currentRoom.X].NextDirection = Enums.RoomDirection.Bottom;
                InstantiateNextRoom(_currentRoom.Y + 1, _currentRoom.X, Enums.RoomDirection.Top);
            }
            else if (_currentRoom.X > ExitRoom.X)
            {
                Map.Rooms[_currentRoom.Y, _currentRoom.X].NextDirection = Enums.RoomDirection.Left;
                InstantiateNextRoom(_currentRoom.Y, _currentRoom.X - 1, Enums.RoomDirection.Right);
            }
            else if (_currentRoom.X < ExitRoom.X)
            {
                Map.Rooms[_currentRoom.Y, _currentRoom.X].NextDirection = Enums.RoomDirection.Right;
                InstantiateNextRoom(_currentRoom.Y, _currentRoom.X + 1, Enums.RoomDirection.Left);
            }

            // Execute recursive until currentposition and exit position match
            if (_currentRoom.Y == ExitRoom.Y && _currentRoom.X == ExitRoom.X)
                return;
                
            SetPath();
        }

        private void InstantiateNextRoom(int y, int x, Enums.RoomDirection direction)
        {
            // Check for start/exit rooms
            if (Map.Rooms[y, x] == null)
            {
                Map.Rooms[y, x] = new RoomModel();
                Map.Rooms[y, x].X = x;
                Map.Rooms[y, x].Y = y;
                Map.Rooms[y, x].Type = Enums.RoomType.Room;
            }
            Map.Rooms[y, x].LastDirection = direction;

            // Set currentroom for next iteration
            CurrentRoom = Map.Rooms[y, x];
        }

        private void SetSidePaths()
        {
            var random = new Random();

            foreach (var room in Map.Rooms)
            {
                if (room == null)
                    continue;

                if (room.Type == Enums.RoomType.Start || room.Type == Enums.RoomType.Exit)
                    continue;

                //if (random.Next(100) < _chanceSidePath)
                {
                    //CreateSidePathPassage(room);
                    //CreateSidePath(); 
                }
            }
        }

        private void CreateSidePathPassage(RoomModel room)
        {
            bool canBuildLeft = (room.X - 1) > 0 
                              && Map.Rooms[room.Y, room.X - 1] == null;
            bool canBuildTop = (room.Y - 1) > 0
                             && Map.Rooms[room.Y - 1, room.X] == null;
            bool canBuildRight = (room.X + 1) < Map.Rooms.GetLength(1)
                               && Map.Rooms[room.Y, room.X + 1] == null;
            bool canBuildBottom = (room.Y + 1) < Map.Rooms.GetLength(0)
                                && Map.Rooms[room.Y + 1, room.X] == null;

            if (canBuildLeft)
            {
                InstantiateNextRoom(room.Y, room.X - 1, Enums.RoomDirection.Right);
            }
            if (canBuildTop)
            {
                InstantiateNextRoom(room.Y - 1, room.X, Enums.RoomDirection.Bottom);
            }
            if (canBuildRight)
            {
                InstantiateNextRoom(room.Y, room.X + 1, Enums.RoomDirection.Left);
            }
            if (canBuildBottom)
            {
                InstantiateNextRoom(room.Y + 1, room.X, Enums.RoomDirection.Top);
            }
        }

        private void BuildRooms()
        {
            var random = new Random();

            foreach (var room in Map.Rooms)
            {
                // Skip empty rooms
                if (room == null)
                    continue;
                
                // Instantiate tiles
                room.Tiles = new TileModel[_tileSize, _tileSize];

                // Instantiate all tiles
                for (int y = 0; y < _tileSize; y++)
                {
                    for (int x = 0; x < _tileSize; x++)
                    {
                        if (room.Tiles[y, x] == null)
                            room.Tiles[y, x] = new TileModel();
                    }
                }

                for (int y = 0; y < _tileSize; y++)
                {
                    for (int x = 0; x < _tileSize; x++)
                    {
                        // Build walls
                        if (y == 0 || y == _tileSize - 1 || x == 0 || x == _tileSize - 1)
                            room.Tiles[y, x].Type = Enums.TileType.Wall;

                        // Set passage from last direction
                        switch (room.LastDirection)
                        {
                            case Enums.RoomDirection.Left:
                                room.Tiles[2, 0].Type = Enums.TileType.Passage;
                                break;
                            case Enums.RoomDirection.Top:
                                room.Tiles[0, 2].Type = Enums.TileType.Passage;
                                break;
                            case Enums.RoomDirection.Right:
                                room.Tiles[2, _tileSize - 1].Type = Enums.TileType.Passage;
                                break;
                            case Enums.RoomDirection.Bottom:
                                room.Tiles[_tileSize - 1, 2].Type = Enums.TileType.Passage;
                                break;
                            default:
                                break;
                        }

                        // Set passage from next direction
                        switch (room.NextDirection)
                        {
                            case Enums.RoomDirection.Left:
                                room.Tiles[2, 0].Type = Enums.TileType.Passage;
                                break;
                            case Enums.RoomDirection.Top:
                                room.Tiles[0, 2].Type = Enums.TileType.Passage;
                                break;
                            case Enums.RoomDirection.Right:
                                room.Tiles[2, _tileSize - 1].Type = Enums.TileType.Passage;
                                break;
                            case Enums.RoomDirection.Bottom:
                                room.Tiles[_tileSize - 1, 2].Type = Enums.TileType.Passage;
                                break;
                            default:
                                break;
                        }

                        // Set start point
                        if (room.Type == Enums.RoomType.Start)
                            room.Tiles[2, 2].Type = Enums.TileType.Start;
                        // Set exit point
                        else if (room.Type == Enums.RoomType.Exit)
                            room.Tiles[2, 2].Type = Enums.TileType.Exit;
                        
                        // Place money and enemy's, but only in rooms without start / exit
                        if (room.Type == Enums.RoomType.Room && room.Tiles[y, x].Type == Enums.TileType.Nothing)
                        {
                            if (random.Next(100) < _chanceEnemy)
                                room.Tiles[y, x].Type = Enums.TileType.Enemy;

                            else if (random.Next(100) < _chanceTreasure)
                                room.Tiles[y, x].Type = Enums.TileType.Treasure;
                        }

                    }
                }

            }

            // Place Boss when path is larger than 2 rooms
            if (_floorPath.Count > 2)
            {
                int roomBeforExitY = _floorPath[_floorPath.Count - 2].Y;
                int roomBeforExitX = _floorPath[_floorPath.Count - 2].X;
                Map.Rooms[roomBeforExitY, roomBeforExitX].Tiles[2, 2].Type = Enums.TileType.Boss;
            }

        }

    }
}
