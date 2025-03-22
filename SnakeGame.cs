using Snake_Game.Entities;
using Snake_Game.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Snake_Game
{
    class SnakeGame
    {
        private Snake snake;
        private Cell[,] map;
        private Graph graph;
        private bool lose;
        private Random random;
        private Direction direction;
        
        private int fruits_eaten = 0;
        private int score = 0;
        private int time = 0;
        private GameScreen view;

        internal Snake Snake { get => snake; set => snake = value; }
        internal Cell[,] Map { get => map; set => map = value; }
        public bool Lose { get => lose; set => lose = value; }

        public SnakeGame(GameScreen view)
        {
            this.view = view;
            direction = 0;
            random = new Random();
        }

        /// <summary>
        /// Method that initiates and handles the steps of the game.
        /// </summary>
        public void StartGame()
        {
            map = MapGenerator.GenerateMap();
            snake = new Snake(Config.MAP_X / 2, Config.MAP_Y / 2, Config.INITIAL_SNAKE_SIZE);
            view.PaintMap();
            lose = false;
            time = 0;
            score = 0;
            direction = 0;
        }

        /// <summary>
        /// Method that handles the game loop, finishes when the game is lost.
        /// </summary>
        public void GameLoop()
        {
            time++;
            Update();
            view.ChangeInfo("Time: "+ (time/(1000/Config.TIMER)+1));
        }

        /// <summary>
        /// Method that handles the game logic and updates the map accordingly.
        /// </summary>
        private void Update()
        {
            int oldHeadX = snake.Head_x;
            int oldHeadY = snake.Head_y;
            Direction oldHeadDir = (Direction) map[snake.Head_x, snake.Head_y].Value;
            map[snake.Head_x, snake.Head_y].Value = (int) direction;
            snake.MoveHead(direction);
            CheckHeadBorder();
            Cell eaten_cell = map[snake.Head_x, snake.Head_y];
            if (eaten_cell.Type == CellType.Obstacle) lose = true;
            else if(eaten_cell.Type == CellType.Snake) lose = true;
            else if (eaten_cell.Type == CellType.Fruit) 
            {
                
                if (snake.Size + eaten_cell.Value < 3)
                {
                    snake.Growing = snake.Size + eaten_cell.Value;
                    snake.Size = 3;
                }
                else
                {
                    snake.Growing += eaten_cell.Value;
                    snake.Size += eaten_cell.Value;
                }
                score += eaten_cell.Value;
                map[snake.Head_x, snake.Head_y].Type = CellType.Snake;
                map[snake.Head_x, snake.Head_y].Value = (int) direction;
                fruits_eaten++;
                PutFruit();
            }
            else
            {
                map[snake.Head_x, snake.Head_y].Type = CellType.Snake;
                map[snake.Head_x, snake.Head_y].Value = (int) direction;
            }
            removeTail();
            UpdateHead( snake.Head_x, snake.Head_y, oldHeadX, oldHeadY, oldHeadDir);
            UpdateTail(snake.Tail_x, snake.Tail_y);
        }

        /// <summary>
        /// Method that handles user's input
        /// </summary>
        public void getInput(ConsoleKey key)
        {
            if (key == Config.IN_LEFT) direction = Direction.Left;
            else if (key == Config.IN_RIGHT) direction = Direction.Right;
            else if (key == Config.IN_UP) direction = Direction.Up;
            else if (key == Config.IN_DOWN) direction = Direction.Down;    
        }

        /// <summary>
        /// Method that handles the removal of the snake's tail. If the snake is growing, the tail will not be removed
        /// </summary>
        private void removeTail()
        {
            if (snake.Growing > 0) snake.Growing--;
            else
            {
                while (snake.Growing < 0)
                {
                    int x1 = snake.Tail_x;
                    int y1 = snake.Tail_y;
                    snake.MoveTail((Direction) map[x1, y1].Value);
                    CheckTailBorder(map[x1, y1].Value);
                    map[x1, y1] = new Cell(CellType.Void, 0);
                    view.UpdateCell(x1, y1, "");
                    snake.Growing++;
                }

                int x = snake.Tail_x;
                int y = snake.Tail_y;
                snake.MoveTail((Direction) map[x, y].Value);
                CheckTailBorder(map[x, y].Value);
                map[x, y] = new Cell(CellType.Void, 0);
                view.UpdateCell(x, y, "");
            }
        }

        /// <summary>
        /// Method that detects and changes the position of the snake's tail if it is going out of bounds
        /// </summary>
        /// <param name="value"></param>
        private void CheckTailBorder(int value)
        {
            switch (value)
            {
                case 0:
                    if (snake.Tail_x < 0) snake.Tail_x = map.GetLength(0) - 1;
                    break;
                case 1:
                    if (snake.Tail_x >= map.GetLength(0)) snake.Tail_x = 0;
                    break;
                case 2:
                    if (snake.Tail_y < 0) snake.Tail_y = map.GetLength(1) - 1;
                    break;
                case 3:
                    if (snake.Tail_y >= map.GetLength(1)) snake.Tail_y = 0;
                    break;
            }
        }

        /// <summary>
        /// Method that detects and changes the position of the snake's head if it is going out of bounds
        /// </summary>
        private void CheckHeadBorder()
        {
            switch (direction)
            {
                case Direction.Left:
                    if (snake.Head_x < 0) snake.Head_x = map.GetLength(0) - 1;
                    break;
                case Direction.Right:
                    if (snake.Head_x >= map.GetLength(0)) snake.Head_x = 0;
                    break;
                case Direction.Up:
                    if (snake.Head_y < 0) snake.Head_y = map.GetLength(1) - 1;
                    break;
                case Direction.Down:
                    if (snake.Head_y >= map.GetLength(1)) snake.Head_y = 0;
                    break;
            }
        }

        /// <summary>
        /// Method that puts fruits on the map with a possibilty to put special fruits with an extra value
        /// </summary>
        private void PutFruit()
        {
            bool exit = false;
            while (!exit)
            {
                int x = random.Next(Config.MAP_X);
                int y = random.Next(Config.MAP_Y);
                double value = 1;
                if (Config.SPECIAL_FRUIT_AVAILABLE)
                {
                    value = random.NextDouble();
                }
                if (map[x, y].Type == CellType.Void)
                {
                    map[x, y].Type = CellType.Fruit;
                    if (value < Config.SPECIAL_FRUIT_PCT)
                    {
                        map[x, y].Value = Config.SPECIAL_FRUIT_VALUE;
                        view.UpdateCell(x, y, "f_s");
                    }
                    else
                    {
                        map[x, y].Value = 1;
                        view.UpdateCell(x, y, "f_n");
                    }
                    exit = true;
                }
            }
        }

        private void UpdateHead(int newX, int newY, int oldX, int oldY, Direction oldDirection)
        {
            switch (direction)
            {
                case Direction.Left:
                    view.UpdateCell(oldX, oldY, "s_b_l");
                    view.UpdateCell(newX, newY, "s_h_l");
                    break;
                case Direction.Right:
                    view.UpdateCell(oldX, oldY, "s_b_r");
                    view.UpdateCell(newX, newY, "s_h_r");
                    break;
                case Direction.Up:
                    view.UpdateCell(oldX, oldY, "s_b_u");
                    view.UpdateCell(newX, newY, "s_h_u");
                    break;
                case Direction.Down:
                    view.UpdateCell(oldX, oldY, "s_b_d");
                    view.UpdateCell(newX, newY, "s_h_d");
                    break;
            }
            if(direction != oldDirection)
            {
                switch (oldDirection)
                {
                    case Direction.Left:
                        if(direction == Direction.Up) view.UpdateCell(oldX, oldY, "s_b_l_u");
                        else view.UpdateCell(oldX, oldY, "s_b_l_d");
                        break;
                    case Direction.Right:
                        if (direction == Direction.Up) view.UpdateCell(oldX, oldY, "s_b_r_u");
                        else view.UpdateCell(oldX, oldY, "s_b_r_d");
                        break;
                    case Direction.Up:
                        if (direction == Direction.Left) view.UpdateCell(oldX, oldY, "s_b_u_l");
                        else view.UpdateCell(oldX, oldY, "s_b_u_r");
                        break;
                    case Direction.Down:
                        if (direction == Direction.Left) view.UpdateCell(oldX, oldY, "s_b_d_l");
                        else view.UpdateCell(oldX, oldY, "s_b_d_r");
                        break;
                }
            }
        }

        private void UpdateTail(int x, int y)
        {
            switch (map[x, y].Value)
            {
                case 0:
                    view.UpdateCell(x, y, "s_t_l");
                    break;
                case 1:
                    view.UpdateCell(x, y, "s_t_r");
                    break;
                case 2:
                    view.UpdateCell(x, y, "s_t_u");
                    break;
                case 3:
                    view.UpdateCell(x, y, "s_t_d");
                    break;
            }
        }

    }

}
