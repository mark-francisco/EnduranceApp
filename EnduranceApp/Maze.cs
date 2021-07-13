using System;
using System.Collections.Generic;
using System.Linq;

namespace EnduranceApp
{
    public class Maze
    {
        // Properties:
        public int numRows;
        public int numCols;
        public Cell solutionCell;
        public List<Cell> nodes;
        public bool foundSolution;
        public Cell currentCell;
        public List<Cell> checkedCells = new List<Cell>();
        public List<Cell> path = new List<Cell>();


        // Methods: 
        public List<Cell> DefineNeighbors(Cell currentCell)
        {
            var neighbors = new List<Cell>();
            var downNeighbor = this.nodes.FirstOrDefault(node => node.Y == currentCell.Y + 1 && node.X == currentCell.X);
            if (downNeighbor != null)
            {
                neighbors.Add(downNeighbor);
            }

            var leftNeighbor = this.nodes.FirstOrDefault(node => node.Y == currentCell.Y && node.X == currentCell.X - 1);
            if (leftNeighbor != null)
            {
                neighbors.Add(leftNeighbor);
            }

            var upNeighbor = this.nodes.FirstOrDefault(node => node.Y == currentCell.Y - 1 && node.X == currentCell.X);
            if (upNeighbor != null)
            {
                neighbors.Add(upNeighbor);
            }

            var rightNeighbor = this.nodes.FirstOrDefault(node => node.Y == currentCell.Y && node.X == currentCell.X + 1);
            if (rightNeighbor != null)
            {
                neighbors.Add(rightNeighbor);
            }
            return neighbors;
        }

        public Cell CheckNeighbors(List<Cell> neighbors)
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

        public bool ValidMazeMove(Cell targetCell)
        {
            return ValidateCellInBounds(targetCell) && ValidateCellNotCheckedYet(targetCell) ? true : false;
        }


        public bool ValidateCellInBounds(Cell cellToCheck)
        {
            return cellToCheck.Y <= this.numRows && cellToCheck.X <= this.numCols ? true : false;
        }


        public bool ValidateCellNotCheckedYet(Cell cellToCheck)
        {
            if (!this.checkedCells.Contains(cellToCheck))
            {
                this.checkedCells.Add(cellToCheck);
                return true;
            }
            else
            {
                return false;
            }

        }
    }
}
