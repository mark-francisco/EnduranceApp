﻿using System;
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
            foreach(string arg in args)
            {
                Maze.SetUpMaze();
                SolveMaze(arg);
                Console.WriteLine("---------------");
            }
            Console.ReadLine();
        }


        static void SolveMaze(string maze) {

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
            var nodes = allCells.FindAll(cell => cell.Value == 1);

            Console.WriteLine("List of valid spaces:");
            foreach (Cell node in nodes)
            {
                Console.WriteLine(GetAllProperties(node));
            }

            // Define the end goal
            Globals.solutionCell = nodes[nodes.Count() - 1];
            Console.WriteLine("Solution cell is: " + GetAllProperties(Globals.solutionCell));


            ////////////////////////////////////////////////////////


            //Start with the first cell in the array (there's only 1 node with a y-coordinate of 1).
            var currentCell = nodes[0];
            var foundSolution = false;

            // First, check if you've reached the end of the maze
            if (currentCell == Globals.solutionCell)
            {
                foundSolution = true;
            }

            // If you've reached the end, add that Cell to path. Work your way back and fill in the rest of the path.
            if (foundSolution == true)
            {
                Globals.path.Insert(0, $"({currentCell.Y},{currentCell.X})");
                //recursively go back up the fn calls in the call stack.
                //TODO: figure out how to go back one recursive call in the call stack in C#.
            }

            // Otherwise, you're not done with the maze yet. Check if you can make a move to one of the neighboring Cells. Define the 4 neighbors.
            //DefineNeighbors(currentCell);

            //note to self: this returns a Cell if neighbor exists in nodes array, or null otherwise.
            var downNeighbor = nodes.FirstOrDefault(node => node.Y == currentCell.Y + 1 && node.X == currentCell.X);
            var leftNeighbor = nodes.FirstOrDefault(node => node.Y == currentCell.Y && node.X == currentCell.X - 1);
            var upNeighbor = nodes.FirstOrDefault(node => node.Y == currentCell.Y - 1 && node.X == currentCell.X);
            var rightNeighbor = nodes.FirstOrDefault(node => node.Y == currentCell.Y && node.X == currentCell.X + 1);


            // if the targetCell exists in the nodes array, proceed to generate the 4 neighbors for that cell and check if ValidMazeMove.
            //TODO: figure out how to structure the neighbors/checks. need to either use a loop or a separate fn.
            //TODO: figure out how to work with the call stack in C#.

            //if (downNeighbor != null && ValidMazeMove(currentCell, downNeighbor)) {

            //}
            //if (leftNeighbor!= null)
            //{
            //    ValidMazeMove(currentCell, leftNeighbor);
            //}
            //if (upNeighbor != null)
            //{
            //    ValidMazeMove(currentCell, upNeighbor);
            //}
            //if (rightNeighbor != null)
            //{
            //    ValidMazeMove(currentCell, rightNeighbor);
            //}
            //if the move is valid for that targetCell, recursively re-run the function again, but with the next node that was moved to (run solveMaze(targetCell)).

            //if none of the 4 moves are valid, backtrack. meaning, break out of the function call and go back up one level to the previous fn call (go back 1 level in the stack). run the function again for the previous Cell. it will check for possible valid moves, based on which remaining cells haven't been checked yet.
        }

        //static List<Cell> DefineNeighbors(Cell currentCell)
        //{

        //}

        static bool ValidMazeMove(Cell currentCell, Cell targetCell)
        {
            //Criteria:
            //check that targetCell is not out of bounds (targetCell.Y <= numRows and targetCell.X <= numCols).
            //check that targetCell hasn't been traversed/checked yet (targetCell NOT IN checked[]).

            
            if (ValidateCellInBounds(targetCell) && ValidateCellNotCheckedYet(targetCell))
            {
                Globals.checkedCells.Add(targetCell);
                return true;
            } else
            {
                return false;
            }

        }

        static bool ValidateCellInBounds(Cell cellToCheck)
        {            
            if (cellToCheck.Y <= Globals.numRows && cellToCheck.X <= Globals.numCols) {
                return true;
            } else
            {
                return false;
            }
        }

        static bool ValidateCellNotCheckedYet(Cell cellToCheck) {
            if (!Globals.checkedCells.Contains(cellToCheck)) {
                return true;
            } else
            {
                return false;
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
