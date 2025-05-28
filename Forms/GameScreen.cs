using Snake_Game.Entities;
using Snake_Game.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Snake_Game.Forms
{
    public partial class GameScreen : Form
    {
        GameController controller;
        Timer gameLoop = new Timer();
        bool inGame = false;
        private int defaultFormWidth;

        private int cellSize = 32;
        public GameScreen()
        {
            InitializeComponent();

            typeof(Panel).InvokeMember("DoubleBuffered",
    System.Reflection.BindingFlags.SetProperty | System.Reflection.BindingFlags.Instance | System.Reflection.BindingFlags.NonPublic,
    null, panelGame, new object[] { true });

            gameLoop.Tick += GameLoop;
            controller = new GameController(this);
            defaultFormWidth = this.Width;
        }

        public void PaintMap()
        {
            panelGame.Invalidate();
        }

        public void UpdateCell(int x, int y)
        {
            Rectangle cellRect = new Rectangle(x * cellSize, y * cellSize, cellSize, cellSize);
            panelGame.Invalidate(cellRect);
        }

        private void StartRandomGame()
        {
            ThemeManager.LoadTheme("Default");
            
            panelGame.Size = new Size(Config.MAP_X * cellSize, Config.MAP_Y * cellSize);
            int width = Math.Max(defaultFormWidth, panelGame.Right + 64);
            int height = panelGame.Bottom + 128;
            this.Size = new Size(width, height);
            this.CenterToScreen();

            controller.StartRandomGame();
            PaintMap();
            gameLoop.Interval = Config.TIMER;   // milliseconds
            gameLoop.Start();
            SoundManager.PlayBackgroundMusic();
            inGame = true;
        }

        private void StartCustomGame(MapInfo customMap)
        {
            ThemeManager.LoadTheme(customMap.Theme);

            controller.StartCustomGame(customMap);
            panelGame.Size = new Size(Config.MAP_X * cellSize, Config.MAP_Y * cellSize);
            int width = Math.Max(defaultFormWidth, panelGame.Right + 64);
            int height = panelGame.Bottom + 128;
            this.Size = new Size(width, height);
            this.CenterToScreen();
            PaintMap();

            gameLoop.Interval = Config.TIMER;   // milliseconds
            gameLoop.Start();
            SoundManager.PlayBackgroundMusic();
            inGame = true;
        }

        private void GameLoop(object sender, EventArgs e)  //run this logic each timer tick
        {
            Task.Run(() =>
         {
             controller.GameLoop();
             if (controller.Lose)
             {
                 Invoke(new Action(() =>
                 {
                     gameLoop.Stop();
                     inGame = false;
                     SoundManager.StopBackgroundMusic();
                     SoundManager.PlayEffect("death");
                 }));
             }
         });
        }

        private void Pause()
        {
            gameLoop.Stop();
            MessageBox.Show("Game is paused", "PAUSE", MessageBoxButtons.OK, MessageBoxIcon.Information);
            gameLoop.Start();
        }


        public void ChangeInfo(string msg)
        {
            if (lbInfo.InvokeRequired)
            {
                lbInfo.Invoke(new Action(() => ChangeInfo(msg)));
            }
            else
            {
                lbInfo.Text = msg;
                lbInfo.BringToFront();
            }
        }

        private void GameScreen_KeyPress(object sender, KeyPressEventArgs e)
        {
            ConsoleKey key = (ConsoleKey)Char.ToUpper(e.KeyChar);
            if (key.Equals(Config.IN_PAUSE)) Pause();
            else if (key.Equals(Config.IN_NEW)) StartRandomGame();
            else controller.getInput(key);
        }

        private void bt_Options_Click(object sender, EventArgs e)
        {
            SoundManager.PlayEffect("click");
            gameLoop.Stop();
            Form options = new Options();
            options.ShowDialog(this);
            if (inGame) gameLoop.Start();
        }

        private void bt_newGame_Click(object sender, EventArgs e)
        {
            SoundManager.PlayEffect("click");
            StartRandomGame();
        }

        private void bt_exit_Click(object sender, EventArgs e)
        {
            SoundManager.PlayEffect("click");
            Application.Exit();
        }

        private void bt_Credits_Click(object sender, EventArgs e)
        {
            SoundManager.PlayEffect("click");
            gameLoop.Stop();
            MessageBox.Show("- THE GAME -\n" +
                "\nThis is the snake game." +
                "\nThe objective of this game is to survive for as long as possible while eating fruits to make your snake's body larger." +
                "\nTouching an obstacle or your own body will instantly kill you.\n" +
                "\n- CONTROLS -\n" +
                " · Move Up: " + Config.IN_UP.ToString() +
                "\n · Move Down: " + Config.IN_DOWN.ToString() +
                "\n · Move Left: " + Config.IN_LEFT.ToString() +
                "\n · Move Right: " + Config.IN_RIGHT.ToString() +
                "\n · Pause: " + Config.IN_PAUSE.ToString() +
                "\n · New Random Game: " + Config.IN_NEW.ToString() +
                "\n (Can be changed in options)\n" +
                "\n- CREDITS -\n" +
                "Game made by Bruno (BrunusOP) Dopico\n", "CREDITS", MessageBoxButtons.OK, MessageBoxIcon.Information);
            if (inGame) gameLoop.Start();
        }

        private void btLoadMap_Click(object sender, EventArgs e)
        {
            SoundManager.PlayEffect("click");
            using (var mapSelector = new MapSelector())
            {
                if (mapSelector.ShowDialog() == DialogResult.OK)
                {
                    MapInfo selectedMap = mapSelector.SelectedMap;

                    StartCustomGame(selectedMap);
                }
                else
                {
                    MessageBox.Show("No map was selected.", "Map Selection", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
        }

        private void buttons_MouseEnter(object sender, EventArgs e)
        {
            SoundManager.PlayEffect("hover");
        }

        private void panelGame_Paint(object sender, PaintEventArgs e)
        {
            if (controller?.Map == null) return;
            var g = e.Graphics;
            var clip = e.ClipRectangle;

            // Calculate the range of cell indices that intersect with the clip rectangle
            int minX = Math.Max(0, clip.Left / cellSize);
            int maxX = Math.Min(Config.MAP_X - 1, (clip.Right - 1) / cellSize);
            int minY = Math.Max(0, clip.Top / cellSize);
            int maxY = Math.Min(Config.MAP_Y - 1, (clip.Bottom - 1) / cellSize);

            for (int x = minX; x <= maxX; x++)
            {
                for (int y = minY; y <= maxY; y++)
                {
                    Rectangle cellRect = new Rectangle(x * cellSize, y * cellSize, cellSize, cellSize);

                    // Draw background
                    Image background = ThemeManager.GetSprite(SpriteType.Background);
                    if (background != null)
                        g.DrawImage(background, cellRect);

                    // Draw cell sprite
                    Cell current = controller.Map[x, y];
                    Image sprite = ThemeManager.GetSprite(current.Sprite);

                    if (sprite != null)
                        g.DrawImage(sprite, cellRect);
                }
            }
        }
    }
}
