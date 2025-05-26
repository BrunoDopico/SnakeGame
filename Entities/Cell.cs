using Snake_Game.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Snake_Game.Entities
{
    public class Cell
    {
        public Cell(CellType type, int value)
        {
            Type = type;
            Value = value;
        }

        //Type of the cell, possible values: 'V':Void, 'S':Snake, 'F':Fruit, 'O':Obstacle
        public CellType Type { get; set; }

        /**
         * Value of the cell:
         * For snake: Indicates the snake's next part Direction (parsing the Direction enum) where 0: left, 1: right, 2: up, 3: down
         * For fruit: Indicates the fruit's added length to the snake
         * For obstacle: 0: Wall, 1: Terrain
        **/
        public int Value { get; set; }

    }
}

    
