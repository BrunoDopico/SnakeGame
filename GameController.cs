using Snake_Game.Entities;
using Snake_Game.Enums;
using Snake_Game.Forms;
using System;
using System.Collections.Generic;
using System.Drawing;
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
        public void StartRandomGame()
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

        public void StartCustomGame(MapInfo mapData)
        {
            Point snakeSpawn = new Point();
            (Map, snakeSpawn) = MapLoader.LoadMapIntoGame(mapData);
            Snake = new Snake(snakeSpawn.X, snakeSpawn.Y, Config.INITIAL_SNAKE_SIZE);
            Config.setTimer(mapData.Difficulty);
            fillAvailableCells();
            Lose = false;
            time = 0;
            score = 0;
            direction = (Direction) Map[snakeSpawn.X,snakeSpawn.Y].Value;
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
                    view.UpdateCell(x1, y1, SpriteType.Background);
                    Snake.Growing++;
                }

                int x = Snake.Tail_x;
                int y = Snake.Tail_y;
                Snake.MoveTail((Direction) Map[x, y].Value);
                CheckTailBorder(Map[x, y].Value);
                availableCells.Add((x, y));
                Map[x, y] = new Cell(CellType.Void, 0);
                view.UpdateCell(x, y, SpriteType.Background);
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
                view.UpdateCell(x, y, SpriteType.FruitSpecial);
            }
            else
            {
                Map[x, y].Value = 1;
                view.UpdateCell(x, y, SpriteType.FruitNormal);
            }
        }

        private void UpdateHead(int newX, int newY, int oldX, int oldY, Direction oldDirection)
        {
            switch (direction)
            {
                case Direction.Left:
                    view.UpdateCell(oldX, oldY, SpriteType.SnakeBodyLeft);
                    view.UpdateCell(newX, newY, SpriteType.SnakeHeadLeft);
                    break;
                case Direction.Right:
                    view.UpdateCell(oldX, oldY, SpriteType.SnakeBodyRight);
                    view.UpdateCell(newX, newY, SpriteType.SnakeHeadRight);
                    break;
                case Direction.Up:
                    view.UpdateCell(oldX, oldY, SpriteType.SnakeBodyUp);
                    view.UpdateCell(newX, newY, SpriteType.SnakeHeadUp);
                    break;
                case Direction.Down:
                    view.UpdateCell(oldX, oldY, SpriteType.SnakeBodyDown);
                    view.UpdateCell(newX, newY, SpriteType.SnakeHeadDown);
                    break;
            }
            if(direction != oldDirection)
            {
                switch (oldDirection)
                {
                    case Direction.Left:
                        if(direction == Direction.Up) view.UpdateCell(oldX, oldY, SpriteType.SnakeBodyLeftUp);
                        else view.UpdateCell(oldX, oldY, SpriteType.SnakeBodyLeftDown);
                        break;
                    case Direction.Right:
                        if (direction == Direction.Up) view.UpdateCell(oldX, oldY, SpriteType.SnakeBodyRightUp);
                        else view.UpdateCell(oldX, oldY, SpriteType.SnakeBodyRightDown);
                        break;
                    case Direction.Up:
                        if (direction == Direction.Left) view.UpdateCell(oldX, oldY, SpriteType.SnakeBodyUpLeft);
                        else view.UpdateCell(oldX, oldY, SpriteType.SnakeBodyUpRight);
                        break;
                    case Direction.Down:
                        if (direction == Direction.Left) view.UpdateCell(oldX, oldY, SpriteType.SnakeBodyDownLeft);
                        else view.UpdateCell(oldX, oldY, SpriteType.SnakeBodyDownRight);
                        break;
                }
            }
        }

        private void UpdateTail(int x, int y)
        {
            switch (Map[x, y].Value)
            {
                case 0:
                    view.UpdateCell(x, y, SpriteType.SnakeTailLeft);
                    break;
                case 1:
                    view.UpdateCell(x, y, SpriteType.SnakeTailRight);
                    break;
                case 2:
                    view.UpdateCell(x, y, SpriteType.SnakeTailUp);
                    break;
                case 3:
                    view.UpdateCell(x, y, SpriteType.SnakeTailDown);
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
