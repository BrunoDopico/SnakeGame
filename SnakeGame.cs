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
        private bool lose;
        private Random random;
        private int direction;
        
        private int fruits_eaten = 0;
        private int score = 0;
        private int time = 0;
        private bool pause = false;
        private Main view;

        internal Snake Snake { get => snake; set => snake = value; }
        internal Cell[,] Map { get => map; set => map = value; }
        public bool Lose { get => lose; set => lose = value; }

        public SnakeGame(Main view)
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
            GenerateEmptyMap();
            GenerateMap();
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
            view.ChangeInfo("Time: "+time);
        }

        /// <summary>
        /// Method that handles the game logic and updates the map accordingly.
        /// </summary>
        private void Update()
        {
            int oldHeadX = snake.Head_x;
            int oldHeadY = snake.Head_y;
            int oldHeadDir = map[snake.Head_x, snake.Head_y].Value;
            map[snake.Head_x, snake.Head_y].Value = direction;
            snake.MoveHead(direction);
            CheckHeadBorder();
            Cell eaten_cell = map[snake.Head_x, snake.Head_y];
            if (eaten_cell.Type == 'O') lose = true;
            else if(eaten_cell.Type == 'S') lose = true;
            else if (eaten_cell.Type == 'F') 
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
                map[snake.Head_x, snake.Head_y].Type = 'S';
                map[snake.Head_x, snake.Head_y].Value = direction;
                fruits_eaten++;
                PutFruit();
            }
            else
            {
                map[snake.Head_x, snake.Head_y].Type = 'S';
                map[snake.Head_x, snake.Head_y].Value = direction;
            }
            removeTail();
            UpdateHead( snake.Head_x, snake.Head_y, oldHeadX, oldHeadY, oldHeadDir);
            UpdateTail(snake.Tail_x, snake.Tail_y);
        }

        /// <summary>
        /// Method that handles user's input
        /// </summary>
        public void getInput(char key)
        {
            switch (key)
            {
                // LEFT
                case 'a':
                    direction = 0;
                    break;
                // RIGHT
                case 'd':
                    direction = 1;
                    break;
                // UP
                case 'w':
                    direction = 2;
                    break;
                // DOWN
                case 's':
                    direction = 3;
                    break;
                case 'p':
                    pause = true;
                    break;
                default:
                    break;
            }
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
                    snake.MoveTail(map[x1, y1].Value);
                    CheckTailBorder(map[x1, y1].Value);
                    map[x1, y1] = new Cell('V', 0);
                    view.UpdateCell(x1, y1, "");
                    snake.Growing++;
                }

                int x = snake.Tail_x;
                int y = snake.Tail_y;
                snake.MoveTail(map[x, y].Value);
                CheckTailBorder(map[x, y].Value);
                map[x, y] = new Cell('V', 0);
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
                case 0:
                    if (snake.Head_x < 0) snake.Head_x = map.GetLength(0) - 1;
                    break;
                case 1:
                    if (snake.Head_x >= map.GetLength(0)) snake.Head_x = 0;
                    break;
                case 2:
                    if (snake.Head_y < 0) snake.Head_y = map.GetLength(1) - 1;
                    break;
                case 3:
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
                if (map[x, y].Type == 'V')
                {
                    map[x, y].Type = 'F';
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

        public void GenerateMap()
        {
            switch (Config.MAP_TYPE)
            {
                case 0:
                    PutMapWalls();
                    break;
                case 1:
                    break;
                case 2:
                    PutMapWalls();
                    RemoveRandomWalls(6);
                    break;
                case 3:
                    PutRandomWalls(3);
                    break;
                case 4:
                    PutMapWalls();
                    PutRandomWalls(3);
                    RemoveRandomWalls(6);
                    break;
            }
            

            switch (Config.DIFFICULTY)
            {
                case 0:
                    Config.TIMER = 250;
                    PopulateMap(0, 4);
                    break;
                case 1:
                    Config.TIMER = 250;
                    PopulateMap((Config.MAP_X+Config.MAP_Y)/10, 2);
                    break;
                case 2:
                    Config.TIMER = 180;
                    PopulateMap((Config.MAP_X + Config.MAP_Y) / 5, 2);
                    break;
                case 3:
                    Config.TIMER = 120;
                    PopulateMap((Config.MAP_X + Config.MAP_Y/3), 1);
                    break;
            }
        }

        private void PopulateMap(int walls, int fruits)
        {
            int wall_counter = walls;
            int fruit_counter = fruits;

            while(wall_counter > 0)
            {
                int x = random.Next(Config.MAP_X);
                int y = random.Next(Config.MAP_Y);

                if (map[x, y].Type == 'V')
                {
                    map[x, y].Type = 'O';
                    wall_counter--;
                }
            }

            while (fruit_counter > 0)
            {
                PutFruit();
                fruit_counter--;
            }

            snake = new Snake(Config.MAP_X / 2, Config.MAP_Y / 2, Config.INITIAL_SNAKE_SIZE);
            map[Config.MAP_X / 2, Config.MAP_Y / 2] = new Cell('S', 0);
        }
        private void PutMapWalls()
        {
            Cell wall = new Cell('O',0);
            for (int i = 0; i < Config.MAP_X; i++)
            {
                map[i, 0] = wall;
                map[i, Config.MAP_Y - 1] = wall;
            }

            for (int i = 0; i < Config.MAP_Y; i++)
            {
                map[0, i] = wall;
                map[Config.MAP_X - 1, i] = wall;
            }
        }

        private void PutRandomWalls(int n)
        {
            Cell wall = new Cell('O', 0);
            while (n > 0)
            {
                int x = random.Next(Config.MAP_X);
                int y = random.Next(Config.MAP_Y);
                int sum;
                if (random.NextDouble() > 0.5)
                {
                    for (int i = 0; i < Config.MAP_X/3; i++)
                    {
                        sum = x + i;
                        if(sum >= Config.MAP_X)
                        {
                            sum -= Config.MAP_X;
                        }
                        map[sum, y] = wall;
                    }
                } 
                else
                {
                    for (int i = 0; i < Config.MAP_Y/3; i++)
                    {
                        sum = y + i;
                        if (sum >= Config.MAP_Y)
                        {
                            sum -= Config.MAP_Y;
                        }
                        map[x, sum] = wall;
                    }
                }
                n--;
            }
        }

        private void RemoveRandomWalls(int n)
        {
            while (n > 0)
            {
                int x = random.Next(Config.MAP_X);
                int y = random.Next(Config.MAP_Y);
                if (random.NextDouble() > 0.5)
                {
                    if (map[x, 0].Type == 'V') n++;
                    else
                    {
                        map[x, 0] = new Cell('V', 0);
                        map[x, Config.MAP_Y - 1] = new Cell('V', 0);
                    }
                    
                }
                else
                {
                    if (map[0, y].Type == 'V') n++;
                    else
                    {
                        map[0, y] = new Cell('V', 0);
                        map[Config.MAP_X - 1, y] = new Cell('V', 0);
                    }
                }
                n--;
            }
        }

        private void UpdateHead(int newX, int newY, int oldX, int oldY, int oldDirection)
        {
            switch (direction)
            {
                case 0:
                    view.UpdateCell(oldX, oldY, "s_b_l");
                    view.UpdateCell(newX, newY, "s_h_l");
                    break;
                case 1:
                    view.UpdateCell(oldX, oldY, "s_b_r");
                    view.UpdateCell(newX, newY, "s_h_r");
                    break;
                case 2:
                    view.UpdateCell(oldX, oldY, "s_b_u");
                    view.UpdateCell(newX, newY, "s_h_u");
                    break;
                case 3:
                    view.UpdateCell(oldX, oldY, "s_b_d");
                    view.UpdateCell(newX, newY, "s_h_d");
                    break;
            }
            if(direction != oldDirection)
            {
                switch (oldDirection)
                {
                    case 0:
                        if(direction == 2) view.UpdateCell(oldX, oldY, "s_b_l_u");
                        else view.UpdateCell(oldX, oldY, "s_b_l_d");
                        break;
                    case 1:
                        if (direction == 2) view.UpdateCell(oldX, oldY, "s_b_r_u");
                        else view.UpdateCell(oldX, oldY, "s_b_r_d");
                        break;
                    case 2:
                        if (direction == 0) view.UpdateCell(oldX, oldY, "s_b_u_l");
                        else view.UpdateCell(oldX, oldY, "s_b_u_r");
                        break;
                    case 3:
                        if (direction == 0) view.UpdateCell(oldX, oldY, "s_b_d_l");
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

        public void GenerateEmptyMap()
        {
            map = new Cell[Config.MAP_X, Config.MAP_Y];
            for (int i = 0; i < Config.MAP_X; i++)
            {
                for (int j = 0; j < Config.MAP_Y; j++)
                {
                    map[i, j] = new Cell('V', 0);
                }
            }
        }

    }

}
