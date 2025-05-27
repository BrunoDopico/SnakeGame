using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Media;
using WMPLib;

namespace Snake_Game
{
    public static class SoundManager
    {
        private static WindowsMediaPlayer bgmPlayer;
        private static SoundPlayer eatPlayer;
        private static SoundPlayer startPlayer;
        private static SoundPlayer deathPlayer;

        private static string currentMusicPath = System.IO.Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Resources\\Sounds\\Music\\");
        public static void Init()
        {
            // Background music (looped)
            bgmPlayer = new WindowsMediaPlayer();
            bgmPlayer.settings.setMode("loop", true);
            bgmPlayer.settings.volume = 30; // Adjust as needed

            // Sound effects
            eatPlayer = new SoundPlayer(System.IO.Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Resources\\Sounds\\Effects\\eat.wav"));
            startPlayer = new SoundPlayer(System.IO.Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Resources\\Sounds\\Effects\\eat.wav"));
            deathPlayer = new SoundPlayer(System.IO.Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Resources\\Sounds\\Effects\\eat.wav"));
        }

        public static void SetBackgroundMusic(string theme)
        {
            if (bgmPlayer == null)
                return;

            string[] extensions = { ".mp3", ".wav", ".wma" };
            string musicFile = null;

            // Try to find the file for the given theme
            foreach (var ext in extensions)
            {
                string path = System.IO.Path.Combine(currentMusicPath, theme + ext);
                if (System.IO.File.Exists(path))
                {
                    musicFile = path;
                    break;
                }
            }

            // If not found, try the "Default" theme
            if (musicFile == null)
            {
                foreach (var ext in extensions)
                {
                    string path = System.IO.Path.Combine(currentMusicPath, "Default" + ext);
                    if (System.IO.File.Exists(path))
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

        public static void PlayEat()
        {
            eatPlayer.Play();
        }

        public static void PlayStart()
        {
            if (!startPlayer.IsLoadCompleted)
                return;
            startPlayer.Play();
        }

        public static void PlayDeath()
        {
            if (!deathPlayer.IsLoadCompleted)
                return;
            deathPlayer.Play();
        }
    }
}
