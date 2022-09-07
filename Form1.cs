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

        public Form1()
        {
            controller = new SnakeGame(this);
            InitializeComponent();
            grid = new PictureBox[Config.MAP_X, Config.MAP_Y];
            FillGrid();
            controller.GenerateEmptyMap();
            controller.GenerateMap();
            PaintMap();
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
                    grid[i, j].BackgroundImage = Image.FromFile(@"Sprites\grass.png");
                    grid[i, j].Location = new Point(x_margin + 32 * i, y_margin + 32 * j);
                    grid[i, j].Visible = true;
                    grid[i, j].Size = new Size(32, 32);
                    this.Controls.Add(grid[i, j]);
                }
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
                        case 'V':
                            break;
                        case 'O':
                            sprite = Image.FromFile(@"Sprites\wall.png");
                            ChangeGrid(i, j, sprite);
                            break;
                        case 'F':
                            if (current.Value == Config.SPECIAL_FRUIT_VALUE) sprite = Image.FromFile(@"Sprites\fruit_special.png");
                            else sprite = Image.FromFile(@"Sprites\fruit_normal.png");
                            ChangeGrid(i, j, sprite);
                            break;
                        case 'S':
                            sprite = Image.FromFile(@"Sprites\snake_head_left.png");
                            ChangeGrid(i, j, sprite);
                            break;
                    }
                }
            }
        }

        private void ChangeGrid(int x, int y, Image sprite)
        {
            grid[x, y].Image = sprite;
        }

    }
}
