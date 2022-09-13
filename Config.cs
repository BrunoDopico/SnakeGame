using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

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
        public static Keys IN_PAUSE = Keys.P;
        public static Keys IN_LEFT = Keys.Left;
        public static Keys IN_RIGHT = Keys.Right;
        public static Keys IN_UP = Keys.Up;
        public static Keys IN_DOWN = Keys.Down;
        public static Keys IN_LEFT_ALTER = Keys.A;
        public static Keys IN_RIGHT_ALTER = Keys.D;
        public static Keys IN_UP_ALTER = Keys.W;
        public static Keys IN_DOWN_ALTER = Keys.S;
    }
}
