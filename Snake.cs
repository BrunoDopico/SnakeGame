using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Snake_Game
{
    class Snake
    {
        private int head_x;
        private int head_y;
        private int tail_x;
        private int tail_y;
        private int size;
        private int growing;

        //CONSTRUCTOR
        public Snake(int initialPosition_x, int initialPosition_y, int initialSize)
        {
            head_x = initialPosition_x;
            head_y = initialPosition_y;
            tail_x = initialPosition_x;
            tail_y = initialPosition_y;
            size = initialSize;
            growing = initialSize -1;
        }

        //SETTERS & GETTERS

        public int Size { get => size; set => size = value; }
        public int Growing { get => growing; set => growing = value; }
        public int Head_x { get => head_x; set => head_x = value; }
        public int Head_y { get => head_y; set => head_y = value; }
        public int Tail_x { get => tail_x; set => tail_x = value; }
        public int Tail_y { get => tail_y; set => tail_y = value; }

        //METHODS
        public void MoveHead(int direction)
        {
            
            switch (direction)
            {
                case 0:
                    head_x --;
                    break;
                case 1:
                    head_x ++;
                    break;
                case 2:
                    head_y --;
                    break;
                case 3:
                    head_y ++;
                    break;
            }
        }

        public void MoveTail(int direction)
        {

            switch (direction)
            {
                case 0:
                    tail_x--;
                    break;
                case 1:
                    tail_x++;
                    break;
                case 2:
                    tail_y--;
                    break;
                case 3:
                    tail_y++;
                    break;
            }
        }

    }
}
