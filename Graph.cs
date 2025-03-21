using Snake_Game.Entities;
using Snake_Game.Enums;
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

        public Graph(Cell[,] Walls)
        {
            this.mapX = Config.MAP_X;
            this.mapY = Config.MAP_Y;
            this.WallMap = Walls;
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

        public void AddEdges(int x, int y, int[] edges)
        {
            if (x >= mapX || y >= mapY || x < 0 || y < 0)
                throw new ArgumentOutOfRangeException("Vertices are out of bounds");
            for (int edge = 0; edge < edges.Length; edge++)
            {
                Matrix[x,y,edge] = edges[edge];
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
            for(int i = 0; i < mapX; i++)  
            {
                 for(int j = 0; j < mapY; j++)  
                 {
                    if(WallMap[i,j].Type != CellType.Obstacle)
                    {
                        int[] edges = { 0, 0, 0, 0 };
                        int wallCount = 0;
                        if(WallMap[LoopMap(i-1,true),j].Type != CellType.Obstacle) edges[0] = 1; //LEFT
                        else wallCount++;
                        if(WallMap[LoopMap(i+1,true),j].Type != CellType.Obstacle) edges[1] = 1; //RIGHT
                        else wallCount++;
                        if(WallMap[i,LoopMap(j-1,false)].Type != CellType.Obstacle) edges[2] = 1; //UP
                        else wallCount++;
                        if(WallMap[i,LoopMap(j+1,false)].Type != CellType.Obstacle) edges[3] = 1; //DOWN
                        else wallCount++;
                        
                        if (wallCount > 3)
                        {
                            WallMap[i, j].Type = CellType.Obstacle;
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

        public int ConvertMatrixToGraph()
        {
            int[,] graph = new int[totalVertices,5];
            int count = 0;
            bool isVertex = false;
            for (int i = 0; i < mapX; i++)
            {
                for (int j = 0; j < mapY; j++)
                {
                    if(count < totalVertices)
                    {
                        if (Matrix[i, j, 0] == 1)
                        {
                            isVertex = true;
                            graph[count, 1] = 100 * LoopMap(i - 1, true) + j;
                        }
                        if (Matrix[i, j, 1] == 1)
                        {
                            isVertex = true;
                            graph[count, 2] = 100 * LoopMap(i + 1, true) + j;
                        }
                        if (Matrix[i, j, 2] == 1)
                        {
                            isVertex = true;
                            graph[count, 3] = 100 * i + LoopMap(j - 1, false);
                        }
                        if (Matrix[i, j, 3] == 1)
                        {
                            isVertex = true;
                            graph[count, 4] = 100 * i + LoopMap(j + 1, false);
                        }
                        if (isVertex)
                        {
                            graph[count, 0] = 100 * i + j;
                            count++;
                            isVertex = false;
                        }
                    }
                }
            }
            HamiltonianCycle ham = new HamiltonianCycle();
            return ham.HamCycle(graph, totalVertices);
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