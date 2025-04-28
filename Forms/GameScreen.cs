using Snake_Game.Entities;
using Snake_Game.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
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
        Timer gameLoop = new Timer();
        bool inGame = false;
        private int defaultFormWidth;

        public GameScreen()
        {
            InitializeComponent();
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
                    grid[i, j].BackgroundImage = Properties.Resources.grass;
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
                            sprite = Properties.Resources.wall;
                            PaintCell(i, j, sprite);
                            break;
                        case CellType.Fruit:
                            if (current.Value == Config.SPECIAL_FRUIT_VALUE) sprite = Properties.Resources.fruit_special;
                            else sprite = Properties.Resources.fruit_normal;
                            PaintCell(i, j, sprite);
                            break;
                        case CellType.Snake:
                            sprite = Properties.Resources.snake_head_left;
                            PaintCell(i, j, sprite);
                            break;
                    }
                }
            }
        }

        public void UpdateCell(int x, int y, string value)
        {
            Image sprite = null;
            switch (value)
            {
                case "f_n": //fruit normal
                    sprite = Properties.Resources.fruit_normal;
                    break;
                case "f_s": //fruit special
                    sprite = Properties.Resources.fruit_special;
                    break;
                case "s_h_u": //snake head up
                    sprite = Properties.Resources.snake_head_up;
                    break;
                case "s_h_d": //snake head down
                    sprite = Properties.Resources.snake_head_down;
                    break;
                case "s_h_l": //snake head left
                    sprite = Properties.Resources.snake_head_left;
                    break;
                case "s_h_r": //snake head right
                    sprite = Properties.Resources.snake_head_right;
                    break;
                case "s_t_u": //snake tail up
                    sprite = Properties.Resources.snake_tail_up;
                    break;
                case "s_t_d": //snake tail down
                    sprite = Properties.Resources.snake_tail_down;
                    break;
                case "s_t_l": //snake tail left
                    sprite = Properties.Resources.snake_tail_left;
                    break;
                case "s_t_r": //snake tail right
                    sprite = Properties.Resources.snake_tail_right;
                    break;
                case "s_b_u": //snake body up
                    sprite = Properties.Resources.snake_body_up;
                    break;
                case "s_b_d": //snake body down
                    sprite = Properties.Resources.snake_body_down;
                    break;
                case "s_b_l": //snake body left
                    sprite = Properties.Resources.snake_body_left;
                    break;
                case "s_b_r": //snake body right
                    sprite = Properties.Resources.snake_body_right;
                    break;
                case "s_b_u_l": //snake body up left
                    sprite = Properties.Resources.snake_body_up_left;
                    break;
                case "s_b_u_r": //snake body up right
                    sprite = Properties.Resources.snake_body_up_right;
                    break;
                case "s_b_d_l": //snake body down left
                    sprite = Properties.Resources.snake_body_down_left;
                    break;
                case "s_b_d_r": //snake body down right
                    sprite = Properties.Resources.snake_body_down_right;
                    break;
                case "s_b_l_u": //snake body left up
                    sprite = Properties.Resources.snake_body_left_up;
                    break;
                case "s_b_l_d": //snake body left down
                    sprite = Properties.Resources.snake_body_left_down;
                    break;
                case "s_b_r_u": //snake body right up
                    sprite = Properties.Resources.snake_body_right_up;
                    break;
                case "s_b_r_d": //snake body right down
                    sprite = Properties.Resources.snake_body_right_down;
                    break;
                default:
                    sprite = Properties.Resources.grass;
                    break;
            }
            PaintCell(x, y, sprite);
        }

        private void PaintCell(int x, int y, Image sprite)
        {
            grid[x, y].Image = sprite;
        }

        private void StartGame()
        {
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
            inGame = true;
        }

        private void StartCustomGame(MapInfo customMap)
        {
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
            else if (key.Equals(Config.IN_NEW)) StartGame();
            else controller.getInput(key);
        }

        private void bt_Options_Click(object sender, EventArgs e)
        {
            gameLoop.Stop();
            Form options = new Options();
            options.ShowDialog(this);
            if (inGame) gameLoop.Start();
        }

        private void bt_newGame_Click(object sender, EventArgs e)
        {
            StartGame();
        }

        private void bt_exit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void bt_Credits_Click(object sender, EventArgs e)
        {
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
    }
}
