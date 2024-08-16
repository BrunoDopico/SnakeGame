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
        int[,] Matrix;
        Cell[,] WallMap;

        public Graph(int mapX, int mapY, Cell[,] WallMap)
        {
            this.mapX = mapX;
            this.mapY = mapY;
            this.WallMap = WallMap;
            GenerateEmptyMatrix();
        }

        private void GenerateEmptyMatrix()
        {
            this.Matrix = new int[numX*numY, numX*numY];
            for (int row = 0; row < numX*numY; row++)
            {
                for (int col = 0; col < umX*numY; col++)
                {
                    Matrix[row, col] = 0;
                }
            }
        }

        public void AddEdge(int v1, int v2, weight)
        {
            if (v1 >= this.numVertices || v2 >= this.numVertices || v1 < 0 || v2 < 0)
                throw new ArgumentOutOfRangeException("Vertices are out of bounds");

            this.Matrix[v1, v2] = weight;
            this.Matrix[v2, v1] = weight;
        }       

        public IEnumerable<int> GetAdjacentVertices(int v, bool allVertices){
            if (v < 0 || v >= mapX*mapY) throw new ArgumentOutOfRangeException("Cannot access vertex");

            List<int> adjacentVertices = new List<int>();
            for (int i = 0; i < this.mapX*mapY; i++)
            {
                if (this.Matrix[v, i] != 0)
                    allVertices == true ? adjacentVertices.Add(i) : if(this.Matrix[v, i] > 0) adjacentVertices.Add(i);
            }
                    
            return adjacentVertices;
        }

        public void populateMatrix()
        {
            for(int i = 0; i < this.mapX; i++)  
            {
                 for(int j = 0; i < this.mapY; j++)  
                {
                    //TODO
                }
            }
        }

        public int NumVertices { get { return this.numVertices; } }
    }
}