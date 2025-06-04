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
        private Direction currentDirection;
        private List<(int, int)> availableCells = new List<(int, int)>();
        
        private int fruits_eaten = 0;
        private int score = 0;
        private int time = 0;
        private IGameView view;

        internal Snake Snake { get; set; }
        internal Cell[,] Map { get; set; }
        public bool Lose { get; set; }

        public GameController(IGameView view)
        {
            this.view = view;
            currentDirection = Direction.Left;
            random = new Random();
        }

        /// <summary>
        /// Method that initiates and handles the steps of the game.
        /// </summary>
        public void StartRandomGame()
        {
            Map = MapGenerator.GenerateMap();
            FillMapSprites();
            Snake = new Snake(Config.MAP_X / 2, Config.MAP_Y / 2, Config.INITIAL_SNAKE_SIZE);
            fillAvailableCells();
            Lose = false;
            time = 0;
            score = 0;
            currentDirection = Direction.Left;
        }

        private void FillMapSprites()
        {
            for (int x = 0; x < Config.MAP_X; x++)
            {
                for (int y = 0; y < Config.MAP_Y; y++)
                {
                    switch (Map[x, y].Type)
                    {
                        case CellType.Void:
                            Map[x, y].Sprite = SpriteType.None;
                            break;
                        case CellType.Obstacle:
                            Map[x, y].Sprite = SpriteType.Wall;
                            break;
                        case CellType.Fruit:
                            Map[x, y].Sprite = (Map[x, y].Value == Config.SPECIAL_FRUIT_VALUE)
                                ? SpriteType.FruitSpecial
                                : SpriteType.FruitNormal;
                            break;
                        case CellType.DisappearFruit:
                            Map[x, y].Sprite = SpriteType.FruitDisappear;
                            break;
                        case CellType.Snake:
                            Map[x, y].Sprite = SpriteType.SnakeHeadLeft; // Or whatever is appropriate for spawn
                            break;
                    }
                }
            }
        }

        /// <summary>
        /// Method that initiates a custom game with a given map data.
        /// </summary>
        /// <param name="mapData">The map information to create the custom game.</param>
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
            currentDirection = (Direction) Map[snakeSpawn.X,snakeSpawn.Y].Value;
        }

        /// <summary>
        /// Method that handles the game loop, finishes when the game is lost.
        /// </summary>
        public void Step()
        {
            time++;
            Update();
            view.ChangeScore(score);
            view.ChangeTime(time / (1000 / Config.TIMER) + 1);
        }

        /// <summary>
        /// Method that handles the game logic and updates the map accordingly.
        /// </summary>
        private void Update()
        {
            int oldHeadX = Snake.Head_x;
            int oldHeadY = Snake.Head_y;
            Direction oldHeadDir = (Direction) Map[Snake.Head_x, Snake.Head_y].Value;
            Map[Snake.Head_x, Snake.Head_y].Value = (int) currentDirection;
            Snake.MoveHead(currentDirection);
            CheckHeadBorder();
            Cell eaten_cell = Map[Snake.Head_x, Snake.Head_y];

            availableCells.Remove((Snake.Head_x, Snake.Head_y));

            if (eaten_cell.Type == CellType.Obstacle) Lose = true;
            else if (eaten_cell.Type == CellType.Snake) Lose = true;
            else if (eaten_cell.Type == CellType.Fruit || eaten_cell.Type == CellType.DisappearFruit) EatFruit(eaten_cell);

            //Move the snake after checking for collisions
            Map[Snake.Head_x, Snake.Head_y].Type = CellType.Snake;
            Map[Snake.Head_x, Snake.Head_y].Value = (int)currentDirection;

            removeTail();
            UpdateHead(Snake.Head_x, Snake.Head_y, oldHeadX, oldHeadY, oldHeadDir);
            UpdateTail(Snake.Tail_x, Snake.Tail_y);
        }

        /// <summary>
        /// Method that handles user's input
        /// </summary>
        public void getInput(ConsoleKey key)
        {
            if (key == Config.IN_LEFT) currentDirection = Direction.Left;
            else if (key == Config.IN_RIGHT) currentDirection = Direction.Right;
            else if (key == Config.IN_UP) currentDirection = Direction.Up;
            else if (key == Config.IN_DOWN) currentDirection = Direction.Down;    
        }

        /// <summary>
        /// Method that handles the removal of the snake's tail. If the snake is growing, the tail will not be removed
        /// </summary>
        private void removeTail()
        {
            if (Snake.Growing > 0) Snake.Growing--;
            else
            {
                // If there is "negative growing" the snake is shrinking (this can happen when the special fruit's value is negative)
                while (Snake.Growing < 0)
                {
                    int x1 = Snake.Tail_x;
                    int y1 = Snake.Tail_y;
                    Snake.MoveTail((Direction) Map[x1, y1].Value);
                    CheckTailBorder(Map[x1, y1].Value);
                    availableCells.Add((x1, y1));
                    Map[x1, y1] = new Cell(CellType.Void, 0);
                    view.UpdateCell(x1, y1);
                    Snake.Growing++;
                }

                int x = Snake.Tail_x;
                int y = Snake.Tail_y;
                Snake.MoveTail((Direction) Map[x, y].Value);
                CheckTailBorder(Map[x, y].Value);
                availableCells.Add((x, y));
                Map[x, y] = new Cell(CellType.Void, 0);
                view.UpdateCell(x, y);
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
            switch (currentDirection)
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

        private void EatFruit(Cell eaten_cell)
        {
            SoundManager.PlayEffect("eat");
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
            fruits_eaten++;
            if(eaten_cell.Type != CellType.DisappearFruit)
                PutFruit();
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
                Map[x, y].Sprite = SpriteType.FruitSpecial;
                view.UpdateCell(x, y);
            }
            else
            {
                Map[x, y].Value = 1;
                Map[x, y].Sprite = SpriteType.FruitNormal;
                view.UpdateCell(x, y);
            }
        }

        /// <summary>
        /// Method that updates the head and body of the snake based on its direction and the previous position.
        /// </summary>
        /// <param name="newX">The new X coordinate for the head.</param>
        /// <param name="newY">The new Y coordinate for the head.</param>
        /// <param name="oldX">The old X coordinate where the head used to be.</param>
        /// <param name="oldY">The old Y coordinate where the head used to be.</param>
        /// <param name="oldDirection">The previous direction the snake was moving.</param>
        private void UpdateHead(int newX, int newY, int oldX, int oldY, Direction oldDirection)
        {
            switch (currentDirection)
            {
                case Direction.Left:
                    Map[newX, newY].Sprite = SpriteType.SnakeHeadLeft;
                    Map[oldX, oldY].Sprite = SpriteType.SnakeBodyLeft;
                    break;
                case Direction.Right:
                    Map[newX, newY].Sprite = SpriteType.SnakeHeadRight;
                    Map[oldX, oldY].Sprite = SpriteType.SnakeBodyRight;
                    break;
                case Direction.Up:
                    Map[newX, newY].Sprite = SpriteType.SnakeHeadUp;
                    Map[oldX, oldY].Sprite = SpriteType.SnakeBodyUp;
                    break;
                case Direction.Down:
                    Map[newX, newY].Sprite = SpriteType.SnakeHeadDown;
                    Map[oldX, oldY].Sprite = SpriteType.SnakeBodyDown;
                    break;
            }
            
            if (currentDirection != oldDirection)
            {
                switch (oldDirection)
                {
                    case Direction.Left:
                        if(currentDirection == Direction.Up) Map[oldX, oldY].Sprite = SpriteType.SnakeBodyLeftUp;
                        else Map[oldX, oldY].Sprite = SpriteType.SnakeBodyLeftDown;
                        break;
                    case Direction.Right:
                        if (currentDirection == Direction.Up) Map[oldX, oldY].Sprite = SpriteType.SnakeBodyRightUp;
                        else Map[oldX, oldY].Sprite = SpriteType.SnakeBodyRightDown;
                        break;
                    case Direction.Up:
                        if (currentDirection == Direction.Left) Map[oldX, oldY].Sprite = SpriteType.SnakeBodyUpLeft;
                        else Map[oldX, oldY].Sprite = SpriteType.SnakeBodyUpRight;
                        break;
                    case Direction.Down:
                        if (currentDirection == Direction.Left) Map[oldX, oldY].Sprite = SpriteType.SnakeBodyDownLeft;
                        else Map[oldX, oldY].Sprite = SpriteType.SnakeBodyDownRight;
                        break;
                }
            }
            view.UpdateCell(oldX, oldY);
            view.UpdateCell(newX, newY);
        }

        /// <summary>
        /// Method that updates the tail of the snake based on its direction.
        /// </summary>
        /// <param name="x">The new coordinate X of the tail</param>
        /// <param name="y">The new coordinate Y of the tail</param>
        private void UpdateTail(int x, int y)
        {
            switch (Map[x, y].Value)
            {
                case (int)Direction.Left:
                    Map[x, y].Sprite = SpriteType.SnakeTailLeft;
                    break;
                case (int)Direction.Right:
                    Map[x, y].Sprite = SpriteType.SnakeTailRight;
                    break;
                case (int)Direction.Up:
                    Map[x, y].Sprite = SpriteType.SnakeTailUp;
                    break;
                case (int)Direction.Down:
                    Map[x, y].Sprite = SpriteType.SnakeTailDown;
                    break;
            }
            view.UpdateCell(x, y);
        }

        /// <summary>
        /// Method that fills the availableCells list with all the cells that are empty (CellType.Void).
        /// </summary>
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
