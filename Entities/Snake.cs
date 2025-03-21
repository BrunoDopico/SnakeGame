using Snake_Game.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Snake_Game.Entities
{
    class Snake
    {
        //CONSTRUCTOR
        public Snake(int initialPosition_x, int initialPosition_y, int initialSize)
        {
            Head_x = initialPosition_x;
            Head_y = initialPosition_y;
            Tail_x = initialPosition_x;
            Tail_y = initialPosition_y;
            Size = initialSize;
            Growing = initialSize -1;
        }

        //SETTERS & GETTERS

        public int Size { get; set; }
        public int Growing { get; set; }
        public int Head_x { get; set; }
        public int Head_y { get; set; }
        public int Tail_x { get; set; }
        public int Tail_y { get; set; }

        //METHODS
        public void MoveHead(Direction direction)
        {
            
            switch (direction)
            {
                case Direction.Left:
                    Head_x --;
                    break;
                case Direction.Right:
                    Head_x ++;
                    break;
                case Direction.Up:
                    Head_y --;
                    break;
                case Direction.Down:
                    Head_y ++;
                    break;
            }
        }

        public void MoveTail(Direction direction)
        {

            switch (direction)
            {
                case Direction.Left:
                    Tail_x--;
                    break;
                case Direction.Right:
                    Tail_x++;
                    break;
                case Direction.Up:
                    Tail_y--;
                    break;
                case Direction.Down:
                    Tail_y++;
                    break;
            }
        }

    }
}
