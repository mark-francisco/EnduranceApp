using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;

namespace EnduranceApp
{
    class Program
    {
        static void Main(string[] mazeFiles)
        {
            foreach (string mazeFile in mazeFiles)
            {
                SetUpMaze(mazeFile);               
                Console.WriteLine("---------------");
            }
            Console.ReadLine();
        }

        static void SetUpMaze(string mazeFile)
        {
            //instantiate new Maze Object
            var currentMaze = new Maze();

            // Read from the filepath
            List<string> rows = File.ReadLines(Globals.mazesDirectory + mazeFile).ToList();

            // Format the board with all cells from .txt file
            List<Cell> allCells = new List<Cell>();

            int i = 0;
            foreach (string row in rows)
            {
                int rowNum = i + 1;
                string[] cells = row.Split(" ");
                int j = 0;
                while (j < cells.Count())
                {
                    int columnNum = j + 1;
                    Cell newCell = new Cell();
                    newCell.Value = Convert.ToInt16(cells[j]);
                    newCell.Y = rowNum;
                    newCell.X = columnNum;
                    allCells.Add(newCell);
                    j++;
                }
                i++;
                currentMaze.numRows = i;
                currentMaze.numCols = j;
            }

            // Filter for only the valid maze spaces
            currentMaze.nodes = allCells.FindAll(cell => cell.Value == 1);

            // Define the end goal
            currentMaze.solutionCell = currentMaze.nodes[currentMaze.nodes.Count() - 1];            
            currentMaze.foundSolution = false;

            // Now let's get started with the first "node" (we know from the assumptions that there's exactly 1 node with a y-coordinate of 1).
            var currentCell = currentMaze.nodes[0];
            currentMaze.checkedCells.Add(currentCell);
            currentMaze.path.Add(currentCell);

            // And now we're going thru the maze
            RunMazeMove(currentCell, currentMaze);


            // After all the moves are done, print out the solution.
            Console.WriteLine($"Path for {mazeFile}: ");
            foreach (Cell pathCell in currentMaze.path)
            {
                Console.WriteLine($"({pathCell.Y }, {pathCell.X})");
            }

        }

        static void RunMazeMove(Cell currentCell, Maze currentMaze)
        {

            // Exit Condition: check if you've reached the end of the maze
            if (currentCell == currentMaze.solutionCell)
            {
                currentMaze.foundSolution = true;
                return;
            }
            if (!currentMaze.foundSolution)
            {
            
                // Check if you can make a move to a neighboring Cell.
                // Define the neighbors.
                var neighbors = currentMaze.DefineNeighbors(currentCell);

                // Check if you can make a valid move to one of the neighbors.
                var neighbor = currentMaze.CheckNeighbors(neighbors);

                if (neighbor != null)
                {
                    // We found a legit neighbor, so add them to the Path for the next round. 
                    currentMaze.path.Add(neighbor);                    
                } else
                {
                    // No neighboring moves were valid, so backtrack from that dead end.
                    currentMaze.path.RemoveAt(currentMaze.path.Count - 1);                  
                }

                // Start the next round: check based on the last node currently in the path.
                RunMazeMove(currentMaze.path[currentMaze.path.Count - 1], currentMaze);
            }
        }



        public static string GetAllProperties(object obj)
        {
            return string.Join(" ", obj.GetType()
                                        .GetProperties()
                                        .Select(prop => prop.GetValue(obj)));
        }
    }
}