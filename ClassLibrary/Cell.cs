/**
 *  Gloria Quezada
 *  CST-250
 *  Milestone Project
 *  Created : 18 September 2023
 *  Last Updated: 25 September 2023
 **/


namespace ClassLibrary
{
    /// <summary>
    /// This class models a game Cell in a Minesweeper Game. 
    /// </summary>
    public class Cell
    {
        // ----- ATTRIBUTES -----
        private int row = -1;
        private int col = -1;   // short for column
        private int  liveNeighbors = 0;     // number of neighboring live cells
        private bool isVisited = false;     // has cell been revealed?
        private bool isLive = false;        // is cell live (bomb)?

        // ACCESSORS and MUTATORS
        public int LiveNeighbors { get { return liveNeighbors; } set { liveNeighbors = value; } }  
        public bool IsVisited { get {  return isVisited; } set {  isVisited = value; } }
        public bool IsLive { get { return isLive; } set { isLive = value; } }

        // ----- CONTRUCTORS -----

        /// <summary>
        /// Create cell with assigned Row and Column, 
        ///     and default LiveNeigbors, IsVisited, and IsLive attributes
        /// </summary>
        /// <param name="row"></param>
        /// <param name="col"></param>
        public Cell(int row, int col) 
        {
            this.row = row;
            this.col = col;
            LiveNeighbors = 0;
            IsVisited = false; 
            IsLive = false;
        }
    }
}