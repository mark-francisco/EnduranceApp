using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;

namespace EnduranceApp
{
    class Program
    {
        // instructions (for now):
        // user must change filepath to represent the directory on their machine on which the application lives
        // user must pass in .txt files to the console app as fn arguments

        //TODO: re-factor code. split functionality into separate components: functions and classes.


        static void Main(string[] args)
        {
            foreach (string arg in args)
            {
                var maze = new Maze();
                maze.SetUpMaze(arg);
                SolveMaze(arg);
                Console.WriteLine("---------------");
            }
            Console.ReadLine();
        }


        static void SolveMaze(string maze)
        {

            // Set up Maze
            string mazeFile = Globals.mazesFilepath + maze;
            List<string> rows = File.ReadLines(mazeFile).ToList();

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
                Globals.numRows = i;
                Globals.numCols = j;
            }

            // Filter for only the valid maze spaces
            Globals.nodes = allCells.FindAll(cell => cell.Value == 1);

            Console.WriteLine("List of valid spaces:");
            foreach (Cell node in Globals.nodes)
            {
                Console.WriteLine(GetAllProperties(node));
            }

            // Define the end goal
            Globals.solutionCell = Globals.nodes[Globals.nodes.Count() - 1];
            Console.WriteLine("Solution cell is: " + GetAllProperties(Globals.solutionCell));




            //Start with the first cell in the array (there's only 1 node with a y-coordinate of 1).
            Globals.currentCell = Globals.nodes[0];
            Globals.foundSolution = false;

            ////////////////////////////////////////////////////////
            ////////////////////////////////////////////////////////


            //Run Maze Move (this fn will be run while foundSolution == false).

            // EXIT CONDITION: First, check if you've reached the end of the maze
            if (Globals.currentCell == Globals.solutionCell)
            {
                Globals.foundSolution = true;
                Console.WriteLine(Globals.path);
                return;
            }

            // Otherwise, you're not done with the maze yet. Check if you can make a move to one of the neighboring Cells. Define the 4 neighbors.
            var neighbors = DefineNeighbors(Globals.currentCell);
            foreach (Cell neighbor in neighbors)
            {
                if (ValidMazeMove(neighbor))
                {
                    //foreach (Cell checkedCell in Globals.checkedCells) {
                    //    Console.WriteLine(GetAllProperties(checkedCell));
                    //};
                    Globals.path.Insert(0, $"({neighbor.Y},{neighbor.X})");
                    Globals.currentCell = neighbor;
                    //RunMazeMove(currentCell);
                }   
            }
            //if none of the 4 moves are valid, backtrack. meaning, break out of the function call and go back up one level to the previous fn call (go back 1 level in the stack). run the function again for the previous Cell. it will check for possible valid moves, based on which remaining cells haven't been checked yet.
            //Globals.path.RemoveAt(Globals.path.Count - 1);


            static List<Cell> DefineNeighbors(Cell currentCell)
            {
                var neighbors = new List<Cell>();
                var downNeighbor = Globals.nodes.FirstOrDefault(node => node.Y == currentCell.Y + 1 && node.X == currentCell.X);
                if (downNeighbor != null)
                {
                    neighbors.Add(downNeighbor);
                }
                var leftNeighbor = Globals.nodes.FirstOrDefault(node => node.Y == currentCell.Y && node.X == currentCell.X - 1);
                if (leftNeighbor != null)
                {
                    neighbors.Add(leftNeighbor);
                }
                var upNeighbor = Globals.nodes.FirstOrDefault(node => node.Y == currentCell.Y - 1 && node.X == currentCell.X);
                if (upNeighbor != null)
                {
                    neighbors.Add(upNeighbor);
                }
                var rightNeighbor = Globals.nodes.FirstOrDefault(node => node.Y == currentCell.Y && node.X == currentCell.X + 1);
                if (rightNeighbor != null)
                {
                    neighbors.Add(rightNeighbor);
                }
                return neighbors;
            }

            static bool ValidMazeMove(Cell targetCell)
            {
                if (ValidateCellInBounds(targetCell) && ValidateCellNotCheckedYet(targetCell))
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }


            static bool ValidateCellInBounds(Cell cellToCheck)
            {
                if (cellToCheck.Y <= Globals.numRows && cellToCheck.X <= Globals.numCols)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }


            static bool ValidateCellNotCheckedYet(Cell cellToCheck)
            {
                if (!Globals.checkedCells.Contains(cellToCheck))
                {
                    Globals.checkedCells.Add(cellToCheck);
                    return true;
                }
                else
                {
                    return false;
                }

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