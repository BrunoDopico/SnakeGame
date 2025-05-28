using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Snake_Game
{
    public interface IGameView
    {
        void UpdateCell(int x, int y);
        void ChangeTime(int seconds);
        void ChangeScore(int score);
    }
}
