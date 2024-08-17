using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Snake_Game
{
    class Graph
    {
        int mapX;
        int mapY;
        int[,,] Matrix;
        Cell[,] WallMap;
        int totalVertices;

        public Graph(int mapX, int mapY, Cell[,] WallMap)
        {
            this.mapX = mapX;
            this.mapY = mapY;
            this.WallMap = WallMap;
            totalVertices = 0;
            GenerateEmptyMatrix();
            populateMatrix();
        }

        private void GenerateEmptyMatrix()
        {
            this.Matrix = new int[mapX,mapY, 4];
            for (int row = 0; row < mapX; row++)
            {
                for (int col = 0; col < mapY; col++)
                {
                    int[] edges = { 0, 0, 0, 0 };
                    AddEdges(row, col, edges);
                }
            }
        }

        public void AddEdges(int x, int y, int[] walls)
        {
            if (x >= mapX || y >= mapY || x < 0 || y < 0)
                throw new ArgumentOutOfRangeException("Vertices are out of bounds");
            for (int wall = 0; wall < walls.Length; wall++)
            {
                Matrix[x,y,wall] = walls[wall];
            }
        }       

        public IEnumerable<int> GetAdjacentVertices(int x, int y, bool allVertices)
        {
            List<int> adjacentVertices = new List<int>();
            for (int i = 0; i < 4; i++)
            {
                if (allVertices == true) adjacentVertices.Add(i);
                else if(this.Matrix[x,y,i] > 0) adjacentVertices.Add(i);
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
                        int[] edges = { 0, 0, 0, 0 };
                        int wallCount = 0;
                        if(WallMap[LoopMap(i-1,true),j].Type != 'O') edges[0] = 1; //LEFT
                        else wallCount++;
                        if(WallMap[LoopMap(i+1,true),j].Type != 'O') edges[1] = 1; //RIGHT
                        else wallCount++;
                        if(WallMap[i,LoopMap(j-1,false)].Type != 'O') edges[2] = 1; //UP
                        else wallCount++;
                        if(WallMap[i,LoopMap(j+1,false)].Type != 'O') edges[3] = 1; //DOWN
                        else wallCount++;
                        if (wallCount > 3)
                        {
                            WallMap[i, j].Type = 'O';
                            //AddEdges(i, j,new int[]{0,0,0,0});
                            //if (i > 0) Matrix[i - 1, j, 1] = 0;
                            //if (j > 0) Matrix[i, j - 1, 3] = 0;
                        }
                        else
                        {
                            AddEdges(i, j, edges);
                            totalVertices++;
                        }
                    }
                 }
            }
        }

        public void ConvertMatrixToGraph()
        {
            int[,] graph = new int[totalVertices, totalVertices];
            for (int i = 0; i < totalVertices; i++)
            {
                for (int j = 0; j < totalVertices; j++)
                {
                    //TODO
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
    }
}