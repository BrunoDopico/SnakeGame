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
    public class ThemeManager
    {
        private readonly string _themesFolderPath;
        private Dictionary<SpriteType, Image> _sprites;

        public string CurrentTheme { get; private set; }
        public string CurrentMusicPath { get; private set; }

        public ThemeManager(string themesFolderPath)
        {
            _themesFolderPath = themesFolderPath;
            _sprites = new Dictionary<SpriteType, Image>();
        }

        public void LoadTheme(string themeName)
        {
            string themePath = Path.Combine(_themesFolderPath, themeName);
            if (!Directory.Exists(themePath))
            {
                Console.WriteLine($"Theme '{themeName}' not found. Falling back to Default.");
                themePath = Path.Combine(_themesFolderPath, "Default");
            }

            CurrentTheme = themeName;
            _sprites.Clear();

            foreach (SpriteType type in Enum.GetValues(typeof(SpriteType)))
            {
                string fileName = $"{type.ToString()}.png";
                string filePath = Path.Combine(themePath, fileName);

                try
                {
                    _sprites[type] = Image.FromFile(filePath);
                }
                catch
                {
                    Console.WriteLine($"Missing sprite '{fileName}' in theme '{themeName}'.");
                    // Load a fallback from Default theme if available
                    string fallbackPath = Path.Combine(_themesFolderPath, "Default", $"{type.ToString().ToLower()}.png");
                    _sprites[type] = File.Exists(fallbackPath) ? Image.FromFile(fallbackPath) : null;
                }
            }

            SoundManager.SetBackgroundMusic(themeName);
        }

        public Image GetSprite(SpriteType type)
        {
            if (_sprites.TryGetValue(type, out var image))
            {
                return image;
            }

            // Fallback to default sprite if missing
            string fallbackPath = Path.Combine(_themesFolderPath, "Default", $"{type.ToString().ToLower()}.png");
            return File.Exists(fallbackPath) ? Image.FromFile(fallbackPath) : null;
        }
    }
}
