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
            //TODO: figure out how to get a more dynamic filepath...
            //TODO: split out functionality into separate methods, classes, components
            //TODO: allow the User to pass in multiple mazes as arguments at once
            //TODO: re-factor code and work on improving efficiency
            string filepath = @$"/Users/juanmarcofrancisco/Actualize/VisualStudioProjects/EnduranceApp/ExampleMazes/{args[0]}";
            Console.WriteLine(filepath);
            List<string> rows = File.ReadLines(filepath).ToList();
            //Console.WriteLine(rows);

            int numRows = 0;
            int numCols = 0;

            List<Cell> allCells = new List<Cell>();

            int i = 0;
            foreach (string row in rows)
            {
                int rowNum = i + 1;
                //Console.WriteLine("row " + rowNum + ": " + row);
                string[] cells = row.Split(" ");
                int j = 0;
                while (j < cells.Count())
                {
                    int columnNum = j + 1;
                    //create an array of values (1's and 0's) from the .txt file. use the outer and inner indexes to get the y and x coordinates.
                    //Console.WriteLine("Y: " + rowNum + ", X: " + columnNum + ", value: " + cells[j]);
                    Cell newCell = new Cell();
                    newCell.Value = Convert.ToInt16(cells[j]);
                    newCell.Y = rowNum;
                    newCell.X = columnNum;
                    allCells.Add(newCell);
                    j++;
                }
                i++;
                numRows = i;
                numCols = j;
            }
            //Console.WriteLine($"number of rows in maze: {numRows}");
            //Console.WriteLine($"number of cols in maze: {numCols}");

            //foreach (Cell cell in allCells)
            //{
            //    Console.WriteLine("Cell:");
            //    Console.WriteLine("Value: " + cell.Value);
            //    Console.WriteLine("Y: " + cell.Y);
            //    Console.WriteLine("X: " + cell.X);
            //}



            //www.techiedelight.com/find-shortest-path-in-maze/
            //Assumption: there is only one legitimate path.
            //Approach: traverse thru each possible route as far as you can. see if you can hit the end. if not, backtrack as necessary.


            //filter out only the cells that are 1's.
            //nodes = []. iterate thru allCells. put all the Cells with 1's in an array.
            //solutionCell = nodes[nodes.Count() - 1];

            //checked = [] (array of cells). initialize this var to represent which cells/nodes have already been checked.


            //start with the first cell in the array (the one with a y-coordinate of 1). nodes[0].

            //use the Cell's getter methods (Cell.X and Cell.Y) to search thru each Cell in allCells. then at the end, map the Cell objects into [y,x] array items. 





            //the edge is whether or not an adjacent cell also exists in nodes and has not been checked yet. (check if the theoretical adjacent targetCell's coordinates exists in nodes AND hasn't been checked yet. if so, it's a valid edge/move.)


            //write a function that loops thru the maze (each cell in nodes). first, check if the current node is the solutionCell (if so, then populate the path). then, add that node to the checked array. we are checking whether that node is allowed to make a legitimate move. if so, re-run the function with the next node that was moved to (find that Cell in the nodes array). if not, break out of the function call and go back up one level to the previous fn call (go back 1 level in the stack).

            //start on line 1 and end at line n. stop once you've hit a 1 on the last row of the file.
            //currentCell = [y,x]

            //path = [] (array of arrays)

            //define the operations/possible moves: down, left, up, right
            //define the neighbors. down = (y + 1, x), left = (y, x - 1), up = (y - 1, x), right = (y, x + 1)
            //check the neighbors. each turn, validate if you can do each of the moves until you get a successful pass.
            //targetCell must be adjacent to currentCell AND target cell's value must be 1 AND targetCell cannot already have been traversed/checked yet (aka targetCell is not in the checked array).
            // once you've found a cell that lets you keep going/lets you make the move, recursively call the function again, but with the targetCell as the new currentCell. add targetCell to checked array.
            //if you can't keep going with a valid move and need to backtrack, backtrack 1 cell/function call. 
            //try to run the other directions that haven't been checked yet to try and get a possible move. backtrack further (return false and go back up 1 recursive fn call in the call stack) whenever the current cell you're on has no more possible options/moves.
            //if you reach the solution cell, then return true and recursively go back up the fn calls in the call stack. add the currentCell's coordinates to "path" each time.



            Console.ReadLine();
        }

        static void SolveMaze()
        {}
        static void ValidateCellNotChecked() { }
        static void ValidateValidMove() { }
    }
}
