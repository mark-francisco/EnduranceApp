using System;
using System.IO;
using System.Collections.Generic;

namespace EnduranceApp
{
    class Program
    {
        static void Main(string[] matrix)
        {
            // www.techiedelight.com/find-shortest-path-in-maze/
            //intake a .txt file as an argument
            //question: how to parse thru txt files and find out how many rows and columns it has.
            //question: how to tell the value of a cell: if it's 1 or 0?
            string[] lines = File.ReadAllLines(@"/Users/juanmarcofrancisco/Actualize/VisualStudioProjects/EnduranceApp/maze1.txt");
            var allCells = new List<string>();
            Console.WriteLine(allCells);

            foreach (string line in lines)
            Console.WriteLine(allCells);
            //allCells.Add(line);
            
            //allCells = matrix
            //allCells.each { |cell|
            //  if cell == 1
            //}

            //there is only one legitimate path. so, brute force approach: try traversing each possible route as far as you can. see if you can hit the end. if not, backtrack as necessary.

            //nodes = []. iterate thru text file. put all the coordinates of cells with 1's in an array.
            //the 1s are the nodes of a tree. start with the first cell in the array (the one with a y-coordinate of 1). 
            //checked = [] (array of arrays). var to represent which cells/nodes have already been checked.
            //the index of the node in nodes is the node #.
            //the edge is whether or not an adjacent cell also exists in nodes and has not been checked yet. (check if the theoretical adjacent targetCell's coordinates exists in nodes AND hasn't been checked yet. if so, it's a valid edge/move.)
            //write a function that loops thru the maze. start on line 1 and end at line n. stop once you've hit a 1 on the last row of the file.
            //currentCell = [y,x]
            //solutionCell = [y,x]
            //path = [] (array of arrays)
            //Stack<Array> stack = new Stack<Array>();

            //define the operations/possible moves: down, left, up, right
            //define the neighbors. down = (y + 1, x), left = (y, x - 1), up = (y - 1, x), right = (y, x + 1)
            //check the neighbors. each turn, validate if you can do each of the moves until you get a successful pass.
            //targetCell must be adjacent to currentCell AND target cell's value must be 1 AND targetCell cannot already have been traversed/checked yet (aka targetCell is not in the checked array).
            // once you've found a cell that lets you keep going/lets you make the move, recursively call the function again, but with the targetCell as the new currentCell. add targetCell to checked array.
            //if you can't keep going with a valid move and need to backtrack, backtrack 1 cell/function call. 
            //try to run the other directions that haven't been checked yet to try and get a possible move. backtrack further (return false and go back up 1 recursive fn call in the call stack) whenever the current cell you're on has no more possible options/moves.
            //if you reach the solution cell, then return true and recursively go back up the fn calls in the call stack. add the currentCell's coordinates to "path" each time. do a .Push to the stack every time the function is recursively run (at the end of the fn, after the recursive fn calls).



            //Objects: Maze: numRows,numCols. currentCell: value, xCoord, yCoord.  
            
        }
    }
}
