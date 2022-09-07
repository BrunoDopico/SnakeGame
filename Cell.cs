using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Snake_Game
{
    class Cell
    {
        //Type of the cell, possible values: 'V':Void, 'S':Snake, 'F':Fruit, 'O':Obstacle
        private char type;
        /**
         * Value of the cell:
         * For snake: Indicates the snake's next part direction where 0: left, 1: right, 2: up, 3: down
         * For fruit: Indicates the fruit's added length to the snake
         * For obstacle: 0: Wall, 1: Terrain
        **/
        private int value;

        public Cell(char type, int value)
        {
            this.type = type;
            this.value = value;
        }

        public char Type { get => type; set => type = value; }
        public int Value { get => value; set => this.value = value; }

    }
}

    
