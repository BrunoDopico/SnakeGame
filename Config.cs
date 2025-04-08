using Snake_Game.Enums;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Snake_Game
{
    class Config
    {
        //GAME CONFIGURATIONS
        public static Difficulty DIFFICULTY;
        public static int TIMER; //this stat is public in the code, but should not be modified by the players and therefore it is not saved.

        //MAP CONFIGURATIONS
        public static int MAP_X; //Min 6, Max 50
        public static int MAP_Y; //Min 6, Max 30
        public static MapType MAP_TYPE;

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
        public static ConsoleKey IN_NEW;

        public static void SaveConfig()
        {
            using (StreamWriter saveFile = new StreamWriter(Path.Combine(Environment.CurrentDirectory, "Configuration.txt")))
            {
                saveFile.WriteLine(((int)DIFFICULTY) + "; Difficulty -- 0 Easy - 1 Medium - 2 Hard - 3 Hardcore");
                saveFile.WriteLine(MAP_X + "; Map Length -- Minimum size: 6 - Maximum size: 50");
                saveFile.WriteLine(MAP_Y + "; Map Height -- Minimum size: 6 - Maximum size: 30");
                saveFile.WriteLine(((int)MAP_TYPE) + "; Map Type -- 0 STANDARD - 1 BORDERLESS - 2 HOLES ON THE WALL - 3 EXTRA WALLS - 4 HOLES AND WALLS");
                saveFile.WriteLine(SPECIAL_FRUIT_AVAILABLE + "; Special Fruit Available -- True - False");
                saveFile.WriteLine(SPECIAL_FRUIT_PCT + "; Special Fruit Percentage -- 0,00 0% - 1 100% - Recommended to make 0,05 increments");
                saveFile.WriteLine(SPECIAL_FRUIT_VALUE + "; Special Fruit Value -- -3 - 10");
                saveFile.WriteLine(INITIAL_SNAKE_SIZE + "; Initial Snake Size -- 3 - 15");
                saveFile.WriteLine(IN_UP + "; Controls: Move Up");
                saveFile.WriteLine(IN_DOWN + "; Controls: Move Down");
                saveFile.WriteLine(IN_LEFT + "; Controls: Move Left");
                saveFile.WriteLine(IN_RIGHT + "; Controls: Move Right");
                saveFile.WriteLine(IN_PAUSE + "; Controls: Pause");
                saveFile.WriteLine(IN_NEW + "; Controls: New game");
            }
        }

        public static void LoadConfig()
        {
            if(!File.Exists(Path.Combine(Environment.CurrentDirectory, "Configuration.txt")))
            {
                SetToDefault();
                SaveConfig();
            } 
            else
            { 
                using (StreamReader readFile = new StreamReader(Path.Combine(Environment.CurrentDirectory, "Configuration.txt")))
                {
                    try
                    {
                        DIFFICULTY = (Difficulty) Int32.Parse(readFile.ReadLine().Split(';')[0]);
                        MAP_X = Int32.Parse(readFile.ReadLine().Split(';')[0]);
                        MAP_Y = Int32.Parse(readFile.ReadLine().Split(';')[0]);
                        MAP_TYPE = (MapType) Int32.Parse(readFile.ReadLine().Split(';')[0]);
                        SPECIAL_FRUIT_AVAILABLE = Boolean.Parse(readFile.ReadLine().Split(';')[0]);
                        SPECIAL_FRUIT_PCT = Double.Parse(readFile.ReadLine().Split(';')[0]);
                        SPECIAL_FRUIT_VALUE = Int32.Parse(readFile.ReadLine().Split(';')[0]);
                        INITIAL_SNAKE_SIZE = Int32.Parse(readFile.ReadLine().Split(';')[0]);
                        IN_UP = (ConsoleKey) readFile.ReadLine().Split(';')[0][0];
                        IN_DOWN = (ConsoleKey) readFile.ReadLine().Split(';')[0][0];
                        IN_LEFT = (ConsoleKey) readFile.ReadLine().Split(';')[0][0];
                        IN_RIGHT = (ConsoleKey) readFile.ReadLine().Split(';')[0][0];
                        IN_PAUSE = (ConsoleKey) readFile.ReadLine().Split(';')[0][0];
                        IN_NEW = (ConsoleKey) readFile.ReadLine().Split(';')[0][0];
                    }
                    catch (IOException)
                    {
                        SetToDefault();
                    }
                }
            }
        }

        public static void SetToDefault()
        {
            DIFFICULTY = Difficulty.Easy;
            TIMER = 250;

            MAP_X = 20;
            MAP_Y = 15;
            MAP_TYPE = MapType.Standard;
            SPECIAL_FRUIT_AVAILABLE = true;
            SPECIAL_FRUIT_PCT = 0.05;
            SPECIAL_FRUIT_VALUE = 3;
            INITIAL_SNAKE_SIZE = 4;
            IN_LEFT = ConsoleKey.A;
            IN_RIGHT = ConsoleKey.D;
            IN_UP = ConsoleKey.W;
            IN_DOWN = ConsoleKey.S;
            IN_PAUSE = ConsoleKey.P;
            IN_NEW = ConsoleKey.N;
        }
    }
}
