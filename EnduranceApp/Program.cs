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


        static void Main(string[] args)
        {
            foreach (string arg in args)
            {
                var maze = new Maze();
                SetUpMaze(arg);
                Console.WriteLine("Path: ");
                foreach(Cell pathCell in Globals.path)
                {
                    Console.WriteLine(GetAllProperties(pathCell));
                }
                Console.WriteLine("---------------");
            }
            Console.ReadLine();
        }

        static void SetUpMaze(string maze)
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

            //Console.WriteLine("List of allowed spaces:");
            //foreach (Cell node in Globals.nodes)
            //{
            //    Console.WriteLine(GetAllProperties(node));
            //}

            // Define the end goal
            Globals.solutionCell = Globals.nodes[Globals.nodes.Count() - 1];            

            //Start with the first cell in the array (there's only 1 node with a y-coordinate of 1).            
            Globals.foundSolution = false;
            var currentCell = Globals.nodes[0];
            Globals.checkedCells.Add(currentCell);
            Globals.path.Add(currentCell);
            RunMazeMove(currentCell);            

        }

        static void RunMazeMove(Cell currentCell)
        {
            //Console.WriteLine("PATH: ");
            //foreach (Cell coord in Globals.path)
            //{
            //    Console.WriteLine(GetAllProperties(coord));
            //}
            // EXIT CONDITION: check if you've reached the end of the maze
            if (currentCell == Globals.solutionCell)
            {
                Globals.foundSolution = true;
                return;
            }
            if (!Globals.foundSolution)
            {
            
                // Otherwise, not done with maze yet. Check if you can make a move to a neighboring Cell.
                var neighbors = DefineNeighbors(currentCell);
                var neighbor = CheckNeighbors(neighbors);
                //foreach (Cell checkedCell in Globals.checkedCells)
                //{
                //    Console.WriteLine("Checked: " + GetAllProperties(checkedCell));
                //};

                if (neighbor != null)
                {
                    //Console.WriteLine("current neighbor: " + GetAllProperties(neighbor));
                    Globals.path.Add(neighbor);                    
                } else
                {
                    //Console.WriteLine("no valid neighbors from here!");
                    //none of the neighboring moves are valid, so go and run fn again with currentCell's next unchecked neighbor.
                    Globals.path.RemoveAt(Globals.path.Count - 1);                  
                }
                //foreach (Cell cell in Globals.checkedCells) {
                //    Console.WriteLine(GetAllProperties(cell));
                //}
                RunMazeMove(Globals.path[Globals.path.Count - 1]);

            }


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

            static Cell CheckNeighbors(List<Cell> neighbors)
            {                
                foreach (Cell neighbor in neighbors)
                {
                    if (ValidMazeMove(neighbor))
                    {
                        return neighbor;
                    }
                }
                return null;
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