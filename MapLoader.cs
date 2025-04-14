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

    }
}
