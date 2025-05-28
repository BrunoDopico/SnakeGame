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
    public static class ThemeManager
    {
        private static string _themesFolderPath;
        private static Dictionary<SpriteType, Image> _sprites = new Dictionary<SpriteType, Image>();

        public static string CurrentTheme { get; private set; }

        public static void Init(string themesFolderPath)
        {
            if (!Directory.Exists(themesFolderPath))
                throw new DirectoryNotFoundException($"Theme folder path '{themesFolderPath}' does not exist.");

            _themesFolderPath = themesFolderPath;
        }

        public static void LoadTheme(string themeName)
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
                if(type == SpriteType.None)
                    continue;
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
                    _sprites[type] = File.Exists(fallbackPath) ? Image.FromFile(fallbackPath) : CreateErrorImage();
                }
            }

            SoundManager.SetBackgroundMusic(themeName);
        }

        public static Image GetSprite(SpriteType type)
        {
            if (type == SpriteType.None)
                return null;
            if (_sprites.TryGetValue(type, out var image))
            {
                return image;
            }

            // Fallback to default sprite if missing
            string fallbackPath = Path.Combine(_themesFolderPath, "Default", $"{type.ToString().ToLower()}.png");
            return File.Exists(fallbackPath) ? Image.FromFile(fallbackPath) : CreateErrorImage();
        }

        public static Image GetImage(string themeName, string imageName)
        {
            string fileName = imageName.EndsWith(".png", StringComparison.OrdinalIgnoreCase)
                ? imageName
                : imageName + ".png";

            if (string.Equals(themeName, CurrentTheme, StringComparison.OrdinalIgnoreCase))
            {
                // Try to find in loaded sprites
                foreach (var kvp in _sprites)
                {
                    if (string.Equals($"{kvp.Key}.png", fileName, StringComparison.OrdinalIgnoreCase))
                        return kvp.Value;
                }
            }

            // Try to load from theme folder
            string themePath = Path.Combine(_themesFolderPath, themeName, fileName);
            if (File.Exists(themePath))
                return Image.FromFile(themePath);

            // Fallback to Default theme
            string fallbackPath = Path.Combine(_themesFolderPath, "Default", fileName);
            if (File.Exists(fallbackPath))
                return Image.FromFile(fallbackPath);

            return null;
        }

        private static Image CreateErrorImage()
        {
            Bitmap bmp = new Bitmap(32, 32);
            using (Graphics g = Graphics.FromImage(bmp))
            {
                g.Clear(Color.Magenta);
                using (Pen pen = new Pen(Color.Red, 3))
                {
                    g.DrawLine(pen, 0, 0, 31, 31);
                    g.DrawLine(pen, 31, 0, 0, 31);
                }
            }
            return bmp;
        }
    }
}
