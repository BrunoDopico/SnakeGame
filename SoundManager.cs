using System;
using System.Collections.Generic;
using System.IO;
using System.Media;
using WMPLib;

namespace Snake_Game
{
    public static class SoundManager
    {
        private static WindowsMediaPlayer bgmPlayer;
        private static readonly Dictionary<string, byte[]> effectData = new Dictionary<string, byte[]>(StringComparer.OrdinalIgnoreCase);
        private static string effectsFolder = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Resources\\Sounds\\Effects");
        private static string currentMusicPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Resources\\Sounds\\Music\\");

        public static void Init()
        {
            // Background music (looped)
            bgmPlayer = new WindowsMediaPlayer();
            bgmPlayer.settings.setMode("loop", true);
            bgmPlayer.settings.volume = 30;

            // Load all effects
            effectData.Clear();
            if (Directory.Exists(effectsFolder))
            {
                foreach (var file in Directory.GetFiles(effectsFolder, "*.*", SearchOption.TopDirectoryOnly))
                {
                    var ext = Path.GetExtension(file).ToLowerInvariant();
                    if (ext == ".wav") // SoundPlayer supports only WAV
                    {
                        var name = Path.GetFileNameWithoutExtension(file);
                        try
                        {
                            effectData[name] = File.ReadAllBytes(file);
                        }
                        catch
                        {
                            // TODO: log or handle error
                        }
                    }
                }
            }
        }

        public static void SetBackgroundMusic(string theme)
        {
            if (bgmPlayer == null)
                return;

            string[] extensions = { ".mp3", ".wav", ".wma" };
            string musicFile = null;

            foreach (var ext in extensions)
            {
                string path = Path.Combine(currentMusicPath, theme + ext);
                if (File.Exists(path))
                {
                    musicFile = path;
                    break;
                }
            }

            if (musicFile == null)
            {
                foreach (var ext in extensions)
                {
                    string path = Path.Combine(currentMusicPath, "Default" + ext);
                    if (File.Exists(path))
                    {
                        musicFile = path;
                        break;
                    }
                }
            }

            if (musicFile != null)
            {
                bgmPlayer.URL = musicFile;
            }
        }

        public static void PlayBackgroundMusic()
        {
            if (bgmPlayer == null || string.IsNullOrEmpty(bgmPlayer.URL))
                return;
            bgmPlayer.controls.play();
        }

        public static void StopBackgroundMusic()
        {
            if (bgmPlayer == null)
                return;
            bgmPlayer.controls.stop();
        }

        public static void PlayEffect(string effectName)
        {
            if (effectData.TryGetValue(effectName, out var data))
            {
                var ms = new MemoryStream(data);
                var player = new SoundPlayer(ms);
                player.Play();
            }
            // Optionally handle missing effect (e.g., log or play a default sound)
        }
    }
}
