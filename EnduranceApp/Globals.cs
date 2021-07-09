using System;
using System.Collections.Generic;

namespace EnduranceApp
{
    public static class Globals
    {
        //TODO: figure out how to get a more dynamic filepath...
        public static string mazesFilepath = @$"/Users/juanmarcofrancisco/Actualize/VisualStudioProjects/EnduranceApp/ExampleMazes/";


        public static Cell solutionCell;
        public static List<Cell> checkedCells;
        public static int numRows;
        public static int numCols;
        public static List<string> path;
        
    }
}
