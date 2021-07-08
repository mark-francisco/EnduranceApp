using System;

namespace EnduranceApp
{
    class Program
    {
        static void Main(string[] args)
        {
            // www.techiedelight.com/find-shortest-path-in-maze/
            //intake a .txt file as an argument
            //question: how to parse thru txt files and find out how many rows and columns it has.
            //question: how to tell the value of a cell: if it's 1 or 0?

            //there is only one legitimate path. so, brute force approach: try traversing each possible route as far as you can. see if you can hit the end. if not, backtrack as necessary.

            //nodes = []. iterate thru text file. put all the coordinates of cells with 1's in an array. start with the first cell in the array (the one with a y-coordinate of 1). the 1s are the nodes of a tree.
            //the index of the node in nodes is the node #. the edge is whether or not an adjacent cell also exists in nodes and has not been checked yet. (check if the theoretical adjacent targetCell's coordinates exists in nodes AND hasn't been checked yet. if so, it's a valid edge/move.)
            //checked = [] (array of arrays). store var to represent which cells/nodes have already been checked.
            //write a function that loops thru the maze. start on line 1 and end at line n. stop once you've hit a 1 on the last row of the file.
            //currentCell = [y,x]
            //solutionCell = [y,x]
            //path = [] (array of arrays)

            //the options are to move either down, left, up, or right
            //define the operations/possible moves: up, down, left, right
            //define the neighbors.
            //check the neighbords. each turn, validate if you can do each of the moves until you get a successful pass.
                //target cell must be adjacent to currentCell (up, left, down, right) AND target cell must be 1 AND target cell cannot have already been traversed/checked yet (aka are not in the checked array).
            // once you've found a cell that lets you keep going/lets you make the move, add the target cell to checked. recursively call the function again, but this time with targetCell as the new current Cell.

            //if you can't keep going and need to backtrack, backtrack 1 cell. keep checkedCell's coordinates in the checked array. try to run the other directions that haven't been checked yet to try and get a possible move. backtrack further (return false and go back up 1 recursive fn call in the call stack) whenever the current cell you're on has no more possible options/moves.
            //if you reach the solution cell, then return true and recursively go back up the fn calls in the call stack. add the currentCell's coordinates to path each time.



            //Objects: Maze: numRows,numCols. currentCell: value, xCoord, yCoord.  
            Console.WriteLine("   /|");
            Console.WriteLine("  / |");
            Console.WriteLine(" /  |");
            Console.WriteLine("/___|");
            Console.ReadLine();
        }
    }
}
