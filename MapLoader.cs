using Snake_Game.Entities;
using Snake_Game.Enums;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Snake_Game
{
    public static class MapLoader
    {
        /// <summary>
        /// Loads a map from a file.
        /// </summary>
        /// <param name="path">The path where the map is located.</param>
        /// <returns>A touple containing the retrieved map and the snake's initial position.</returns>
        public static (Cell[,], Point) LoadMapFromFile(string path)
        {
            string[] lines = File.ReadAllLines(path);

            Dictionary<string, string> metadata = new Dictionary<string, string>();
            List<string> mapLines = new List<string>();

            bool readingMap = false;
            foreach (string rawLine in lines)
            {
                string line = rawLine.Trim();

                if (string.IsNullOrWhiteSpace(line) || line.StartsWith("//"))
                    continue;

                if (line.StartsWith("# MAP"))
                {
                    readingMap = true;
                    continue;
                }

                if (!readingMap)
                {
                    // Metadata line (e.g. "Width: 10")
                    string[] parts = line.Split(':');
                    if (parts.Length == 2)
                    {
                        metadata[parts[0].Trim()] = parts[1].Trim();
                    }
                }
                else
                {
                    mapLines.Add(line);
                }
            }

            // Parse metadata
            int width = int.Parse(metadata["Width"]);
            int height = int.Parse(metadata["Height"]);
            int difficulty = int.Parse(metadata["Difficulty"]);
            int initialSnakeLength = int.Parse(metadata["InitialSnakeLength"]);
            bool specialFruitAvailable = Boolean.Parse(metadata["SpecialFruitAvailable"]);
            double specialFruitChance = double.Parse(metadata["SpecialFruitChance"]);
            int specialFruitValue = int.Parse(metadata["SpecialFruitValue"]);

            // Store to global vars or config system
            Config.MAP_X = width;
            Config.MAP_Y = height;
            Config.DIFFICULTY = (Difficulty) difficulty;
            Config.INITIAL_SNAKE_SIZE = initialSnakeLength;
            Config.SPECIAL_FRUIT_PCT = specialFruitChance;
            Config.SPECIAL_FRUIT_VALUE = specialFruitValue;

            Cell[,] grid = new Cell[width, height];
            Point snakeHead = new Point(-1,-1);

            for (int y = 0; y < height; y++)
            {
                string line = mapLines[y];
                for (int x = 0; x < width; x++)
                {
                    char c = line[x];
                    Cell cell;

                    switch (c)
                    {
                        case '#':
                            cell = new Cell(CellType.Obstacle, 0);
                            break;

                        case 'F':
                            cell = new Cell(CellType.Fruit, 1);
                            break;

                        case '^':
                            cell = new Cell(CellType.Snake, value: (int)Direction.Up);
                            snakeHead = new Point(x, y);
                            break;

                        case 'v':
                            cell = new Cell(CellType.Snake, value: (int)Direction.Down);
                            snakeHead = new Point(x, y);
                            break;

                        case '<':
                            cell = new Cell(CellType.Snake, value: (int)Direction.Left);
                            snakeHead = new Point(x, y);
                            break;

                        case '>':
                            cell = new Cell(CellType.Snake, value: (int)Direction.Right);
                            snakeHead = new Point(x, y);
                            break;

                        default:
                            cell = new Cell(CellType.Void, 0);
                            break;
                    }

                    grid[x, y] = cell;
                }
            }
            return (grid, snakeHead);
        }

        /// <summary>
        /// Retrieves a list of available maps from the specified folder.
        /// </summary>
        /// <param name="folderPath">The folder to retrieve maps from.</param>
        /// <returns>A list of all the found maps in the selected folder.</returns>
        public static List<MapInfo> GetAvailableMaps(string folderPath)
        {
            var maps = new List<MapInfo>();
            var files = Directory.GetFiles(folderPath, "*.txt");

            foreach (var file in files)
            {
                string[] lines = File.ReadAllLines(file);

                string name = "Unnamed Map";
                string theme = "Default";
                int width = 0, height = 0;
                Difficulty difficulty = Difficulty.Easy;

                foreach (string line in lines)
                {
                    if (line.StartsWith("# MAP")) break;

                    var parts = line.Split(':');
                    if (parts.Length != 2) continue;

                    string key = parts[0].Trim();
                    string value = parts[1].Trim();

                    switch (key)
                    {
                        case "Name": name = value; break;
                        case "Theme": theme = value; break;
                        case "Width": width = int.Parse(value); break;
                        case "Height": height = int.Parse(value); break;
                        case "Difficulty": difficulty = (Difficulty) int.Parse(value); break;
                    }
                }

                maps.Add(new MapInfo
                {
                    FilePath = file,
                    Name = name,
                    Theme = theme,
                    Width = width,
                    Height = height,
                    Difficulty = difficulty
                });
            }

            return maps;
        }
    }
}
