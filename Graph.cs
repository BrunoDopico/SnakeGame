using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Snake_Game
{
    public class Graph
    {
        int mapX;
        int mapY;
        int[,,] Matrix;
        Cell[,] WallMap;

        public Graph(int mapX, int mapY, Cell[,] WallMap)
        {
            this.mapX = mapX;
            this.mapY = mapY;
            this.WallMap = WallMap;
            GenerateEmptyMatrix();
            populateMatrix();
        }

        private void GenerateEmptyMatrix()
        {
            this.Matrix = new int[numX,numY, 4];
            for (int row = 0; row < numX; row++)
            {
                for (int col = 0; col < numY; col++)
                {
                    for(int depth = 0; depth < 4; depth++) 
                        Matrix[row,col,depth] = 0;
                }
            }
        }

        public void AddEdges(int x, int y, int[] walls)
        {
            if (x >= this.numVertices || y >= this.numVertices || x < 0 || y < 0)
                throw new ArgumentOutOfRangeException("Vertices are out of bounds");
            for (int wall = 0; wall < walls.length; wall++)
            {
                Matrix[x,y,wall] = walls[wall];
            }
        }       

        public IEnumerable<int> GetAdjacentVertices(int x, int y, bool allVertices){
            List<int> adjacentVertices = new List<int>();
            for (int i = 0; i < Matrix.GetLength(2); i++)
            {
                allVertices == true ? adjacentVertices.Add(i) : if(this.Matrix[v, i] > 0) adjacentVertices.Add(i);
            }

            return adjacentVertices;
        }

        public void populateMatrix()
        {
            bool isWall = false;
            for(int i = 0; i < this.mapX; i++)  
            {
                 for(int j = 0; i < this.mapY; j++)  
                {
                    isWall = WallMap[i,j].Type == 'O';
                    if(!isWall){
                        int wallCount = 0;
                        if(WallMap[LoopMap(i-1,true),j].Type != 'O') {Matrix[i,j,0] = 1; //LEFT
                        else wallCount++;
                        if(WallMap[LoopMap(i+1,true),j].Type != 'O') Matrix[i,j,1] = 1; //RIGHT
                        else wallCount++;
                        if(WallMap[i,LoopMap(j-1,false)].Type != 'O') Matrix[i,j,2] = 1; //UP
                        else wallCount++;
                        if(WallMap[i,LoopMap(j+1,false)].Type != 'O') Matrix[i,j,3] = 1; //DOWN
                        else wallCount++;
                        if(wallCount == 1 || wallCount == 4) WallMap[i,j].Type ='O';
                    }
                }
            }
        }

        public int LoopMap(int value, bool isX){
            if(value < 0){
                if(isX) return mapX-1;
                else return mapY-1;
            }
            else if(isX){
                if(value >= mapX) return 0;
            }
            else if(value >= mapY) return 0;
            return value;
        }

        public int NumVertices { get { return this.numVertices; } }
    }
}