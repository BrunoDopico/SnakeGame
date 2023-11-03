using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Snake_Game
{
    class Config
    {
        //GAME CONFIGURATIONS
        public static int DIFFICULTY = 0;
        public static int TIMER = 250;

        //MAP CONFIGURATIONS
        public static int MAP_X = 20;
        public static int MAP_Y = 15;
        public static int MAP_TYPE = 0;

        //FRUIT CONFIGURATIONS
        public static bool SPECIAL_FRUIT_AVAILABLE = true;
        public static double SPECIAL_FRUIT_PCT = 0.05;
        public static int SPECIAL_FRUIT_VALUE = 3;

        //SNAKE CONFIGURATIONS
        public static int INITIAL_SNAKE_SIZE = 4;

        //INPUT CONFIGURATIONS
        public static ConsoleKey IN_PAUSE = ConsoleKey.P;
        public static ConsoleKey IN_LEFT = ConsoleKey.LeftArrow;
        public static ConsoleKey IN_RIGHT = ConsoleKey.RightArrow;
        public static ConsoleKey IN_UP = ConsoleKey.UpArrow;
        public static ConsoleKey IN_DOWN = ConsoleKey.DownArrow;

    }
}
