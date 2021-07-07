using System;

namespace EnduranceApp
{
    class Program
    {
        static void Main(string[] args)
        {
            //intake a .txt file as an argument
            //question: how to parse thru txt files and find out how many rows and columns it has.
            //question: how to tell the value of a cell: if it's 1 or 0?
            //write a function that loops thru the maze. start on line 1 and end at line n. stop once you've hit a 1 on the last row of the file.
            //the 1s are the nodes of a tree.
            //path = [] (array of arrays)
            //currentCell = [y,x]
            //checked = [] (array of arrays). store var to represent which cells have already been checked.
            //the options are to move either down, left, right, or up
            //there is only one legitimate path. so, brute force approach: try traversing each possible route as far as you can. see if you can hit the end. if not, backtrack as necessary.
            //1. define the operations/possible moves: up, down, left, right
            //2. each turn, validate if you can do each of the moves until you get 1 successful pass. target cell must be adjacent to currentCell (up, left, down, right) AND target cell must be 1 AND target cell cannot have already been traversed/checked yet (aka are not in path array or checked array).
            // once you've found a cell that lets you keep going/lets you make the move, add the target cell to checked. add the current cell to path. recursively call the function again, but this time with targetCell as the new current Cell.

            //5.if you can't keep going and need to backtrack, backtrack 1 cell and remove previously checked cell's coordinates from path, but keep it in the checked array. backtrack (return false and go back up 1 recursive fn call in the call stack) whenever the current cell you're on has no more possible options/moves.
            //6. 



            //idea: put all the coordinates of cells with 1's in an array. start with the first cell in the array (the one in the top row).
            //Objects: Maze: numRows,numCols. currentCell: value, xCoord, yCoord.  
            Console.WriteLine("   /|");
            Console.WriteLine("  / |");
            Console.WriteLine(" /  |");
            Console.WriteLine("/___|");
            Console.ReadLine();
        }
    }
}
