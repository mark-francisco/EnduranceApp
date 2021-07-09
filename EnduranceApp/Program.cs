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
            //TODO: split out functionality into separate components: functions and classes/objects.
            //TODO: allow User to pass in multiple mazes as arguments at once
            //TODO: re-factor code and work on improving efficiency

            foreach(string arg in args)
            {
                SolveMaze(arg);
                Console.WriteLine("---------------");
            }
            Console.ReadLine();
        }
        //for each args passed into Main, run SolveMaze. SolveMaze uses ValidateCellNotChecked, ValidateInBounds.
        static void SolveMaze(string maze) {

            string filepath = @$"/Users/juanmarcofrancisco/Actualize/VisualStudioProjects/EnduranceApp/ExampleMazes/{maze}";
            List<string> rows = File.ReadLines(filepath).ToList();

            int numRows = 0;
            int numCols = 0;

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

            //www.techiedelight.com/find-shortest-path-in-maze/
            //Assumption: there is only one legitimate path.
            //Approach: traverse thru each possible route as far as you can. see if you can hit the end. if not, backtrack as necessary.

            var nodes = allCells.FindAll(cell => cell.Value == 1);
            foreach (Cell node in nodes)
            {
                Console.WriteLine(GetAllProperties(node));
            }

            var solutionCell = nodes[nodes.Count() - 1];
            Console.WriteLine("Solution cell is: " + GetAllProperties(solutionCell));

            var checkedCells = new List<Cell>();

            var foundSolution = false;
            var path = new List<string>();


            //start with the first cell in the array (the one with a y-coordinate of 1).
            var currentCell = nodes[0];

            if (currentCell == solutionCell)
            {
                foundSolution = true;
                path.Insert(0, $"({currentCell.Y},{currentCell.X})");
                //recursively go back up the fn calls in the call stack.
                //TODO: figure out how to go back one recursive call in the call stack in C#.
            }



            //run the 4 neighbor checks: for each neighbor, is there a Cell in nodes whose Y and X coordinates would match this potential move?
            //Criteria:
            ////targetCell must be adjacent to currentCell (currentCell to targetCell neighbor comparison logic).
            ////target cell's value must be 1 (targetCell IN nodes).
            ////targetCell hasn't been traversed/checked yet (targetCell NOT IN checked[]).
            ////targetCell is not out of bounds (targetCell.Y <= numRows and targetCell.X <= numCols).

            //check down. targetCell = (y + 1, x).
            //check left. targetCell = (y, x - 1).
            //check up. targetCell = (y - 1, x).
            //check right. targetCell = (y, x + 1).

            //searching thru a list of Objects by property:
            //www.stackoverflow.com/questions/36016144/how-to-get-find-an-object-by-property-value-in-a-list
            //www.stackoverflow.com/questions/1485766/finding-an-item-in-a-list-using-c-sharp/1485775#1485775

            //for each check, add that node (aka targetCell) to the checked array.

            //if the move is valid for that targetCell, recursively re-run the function again, but with the next node that was moved to (run solveMaze(targetCell)).

            //if none of the 4 moves are valid, backtrack. meaning, break out of the function call and go back up one level to the previous fn call (go back 1 level in the stack). run the function again for the previous Cell. it will check for possible valid moves, based on which remaining cells haven't been checked yet.


            //at the end, map the Cell objects in path to [y,x] array items.




        }
        static void CheckMazeMove() { }
        static void ValidateCellNotChecked() { }
        static void ValidateCellInBounds() { }

        public static string GetAllProperties(object obj)
        {
            return string.Join(" ", obj.GetType()
                                        .GetProperties()
                                        .Select(prop => prop.GetValue(obj)));
        }
    }
}
