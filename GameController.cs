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
    public class GameController
    {
        private Graph graph;
        private Random random;
        private Direction direction;
        private List<(int, int)> availableCells = new List<(int, int)>();
        
        private int fruits_eaten = 0;
        private int score = 0;
        private int time = 0;
        private GameScreen view;

        internal Snake Snake { get; set; }
        internal Cell[,] Map { get; set; }
        public bool Lose { get; set; }

        public GameController(GameScreen view)
        {
            this.view = view;
            direction = Direction.Left;
            random = new Random();
        }

        /// <summary>
        /// Method that initiates and handles the steps of the game.
        /// </summary>
        public void StartGame()
        {
            Map = MapGenerator.GenerateMap();
            Snake = new Snake(Config.MAP_X / 2, Config.MAP_Y / 2, Config.INITIAL_SNAKE_SIZE);
            fillAvailableCells();
            view.PaintMap();
            Lose = false;
            time = 0;
            score = 0;
            direction = Direction.Left;
        }

        /// <summary>
        /// Method that handles the game loop, finishes when the game is lost.
        /// </summary>
        public void GameLoop()
        {
            time++;
            Update();
            view.ChangeInfo("Score: " + score + " Time: " + (time/(1000/Config.TIMER)+1));
        }

        /// <summary>
        /// Method that handles the game logic and updates the map accordingly.
        /// </summary>
        private void Update()
        {
            int oldHeadX = Snake.Head_x;
            int oldHeadY = Snake.Head_y;
            Direction oldHeadDir = (Direction) Map[Snake.Head_x, Snake.Head_y].Value;
            Map[Snake.Head_x, Snake.Head_y].Value = (int) direction;
            Snake.MoveHead(direction);
            CheckHeadBorder();
            Cell eaten_cell = Map[Snake.Head_x, Snake.Head_y];

            availableCells.Remove((Snake.Head_x, Snake.Head_y));

            if (eaten_cell.Type == CellType.Obstacle) Lose = true;
            else if(eaten_cell.Type == CellType.Snake) Lose = true;
            else if (eaten_cell.Type == CellType.Fruit) 
            {
                
                if (Snake.Size + eaten_cell.Value < 3)
                {
                    Snake.Growing = Snake.Size + eaten_cell.Value;
                    Snake.Size = 3;
                }
                else
                {
                    Snake.Growing += eaten_cell.Value;
                    Snake.Size += eaten_cell.Value;
                }
                score += eaten_cell.Value;
                Map[Snake.Head_x, Snake.Head_y].Type = CellType.Snake;
                Map[Snake.Head_x, Snake.Head_y].Value = (int) direction;
                fruits_eaten++;
                PutFruit();
            }
            else
            {
                Map[Snake.Head_x, Snake.Head_y].Type = CellType.Snake;
                Map[Snake.Head_x, Snake.Head_y].Value = (int) direction;
            }
            removeTail();
            UpdateHead( Snake.Head_x, Snake.Head_y, oldHeadX, oldHeadY, oldHeadDir);
            UpdateTail(Snake.Tail_x, Snake.Tail_y);
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
            if (Snake.Growing > 0) Snake.Growing--;
            else
            {
                while (Snake.Growing < 0)
                {
                    int x1 = Snake.Tail_x;
                    int y1 = Snake.Tail_y;
                    Snake.MoveTail((Direction) Map[x1, y1].Value);
                    CheckTailBorder(Map[x1, y1].Value);
                    availableCells.Add((x1, y1));
                    Map[x1, y1] = new Cell(CellType.Void, 0);
                    view.UpdateCell(x1, y1, "");
                    Snake.Growing++;
                }

                int x = Snake.Tail_x;
                int y = Snake.Tail_y;
                Snake.MoveTail((Direction) Map[x, y].Value);
                CheckTailBorder(Map[x, y].Value);
                availableCells.Add((x, y));
                Map[x, y] = new Cell(CellType.Void, 0);
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
                    if (Snake.Tail_x < 0) Snake.Tail_x = Map.GetLength(0) - 1;
                    break;
                case 1:
                    if (Snake.Tail_x >= Map.GetLength(0)) Snake.Tail_x = 0;
                    break;
                case 2:
                    if (Snake.Tail_y < 0) Snake.Tail_y = Map.GetLength(1) - 1;
                    break;
                case 3:
                    if (Snake.Tail_y >= Map.GetLength(1)) Snake.Tail_y = 0;
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
                    if (Snake.Head_x < 0) Snake.Head_x = Map.GetLength(0) - 1;
                    break;
                case Direction.Right:
                    if (Snake.Head_x >= Map.GetLength(0)) Snake.Head_x = 0;
                    break;
                case Direction.Up:
                    if (Snake.Head_y < 0) Snake.Head_y = Map.GetLength(1) - 1;
                    break;
                case Direction.Down:
                    if (Snake.Head_y >= Map.GetLength(1)) Snake.Head_y = 0;
                    break;
            }
        }

        /// <summary>
        /// Method that puts fruits on the map with a possibilty to put special fruits with an extra value
        /// </summary>
        private void PutFruit()
        {
            if (availableCells.Count == 0) return; //No space left for new fruits

            int index = random.Next(availableCells.Count);
            (int x, int y) = availableCells[index];
            availableCells.RemoveAt(index);

            Map[x, y].Type = CellType.Fruit;
            
            double value = 1;
            if (Config.SPECIAL_FRUIT_AVAILABLE)
            {
                value = random.NextDouble();
            }
            if (value < Config.SPECIAL_FRUIT_PCT)
            {
                Map[x, y].Value = Config.SPECIAL_FRUIT_VALUE;
                view.UpdateCell(x, y, "f_s");
            }
            else
            {
                Map[x, y].Value = 1;
                view.UpdateCell(x, y, "f_n");
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
            switch (Map[x, y].Value)
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

        private void fillAvailableCells()
        {
            availableCells.Clear();
            for (int i = 0; i < Map.GetLength(0); i++)
            {
                for (int j = 0; j < Map.GetLength(1); j++)
                {
                    if (Map[i, j].Type == CellType.Void)
                    {
                        availableCells.Add((i, j));
                    }
                }
            }
        }

    }

}
