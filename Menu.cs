using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Snake_Game
{
    class Program
    {

        static void MainMenu()
        {
            bool exit = false;
            string[] items = {"EXIT","NEW GAME","OPTIONS","HOW TO PLAY"};
            do
            {
                Console.Clear();
                Console.WriteLine("-_MAIN MENU_-");
                for (int i = 0; i < items.Length; i++)
                {
                    Console.WriteLine(String.Format("{0}.- {1}", i, items[i]));
                }
                bool correct = false;
                int option = -1;
                do
                {
                    try
                    {
                        Console.Write("- ");
                        option = Int32.Parse(Console.ReadLine());
                        if (option >= 0 && option < items.Length) correct = true;
                        else Console.WriteLine("Wrong number!");
                    }
                    catch (FormatException)
                    {
                        Console.WriteLine("Wrong input! Must be a number");
                    }
                } while (!correct);

                switch (option)
                {
                    case 0:
                        //EXIT PROGRAM
                        exit = true;
                        break;
                    case 1:
                        //START A NEW GAME
                        //SnakeGame game = new SnakeGame();
                        //game.PlayGame();
                        break;
                    case 2:
                        //OPEN THE OPTIONS MENU
                        OptionsMenu();
                        break;
                    case 3:
                        //SHOW THE HOW TO PLAY
                        HowToPlay();
                        break;
                }
            } while (!exit);
            
        }

        private static void HowToPlay()
        {
            Console.Clear();
            Console.WriteLine("This is the snake game. \n" +
                "The objective of this game is to survive for as long as possible \n" +
                "while eating fruits ('" + Config.DIS_N_FRUIT + "','" + Config.DIS_SUPER_FRUIT + "') to make your snake's body larger. \n" +
                "Touching an obstacle or your own body will instantly kill you.\n" +
                "\n- CONTROLS -\n" +
                " ·Move Up: " + Config.IN_UP.ToString() +
                "\n ·Move Down: " + Config.IN_DOWN.ToString() +
                "\n ·Move Left: " + Config.IN_LEFT.ToString() +
                "\n ·Move Right: " + Config.IN_RIGHT.ToString() +
                "\n ·Pause: " + Config.IN_PAUSE.ToString() +
                "\n\n- MAP -\n" +
                "'"+Config.DIS_EMPTY+"': Empty space\n" +
                "'" + Config.DIS_SNAKE_BODY + "': Snake's body\n" +
                "'" + Config.DIS_WALL + "': Wall\n" +
                "'" + Config.DIS_N_FRUIT + "': Normal fruit (value 1)\n" +
                "'" + Config.DIS_SUPER_FRUIT + "': Special fruit (value "+ Config.SPECIAL_FRUIT_VALUE+") (Can be changed in configuration)\n" +
                "\n- CREDITS -\n" +
                "Game made by Bruno (BrunusOP) Dopico\n");
            Console.Write("Press Enter to go back");
            Console.ReadLine();
        }

        static void OptionsMenu()
        {
            bool exit = false;
            string[] items = { "BACK", "Change map type", "Change map size", "Change difficulty", "Change initial snake size"};
            do
            {
                Console.Clear();
                Console.WriteLine("-_OPTIONS_-");
                for (int i = 0; i < items.Length; i++)
                {
                    Console.WriteLine(String.Format("{0}.- {1}", i, items[i]));
                }
                bool correct = false;
                int option = -1;
                do
                {
                    try
                    {
                        Console.Write("- ");
                        option = Int32.Parse(Console.ReadLine());
                        if (option >= 0 && option < items.Length) correct = true;
                        else Console.WriteLine("Wrong number!");
                    }
                    catch (FormatException)
                    {
                        Console.WriteLine("Wrong input! Must be a number");
                    }
                } while (!correct);

                switch (option)
                {
                    case 0:
                        exit = true;
                        break;
                    case 1:
                        //CHANGE MAP TYPE
                        ChangeMapType();
                        break;
                    case 2:
                        //CHANGE MAP SIZE
                        ChangeMapSize();
                        break;
                    case 3:
                        //CHANGE DIFFICULTY
                        ChangeDifficulty();
                        break;
                    case 4:
                        //CHANGE SNAKE SIZE
                        ChangeSnakeSize();
                        break;

                }
            } while (!exit);
        }

        static void ChangeMapType()
        {
            Console.Clear();
            Console.WriteLine("Actual map type: " + Config.MAP_TYPE);
            Console.WriteLine("Map types: \n" +
                "[0] Default: The map is bordered by walls.\n" +
                "[1] Ouroboros: The map has no outer walls, and exiting by one side makes you come back on the other\n" +
                "[2] Portaled: There are outer walls, but some of them have holes you can pass through.\n" +
                "[3] Walled: Some walls scattered in the map.\n" +
                "[4] All out: A mixture of everything.");
            bool correct = false;
            do
            {
                try
                {
                    Console.Write("Input an option: ");
                    int input = Int32.Parse(Console.ReadLine());
                    if (input >= 0 && input < 5)
                    {
                        correct = true;
                        Config.MAP_TYPE = input;
                    }

                    else Console.WriteLine("Wrong number!");
                }
                catch (FormatException)
                {
                    Console.WriteLine("Wrong input! Must be a number");
                }
            } while (!correct);
            Console.WriteLine("The map type has been successfully changed to: "+ Config.MAP_TYPE+"\nPress Enter to go back.");
            Console.ReadLine();
        }

        static void ChangeMapSize()
        {
            Console.Clear();
            Console.WriteLine("Actual map size: " + Config.MAP_X+" x " + Config.MAP_Y);
            Console.WriteLine("Minimum size: 7 | Maximum size: 45");
            bool correct = false;
            do
            {
                try
                {
                    Console.Write("Input the X coordinate: ");
                    int input = Int32.Parse(Console.ReadLine());
                    if (input >= 7 && input <= 45)
                    {
                        correct = true;
                        Config.MAP_X = input;
                    }

                    else Console.WriteLine("Wrong number!");
                }
                catch (FormatException)
                {
                    Console.WriteLine("Wrong input! Must be a number");
                }
            } while (!correct);

            correct = false;
            do
            {
                try
                {
                    Console.Write("Input the Y coordinate: ");
                    int input = Int32.Parse(Console.ReadLine());
                    if (input >= 7 && input <= 45)
                    {
                        correct = true;
                        Config.MAP_Y = input;
                    }

                    else Console.WriteLine("Wrong number!");
                }
                catch (FormatException)
                {
                    Console.WriteLine("Wrong input! Must be a number");
                }
            } while (!correct);


            Console.WriteLine("The map size has been successfully changed to: " + Config.MAP_X + " x " + Config.MAP_Y + "\nPress Enter to go back.");
            Console.ReadLine();
        }

        static void ChangeDifficulty()
        {
            Console.Clear();
            Console.WriteLine("Actual difficulty: " + Config.DIFFICULTY);
            Console.WriteLine("Difficulties:\n" +
                "[0] Default: No random walls, 4 fruits, slow timer.\n" +
                "[1] Enhanced: Some random walls in the map, 2 fruits, slow timer.\n" +
                "[2] Hard: Random walls, 2 fruits, medium timer.\n" +
                "[3] Insane: Many random walls, 1 fruit, fast timer.");
            bool correct = false;
            do
            {
                try
                {
                    Console.Write("Input an option: ");
                    int input = Int32.Parse(Console.ReadLine());
                    if (input >= 0 && input < 4)
                    {
                        correct = true;
                        Config.DIFFICULTY = input;
                    }

                    else Console.WriteLine("Wrong number!");
                }
                catch (FormatException)
                {
                    Console.WriteLine("Wrong input! Must be a number");
                }
            } while (!correct);
            Console.WriteLine("The difficulty has been successfully changed to: " + Config.DIFFICULTY + "\nPress Enter to go back.");
            Console.ReadLine();
        }

        static void ChangeSnakeSize()
        {
            Console.Clear();
            Console.WriteLine("Actual snake size: "+Config.INITIAL_SNAKE_SIZE);
            Console.WriteLine("Input the new initial snake size (MIN: 1, MAX: 15) Write 0 to cancel.");
            bool correct = false;
            do
            {
                try
                {
                    Console.Write("Input a number: ");
                    int input = Int32.Parse(Console.ReadLine());
                    if (input >= 0 && input < 16)
                    {
                        correct = true;
                        if (input > 0) Config.INITIAL_SNAKE_SIZE = input; 
                    }
                    
                    else Console.WriteLine("Wrong number!");
                }
                catch (FormatException)
                {
                    Console.WriteLine("Wrong input! Must be a number");
                }
            } while (!correct);
            Console.WriteLine("The snake initial lenght has been successfully changed to: " + Config.INITIAL_SNAKE_SIZE + "\nPress Enter to go back.");
            Console.ReadLine();
        }
    }
}
