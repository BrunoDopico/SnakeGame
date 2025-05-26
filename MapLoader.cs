using Snake_Game.Entities;
using Snake_Game.Enums;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;

namespace Snake_Game
{
    public static class MapLoader
    {
        /// <summary>
        /// Loads a map from a file.
        /// </summary>
        /// <param name="data">The map data.</param>
        /// <returns>A touple containing the retrieved map and the snake's initial position.</returns>
        public static (Cell[,], Point) LoadMapIntoGame(MapInfo data)
        {
            // Store map data to global vars
            Config.MAP_X = data.Width;
            Config.MAP_Y = data.Height;
            Config.DIFFICULTY = data.Difficulty;
            Config.INITIAL_SNAKE_SIZE = data.InitialSnakeLength;
            Config.SPECIAL_FRUIT_PCT = data.SpecialFruitChance;
            Config.SPECIAL_FRUIT_VALUE = data.SpecialFruitValue;

            Cell[,] grid = new Cell[data.Width, data.Height];
            Point snakeHead = new Point(-1,-1);

            for (int y = 0; y < data.Height; y++)
            {
                string line = data.MapLines[y];
                for (int x = 0; x < data.Width; x++)
                {
                    if (x >= line.Length)
                    {
                        grid[x, y] = new Cell(CellType.Void, 0); // Fill with void if line is shorter than the width (empty)
                        continue;
                    }

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

                        case 'S':
                            cell = new Cell(CellType.Fruit, data.SpecialFruitValue);
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

                string name = "Unnamed Map";
                string theme = "Default";
                int initialSnakeLength = 4, specialFruitValue = 3;
                bool specialFruitAvailable = true;
                double specialFruitChance = 0.05;

                // Parse metadata
                if (metadata.ContainsKey("Name"))
                    name = metadata["Name"];
                if (metadata.ContainsKey("Theme")) 
                    theme = metadata["Theme"];

                int width = int.Parse(metadata["Width"]);
                int height = int.Parse(metadata["Height"]);
                int difficulty = int.Parse(metadata["Difficulty"]);
                if(metadata.ContainsKey("InitialSnakeLength"))
                    initialSnakeLength = int.Parse(metadata["InitialSnakeLength"]);
                if (metadata.ContainsKey("SpecialFruitAvailable"))
                    specialFruitAvailable = Boolean.Parse(metadata["SpecialFruitAvailable"]);
                if(metadata.ContainsKey("SpecialFruitChance"))
                    specialFruitChance = double.Parse(metadata["SpecialFruitChance"]);
                if(metadata.ContainsKey("SpecialFruitValue"))
                    specialFruitValue = int.Parse(metadata["SpecialFruitValue"]);

                maps.Add(new MapInfo
                {
                    FilePath = file,
                    Name = name,
                    Theme = theme,
                    Width = width,
                    Height = height,
                    Difficulty = (Difficulty)difficulty,
                    InitialSnakeLength = initialSnakeLength,
                    SpecialFruitValue = specialFruitValue,
                    SpecialFruitAvailable = specialFruitAvailable,
                    SpecialFruitChance = specialFruitChance,
                    MapLines = mapLines,
                });
            }

            return maps;
        }
    }
}
