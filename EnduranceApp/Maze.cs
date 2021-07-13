using System;
using System.Collections.Generic;

namespace EnduranceApp
{
    public class Maze
    {
        public int numRows;
        public int numCols;
        public Cell solutionCell;
        public bool foundSolution;
        public List<Cell> nodes;
        public List<Cell> checkedCells = new List<Cell>();
        public Cell currentCell;
        public List<Cell> path = new List<Cell>();

        public void SetUpMaze(string mazeFile)
        {
            Console.WriteLine("hey");
        }
    }
}
