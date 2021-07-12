using System;
using System.Collections.Generic;

namespace EnduranceApp
{
    public class Maze
    {
        public Cell solutionCell;
        public List<Cell> checkedCells;
        public Cell currentCell;
        public bool foundSolution;
        public int numRows;
        public int numCols;
        public List<string> path;
        public List<Cell> nodes;

        public void SetUpMaze(string mazeFile)
        {
            Console.WriteLine("hey");
        }
    }
}
