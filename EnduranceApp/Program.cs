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
            foreach(string arg in args)
            {
                SolveMaze(arg);
                Console.WriteLine("---------------");
            }
            Console.ReadLine();
        }


        static void SolveMaze(string maze) {

            string mazeFile = Globals.mazesFilepath + maze;
            List<string> rows = File.ReadLines(mazeFile).ToList();

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
                Globals.numRows = i;
                Globals.numCols = j;
            }

            //Assumption: there is only one legitimate path. Approach: traverse thru each possible route as far as you can. see if you can hit the end. if not, backtrack as necessary.


            var nodes = allCells.FindAll(cell => cell.Value == 1);
            Console.WriteLine("List of valid spaces:");
            foreach (Cell node in nodes)
            {
                Console.WriteLine(GetAllProperties(node));
            }

            Globals.solutionCell = nodes[nodes.Count() - 1];
            Console.WriteLine("Solution cell is: " + GetAllProperties(Globals.solutionCell));


            
            var foundSolution = false;


            //start with the first cell in the array (there's only 1 node with a y-coordinate of 1).
            var currentCell = nodes[0];

            // check if you've reached the end of the maze
            if (currentCell == Globals.solutionCell)
            {
                foundSolution = true;
            }

            if (foundSolution == true)
            {
                Globals.path.Insert(0, $"({currentCell.Y},{currentCell.X})");
                //recursively go back up the fn calls in the call stack.
                //TODO: figure out how to go back one recursive call in the call stack in C#.
            }



        }

        static Cell DefineNewCurrentCell(Cell currentCell)
        {

            // define the 4 neighbors
            var downNeighbor = currentCell;
            //check down. targetCell = (y + 1, x).
            //check left. targetCell = (y, x - 1).
            //check up. targetCell = (y - 1, x).
            //check right. targetCell = (y, x + 1).
            var leftNeighbor = currentCell;
            var upNeighbor = currentCell;
            var rightNeighbor = currentCell;

            //run the 4 neighbor checks: for each neighbor, is there a Cell in nodes whose Y and X coordinates would match this potential move? if so, return that Cell and break out of this fn.
            CheckMazeMove(currentCell, downNeighbor);
            CheckMazeMove(currentCell, leftNeighbor);
            CheckMazeMove(currentCell, upNeighbor);
            CheckMazeMove(currentCell, rightNeighbor);

        }

        static bool CheckMazeMove(Cell currentCell, Cell targetCell)
        {
            //returns true or false
            return true;
            
            //Criteria:
            //confirm that targetCell is adjacent to currentCell (currentCell to targetCell neighbor comparison logic).
            //check if target cell's value is 1 (targetCell IN nodes).
            //check that targetCell hasn't been traversed/checked yet (targetCell NOT IN checked[]).
            ////check that targetCell is not out of bounds (targetCell.Y <= numRows and targetCell.X <= numCols).



            //searching thru a list of Objects by property:
            //www.stackoverflow.com/questions/36016144/how-to-get-find-an-object-by-property-value-in-a-list
            //www.stackoverflow.com/questions/1485766/finding-an-item-in-a-list-using-c-sharp/1485775#1485775

            //for each check, add that node (aka targetCell) to the checked array.

            //if the move is valid for that targetCell, recursively re-run the function again, but with the next node that was moved to (run solveMaze(targetCell)).

            //if none of the 4 moves are valid, backtrack. meaning, break out of the function call and go back up one level to the previous fn call (go back 1 level in the stack). run the function again for the previous Cell. it will check for possible valid moves, based on which remaining cells haven't been checked yet.




        }


        static bool ValidateCellNotChecked() {
            //returns true or false
            return true;

        }
        static bool ValidateCellInBounds() {
            //returns true or false
            return true;
        }




        public static string GetAllProperties(object obj)
        {
            return string.Join(" ", obj.GetType()
                                        .GetProperties()
                                        .Select(prop => prop.GetValue(obj)));
        }
    }
}
