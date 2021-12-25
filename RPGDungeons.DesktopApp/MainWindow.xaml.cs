using RPGDungeons.Library.World;
using RPGDungeons.Library.World.Enums;

using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Shapes;

namespace RPGDungeons.DesktopApp
{
    public partial class MainWindow : Window, INotifyPropertyChanged
    {
        private int _roomSize;
        private int _scale;
        private int _margin;
        private int _mapWidth;
        private int _mapHeigth;

        public event PropertyChangedEventHandler? PropertyChanged;

        public MapModel Map { get; set; }

        public int MapWidth
        {
            get { return _mapWidth; }
            set
            {
                _mapWidth = value;
                OnPropertyChanged();
            }
        }

        public int MapHeigth
        {
            get { return _mapHeigth; }
            set
            {
                _mapHeigth = value;
                OnPropertyChanged();
            }
        }

        public int Scale
        {
            get { return _scale; }
            set
            {
                _scale = value;
                OnPropertyChanged();
            }
        }


        public MainWindow()
        {
            InitializeComponent();
            InitializeVariables();

            DataContext = this;

            WorldGeneration world = new WorldGeneration(_mapHeigth, _mapWidth);
            Map = world.Map;

            SetGrid();
        }

        private void InitializeVariables()
        {
            _roomSize = 5;
            _margin = 10;
            Scale = 5;
            MapWidth = 20;
            MapHeigth = 20;
        }

        protected void OnPropertyChanged([CallerMemberName] string propertyName = "") => PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));

        private void DrawTile(int x, int y, int width, int heigth, TileType type)
        {
            x *= _scale;
            y *= _scale;
            width *= _scale;
            heigth *= _scale;

            var rect = new Rect()
            {
                Height = heigth * _scale / _roomSize,
                Width = width * _scale / _roomSize,
                Location = new Point(x + _margin * 2, y + _margin * 2)
            };

            Rectangle rectangle = new Rectangle();
            rectangle.Width = rect.Width;
            rectangle.Height = rect.Height;
            rectangle.Fill = GetTileColor(type);

            Canvas.SetLeft(rectangle, rect.X);
            Canvas.SetTop(rectangle, rect.Y);

            canvas_Map.Children.Add(rectangle);
        }

        private Brush GetTileColor(TileType type)
        {
            return type switch
            {
                TileType.Wall => Brushes.Black,
                TileType.Enemy => Brushes.Red,
                TileType.Boss => Brushes.Purple,
                TileType.Treasure => Brushes.Yellow,
                TileType.Start => Brushes.Gray,
                TileType.Exit => Brushes.Green,
                _ => Brushes.DarkGray
            };
        }

        private void SetGrid()
        {
            int counterX = 0;
            int counterY = 0;
            int roomLengthX = Map.Rooms.GetLength(1);
            int roomLengthY = Map.Rooms.GetLength(0);

            // Set Windowsize
            SetWindowSize(roomLengthX, roomLengthY);

            // Draw Rooms
            for (int roomY = 0; roomY < roomLengthY; roomY++)
            {
                for (int roomX = 0; roomX < roomLengthX; roomX++)
                {
                    if (Map.Rooms[roomY, roomX] == null || Map.Rooms[roomY, roomX].Tiles == null)
                        continue;

                    int roomTileLengthX = Map.Rooms[roomY, roomX].Tiles.GetLength(1);
                    int roomTileLengthY = Map.Rooms[roomY, roomX].Tiles.GetLength(0);

                    for (int tileY = 0; tileY < roomTileLengthY; tileY++)
                    {
                        for (int tileX = 0; tileX < roomTileLengthX; tileX++)
                        {
                            int currentX = tileX + counterX;
                            int currentY = tileY + counterY;
                            TileType type = Map.Rooms[roomY, roomX].Tiles[tileY, tileX].Type;

                            DrawTile(currentX, currentY, 1, 1, type);
                        }
                    }

                    // Calculate rooms offset in x-axis
                    counterX += _roomSize;

                    if (counterX == roomLengthX * _roomSize)
                        counterX = 0;
                }

                // Calculate rooms offset in y-axis
                counterY += _roomSize;
            }

        }

        private void SetWindowSize(int roomX, int roomY)
        {
            int bottomMargin = 200;
            int fullWidth = _margin + (roomX * _roomSize);
            int fullHeigth = _margin + (roomY * _roomSize);

            // Set Windowsize
            int sizeX = fullWidth * _scale;
            int sizeY = fullHeigth * _scale;
            this.Width = sizeX;
            this.Height = sizeY + bottomMargin;
        }

        private void Generate_Click(object sender, RoutedEventArgs e)
        {
            WorldGeneration world = new WorldGeneration(_mapHeigth, _mapWidth);
            Map = world.Map;

            foreach (var item in canvas_Map.Children)
            {
                if (item is Rectangle rect)
                {
                    rect.Fill = Brushes.Transparent;
                }
            }

            SetGrid();
        }
    }
}
