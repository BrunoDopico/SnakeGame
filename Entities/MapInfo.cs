using Snake_Game.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Snake_Game.Entities
{
    public class MapInfo
    {
        public string FilePath { get; set; }
        public string Name { get; set; } = "Unnamed Map";
        public string Theme { get; set; } = "Default";
        public Difficulty Difficulty { get; set; }
        public int Width { get; set; }
        public int Height { get; set; }
        public int InitialSnakeLength { get; set; } = 4;
        public int SpecialFruitValue { get; set; } = 3;
        public bool SpecialFruitAvailable { get; set; } = true;
        public double SpecialFruitChance { get; set; } = 0.05;
        public List<string> MapLines { get; set; } = new List<string>();
    }
}
