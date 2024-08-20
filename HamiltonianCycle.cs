// C# program for solution of Hamiltonian 
// Cycle problem using backtracking
using System;

public class HamiltonianCycle
{
    int Vertices;
    int[] path;

    /* A utility function to check 
    if the vertex coordinates can be added at 
    index 'pos' in the Hamiltonian Cycle
    constructed so far (stored in 'path[]') */
    public bool IsSafe(int coordinates, int[,] graph,
                int[] path, int pos)
    {
        /* Check if this vertex is 
        an adjacent vertex of the
        previously added vertex. */
        int lastIndex = GetIndexFrom2DArray(graph, path[pos - 1]);
        bool isAdjacent = false;
        for (int i = 1; i < graph.GetLength(1); i++)
        {
            if (graph[lastIndex, i] == coordinates)
            {
                isAdjacent = true;
                break;
            }
        }


        /* Check if the vertex has already 
        been included. This step can be
        optimized by creating an array
        of size V */
        for (int i = 0; i < pos; i++)
            if (path[i] == coordinates)
                return false;

        return true;
    }

    private int GetIndexFrom2DArray(int[,] array, int value)
    {
        for (int i = 0; i < array.GetLength(0); i++)
        {
            if (array[i, 0] == value) return i;
        }
        return -1;
    }

    /* Greedy step to initialize path with promising vertices */
    public void GreedyInitialization(int[,] graph, int[] path)
    {
        bool[] visited = new bool[Vertices];
        visited[0] = true;  // Start from the first vertex
        int currentVertex = graph[0, 0];
        path[0] = currentVertex;

        for (int i = 1; i < Vertices; i++)
        {
            int nextVertex = -1;
            int currentIndex = GetIndexFrom2DArray(graph, currentVertex);

            // Find the first unvisited vertex connected to the current one
            for (int j = 1; j <= 4; j++)
            {
                int candidateVertex = graph[currentIndex, j];
                if (candidateVertex != 0)
                {
                    int candidateIndex = GetIndexFrom2DArray(graph, candidateVertex);
                    if (!visited[candidateIndex])
                    {
                        nextVertex = candidateVertex;
                        visited[candidateIndex] = true;
                        break;
                    }
                }
            }

            if (nextVertex != -1)
            {
                path[i] = nextVertex;
                currentVertex = nextVertex;
            }
            else
            {
                // If no more connections, break early
                break;
            }
        }
    }


    /* A recursive utility function
    to solve hamiltonian cycle problem */
    public bool HamCycleUtil(int[,] graph, int[] path, int pos)
    {
        /* base case: If all vertices 
        are included in Hamiltonian Cycle */
        if (pos == Vertices)
        {
            // And if there is an edge from the last included
            // vertex to the first vertex
            int lastIndex = GetIndexFrom2DArray(graph, path[pos - 1]);
            for (int i = 1; i < graph.GetLength(1); i++)
            {
                if (graph[lastIndex, i] == path[0])
                    return true;
            }
            return false;
        }

        // Try different vertices as a next candidate in
        // Hamiltonian Cycle. We don't try for 0 as we
        // included 0 as starting point in hamCycle()
        for (int v = 1; v < Vertices; v++)
        {
            /* Check if this vertex can be 
            added to Hamiltonian Cycle */
            if (IsSafe(graph[v, 0], graph, path, pos))
            {
                path[pos] = graph[v,0];

                /* recur to construct rest of the path */
                if (HamCycleUtil(graph, path, pos + 1) == true)
                    return true;

                /* If adding vertex v doesn't 
                lead to a solution, then remove it */
                path[pos] = -1;
            }
        }

        /* If no vertex can be added to Hamiltonian Cycle
        constructed so far, then return false */
        return false;
    }

    /* This function solves the Hamiltonian 
    Cycle problem using Backtracking. It 
    mainly uses hamCycleUtil() to solve the
    problem. It returns false if there
    is no Hamiltonian Cycle possible, 
    otherwise return true and prints the path.
    Please note that there may be more than 
    one solutions, this function prints one 
    of the feasible solutions. */
    public int HamCycle(int[,] graph, int vert)
    {
        Vertices = vert;
        path = new int[Vertices];
        for (int i = 0; i < Vertices; i++)
            path[i] = -1;

        GreedyInitialization(graph, path);

        /* Let us put vertex 0 as the first
        vertex in the path. If there is a 
        Hamiltonian Cycle, then the path can be
        started from any point of the cycle 
        as the graph is undirected */
        if (HamCycleUtil(graph, path, 1) == false)
        {
            return 0;
        }
        return 1;
    }
}