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
        PictureBox[,] grid;
        GameController controller;
        ThemeManager themeManager;
        Timer gameLoop = new Timer();
        bool inGame = false;
        private int defaultFormWidth;
        
        public GameScreen()
        {
            InitializeComponent();
            themeManager = new ThemeManager(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "..", "..", "Resources"));
            gameLoop.Tick += GameLoop;
            controller = new GameController(this);
            InitializeComponent();
            defaultFormWidth = this.Width;
        }

        private void FillGrid()
        {
            int x_margin = 32;
            int y_margin = 96;
            for (int i = 0; i < grid.GetLength(0); i++)
            {
                for (int j = 0; j < grid.GetLength(1); j++)
                {
                    grid[i, j] = new PictureBox();
                    grid[i, j].BackgroundImage = themeManager.GetSprite(SpriteType.Background);
                    grid[i, j].Location = new Point(x_margin + 32 * i, y_margin + 32 * j);
                    grid[i, j].Visible = true;
                    grid[i, j].Size = new Size(32, 32);
                    this.Controls.Add(grid[i, j]);
                }
            }
        }

        private void ClearGrid()
        {
            if (grid != null)
            {
                foreach (PictureBox pb in grid) this.Controls.Remove(pb);
                Array.Clear(grid, 0, grid.Length - 1);
            }
        }

        public void PaintMap()
        {
            Image sprite;
            Cell[,] map = controller.Map;
            for (int i = 0; i < Config.MAP_X; i++)
            {
                for (int j = 0; j < Config.MAP_Y; j++)
                {
                    Cell current = map[i, j];
                    switch (current.Type)
                    {
                        case CellType.Void:
                            break;
                        case CellType.Obstacle:
                            sprite = themeManager.GetSprite(SpriteType.Wall);
                            PaintCell(i, j, sprite);
                            break;
                        case CellType.Fruit:
                            if (current.Value == Config.SPECIAL_FRUIT_VALUE) sprite = themeManager.GetSprite(SpriteType.FruitSpecial);
                            else sprite = themeManager.GetSprite(SpriteType.FruitNormal);
                            PaintCell(i, j, sprite);
                            break;
                        case CellType.Snake:
                            sprite = themeManager.GetSprite(SpriteType.SnakeHeadLeft);
                            PaintCell(i, j, sprite);
                            break;
                    }
                }
            }
        }

        public void UpdateCell(int x, int y, SpriteType value)
        {
            PaintCell(x, y, themeManager.GetSprite(value));
        }

        private void PaintCell(int x, int y, Image sprite)
        {
            grid[x, y].Image = sprite;
        }

        private void StartRandomGame()
        {
            themeManager.LoadTheme("Default");
            ClearGrid();
            grid = new PictureBox[Config.MAP_X, Config.MAP_Y];
            FillGrid();
            int width = Math.Max(defaultFormWidth, 64 + grid.GetLength(0) * 32); //Expands the screen width or leaves it as the default in case the result would be smaller

            int height = 128 + grid.GetLength(1) * 32;
            Size = new Size(width, height);
            this.CenterToScreen();
            controller.StartRandomGame();
            gameLoop.Interval = Config.TIMER;   // milliseconds
            gameLoop.Start();
            SoundManager.PlayBackgroundMusic();
            inGame = true;
        }

        private void StartCustomGame(MapInfo customMap)
        {
            themeManager.LoadTheme(customMap.Theme);
            ClearGrid();
            controller.StartCustomGame(customMap);
            grid = new PictureBox[Config.MAP_X, Config.MAP_Y];
            FillGrid();
            int width = Math.Max(defaultFormWidth, 64 + grid.GetLength(0) * 32); //Expands the screen width or leaves it as the default in case the result would be smaller
            int height = 128 + grid.GetLength(1) * 32;
            Size = new Size(width, height);
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

        private void buttons_MouseHover(object sender, EventArgs e)
        {
            SoundManager.PlayEffect("hover");
        }
    }
}
