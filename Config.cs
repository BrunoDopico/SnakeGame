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
        public static int DIFFICULTY;
        public static int TIMER;

        //MAP CONFIGURATIONS
        public static int MAP_X;
        public static int MAP_Y;
        public static int MAP_TYPE;

        //FRUIT CONFIGURATIONS
        public static bool SPECIAL_FRUIT_AVAILABLE;
        public static double SPECIAL_FRUIT_PCT;
        public static int SPECIAL_FRUIT_VALUE;

        //SNAKE CONFIGURATIONS
        public static int INITIAL_SNAKE_SIZE;

        //INPUT CONFIGURATIONS
        public static ConsoleKey IN_PAUSE;
        public static ConsoleKey IN_LEFT;
        public static ConsoleKey IN_RIGHT;
        public static ConsoleKey IN_UP;
        public static ConsoleKey IN_DOWN;

        private void SaveConfig()
        {

        }

        public static void SetToDefault()
        {
            DIFFICULTY = 0;
            TIMER = 250;

            MAP_X = 20;
            MAP_Y = 15;
            MAP_TYPE = 0;
            SPECIAL_FRUIT_AVAILABLE = true;
            SPECIAL_FRUIT_PCT = 0.05;
            SPECIAL_FRUIT_VALUE = 3;
            INITIAL_SNAKE_SIZE = 4;
            IN_PAUSE = ConsoleKey.P;
            IN_LEFT = ConsoleKey.A;
            IN_RIGHT = ConsoleKey.D;
            IN_UP = ConsoleKey.W;
            IN_DOWN = ConsoleKey.S;
        }
    }
}
