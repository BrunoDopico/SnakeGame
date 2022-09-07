using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

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
        private Form1 view;

        internal Snake Snake { get => snake; set => snake = value; }
        internal Cell[,] Map { get => map; set => map = value; }

        public SnakeGame(Form1 view)
        {
            this.view = view;
            direction = 0;
            random = new Random();
        }

        /// <summary>
        /// Method that initiates and handles the steps of the game.
        /// </summary>
        public void PlayGame()
        {
            GenerateEmptyMap();
            GenerateMap();
            Console.Clear();
            Display();
            Console.WriteLine("Press any button to start.");
            Console.ReadKey();
            GameLoop();
            Console.WriteLine("You lose");
            Console.ReadLine();
        }

        /// <summary>
        /// Method that handles the game loop, finishes when the game is lost.
        /// </summary>
        private void GameLoop()
        {
            do
            {
                getInput();
                time++;
                Update();
                Console.Clear();
                Display();
                Thread.Sleep(Config.TIMER);
                if (pause)
                {
                    Console.WriteLine("Game is paused, press Enter to resume.");
                    Console.ReadKey();
                    pause = false;
                }
            } while (!lose);
        }

        /// <summary>
        /// Method that handles the game logic and updates the map accordingly.
        /// </summary>
        private void Update()
        {
            map[snake.Head_x, snake.Head_y].Value = direction;
            snake.MoveHead(direction);
            CheckHeadBorder();
            int[] headPos = { snake.Head_x, snake.Head_y };
            Cell aux = map[headPos[0], headPos[1]];
            if (aux.Type == 'O') lose = true;
            else if(aux.Type == 'S' && (snake.Tail_x != headPos[0] || snake.Tail_y != headPos[1] || snake.Growing > 0)) lose = true;
            else if (aux.Type == 'F') 
            {
                snake.Size += aux.Value;
                snake.Growing += aux.Value;
                score += aux.Value;
                map[headPos[0], headPos[1]].Type = 'S';
                fruits_eaten++;
                PutFruit();
            }
            else
            {
                map[headPos[0], headPos[1]].Type = 'S';
            }
            removeTail();
        }

        /// <summary>
        /// Method that handles user's input
        /// </summary>
        private void getInput()
        {
            if (Console.KeyAvailable && !pause)
            {
                switch (Console.ReadKey(true).Key)
                {
                    // LEFT
                    case ConsoleKey value when value == Config.IN_LEFT:
                        direction = 0;
                        break;
                    // RIGHT
                    case ConsoleKey value when value == Config.IN_RIGHT:
                        direction = 1;
                        break;
                    // UP
                    case ConsoleKey value when value == Config.IN_UP:
                        direction = 2;
                        break;
                    // DOWN
                    case ConsoleKey value when value == Config.IN_DOWN:
                        direction = 3;
                        break;
                    case ConsoleKey value when value == Config.IN_PAUSE:
                        pause = true;
                        break;
                    default:
                        break;
                }
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
                int x = snake.Tail_x;
                int y = snake.Tail_y;
                snake.MoveTail(map[x, y].Value);
                CheckTailBorder(map[x, y].Value);
                map[x, y] = new Cell('V', 0);
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
        /// Method that puts fruits on the map with a possibilty to put special fruits with value of 3
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
                    if(value <Config.SPECIAL_FRUIT_PCT) map[x, y].Value = Config.SPECIAL_FRUIT_VALUE;
                    else map[x, y].Value = 1;
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
                    PopulateMap((Config.MAP_X + Config.MAP_Y/2), 1);
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

        
        /// <summary>
        /// Method that displays the current game state
        /// </summary>
        /// <param name="map"></param>
        private void Display()
        {
            Cell current;
            char displayed = '-';
            for (int i = 0; i < Config.MAP_Y; i++)
            {
                for (int j = 0; j < Config.MAP_X; j++)
                {
                    if (snake.Head_x == j && snake.Head_y == i) 
                    {
                        switch (direction)
                        {
                            case 0:
                                displayed = Config.DIS_SNAKE_HEAD_LEFT;
                                break;
                            case 1:
                                displayed = Config.DIS_SNAKE_HEAD_RIGHT;
                                break;
                            case 2:
                                displayed = Config.DIS_SNAKE_HEAD_UP;
                                break;
                            case 3:
                                displayed = Config.DIS_SNAKE_HEAD_DOWN;
                                break;
                        }
                    }
                    else if (snake.Tail_x == j && snake.Tail_y == i)
                    {
                        switch (map[j, i].Value)
                        {
                            case 0:
                                displayed = Config.DIS_SNAKE_TAIL_RIGHT;
                                break;
                            case 1:
                                displayed = Config.DIS_SNAKE_TAIL_LEFT;
                                break;
                            case 2:
                                displayed = Config.DIS_SNAKE_TAIL_DOWN;
                                break;
                            case 3:
                                displayed = Config.DIS_SNAKE_TAIL_UP;
                                break;
                        }
                    }
                    else
                    {
                        current = map[j, i];
                        switch (current.Type)
                        {
                            case 'V':
                                displayed = Config.DIS_EMPTY;
                                break;
                            case 'S':
                                displayed = Config.DIS_SNAKE_BODY;
                                break;
                            case 'F':
                                if (current.Value == Config.SPECIAL_FRUIT_VALUE) displayed = Config.DIS_SUPER_FRUIT;
                                else displayed = Config.DIS_N_FRUIT;
                                break;
                            case 'O':
                                displayed = Config.DIS_WALL;
                                break;
                        }
                    }
                    Console.Write(displayed+" ");
                }
                Console.WriteLine();
            }
            string details = String.Format("Snake size: {0}| Fruits eaten: {1} | Time survived: {2} | Score: {3}", snake.Size,fruits_eaten, time, score);
            Console.WriteLine(details);
        }


    }

}
