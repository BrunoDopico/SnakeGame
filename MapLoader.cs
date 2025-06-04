using Snake_Game.Entities;
using Snake_Game.Enums;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Globalization;
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

            var cellParsers = new Dictionary<char, Func<int, int, Cell>>
            {
                { '#', (x, y) => new Cell(CellType.Obstacle, 0, SpriteType.Wall) },
                { 'F', (x, y) => new Cell(CellType.Fruit, 1, SpriteType.FruitNormal) },
                { 'S', (x, y) => new Cell(CellType.Fruit, data.SpecialFruitValue, SpriteType.FruitSpecial) },
                { 'D', (x, y) => new Cell(CellType.DisappearFruit, 1, SpriteType.FruitDisappear) },
                { '^', (x, y) => { snakeHead = new Point(x, y); return new Cell(CellType.Snake, (int)Direction.Up, SpriteType.SnakeHeadUp); } },
                { 'v', (x, y) => { snakeHead = new Point(x, y); return new Cell(CellType.Snake, (int)Direction.Down, SpriteType.SnakeHeadDown); } },
                { '<', (x, y) => { snakeHead = new Point(x, y); return new Cell(CellType.Snake, (int)Direction.Left, SpriteType.SnakeHeadLeft); } },
                { '>', (x, y) => { snakeHead = new Point(x, y); return new Cell(CellType.Snake, (int)Direction.Right, SpriteType.SnakeHeadRight); } },
                // Add more mappings as needed
            };

            for (int y = 0; y < data.Height; y++)
            {
                string line = y < data.MapLines.Count ? data.MapLines[y] : string.Empty;
                for (int x = 0; x < data.Width; x++)
                {
                    Cell cell;
                    if (x < line.Length && cellParsers.TryGetValue(line[x], out var parser))
                    {
                        cell = parser(x, y);
                    }
                    else
                    {
                        cell = new Cell(CellType.Void, 0);
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
                var lines = File.ReadAllLines(file);
                var sections = ParseSections(lines);

                // Parse metadata and map lines using dedicated methods
                var metadata = sections.ContainsKey("METADATA") ? ParseMetadata(sections["METADATA"]) : new Dictionary<string, string>();
                int width = int.Parse(metadata["Width"]);
                int height = int.Parse(metadata["Height"]);
                var mapLines = sections.ContainsKey("MAP") ? ParseMapLines(sections["MAP"], width, height) : new List<string>();

                maps.Add(ParseMapInfo(file, metadata, mapLines));
            }

            return maps;
        }

        // Splits the file into sections by header (e.g., #METADATA, #MAP, #SCORES)
        private static Dictionary<string, List<string>> ParseSections(string[] lines)
        {
            var sections = new Dictionary<string, List<string>>(StringComparer.OrdinalIgnoreCase);
            string currentSection = "METADATA"; // Default section if not specified
            sections[currentSection] = new List<string>();

            foreach (var rawLine in lines)
            {
                var line = rawLine;
                if (currentSection != "MAP")
                    line = rawLine.Trim();
                if (currentSection != "MAP" && (string.IsNullOrWhiteSpace(line) || line.StartsWith("//")))
                    continue;

                if (line.StartsWith("@"))
                {
                    var sectionName = line.TrimStart('@').Trim().ToUpperInvariant();
                    currentSection = sectionName;
                    if (!sections.ContainsKey(currentSection))
                        sections[currentSection] = new List<string>();
                    continue;
                }

                sections[currentSection].Add(line);
            }
            return sections;
        }

        private static Dictionary<string, string> ParseMetadata(List<string> lines)
        {
            var metadata = new Dictionary<string, string>(StringComparer.OrdinalIgnoreCase);
            foreach (var line in lines)
            {
                var parts = line.Split(':');
                if (parts.Length == 2)
                    metadata[parts[0].Trim()] = parts[1].Trim();
            }
            return metadata;
        }

        private static List<string> ParseMapLines(List<string> lines, int expectedWidth, int expectedHeight)
        {
            var result = new List<string>(expectedHeight);

            for (int i = 0; i < expectedHeight; i++)
            {
                if (i < lines.Count)
                {
                    var line = lines[i];
                    // Trim or pad the line as needed
                    if (line.Length > expectedWidth)
                        result.Add(line.Substring(0, expectedWidth));
                    else
                        result.Add(line); // If shorter, LoadMapIntoGame will handle missing cells
                }
                else
                {
                    // Fill missing lines with empty strings
                    result.Add(string.Empty);
                }
            }

            return result;
        }

        private static MapInfo ParseMapInfo(string file, Dictionary<string, string> metadata, List<string> mapLines)
        {
            string name = metadata.ContainsKey("Name") ? metadata["Name"] : "Unnamed Map";
            string theme = metadata.ContainsKey("Theme") ? metadata["Theme"] : "Default";
            int width = int.Parse(metadata["Width"]);
            int height = int.Parse(metadata["Height"]);
            int difficulty = int.Parse(metadata["Difficulty"]);
            int initialSnakeLength = metadata.ContainsKey("InitialSnakeLength") ? int.Parse(metadata["InitialSnakeLength"]) : 4;
            int specialFruitValue = metadata.ContainsKey("SpecialFruitValue") ? int.Parse(metadata["SpecialFruitValue"]) : 3;
            bool specialFruitAvailable = metadata.ContainsKey("SpecialFruitAvailable") ? bool.Parse(metadata["SpecialFruitAvailable"]) : true;
            double specialFruitChance = metadata.ContainsKey("SpecialFruitChance") ? double.Parse(metadata["SpecialFruitChance"], System.Globalization.CultureInfo.InvariantCulture) : 0.05;

            return new MapInfo
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
            };
        }
    }
}
