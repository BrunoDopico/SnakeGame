using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Snake_Game
{
    public partial class Form1 : Form
    {
        PictureBox[,] grid;
        SnakeGame controller;
        Timer gameLoop = new Timer();
        
        public Form1()
        {
            gameLoop.Tick += GameLoop;
            controller = new SnakeGame(this);
            InitializeComponent();
            grid = new PictureBox[Config.MAP_X, Config.MAP_Y];
            FillGrid();
        }

        private void FillGrid()
        {
            int x_margin = 32;
            int y_margin = 32;
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
            foreach (PictureBox pb in grid) pb.Image = null;
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
                        case 'V':
                            break;
                        case 'O':
                            sprite = Properties.Resources.wall;
                            PaintCell(i, j, sprite);
                            break;
                        case 'F':
                            if (current.Value == Config.SPECIAL_FRUIT_VALUE) sprite = Properties.Resources.fruit_special;
                            else sprite = Properties.Resources.fruit_normal;
                            PaintCell(i, j, sprite);
                            break;
                        case 'S':
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

        private void newGameToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ClearGrid();
            gameLoop.Interval = Config.TIMER;   // milliseconds
            gameLoop.Start();
            controller.StartGame();
        }

        private void GameLoop(object sender, EventArgs e)  //run this logic each timer tick
        {
            controller.GameLoop();
            if (controller.Lose) gameLoop.Stop();
        }


        public void ChangeInfo(string msg)
        {
            lbInfo.Text = msg;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            controller.getInput('w');
        }

        private void button3_Click(object sender, EventArgs e)
        {
            controller.getInput('a');
        }

        private void btRight_Click(object sender, EventArgs e)
        {
            controller.getInput('d');
        }

        private void btDown_Click(object sender, EventArgs e)
        {
            controller.getInput('s');
        }
    }
}
