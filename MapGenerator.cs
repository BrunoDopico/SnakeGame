using Snake_Game.Entities;
using Snake_Game.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Snake_Game
{
    static class MapGenerator
    {

        /// <summary>
        /// Root method for generating a new random map based on the Config parameters
        /// </summary>
        /// <returns>The randomly generated map</returns>
        public static Cell[,] GenerateMap()
        {
            Cell[,] map = GenerateEmptyMap();

            switch (Config.MAP_TYPE)
            {
                case MapType.Standard:
                    map = PutMapWalls(map);
                    break;
                case MapType.Borderless:
                    break;
                case MapType.HolesOnWalls:
                    map = PutMapWalls(map);
                    map = RemoveRandomWalls(map, 6);
                    break;
                case MapType.ExtraWalls:
                    map = PutMapWalls(map);
                    map = PutRandomWalls(map, 3);
                    break;
                case MapType.HolesAndWalls:
                    map = PutMapWalls(map);
                    map = PutRandomWalls(map, 3);
                    map = RemoveRandomWalls(map, 6);
                    break;
            }


            switch (Config.DIFFICULTY)
            {
                case Difficulty.Easy:
                    Config.TIMER = 250;
                    map = PopulateMap(map, 0, 4);
                    break;
                case Difficulty.Medium:
                    Config.TIMER = 250;
                    map = PopulateMap(map, (Config.MAP_X + Config.MAP_Y) / 10, 2);
                    break;
                case Difficulty.Hard:
                    Config.TIMER = 180;
                    map = PopulateMap(map, (Config.MAP_X + Config.MAP_Y) / 5, 2);
                    break;
                case Difficulty.Hardcore:
                    Config.TIMER = 120;
                    map = PopulateMap(map, (Config.MAP_X + Config.MAP_Y / 3), 1);
                    break;
            }

            return map;
        }

        private static Cell[,] GenerateEmptyMap()
        {
            Cell[,] map;
            map = new Cell[Config.MAP_X, Config.MAP_Y];
            for (int i = 0; i < Config.MAP_X; i++)
            {
                for (int j = 0; j < Config.MAP_Y; j++)
                {
                    map[i, j] = new Cell(CellType.Void, 0);
                }
            }

            return map;
        }

        /// <summary>
        /// Method that puts fruits on the map with a possibilty to put special fruits with an extra value
        /// </summary>
        private static Cell[,] PutInitialFruits(Cell[,] map)
        {
            Random random = new Random();
            bool exit = false;
            while (!exit)
            {
                int x = random.Next(Config.MAP_X);
                int y = random.Next(Config.MAP_Y);
                double specialFruitRandomizer = 1;
                if (Config.SPECIAL_FRUIT_AVAILABLE)
                {
                    specialFruitRandomizer = random.NextDouble();
                }
                if (map[x, y].Type == CellType.Void)
                {
                    map[x, y].Type = CellType.Fruit;
                    if (specialFruitRandomizer < Config.SPECIAL_FRUIT_PCT)
                    {
                        map[x, y].Value = Config.SPECIAL_FRUIT_VALUE;
                    }
                    else
                    {
                        map[x, y].Value = 1;
                    }
                    exit = true;
                }
            }
            return map;
        }

        

        private static Cell[,] PopulateMap(Cell[,] map, int walls, int fruits)
        {
            Random random = new Random();
            int wall_counter = walls;
            int fruit_counter = fruits;

            while (wall_counter > 0)
            {
                int x = random.Next(Config.MAP_X);
                int y = random.Next(Config.MAP_Y);

                if (map[x, y].Type == CellType.Void)
                {
                    map[x, y].Type = CellType.Obstacle;
                    wall_counter--;
                }
            }
            //Graph creation and hamiltonian cycle check
            //Graph graph = new Graph(map);
            //view.ChangeInfo("DATA: " + graph.ConvertMatrixToGraph()); 

            map[Config.MAP_X / 2, Config.MAP_Y / 2] = new Cell(CellType.Snake, 0);

            while (fruit_counter > 0)
            {
                map = PutInitialFruits(map);
                fruit_counter--;
            }
            return map;
        }
        private static Cell[,] PutMapWalls(Cell[,] map)
        {
            Cell wall = new Cell(CellType.Obstacle, 0);
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
            return map;
        }

        private static Cell[,] PutRandomWalls(Cell[,] map, int wallCount)
        {
            Random random = new Random();

            Cell wall = new Cell(CellType.Obstacle, 0);
            while (wallCount > 0)
            {
                int x = random.Next(2,Config.MAP_X-2);
                int y = random.Next(2,Config.MAP_Y-2);
                int sum;
                if (random.NextDouble() > 0.5)
                {
                    for (int i = 0; i < Config.MAP_X / 4; i++)
                    {
                        sum = x + i;
                        if (sum >= Config.MAP_X-2)
                        {
                            sum -= Config.MAP_X-4;
                        }
                        map[sum, y] = wall;
                    }
                }
                else
                {
                    for (int i = 0; i < Config.MAP_Y / 4; i++)
                    {
                        sum = y + i;
                        if (sum >= Config.MAP_Y-2)
                        {
                            sum -= Config.MAP_Y-4;
                        }
                        map[x, sum] = wall;
                    }
                }
                wallCount--;
            }

            return map;
        }

        private static Cell[,] RemoveRandomWalls(Cell[,] map, int n)
        {
            Random random = new Random();

            while (n > 0)
            {
                int x = random.Next(Config.MAP_X);
                int y = random.Next(Config.MAP_Y);
                if (random.NextDouble() > 0.5)
                {
                    if (map[x, 0].Type == CellType.Void) n++;
                    else
                    {
                        map[x, 0] = new Cell(CellType.Void, 0);
                        map[x, Config.MAP_Y - 1] = new Cell(CellType.Void, 0);
                    }

                }
                else
                {
                    if (map[0, y].Type == CellType.Void) n++;
                    else
                    {
                        map[0, y] = new Cell(CellType.Void, 0);
                        map[Config.MAP_X - 1, y] = new Cell(CellType.Void, 0);
                    }
                }
                n--;
            }

            return map;
        }
    }
}
